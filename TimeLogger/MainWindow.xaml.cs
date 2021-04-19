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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TimeLogger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TimeSpan dayTimerDown;
        TimeSpan weekTimerDown;
        TimeSpan dayTimerUp;
        TimeSpan weekTimerUp;
        private Schedule scheduleForm;
        private static Timer trackerTimer;
        int dayHrs;
        int weekHrs;

        public MainWindow()
        {
            InitializeComponent();
            BtnPause.Content = "Start";
            DateTime dayName = DateTime.Today;
            string DayName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DayNames[(int)dayName.DayOfWeek];
            if (Properties.Settings.Default.DayRemaining != null)
            {
                var dr = Properties.Settings.Default.DayRemaining.Split(':');
                var dc = Properties.Settings.Default.DayCount.Split(':');
                var wr = Properties.Settings.Default.WeekRemaining.Split(':');
                var wc = Properties.Settings.Default.WeekCount.Split(':');
                try
                {
                    dayTimerDown = new TimeSpan(int.Parse(dr[0]), int.Parse(dr[1]), int.Parse(dr[2]));
                    dayTimerUp = new TimeSpan(int.Parse(dc[0]), int.Parse(dc[1]), int.Parse(dc[2]));
                    weekTimerDown = new TimeSpan(int.Parse(wr[0]), int.Parse(wr[1]), int.Parse(wr[2]));
                    weekTimerUp = new TimeSpan(int.Parse(wc[0]), int.Parse(wc[1]), int.Parse(wc[2]));
                    Top = Properties.Settings.Default.WindowTop;
                    Left = Properties.Settings.Default.WindowLeft;
                }
                catch
                {
                    dayTimerDown = new TimeSpan(8, 0, 0);
                    dayTimerUp = new TimeSpan(0, 0, 0);
                    weekTimerDown = new TimeSpan(40, 0, 0);
                    weekTimerUp = new TimeSpan(0, 0, 0);
                }

                TxtBlkDayCountdown.Text = dayTimerDown.ToString(@"hh\:mm\:ss");
                TxtBlkDayCountup.Text = dayTimerUp.ToString(@"hh\:mm\:ss");
                string downCount;
                if ((int)weekTimerDown.TotalHours < 10)
                {
                    downCount = "0" + (int)weekTimerDown.TotalHours;
                }
                else
                {
                    downCount = "" + (int)weekTimerDown.TotalHours;
                }
                TxtBlkWeekCountdown.Text = downCount + weekTimerDown.ToString(@"\:mm\:ss");

                string upCount;
                if ((int)weekTimerUp.TotalHours < 10)
                {
                    upCount = "0" + (int)weekTimerUp.TotalHours;
                }
                else
                {
                    upCount = "" + (int)weekTimerUp.TotalHours;
                }
                TxtBlkWeekCountup.Text = upCount + weekTimerUp.ToString(@"\:mm\:ss");

            }
            Background = Brushes.LightYellow;
            dayHrs = int.Parse(Properties.Settings.Default[DayName + "Hrs"].ToString());
            weekHrs = Properties.Settings.Default.WeekHours;
            UpdateShowToolTip();
        }

        private void BtnSchedule_Click(object sender, RoutedEventArgs e)
        {
            scheduleForm = new Schedule();
            scheduleForm.ShowDialog();
        }

        private void UpdateShowToolTip()
        {
            TxtBlkTotal.ToolTip =
                "Monday:       " + Properties.Settings.Default.Monday + Environment.NewLine +
                "Tuesday:       " + Properties.Settings.Default.Tuesday + Environment.NewLine +
                "Wednesday:  " + Properties.Settings.Default.Wednesday + Environment.NewLine +
                "Thursday:      " + Properties.Settings.Default.Thursday + Environment.NewLine +
                "Friday:           " + Properties.Settings.Default.Friday + Environment.NewLine +
                "Saturday:      " + Properties.Settings.Default.Saturday + Environment.NewLine +
                "Sunday:         " + Properties.Settings.Default.Sunday;
        }

        private void Save()
        {
            Properties.Settings.Default.DayCount = TxtBlkDayCountup.Text;
            Properties.Settings.Default.DayRemaining = TxtBlkDayCountdown.Text;
            Properties.Settings.Default.WeekCount = TxtBlkWeekCountup.Text;
            Properties.Settings.Default.WeekRemaining = TxtBlkWeekCountdown.Text;
            Properties.Settings.Default.WindowTop = Top;
            Properties.Settings.Default.WindowLeft = Left;
            Properties.Settings.Default.Save();
        }

        private void NewDay()
        {
            DateTime dayName = DateTime.Today;
            string DayName;
            if (System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DayNames[(int)dayName.DayOfWeek] != Properties.Settings.Default.Today)
            {
                try
                {
                    DayName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DayNames[(int)dayName.DayOfWeek - 1];
                }
                catch
                {
                    DayName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DayNames[(int)dayName.DayOfWeek + 6];
                }
                Properties.Settings.Default.Today = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DayNames[(int)dayName.DayOfWeek];
                Properties.Settings.Default[DayName] = TxtBlkDayCountup.Text;
                Properties.Settings.Default.Save();
            }
            DayName = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.DayNames[(int)dayName.DayOfWeek];
            dayHrs = int.Parse(Properties.Settings.Default[DayName + "Hrs"].ToString());
            dayTimerDown = new TimeSpan(dayHrs, 0, 0);
            TxtBlkDayCountdown.Text = dayTimerDown.ToString(@"hh\:mm\:ss");
            dayTimerUp = new TimeSpan(0, 0, 0);
            TxtBlkDayCountup.Text = dayTimerUp.ToString(@"hh\:mm\:ss");
            UpdateShowToolTip();
            Save();
        }

        private void BtnNewDay_Click(object sender, RoutedEventArgs e)
        {
            NewDay();
        }

        private void BtnNewWeek_Click(object sender, RoutedEventArgs e)
        {
            NewDay();
            weekHrs = Properties.Settings.Default.WeekHours;
            weekTimerDown = new TimeSpan(weekHrs, 0, 0);
            TxtBlkWeekCountdown.Text = weekTimerDown.TotalHours + weekTimerDown.ToString(@"\:mm\:ss");
            weekTimerUp = new TimeSpan(0, 0, 0);
            TxtBlkWeekCountup.Text = "00:00:00";
        }

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            if (BtnPause.Content.ToString() == "Start")
            {
                BtnPause.Content = "Pause";
                Background = Brushes.LightGreen;
                trackerTimer = new Timer(TimeSpan.FromSeconds(1).TotalMilliseconds);
                trackerTimer.Elapsed += TrackTimer_Elapsed;
                trackerTimer.AutoReset = true;
                trackerTimer.Enabled = true;

            }
            else if (BtnPause.Content.ToString() == "Pause")
            {
                trackerTimer.Enabled = false;
                BtnPause.Content = "Resume";
                Background = Brushes.OrangeRed;
            }
            else if (BtnPause.Content.ToString() == "Resume")
            {
                trackerTimer.Enabled = true;
                BtnPause.Content = "Pause";
                Background = Brushes.LightGreen;
            }
        }

        public void MainWindowTimer()
        {
            trackerTimer = new Timer(TimeSpan.FromSeconds(1).TotalMilliseconds);
            trackerTimer.Elapsed += TrackTimer_Elapsed;
            trackerTimer.AutoReset = true;
            trackerTimer.Enabled = true;
        }

        public void TrackTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke((Action)delegate
            {
                TimeSpan ts = TimeSpan.FromSeconds(1);
                dayTimerDown = dayTimerDown.Subtract(ts);
                dayTimerUp = dayTimerUp.Add(ts);
                weekTimerDown = weekTimerDown.Subtract(ts);
                weekTimerUp = weekTimerUp.Add(ts);

                TxtBlkDayCountup.Text = dayTimerUp.ToString(@"hh\:mm\:ss");
                TxtBlkDayCountdown.Text = dayTimerDown.ToString(@"hh\:mm\:ss");

                string downCount;
                if ((int)weekTimerDown.TotalHours < 10)
                {
                    downCount = "0" + (int)weekTimerDown.TotalHours;
                }
                else
                {
                    downCount = "" + (int)weekTimerDown.TotalHours;
                }
                TxtBlkWeekCountdown.Text = downCount + weekTimerDown.ToString(@"\:mm\:ss");

                string upCount;
                if ((int)weekTimerUp.TotalHours < 10)
                {
                    upCount = "0" + (int)weekTimerUp.TotalHours;
                }
                else
                {
                    upCount = "" + (int)weekTimerUp.TotalHours;
                }
                TxtBlkWeekCountup.Text = upCount + weekTimerUp.ToString(@"\:mm\:ss");
                Save();
            });
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Save();
        }

    }
}
