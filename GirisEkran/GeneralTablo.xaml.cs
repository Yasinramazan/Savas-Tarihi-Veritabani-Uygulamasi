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
using Entities;

namespace GirisEkran
{
    
    public partial class GeneralTablo : UserControl
    {
        BusinessLogicLayer BLL;
        public static bool a = false;
        public static bool b = false;
        public GeneralTablo()
        {
            InitializeComponent();
            BLL = new BusinessLogicLayer();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            generalListesi.ItemsSource = BLL.generalVer();
        }

       

        private void generalListesi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GeneralBilgi bilgi = new GeneralBilgi(generalListesi.SelectedItem);
            bilgi.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bu veriyi silmek istediğinize emin misiniz ?", "Dikkat", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;
                BLL.generalSil(btn.DataContext);
            }
        }

        private void Duzenle_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Entities.General general = (Entities.General)btn.DataContext;

            UserControl1 user = new UserControl1();
            user.gen.Tag = general.generalId;
            user.ad.Text = general.ad;
            user.soyad.Tag = general.devletId;
            user.soyad.Text = general.soyad;
            user.dog.Text = general.dogumTarihi;
            user.ol.Text = general.olumTarihi;
            user.dogYer.Text = general.dogumYeri;
            user.olYer.Text = general.olumYeri;
            user.hizmet.Text = general.HizmetYillari;
            user.aciklama.Text = general.aciklama;
            user.kaynak.Text = general.kaynak;
            if (general.foto != null)
                user.resim.Source = new BitmapImage(new Uri(general.foto));
            user.savas.ItemsSource = general.girdigiSavaslar;
            user.gen.IsChecked = general.general;
            user.dev.IsChecked = general.devletAdami;
            DevletAdamıTablo.a = true;
            b = true;
            Kontrol.kontrol(MainWindow.gonder, user);
        }
    }
}
