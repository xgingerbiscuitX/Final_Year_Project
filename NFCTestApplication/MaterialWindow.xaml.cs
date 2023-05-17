using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace NFCTestApplication
{
    public partial class MaterialWindow : Window
    {
        public StarterInformation starts;
        //making a timer so the date and time is accurate
        DispatcherTimer timer = new DispatcherTimer();
        // NFCReaderLibrary
        NFCReader reader = new NFCReader();
        public MaterialWindow(StarterInformation starter)
        {
            timer.Tick += new EventHandler(Date_time);
            timer.Interval = new TimeSpan(0, 0, 1);

            timer.Start();
            starts = starter;
            InitializeComponent();
            StartingWindow(starts);
        }
        public void StartingWindow(StarterInformation starter)
        {
            tbInformation.Text = "Please Put the Tag on Slot 2 and add the Cardboard";
            tbMDistance.Text = "Cardboard";
            tbMType.Text = starter.TagType;

        }
        private void Date_time(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            tbMTime.Text = date.ToString();
        }

        private void btMSave_Click(object sender, RoutedEventArgs e)
        {
            string distance = tbMDistance.Text;
            if (checkInfo())
            {
                //todo save the data
                clearBoxes();

                if (distance == "Cardboard")
                {
                    tbInformation.Text = "Please Put the Tag on Slot 2 and add the Tin foil";
                    tbMDistance.Text = "Tin foil";
                }
                else if (distance == "Tin foil")
                {
                    tbInformation.Text = "Please Put the Tag on Slot 2 and add the Pastic";
                    tbMDistance.Text = "Plastic";
                }
                else
                {
                    //todo
                    //close and save 
                }
            }
            else
            {
                MessageBox.Show("You need to click the button 'Check' to be able to continue.");
            }

        }
        private bool checkInfo()
        {

            if ((tbMconnection.Text == "True" || tbMconnection.Text == "False") && (tbMResults.Text == "Success" || tbMResults.Text == "Failed"))
            {
                return true;
            }
            return false;
        }
        private void clearBoxes()
        {
            tbMconnection.Text = "";
            tbMResults.Text = "";
        }

        private void btMCheck_Click(object sender, RoutedEventArgs e)
        {
            if (reader.Connect())
            {
                tbMResults.Text = "Failed";
                tbMconnection.Text = "True";

            }
            else
            {
                tbMResults.Text = "Success";
                tbMconnection.Text = "False";
            }
        }
    }
}

