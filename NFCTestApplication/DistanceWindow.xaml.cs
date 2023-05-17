using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    public partial class DistanceWindow : Window
    {
        public StarterInformation starts;
        //making a timer so the date and time is accurate
        DispatcherTimer timer = new DispatcherTimer();

        // NFCReaderLibrary
        NFCReader reader = new NFCReader();

        public DistanceWindow(StarterInformation starter)
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
            tbInformation.Text = "Please Put the Tag on Slot 1";
            tbDDistance.Text = "2cm";
            tbDType.Text = starter.TagType;

        }
        private void Date_time(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            tbDTime.Text = date.ToString();
        }

        private void btDSave_Click(object sender, RoutedEventArgs e)
        {
            string distance = tbDDistance.Text;

            if (checkInfo())
            {
                //todo save the data
                clearBoxes();
                switch (distance)
                {
                    case "2cm":
                        tbInformation.Text = "Please Put the Tag on Slot 2";
                        tbDDistance.Text = "5cm";
                        break;
                    case "5cm":
                        tbInformation.Text = "Please Put the Tag on Slot 3";
                        tbDDistance.Text = "7cm";
                        break;
                    case "7cm":
                        tbInformation.Text = "Please Put the Tag on Slot 4";
                        tbDDistance.Text = "10cm";
                        break;
                    case "10cm":
                        tbInformation.Text = "Please Put the Tag on Slot 5";
                        tbDDistance.Text = "15cm";
                        break;
                    case "15cm":
                        tbInformation.Text = "Please Put the Tag on Slot 6";
                        tbDDistance.Text = "20cm";
                        break;
                    default:
                        tbInformation.Text = "Please Put the Tag on Slot 2 and add the Cardboard";
                        break;
                }


            }
            else
            {
                MessageBox.Show("You need to click the button 'Check' to be able to continue.");
            }
        }
        private bool checkInfo()
        {

            if ((tbDconnection.Text == "True" || tbDconnection.Text == "False") && (tbDResults.Text == "Success" || tbDResults.Text == "Failed"))
            {
                return true;
            }
            return false;
        }
        private void clearBoxes()
        {
            tbDconnection.Text = "";
            tbDResults.Text = "";
        }

        private void btDCheck_Click(object sender, RoutedEventArgs e)
        {
            if (reader.Connect())
            {
                tbDResults.Text = "Success";
                tbDconnection.Text = "True";

            }
            else
            {
                tbDResults.Text = "Failed";
                tbDconnection.Text = "False";
            }
        }
    }
}
