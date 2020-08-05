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

            string timeString = DateTime.Now.ToString("HH:mm");                                    //get current time
            string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);   //get exe file pathing

            //switch time cases
            switch (timeString)
            {
                case "00:00":
                    string path0 = @"Resources\Sound\Akizuki-00.wav";     //path of voiceline for time 0000
                    String path00 = Path.Combine(exePath, path0);      //combine file pathing

                    audioPlayer.SoundLocation = path00;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "01:00":
                    string path1 = @"Resources\Sound\Akizuki-01.wav";     //path of voiceline for time 0100
                    string fullPath = Path.Combine(exePath, path1);      //combine file pathing

                    audioPlayer.SoundLocation = fullPath;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "02:00":
                    string path2 = @"Resources\Sound\Akizuki-02.wav";     //path of voiceline for time 0200
                    string path02 = Path.Combine(exePath, path2);      //combine file pathing

                    audioPlayer.SoundLocation = path02;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "03:00":
                    string path3 = @"Resources\Sound\Akizuki-03.wav";     //path of voiceline for time 0300
                    string path03 = Path.Combine(exePath, path3);      //combine file pathing

                    audioPlayer.SoundLocation = path03;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "04:00":
                    string path4 = @"Resources\Sound\Akizuki-04.wav";     //path of voiceline for time 0400
                    string path04 = Path.Combine(exePath, path4);      //combine file pathing

                    audioPlayer.SoundLocation = path04;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;
                
                case "05:00":
                    string path5 = @"Resources\Sound\Akizuki-05.wav";     //path of voiceline for time 0500
                    string path05 = Path.Combine(exePath, path5);      //combine file pathing

                    audioPlayer.SoundLocation = path05;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "06:00":
                    string path6 = @"Resources\Sound\Akizuki-06.wav";     //path of voiceline for time 0600
                    string path06 = Path.Combine(exePath, path6);      //combine file pathing

                    audioPlayer.SoundLocation = path06;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "07:00":
                    string path7 = @"Resources\Sound\Akizuki-07.wav";     //path of voiceline for time 0700
                    string path07 = Path.Combine(exePath, path7);      //combine file pathing

                    audioPlayer.SoundLocation = path07;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;
                
                case "08:00":
                    string path8 = @"Resources\Sound\Akizuki-08.wav";     //path of voiceline for time 0800
                    String path08 = Path.Combine(exePath, path8);      //combine file pathing

                    audioPlayer.SoundLocation = path08;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "09:00":
                    string path9 = @"Resources\temp\Akizuki-09.wav";     //path of voiceline for time 0900
                    string path09 = Path.Combine(exePath, path9);      //combine file pathing

                    audioPlayer.SoundLocation = path09;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "10:00":
                    string path10 = @"Resources\Sound\Akizuki-10.wav";     //path of voiceline for time 1000
                    string path010 = Path.Combine(exePath, path10);      //combine file pathing

                    audioPlayer.SoundLocation = path010;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "11:00":
                    string path11 = @"Resources\Sound\Akizuki-11.wav";     //path of voiceline for time 1100
                    string path011 = Path.Combine(exePath, path11);      //combine file pathing

                    audioPlayer.SoundLocation = path011;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "12:00":
                    string path12 = @"Resources\Sound\Akizuki-12.wav";     //path of voiceline for time 1200
                    string path012 = Path.Combine(exePath, path12);      //combine file pathing

                    audioPlayer.SoundLocation = path012;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;
                
                case "13:00":
                    string path13 = @"Resources\Sound\Akizuki-13.wav";     //path of voiceline for time 1300
                    string path013 = Path.Combine(exePath, path13);      //combine file pathing

                    audioPlayer.SoundLocation = path013;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "14:00":
                    string path14 = @"Resources\Sound\Akizuki-14.wav";     //path of voiceline for time 1400
                    string path014 = Path.Combine(exePath, path14);      //combine file pathing

                    audioPlayer.SoundLocation = path014;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "15:00":
                    string path15 = @"Resources\Sound\Akizuki-15.wav";     //path of voiceline for time 1500
                    string path015 = Path.Combine(exePath, path15);      //combine file pathing

                    audioPlayer.SoundLocation = path015;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;
                
                case "16:43":
                    string path16 = @"Resources\Sound\Akizuki-16.wav";     //path of voiceline for time 1600
                    String path016 = Path.Combine(exePath, path16);      //combine file pathing

                    audioPlayer.SoundLocation = path016;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "17:00":
                    string path17 = @"Resources\Sound\Akizuki-17.wav";     //path of voiceline for time 1700
                    string path017 = Path.Combine(exePath, path17);      //combine file pathing

                    audioPlayer.SoundLocation = path017;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "18:00":
                    string path18 = @"Resources\Sound\Akizuki-18.wav";     //path of voiceline for time 1800
                    string path018 = Path.Combine(exePath, path18);      //combine file pathing

                    audioPlayer.SoundLocation = path018;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "19:00":
                    string path19 = @"Resources\Sound\Akizuki-19.wav";     //path of voiceline for time 1900
                    string path019 = Path.Combine(exePath, path19);      //combine file pathing

                    audioPlayer.SoundLocation = path019;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "20:00":
                    string path20 = @"Resources\Sound\Akizuki-20.wav";     //path of voiceline for time 2000
                    string path020 = Path.Combine(exePath, path20);      //combine file pathing

                    audioPlayer.SoundLocation = path020;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;
                
                case "21:00":
                    string path21 = @"Resources\Sound\Akizuki-21.wav";     //path of voiceline for time 2100
                    string path021 = Path.Combine(exePath, path21);      //combine file pathing

                    audioPlayer.SoundLocation = path021;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "22:00":
                    string path22 = @"Resources\Sound\Akizuki-22.wav";     //path of voiceline for time 2200
                    string path022 = Path.Combine(exePath, path22);      //combine file pathing

                    audioPlayer.SoundLocation = path022;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "23:00":
                    string path23 = @"Resources\Sound\Akizuki-23.wav";     //path of voiceline for time 2300
                    string path023 = Path.Combine(exePath, path23);      //combine file pathing

                    audioPlayer.SoundLocation = path023;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

            }
        }
    }
}