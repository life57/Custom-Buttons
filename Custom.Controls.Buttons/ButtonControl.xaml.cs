using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Custom.Controls.Buttons
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ButtonControl : UserControl, INotifyPropertyChanged
    {
        public enum ImageCategory
        {
            NewPatient = 1,
            EditPatient,
            DeletePatient,
            ImportWorkList,
            Anonymize,
            NewStudy,
            EditStudy,
            DeleteStudy,
            Reports,
            Reconstruct,
            View,
            SaveToCd,
            DeleteReport,
            Archive,
            ExportList,
            Restore,
            Applications,
            DataQc
        }

        public ButtonControl()
        {
            InitializeComponent();
        }
        
        public static readonly DependencyProperty SpCommandProperty = DependencyProperty.Register("SpCommand", typeof(ICommand), typeof(ButtonControl));
        public ICommand SpCommand
        {
            get { return (ICommand)GetValue(SpCommandProperty); }
            set { SetValue(SpCommandProperty, value); }
        }
        public static readonly RoutedEvent LeftClickEvent = EventManager.RegisterRoutedEvent("LeftClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ButtonControl));
        public event RoutedEventHandler LeftClick
        {
            add { AddHandler(LeftClickEvent, value); }
            remove { RemoveHandler(LeftClickEvent, value); }
        }
        public static readonly DependencyProperty SpEnableProperty = DependencyProperty.Register("SpEnable", typeof(bool), typeof(ButtonControl), new PropertyMetadata());

        public bool SpEnable
        {
            get { return (bool)GetValue(SpEnableProperty); }
            set
            {
                SetValue(SpEnableProperty, value);
            }
        }
        public static readonly DependencyProperty ImageCategoryProperty = DependencyProperty.Register("SpImageCategory", typeof(ImageCategory), typeof(ButtonControl));
        public ImageCategory SpImageCategory
        {
            get { return (ImageCategory)GetValue(ImageCategoryProperty); }
            set { SetValue(ImageCategoryProperty, value); }
        }
        public static readonly DependencyProperty SpTextProperty = DependencyProperty.Register("SpText", typeof(string), typeof(ButtonControl));
        public string SpText
        {
            get { return (string)GetValue(SpTextProperty); }
            set { SetValue(SpTextProperty, value); }
        }

        public bool Normal { get { return _selected[0]; } }
        public bool Hover { get { return _selected[1]; } }
        public bool Click { get { return _selected[2]; } }
        public bool Disable { get { return _selected[3]; } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!SpEnable)
            {
                SelectImage(3);
                SpControlText.Foreground = LoadedForegroundDisanableBrush;
                return;
            }

            SpControlText.Foreground = SpEnable ? LoadedForegroundEnableBrush : LoadedForegroundDisanableBrush;
            SelectImage(0);
        }
        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (!SpEnable)
                return;

            SpButton.BorderBrush = MouseEnterBorderBrush;
            SpControlText.Foreground = MouseEnterTextForegroundBrush;

            SelectImage(1);
        }
        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (!SpEnable)
                return;

            SpButton.BorderBrush = MouseLeaveBorderBrush;
            SpControlText.Foreground = MouseLeaveForeground;

            SelectImage(0);
        }
        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!SpEnable)
                return;

            SpButton.BorderBrush = MouseLeftDownBorderBrush;
            SpControlText.Foreground = MouseLeftDownForegroundBrush;

            SelectImage(2);
        }
        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!SpEnable)
                return;

            SpControlText.Foreground = MouseLeftUpForegroundBrush;

            SelectImage(1);
        }
        private void SelectImage(int index)
        {
            _selected[0] = false;
            _selected[1] = false;
            _selected[2] = false;
            _selected[3] = false;

            _selected[index] = true;

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Normal"));
                PropertyChanged(this, new PropertyChangedEventArgs("Hover"));
                PropertyChanged(this, new PropertyChangedEventArgs("Click"));
                PropertyChanged(this, new PropertyChangedEventArgs("Disable"));
            }
        }

        private readonly bool[] _selected = new bool[4];

        #region Private Brushes
        private static readonly SolidColorBrush MouseEnterBorderBrush = new SolidColorBrush(Colors.White);
        private static readonly SolidColorBrush MouseEnterTextForegroundBrush = new SolidColorBrush(Color.FromRgb(0x49, 0x90, 0xE2));
        private static readonly SolidColorBrush MouseLeaveBorderBrush = new SolidColorBrush(Colors.Transparent);
        private static readonly SolidColorBrush MouseLeaveForeground = new SolidColorBrush(Color.FromRgb(0xE0, 0xE0, 0xE0));
        private static readonly SolidColorBrush MouseLeftDownBorderBrush = new SolidColorBrush(Color.FromRgb(0x9B, 0x9B, 0x9B));
        private static readonly SolidColorBrush MouseLeftDownForegroundBrush = new SolidColorBrush(Color.FromRgb(0xF6, 0xA6, 0x23));
        private static readonly SolidColorBrush MouseLeftUpForegroundBrush = new SolidColorBrush(Color.FromRgb(0x49, 0x90, 0xE2));
        private static readonly SolidColorBrush LoadedForegroundEnableBrush = new SolidColorBrush(Color.FromRgb(0xFF, 0xFF, 0xFF));
        private static readonly SolidColorBrush LoadedForegroundDisanableBrush = new SolidColorBrush(Color.FromRgb(0x83, 0x83, 0x83));
        #endregion

        private void OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SpControlText.Foreground = SpEnable ? LoadedForegroundEnableBrush : LoadedForegroundDisanableBrush;
            
            if (!SpEnable)
                SpButton.BorderBrush = MouseLeaveBorderBrush;

            SelectImage(SpEnable ? 0 : 3);
        }
    }
}
