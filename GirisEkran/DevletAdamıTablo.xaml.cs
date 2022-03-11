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
    /// DevletAdamıTablo.xaml etkileşim mantığı
    /// </summary>
    public partial class DevletAdamıTablo : UserControl
    {
        BusinessLogicLayer BLL;
        public static bool a = false;
        public static bool b = false;
        public DevletAdamıTablo()
        {
            InitializeComponent();
            BLL = new BusinessLogicLayer();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            devletAdamiListesi.ItemsSource = BLL.devletAdamiVer();
        }

        private void devletAdamiListesi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DevletAdamiBilgi devlet = new DevletAdamiBilgi(devletAdamiListesi.SelectedItem);
            devlet.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bu veriyi silmek istediğinize emin misiniz ?", "Dikkat", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;
                BLL.devletAdamiSil(btn.DataContext);
            }
        }

        private void Duzenle_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Entities.DevletAdamlari devlet = (Entities.DevletAdamlari)btn.DataContext;
            
            UserControl1 user = new UserControl1();
            user.dev.Tag = devlet.devletId;
            user.ad.Text = devlet.ad;
            user.soyad.Tag = devlet.generalId;
            user.soyad.Text = devlet.soyad;
            user.dog.Text = devlet.dogumTarihi;
            user.ol.Text = devlet.olumTarihi;
            user.dogYer.Text = devlet.dogumYeri;
            user.olYer.Text = devlet.olumYeri;
            user.hizmet.Text = devlet.HizmetYillari;
            user.aciklama.Text = devlet.aciklama;
            user.kaynak.Text = devlet.kaynak;
            if(devlet.foto!=null)
                user.resim.Source = new BitmapImage(new Uri(devlet.foto));
            user.savas.ItemsSource = devlet.girdigiSavaslar;
            user.gen.IsChecked = devlet.general;
            user.dev.IsChecked = devlet.devletAdami;
            a = true;
            b = true;
            Kontrol.kontrol(MainWindow.gonder, user);
        }
    }
}
