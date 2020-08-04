using System;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Reflection;
using System.Timers;
using System.Windows;
using System.Windows.Threading;

namespace TimeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dT;
        SoundPlayer audioPlayer;
        Timer timer;

        const long millisecond_in_minute = 60 * 1000;
        const long ticks_in_millisecond = 10000;
        const long ticks_in_minute = millisecond_in_minute * ticks_in_millisecond;
        long nxtInterval;

        public MainWindow()
        {
            InitializeComponent();
            dT = new DispatcherTimer();
            dT.Tick += new EventHandler(DispatcherTimer_Tick);
            dT.Interval = TimeSpan.FromMilliseconds(100);        //update the clock every 100ms
            dT.Start();

            timer = new Timer();
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(timer_elapsed);
            timer.Interval = GetInitialInterval();
            timer.Start();
        }

        //event to calculate remaining time for next min (to trigger audio executor i suppose?)
        void timer_elapsed(object source, ElapsedEventArgs e)
        {
            Trace.WriteLine(DateTime.Now.ToString("hh:mm:ss tt"));
            Audio_Executor();
            timer.Interval = Get_Interval();
            timer.Start();
        }

        //to get starting interval as soon as the app startup
        private double GetInitialInterval()
        {
            DateTime now = DateTime.Now;                                                 //current local time of the comp
            double timeToNextMin = ((60 - now.Second) * 1000 - now.Millisecond) + 15;    // ((60 sec - current time in sec) * 1000 - current time in ms) + 15
            nxtInterval = now.Ticks + ((long)timeToNextMin * ticks_in_millisecond);      // nxtinterval = currrent time + above equation * ticks in ms

            return timeToNextMin;
        }

        //to get interval in ticks..?
        private double Get_Interval()
        {
            nxtInterval += ticks_in_minute;

            return TicksToMs(nxtInterval - DateTime.Now.Ticks);
        }

        //to convert ticks to ms
        private double TicksToMs(long ticks)
        {
            return (double)(ticks / ticks_in_millisecond);
        }

        //Event to update clocks' hands ticking and texts that shows digital clock
        void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            double secs = DateTime.Now.Second;
            double mins = DateTime.Now.Minute;

            digital_clock.Text = DateTime.Now.ToString("hh:mm:ss");

            secondHandTransform.Angle = secs * 6;
            minuteHandTransform.Angle = mins * 6;
            hourHandTransform.Angle = (DateTime.Now.Hour * 30) + (mins * 0.5);
        }

        void Audio_Executor()
        {
            audioPlayer = new SoundPlayer();

            string timeString = DateTime.Now.ToString("HH");    //get current time
            int timeInt;
            int.TryParse(timeString, out timeInt);              //parse string datetime to int

            string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);   //get exe file pathing

            //switch time cases
            switch (timeInt)
            {
                case 00:
                    string path0 = @"Resources\temp\Akizuki-00.wav";     //path of voiceline for time 0000
                    String path00 = Path.Combine(exePath, path0);      //combine file pathing

                    audioPlayer.SoundLocation = path00;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;
                case 01:
                    string path1 = @"Resources\temp\Akizuki-01.wav";     //path of voiceline for time 0000
                    string fullPath = Path.Combine(exePath, path1);      //combine file pathing

                    audioPlayer.SoundLocation = fullPath;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;
                case 02:
                    string path2 = @"Resources\temp\Akizuki-02.wav";     //path of voiceline for time 0000
                    string path02 = Path.Combine(exePath, path2);      //combine file pathing

                    audioPlayer.SoundLocation = path02;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;
            }
        }
    }
}