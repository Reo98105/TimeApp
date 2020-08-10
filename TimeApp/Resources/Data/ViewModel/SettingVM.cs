using TimeApp.Resources.Data.Model;

namespace TimeApp.Resources.Data.ViewModel
{
    public class SettingVM
    {
        public VoiceM Voice { get; set; }

        public SettingVM()
        {
            Voice = new VoiceM();
        }
    }
}
