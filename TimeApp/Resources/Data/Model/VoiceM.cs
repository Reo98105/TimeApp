using System.ComponentModel;
using System.IO;
using System.Media;
using System.Reflection;

namespace TimeApp.Resources.Data.Model
{
    public class VoiceM : INotifyPropertyChanged
    {
        private string voiceName;
        private string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public string VoiceName
        {
            get
            {
                return voiceName;
            }

            set
            {
                RaisePropertyChange("VoiceName");
            }
        }

        public string AssemblyPath
        {
            get
            {
                return assemblyPath;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// To notify the UI tha something has been changed in the Model
        /// </summary>
        private void RaisePropertyChange(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        /// <summary>
        /// Sound player for voiceline
        /// </summary>
        public void AudioExecutor()
        {
            SoundPlayer audioPlayer = new SoundPlayer();

            string timeString = System.DateTime.Now.ToString("HH:mm");

            //switch time cases
            switch (timeString)
            {
                case "00:00":
                    string path0 = @"Resources\Sound\Akizuki-00.wav";     //path of voiceline for time 0000
                    string path00 = Path.Combine(AssemblyPath, path0);      //combine file pathing

                    audioPlayer.SoundLocation = path00;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "01:00":
                    string path1 = @"Resources\Sound\Akizuki-01.wav";     //path of voiceline for time 0100
                    string fullPath = Path.Combine(AssemblyPath, path1);      //combine file pathing

                    audioPlayer.SoundLocation = fullPath;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "02:00":
                    string path2 = @"Resources\Sound\Akizuki-02.wav";     //path of voiceline for time 0200
                    string path02 = Path.Combine(AssemblyPath, path2);      //combine file pathing

                    audioPlayer.SoundLocation = path02;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "03:00":
                    string path3 = @"Resources\Sound\Akizuki-03.wav";     //path of voiceline for time 0300
                    string path03 = Path.Combine(AssemblyPath, path3);      //combine file pathing

                    audioPlayer.SoundLocation = path03;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "04:00":
                    string path4 = @"Resources\Sound\Akizuki-04.wav";     //path of voiceline for time 0400
                    string path04 = Path.Combine(AssemblyPath, path4);      //combine file pathing

                    audioPlayer.SoundLocation = path04;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "05:00":
                    string path5 = @"Resources\Sound\Akizuki-05.wav";     //path of voiceline for time 0500
                    string path05 = Path.Combine(AssemblyPath, path5);      //combine file pathing

                    audioPlayer.SoundLocation = path05;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "06:00":
                    string path6 = @"Resources\Sound\Akizuki-06.wav";     //path of voiceline for time 0600
                    string path06 = Path.Combine(AssemblyPath, path6);      //combine file pathing

                    audioPlayer.SoundLocation = path06;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "07:00":
                    string path7 = @"Resources\Sound\Akizuki-07.wav";     //path of voiceline for time 0700
                    string path07 = Path.Combine(AssemblyPath, path7);      //combine file pathing

                    audioPlayer.SoundLocation = path07;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "08:00":
                    string path8 = @"Resources\Sound\Akizuki-08.wav";     //path of voiceline for time 0800
                    string path08 = Path.Combine(AssemblyPath, path8);      //combine file pathing

                    audioPlayer.SoundLocation = path08;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "09:00":
                    string path9 = @"Resources\temp\Akizuki-09.wav";     //path of voiceline for time 0900
                    string path09 = Path.Combine(AssemblyPath, path9);      //combine file pathing

                    audioPlayer.SoundLocation = path09;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "10:00":
                    string path10 = @"Resources\Sound\Akizuki-10.wav";     //path of voiceline for time 1000
                    string path010 = Path.Combine(AssemblyPath, path10);      //combine file pathing

                    audioPlayer.SoundLocation = path010;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "11:00":
                    string path11 = @"Resources\Sound\Akizuki-11.wav";     //path of voiceline for time 1100
                    string path011 = Path.Combine(AssemblyPath, path11);      //combine file pathing

                    audioPlayer.SoundLocation = path011;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "12:00":
                    string path12 = @"Resources\Sound\Akizuki-12.wav";     //path of voiceline for time 1200
                    string path012 = Path.Combine(AssemblyPath, path12);      //combine file pathing

                    audioPlayer.SoundLocation = path012;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "13:00":
                    string path13 = @"Resources\Sound\Akizuki-13.wav";     //path of voiceline for time 1300
                    string path013 = Path.Combine(AssemblyPath, path13);      //combine file pathing

                    audioPlayer.SoundLocation = path013;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "14:00":
                    string path14 = @"Resources\Sound\Akizuki-14.wav";     //path of voiceline for time 1400
                    string path014 = Path.Combine(AssemblyPath, path14);      //combine file pathing

                    audioPlayer.SoundLocation = path014;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "15:00":
                    string path15 = @"Resources\Sound\Akizuki-15.wav";     //path of voiceline for time 1500
                    string path015 = Path.Combine(AssemblyPath, path15);      //combine file pathing

                    audioPlayer.SoundLocation = path015;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "16:43":
                    string path16 = @"Resources\Sound\Akizuki-16.wav";     //path of voiceline for time 1600
                    string path016 = Path.Combine(AssemblyPath, path16);      //combine file pathing

                    audioPlayer.SoundLocation = path016;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "17:00":
                    string path17 = @"Resources\Sound\Akizuki-17.wav";     //path of voiceline for time 1700
                    string path017 = Path.Combine(AssemblyPath, path17);      //combine file pathing

                    audioPlayer.SoundLocation = path017;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "18:00":
                    string path18 = @"Resources\Sound\Akizuki-18.wav";     //path of voiceline for time 1800
                    string path018 = Path.Combine(AssemblyPath, path18);      //combine file pathing

                    audioPlayer.SoundLocation = path018;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "19:00":
                    string path19 = @"Resources\Sound\Akizuki-19.wav";     //path of voiceline for time 1900
                    string path019 = Path.Combine(AssemblyPath, path19);      //combine file pathing

                    audioPlayer.SoundLocation = path019;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "20:00":
                    string path20 = @"Resources\Sound\Akizuki-20.wav";     //path of voiceline for time 2000
                    string path020 = Path.Combine(AssemblyPath, path20);      //combine file pathing

                    audioPlayer.SoundLocation = path020;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "21:00":
                    string path21 = @"Resources\Sound\Akizuki-21.wav";     //path of voiceline for time 2100
                    string path021 = Path.Combine(AssemblyPath, path21);      //combine file pathing

                    audioPlayer.SoundLocation = path021;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "22:00":
                    string path22 = @"Resources\Sound\Akizuki-22.wav";     //path of voiceline for time 2200
                    string path022 = Path.Combine(AssemblyPath, path22);      //combine file pathing

                    audioPlayer.SoundLocation = path022;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;

                case "23:00":
                    string path23 = @"Resources\Sound\Akizuki-23.wav";     //path of voiceline for time 2300
                    string path023 = Path.Combine(AssemblyPath, path23);      //combine file pathing

                    audioPlayer.SoundLocation = path023;       //told audioPlayer the voiceline location
                    audioPlayer.Play();                         //play the voiceline
                    break;
            }
        }
    }
}
