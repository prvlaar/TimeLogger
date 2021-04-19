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

namespace TimeLogger
{
    /// <summary>
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : Window
    {
        public string hoursreturn;
        public Schedule()
        {
            InitializeComponent();
            TxtBoxMon.Text = Properties.Settings.Default.MondayHrs.ToString();
            TxtBoxTue.Text = Properties.Settings.Default.TuesdayHrs.ToString();
            TxtBoxWed.Text = Properties.Settings.Default.WednesdayHrs.ToString();
            TxtBoxThu.Text = Properties.Settings.Default.ThursdayHrs.ToString();
            TxtBoxFri.Text = Properties.Settings.Default.FridayHrs.ToString();
            TxtBoxSat.Text = Properties.Settings.Default.SaturdayHrs.ToString();
            TxtBoxSun.Text = Properties.Settings.Default.SundayHrs.ToString();
        //    Properties.Settings.Default.Save();
        //    Console.WriteLine("Should save init..");
        }


        void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int weekTotal = 0;
            Properties.Settings.Default.MondayHrs = int.Parse(TxtBoxMon.Text);
            Properties.Settings.Default.TuesdayHrs = int.Parse(TxtBoxTue.Text);
            Properties.Settings.Default.WednesdayHrs = int.Parse(TxtBoxWed.Text);
            Properties.Settings.Default.ThursdayHrs = int.Parse(TxtBoxThu.Text);
            Properties.Settings.Default.FridayHrs = int.Parse(TxtBoxFri.Text);
            Properties.Settings.Default.SaturdayHrs = int.Parse(TxtBoxSat.Text);
            Properties.Settings.Default.SundayHrs = int.Parse(TxtBoxSun.Text);
            weekTotal += Properties.Settings.Default.MondayHrs;
            weekTotal += Properties.Settings.Default.TuesdayHrs;
            weekTotal += Properties.Settings.Default.WednesdayHrs;
            weekTotal += Properties.Settings.Default.ThursdayHrs;
            weekTotal += Properties.Settings.Default.FridayHrs;
            weekTotal += Properties.Settings.Default.SaturdayHrs;
            weekTotal += Properties.Settings.Default.SundayHrs;
            Properties.Settings.Default.WeekHours = weekTotal;
            Properties.Settings.Default.Save();
            Console.WriteLine("Should save closed..");
        }

    }
}
