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
using Entities;

namespace GirisEkran
{
    /// <summary>
    /// DevletAdamiBilgi.xaml etkileşim mantığı
    /// </summary>
    public partial class DevletAdamiBilgi : Window
    {
        DevletAdamlari devlet;
        public DevletAdamiBilgi(object selected)
        {
            InitializeComponent();
            devlet = (DevletAdamlari)selected;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            anaBilgi.Text = devlet.ad + " " + devlet.soyad + "  " + devlet.dogumTarihi + "-" + devlet.olumTarihi;
            dog.Text = devlet.dogumYeri;
            ol.Text = devlet.olumYeri;
            hizmet.Text = devlet.HizmetYillari;
            kaynak.Text = devlet.kaynak;
            Savaslar.ItemsSource = devlet.girdigiSavaslar;
            aciklama.Text = devlet.aciklama;
            if (devlet.foto != null)
                foto.Source=(new BitmapImage(new Uri(devlet.foto)));
        }
    }
}
