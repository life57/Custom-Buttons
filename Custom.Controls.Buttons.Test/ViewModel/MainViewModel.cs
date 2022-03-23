using System.Diagnostics;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Custom.Controls.Buttons.Test.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        private bool _anonymizeEnable;
        private bool _editEnable;
        private static bool _enbale;
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            MyCommand = new RelayCommand(Work);
            LaunchCommand = new RelayCommand(Launch);
            EditEnable = true;
        }

        private void Launch()
        {
            Process.Start("Calc.exe");
            EditEnable = false;
            Task.Delay(3000).Wait();
        }

        private void Work()
        {
            AnonymizeEnable = !_enbale;
            _enbale = !_enbale;
            EditEnable = true;
        }

        public bool AnonymizeEnable
        {
            get { return _anonymizeEnable; }
            set
            {
                _anonymizeEnable = value;
                RaisePropertyChanged();
            }
        }

        public bool EditEnable
        {
            get { return _editEnable; }
            set
            {
                _editEnable = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand MyCommand { get; set; }
        public RelayCommand LaunchCommand { get; set; }
    }
}