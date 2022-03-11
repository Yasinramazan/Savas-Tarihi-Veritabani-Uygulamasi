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
using System.Windows.Shapes;
using Kutuphane;
using Entities;

namespace GirisEkran
{
    /// <summary>
    /// GeneralBilgi.xaml etkileşim mantığı
    /// </summary>
    public partial class GeneralBilgi : Window
    {
        object secilen;
        BusinessLogicLayer BLL;
        public GeneralBilgi(object secilen)
        {
            InitializeComponent();
            this.secilen = secilen;
            BLL = new BusinessLogicLayer();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            General general = new General();
            general = (General)secilen;
            anaBilgi.Text = general.ad + " " + general.soyad + "  " + general.dogumTarihi + "-" + general.olumTarihi;
            dog.Text = general.dogumYeri;
            ol.Text = general.olumYeri;
            hizmet.Text = general.HizmetYillari;
            kaynak.Text = general.kaynak;
            Savaslar.ItemsSource = general.girdigiSavaslar;
            if(general.foto!=null)
                foto.Source = new BitmapImage(new Uri(general.foto));
            aciklama.Text = general.aciklama;
        }
    }
}
