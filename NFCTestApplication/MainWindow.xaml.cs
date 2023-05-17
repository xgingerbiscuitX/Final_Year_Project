
using PCSC;
using Sydesoft.NfcDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
namespace NFCTestApplication
{
    public partial class MainWindow : Window
    {
        string message;
        DispatcherTimer timer = new DispatcherTimer();
         //DispatcherTimer Idtimer = new DispatcherTimer();

        private static ACR122U acr122u = new ACR122U();
        //get reader
        NFCReader reader = new NFCReader();
       

        public MainWindow()
        {
          
            InitializeComponent();
            CollectData();

            
            


        }

        private void Removed()
        {
            
        }

        private void GetID(ICardReader reader)
        {
            try
            {
                //get id
               string id = BitConverter.ToString(acr122u.GetUID(reader));
               
                //display the id in chip id textbox
                this.Dispatcher.Invoke(() => {
                    tbChipID.Text = id;
                    });
                //displayId(null, null);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

       
        private void fetchDevice(object sender, EventArgs e)
        {
            if (cbNFCReader.Items.Count == 0)
            {
                List<string> collection = SmartCardReaderRetrievecs.RetrieveSmartReader();
                if (collection.FirstOrDefault() != null)
                {
                    foreach (string device in collection)
                    {
                        cbNFCReader.Items.Add(device);
                    }
                    Startreader();
                    timer.Stop();
                }
               
            }
        }

        public void CollectData() {
          List<string> collection =   SmartCardReaderRetrievecs.RetrieveSmartReader();
            if (collection.FirstOrDefault() != null)
            {
                foreach (string device in collection)
                {
                    cbNFCReader.Items.Add(device);

                }

                Startreader();
            }
            else {
                timer.Tick += new EventHandler(fetchDevice);
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Start();
                message ="You have not inserted your Reader. Please insert it";
                ShowMessage(message);

            }

            cbTagType.Items.Add("Phone");
            cbTagType.Items.Add("Leap Card");
            cbTagType.Items.Add("Add New Tag Type");

        }

        private void Startreader()
        {

            acr122u.Init(false, 50, 4, 4, 200);
            acr122u.CardInserted += GetID;
            acr122u.CardRemoved += Removed;
        }

        private void ShowMessage(string message)
        {
            MessageWindow mew = new MessageWindow(message);
            mew.Show();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            //collect information from this form to save to another form.
            StarterInformation starter = new StarterInformation();
            if (cbNFCReader.SelectedIndex != -1 && cbTagType.SelectedIndex != -1)
            {
                int testing;
                testing = (bool)cboxDistance.IsChecked ? 1 : 0;
               // MessageBox.Show(testing.ToString());
                testing += (bool)cbxMaterial.IsChecked ? 2 : 0;
                //MessageBox.Show(testing.ToString());

                starter.readerDevice = cbNFCReader.SelectedItem.ToString();
                starter.TagType = cbTagType.SelectedItem.ToString();
               

                switch (testing)
                {
                    case 0:
                        //They didnt pick any checkbox
                        MessageBox.Show("Please check a box for the type of test");
                        break;
                    case 1:
                        //Distance Testing
                        //saving info
                        saveinformation();
                        //opening Distance Testing Window
                        DistanceWindow dw = new DistanceWindow(starter);
                        dw.Show();
                        break;
                    case 2:
                        //Material Testing
                        //Opening Material Testing Window
                        MaterialWindow mw = new MaterialWindow(starter);
                        mw.Show();
                        break;
                    case 3:
                        // both testing 
                        //Opening both
                        Distance_MaterialWindow dmw = new Distance_MaterialWindow(starter);
                        dmw.Show();
                         break;
                }


            }
            else {
                string message = "To continue you need to select the Reader and the Tag Type";
                ShowMessage(message);
            }
        }

        private void saveinformation()
        {
            Database db = new Database();
            String getUID = tbChipID.Text, getTType = cbTagType.SelectedItem.ToString();

            db.saveUID(getUID,getTType );
        }
    }
}
