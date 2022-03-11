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
    /// Savas.xaml etkileşim mantığı
    /// </summary>
    public partial class Savas : UserControl
    {
        BusinessLogicLayer BLL;   
        public Savas()
        {
            InitializeComponent();
            BLL = new BusinessLogicLayer();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            kazananlar.ItemsSource = BLL.generalVer();
            kaybedenler.ItemsSource = BLL.generalVer();
        }

        private void Kaydet_Click(object sender, RoutedEventArgs e)
        {
            if (SavasTablo.a == false)
            {
                int bayrak = BLL.savasYaz(ad.Text, basla.Text, bit.Text, kaz.Text, kay.Text, kazzay.Text, kayzay.Text, kazananlar.SelectedItems, kaybedenler.SelectedItems, aciklama.Text, kaynak.Text);
                if (bayrak == 1)
                    MessageBox.Show("Kayıt Başarılı", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                else if (bayrak == -100)
                    MessageBox.Show("Doldurulmayan yerler var", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                    MessageBox.Show("Sistem Hatası", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int bayrak = BLL.savasDuzenle(ad.Text, basla.Text, bit.Text, kaz.Text, kay.Text, kazzay.Text, kayzay.Text, kazananlar.SelectedItems, kaybedenler.SelectedItems, aciklama.Text, kaynak.Text,ad.Tag);
                if (bayrak == 1)
                    MessageBox.Show("Düzenleme Başarılı", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                else if (bayrak == -100)
                    MessageBox.Show("Doldurulmayan yerler var", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                    MessageBox.Show("Sistem Hatası", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
