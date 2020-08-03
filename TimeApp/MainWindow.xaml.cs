using System;
using System.IO;
using System.Windows;
using System.Timers;
using System.Windows.Threading;
using System.Media;
using System.Reflection;
using System.Diagnostics;

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

        //event to calculate remaining time for nxt min
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
            nxtInterval = now.Ticks + ((long)timeToNextMin * ticks_in_millisecond);      // nxtinterval = currrent time + abv equation * ticks in ms

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

        //Event that happened for clocks' hands ticking and texts that shows digital clock
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

            /*TimeSpan currentTime = DateTime.Now.TimeOfDay;

            TimeSpan maru_maru = TimeSpan.Parse("20:30");       // 0000 midnight
            TimeSpan maru_hito = TimeSpan.Parse("01:00");       // 0100 late night
            TimeSpan maru_futa = TimeSpan.Parse("02:00");       // 0200 late night
            TimeSpan maru_san = TimeSpan.Parse("03:00");        // 0300 late night
            TimeSpan maru_yon = TimeSpan.Parse("04:00");        // 0400 late night
            TimeSpan maru_go = TimeSpan.Parse("05:00");         // 0500 early morning
            TimeSpan maru_roku = TimeSpan.Parse("06:00");       // 0600 early morning
            TimeSpan maru_nana = TimeSpan.Parse("07:00");       // 0700 early morning
            TimeSpan maru_hachi = TimeSpan.Parse("08:00");      // 0800 morning
            TimeSpan maru_kyuu = TimeSpan.Parse("09:00");       // 0900 morning
            TimeSpan hito_maru = TimeSpan.Parse("10:00");       // 1000 morning
            TimeSpan hito_hito = TimeSpan.Parse("11:00");       // 1100 morning
            TimeSpan hito_futa = TimeSpan.Parse("12:00");       // 1200 noon
            TimeSpan hito_san = TimeSpan.Parse("13:00");        // 1300 afternoon                                 
            TimeSpan hito_yon = TimeSpan.Parse("14:00");        // 1400 afternoon
            TimeSpan hito_go = TimeSpan.Parse("15:00");         // 1500 afternoon
            TimeSpan hito_roku = TimeSpan.Parse("16:00");       // 1600 evening
            TimeSpan hito_nana = TimeSpan.Parse("17:00");       // 1700 evening
            TimeSpan hito_hachi = TimeSpan.Parse("18:00");      // 1800 late evening
            TimeSpan hito_kyuu = TimeSpan.Parse("19:00");       // 1900 night
            TimeSpan futa_maru = TimeSpan.Parse("20:00");       // 2000 night
            TimeSpan futa_hito = TimeSpan.Parse("20:31");       // 2100 night
            TimeSpan futa_futa = TimeSpan.Parse("22:00");       // 2200 night
            TimeSpan futa_san = TimeSpan.Parse("23:00");        // 2300 night */

            if(DateTime.Now.Hour == 16 && DateTime.Now.Minute == 11)
            {
                string exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string filePath = @"Resources\temp\Akizuki-01.wav";
                string fullPath = Path.Combine(exePath, filePath);

                audioPlayer.SoundLocation = fullPath;
                audioPlayer.Play();
            }       
        }
    }
}