using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// HaritaBilgi.xaml etkileşim mantığı
    /// </summary>
    public partial class HaritaBilgi : Window
    {
        Harita harita;
        public HaritaBilgi(object h)
        {
            InitializeComponent();
            harita = (Harita)h;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            baslik.Text = harita.harita + " " + harita.tarih;
            yer.Text = harita.yerAdi;
            kaynak.Text = harita.kaynak;
            aciklama.Text = harita.aciklama;
            if (harita.resim != null)
                foto.Source = new BitmapImage(new Uri(harita.resim));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MuharebeBilgi muharebeBilgi = new MuharebeBilgi(harita.muharebe);
            muharebeBilgi.Show();
        }

        private void foto_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                new Process
                {
                    StartInfo = new ProcessStartInfo(harita.resim)
                    {
                        UseShellExecute = true
                    }
                }.Start();
            }
            catch
            {
                MessageBox.Show("Sistem Hatası", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
