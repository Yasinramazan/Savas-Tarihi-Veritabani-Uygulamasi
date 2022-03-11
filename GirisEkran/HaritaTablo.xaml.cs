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
    /// HaritaTablo.xaml etkileşim mantığı
    /// </summary>
    public partial class HaritaTablo : UserControl
    {
        BusinessLogicLayer BLL;
        public static bool a = false;
        public HaritaTablo()
        {
            InitializeComponent();
            BLL = new BusinessLogicLayer();
        }

        private void haritaListesi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HaritaBilgi haritaBilgi = new HaritaBilgi(haritaListesi.SelectedItem);
            haritaBilgi.Show();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            haritaListesi.ItemsSource = BLL.haritaVer();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bu veriyi silmek istediğinize emin misiniz ?", "Dikkat", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;
                BLL.haritaSil(btn.DataContext);
            }
        }

        private void Duzenle_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            harita harita = new harita();
            Entities.Harita h = new Entities.Harita();
            h = (Entities.Harita)btn.DataContext;
            harita.har.Tag = h.id;
            harita.har.Text = h.harita;
            harita.tarih.Text = h.tarih;
            harita.yer.Text = h.yerAdi;
            harita.kaynak.Text = h.kaynak;
            harita.aciklama.Text = h.aciklama;
            harita.text.Items.Add(h.muharebe);
            harita.dosya.Content = h.resim;
            a = true;
            Kontrol.kontrol(MainWindow.gonder, harita);
        }
    }
}
