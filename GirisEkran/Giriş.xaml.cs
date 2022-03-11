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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Threading;
using System.ComponentModel;

namespace GirisEkran
{
    /// <summary>
    /// Giriş.xaml etkileşim mantığı
    /// </summary>
    public partial class Giriş : UserControl
    {
        /*private string[] files;
        private System.Timers.Timer timer;

        private int counter;
        private int Imagecounter;
        BitmapImage _MainImageSource = null;*/
        public Giriş()
        {
            InitializeComponent();
            //DataContext = this;
            
        }

        /*public BitmapImage MainImageSource  // Using Uri in the binding was no possible because the Source property of an Image is of type ImageSource. (Yes it is possible to write directly the path in the XAML to define the source, but it is a feature of XAML (called a TypeConverter), not WPF)
        {
            get
            {
                return _MainImageSource;
            }
            set
            {
                _MainImageSource = value;
                OnPropertyChanged("MainImageSource");  // Don't forget this line to notify WPF the value has changed.
            }
        }



        private void Giriş_Loaded(object sender, RoutedEventArgs e)
        {
            if (Picture.Source == null)
                Picture.Source = new BitmapImage(new Uri(@"C:\\Users\\yasin\\source\\\repos\\Tarih\\GirisEkran\\ArkaPlanlar\\Colezium.jpg"));

            setupPics();
        }

        private void setupPics()
        {
            timer = new System.Timers.Timer();
            timer.Elapsed += timer_Tick;
            timer.Interval = 3000;
            // Initialize "files", "Imagecounter", "counter" before starting the timer because the timer is not working in the same thread and it accesses these fields.
            files = Directory.GetFiles(@"C:\\Users\\yasin\\source\\\repos\\Tarih\\GirisEkran\\ArkaPlanlar\\");
            
            timer.Start();  // timer.Start() and timer.Enabled are equivalent, only one is necessary
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // WPF requires all the function that modify (or even read sometimes) the visual interface to be called in a WPF dedicated thread.
            // IntroScreen() and MainWindow_Loaded(...) are executed by this thread
            // But, as I have said before, the Tick event of the Timer is called in another thread (a thread from the thread pool), then you can't directly modify the MainImageSource in this thread
            // Why? Because a modification of its value calls OnPropertyChanged that raise the event PropertyChanged that will try to update the Binding (that is directly linked with WPF)
            Dispatcher.Invoke(new Action(() =>  // Call a special portion of your code from the WPF thread (called dispatcher)
            {
                // Now that I have changed the type of MainImageSource, we have to load the bitmap ourselves.
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(files[counter], UriKind.Relative);
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;  // Don't know why. Found here (http://stackoverflow.com/questions/569561/dynamic-loading-of-images-in-wpf)
                bitmapImage.EndInit();
                MainImageSource = bitmapImage;  // Set the property (because if you set the field "_MainImageSource", there will be no call to OnPropertyChanged("MainImageSource"), then, no update of the binding.
            }));
            if (++counter == Imagecounter)
                counter = 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }*/



    }
}
