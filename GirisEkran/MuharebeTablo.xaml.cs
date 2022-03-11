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
    /// MuharebeTablo.xaml etkileşim mantığı
    /// </summary>
    public partial class MuharebeTablo : UserControl
    {
        BusinessLogicLayer BLL;
        public static bool a = false;
        public MuharebeTablo()
        {
            InitializeComponent();
            BLL = new BusinessLogicLayer();
        }

        private void muharebeListesi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MuharebeBilgi muharebeBilgi = new MuharebeBilgi(muharebeListesi.SelectedItem);
            muharebeBilgi.Show();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            muharebeListesi.ItemsSource = BLL.muharebeVer();
        }

        private void Duzenle_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            MuharebeEkle muharebeEkle = new MuharebeEkle();
            Entities.Muharebe muharebe = (Entities.Muharebe)btn.DataContext;
            muharebeEkle.ad.Tag = muharebe.id;
            muharebeEkle.ad.Text = muharebe.ad;
            muharebeEkle.tarih.Text = muharebe.tarih;
            muharebeEkle.kaynak.Text = muharebe.kaynak;
            muharebeEkle.harita.ItemsSource = BLL.haritaVer();
            muharebeEkle.aciklama.Text = muharebe.aciklama;
            for (int i = 0; i < muharebe.kazananlar.Count; i++)
            {
                muharebeEkle.kaz.Text += muharebe.kazananlar[i];
                if (i != muharebe.kazananlar.Count - 1)
                    muharebeEkle.kaz.Text = ",";
            }
            for (int i = 0; i < muharebe.kaybedenler.Count; i++)
            {
                muharebeEkle.kay.Text += muharebe.kaybedenler[i];
                if (i != muharebe.kaybedenler.Count - 1)
                    muharebeEkle.kay.Text = ",";
            }
            for (int i = 0; i < muharebe.kazananZayiati.Count; i++)
            {
                muharebeEkle.kazzay.Text += muharebe.kazananZayiati[i];
                if (i != muharebe.kazananZayiati.Count - 1)
                    muharebeEkle.kazzay.Text = ",";
            }
            for (int i = 0; i < muharebe.kaybedenZayiati.Count; i++)
            {
                muharebeEkle.kayzay.Text += muharebe.kaybedenZayiati[i];
                if (i != muharebe.kaybedenZayiati.Count - 1)
                    muharebeEkle.kayzay.Text = ",";
            }
            muharebeEkle.kazananlar.ItemsSource = BLL.generalVer();
            muharebeEkle.kaybedenler.ItemsSource = BLL.generalVer();
            a = true;
            Kontrol.kontrol(MainWindow.gonder, muharebeEkle);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bu veriyi silmek istediğinize emin misiniz ?", "Dikkat", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;
                BLL.muharebeSil(btn.DataContext);

            }   
        }
    }
}
