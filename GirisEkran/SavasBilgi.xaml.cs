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
    /// SavasBilgi.xaml etkileşim mantığı
    /// </summary>
    public partial class SavasBilgi : Window
    {
        Savaslar savas;
        public SavasBilgi(object selected)
        {
            InitializeComponent();
            savas = (Savaslar)selected;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            baslik.Text = savas.ad + "  " + savas.baslangic + "-" + savas.bitis;
            kazananlar.ItemsSource = savas.kazananlar;
            kaybedenler.ItemsSource = savas.kaybedenler;
            kazananZay.ItemsSource = savas.kazananZayiati;
            kaybedenZay.ItemsSource = savas.kaybedenZayiati;
            kazananGen.ItemsSource = savas.kazananGeneraller;
            kaybedenGen.ItemsSource = savas.kaybedenGeneraller;
            aciklama.Text = savas.aciklama;
            kaynak.Text = savas.kaynak;
        }
    }
}
