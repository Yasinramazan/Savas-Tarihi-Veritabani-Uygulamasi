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
    /// SavasTablo.xaml etkileşim mantığı
    /// </summary>
    public partial class SavasTablo : UserControl
    {
        BusinessLogicLayer BLL;
        Entities.Savaslar secilenSavas;
        public static bool a = false;
        public SavasTablo()
        {
            InitializeComponent();
            BLL = new BusinessLogicLayer();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            savaslistesi.ItemsSource = BLL.savasVer();
        }

        private void savaslistesi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SavasBilgi savasBilgi = new SavasBilgi(savaslistesi.SelectedItem);
            secilenSavas = (Entities.Savaslar)savaslistesi.SelectedItem;
            savasBilgi.Show();
        }

        private void Duzenle_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Savas ekle = new Savas();
            Entities.Savaslar savas = (Entities.Savaslar)btn.DataContext;
            ekle.ad.Tag = savas.id;
            ekle.ad.Text = savas.ad;
            ekle.aciklama.Text = savas.aciklama;
            ekle.basla.Text = savas.baslangic;
            ekle.bit.Text = savas.bitis;
            ekle.kaynak.Text = savas.kaynak;
            ekle.kazananlar.ItemsSource = savas.kazananGeneraller;
            ekle.kaybedenler.ItemsSource = savas.kaybedenGeneraller;
            ekle.kaynak.Text = savas.kaynak;
            foreach(string item in savas.kazananlar)
            {
                ekle.kaz.Text += item;
                if(item!=savas.kazananlar[savas.kazananlar.Count-1])
                    ekle.kaz.Text += ",";
            }
            foreach(string item in savas.kaybedenler)
            {
                ekle.kay.Text += item;
                if (item != savas.kaybedenler[savas.kaybedenler.Count - 1])
                    ekle.kay.Text += ",";
            }
            foreach (string item in savas.kazananZayiati)
            {
                ekle.kazzay.Text += item;
                if (item != savas.kazananZayiati[savas.kazananZayiati.Count - 1])
                    ekle.kazzay.Text += ",";
            }
            foreach (string item in savas.kaybedenZayiati)
            {
                ekle.kayzay.Text += item;
                if (item != savas.kaybedenZayiati[savas.kaybedenZayiati.Count - 1])
                    ekle.kayzay.Text += ",";
            }
            a = true;
            Kontrol.kontrol(MainWindow.gonder, ekle);
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bu veriyi silmek istediğinize emin misiniz ?", "Dikkat", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Button btn = (Button)sender;
                BLL.savasSil(btn.DataContext);
            }
        }
    }
}
