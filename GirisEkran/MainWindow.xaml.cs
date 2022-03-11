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
using Kutuphane;


namespace GirisEkran
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BusinessLogicLayer BLL;
        public static Grid gonder;
        public MainWindow()
        {
            InitializeComponent();
            BLL = new BusinessLogicLayer();
            gonder = kontrolEt;
        }

        private void kapama_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void gizle_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Yeni_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.ShowDialog();
            
            if(window.radio=="Tarihi Şahıs")
            {
                UserControl1 uc = new UserControl1();
                Kontrol.kontrol(kontrolEt, uc);
            }
            else if(window.radio=="Muharebe")
            {
                MuharebeEkle me = new MuharebeEkle();
                Kontrol.kontrol(kontrolEt, me);
            }
            else if(window.radio=="Savaş")
            {
                Savas savas = new Savas();
                Kontrol.kontrol(kontrolEt, savas);
            }
            else if(window.radio=="Harita")
            {
                harita harita = new harita();
                Kontrol.kontrol(kontrolEt, harita);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Giriş g = new Giriş();
            Kontrol.kontrol(kontrolEt, g);

            //text.Text = BLL.aciklamaVer();
        }

        private void General_Click(object sender, RoutedEventArgs e)
        {
            GeneralTablo gen = new GeneralTablo();
            Kontrol.kontrol(kontrolEt, gen);
        }

        private void Muharebe_Click(object sender, RoutedEventArgs e)
        {
            MuharebeTablo muh = new MuharebeTablo();
            Kontrol.kontrol(kontrolEt, muh);
        }

        private void devlet_Click(object sender, RoutedEventArgs e)
        {
            DevletAdamıTablo dev = new DevletAdamıTablo();
            Kontrol.kontrol(kontrolEt, dev);
        }

        private void Savas_Click(object sender, RoutedEventArgs e)
        {
            SavasTablo savasTablo = new SavasTablo();
            Kontrol.kontrol(kontrolEt, savasTablo);
        }

        private void harita_Click(object sender, RoutedEventArgs e)
        {
            HaritaTablo haritaTablo = new HaritaTablo();
            Kontrol.kontrol(kontrolEt, haritaTablo);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Giriş gir = new Giriş();
            Kontrol.kontrol(kontrolEt, gir);
        }
    }
}
