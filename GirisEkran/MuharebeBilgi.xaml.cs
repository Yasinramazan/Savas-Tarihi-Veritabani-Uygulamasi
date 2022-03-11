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
    
    public partial class MuharebeBilgi : Window
    {
        Muharebe muharebe;
        public MuharebeBilgi(object muharebe)
        {
            InitializeComponent();
            this.muharebe = (Muharebe)muharebe;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (muharebe != null)
            {
                baslik.Text = muharebe.ad + " " + muharebe.tarih;
                kaynak.Text = muharebe.kaynak;
                kazananlar.ItemsSource = muharebe.kazananlar;
                kaybedenler.ItemsSource = muharebe.kaybedenler;
                kazananZay.ItemsSource = muharebe.kazananZayiati;
                kaybedenZay.ItemsSource = muharebe.kaybedenZayiati;
                kazananGen.ItemsSource = muharebe.kazananGeneraller;
                kaybedenGen.ItemsSource = muharebe.kaybedenGeneraller;
                aciklama.Text = muharebe.aciklama;
            }
            else
            {
                MessageBox.Show("Bu muharebe kayıtlarda yok.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }
    }
}
