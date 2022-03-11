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
   
    public partial class MuharebeEkle : UserControl
    {
        BusinessLogicLayer BLL;
        public MuharebeEkle()
        {
            InitializeComponent();
            BLL = new BusinessLogicLayer();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            kazananlar.ItemsSource = BLL.generalVer();
            kaybedenler.ItemsSource = BLL.generalVer();
            if(MuharebeTablo.a==false)
                harita.ItemsSource = BLL.haritaVer();
        }

        private void Kaydet_Click(object sender, RoutedEventArgs e)
        {
            if (MuharebeTablo.a == false)
            {
                int bayrak = BLL.muharebeYaz(ad.Text, tarih.Text, kaz.Text, kay.Text, kazzay.Text, kayzay.Text, kazananlar.SelectedItems, kaybedenler.SelectedItems
                    , aciklama.Text, harita.SelectedItem, kaynak.Text);

                if (bayrak == 1)
                    MessageBox.Show("Kayıt başarıyla eklendi", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                else if (bayrak == -100)
                    MessageBox.Show("Doldurulmayan yerler var", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                    MessageBox.Show("Sistem Hatası", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int bayrak = BLL.muharebeDuzenle(ad.Text, tarih.Text, kaz.Text, kay.Text, kazzay.Text, kayzay.Text, kazananlar.SelectedItems, kaybedenler.SelectedItems
                    , aciklama.Text, harita.SelectedItem, kaynak.Text, ad.Tag);

                if (bayrak == 1)
                    MessageBox.Show("Kayıt başarıyla Düzenlendi", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                else if (bayrak == -100)
                    MessageBox.Show("Doldurulmayan yerler var", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                    MessageBox.Show("Sistem Hatası", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
