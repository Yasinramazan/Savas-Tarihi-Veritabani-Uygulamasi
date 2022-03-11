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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kutuphane;
using Microsoft.Win32;
using System.IO;

namespace GirisEkran
{
    /// <summary>
    /// harita.xaml etkileşim mantığı
    /// </summary>
    public partial class harita : UserControl
    {
        BusinessLogicLayer BLL;
        string yol;
        public harita()
        {
            InitializeComponent();
            BLL = new BusinessLogicLayer();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(HaritaTablo.a==false)
                text.ItemsSource = BLL.muharebeVer();
        }

        private void kaydet_Click(object sender, RoutedEventArgs e)
        {
            if (HaritaTablo.a == false)
            {
                int bayrak = BLL.haritaYaz(har.Text, tarih.Text, yer.Text, aciklama.Text, text.SelectedItem, yol, kaynak.Text);

                if (bayrak == 1)
                    MessageBox.Show("Kayıt Başarılı", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                else if (bayrak == -100)
                    MessageBox.Show("Doldurulmayan Yerler Var", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                    MessageBox.Show("Sistem hatası", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                int bayrak = BLL.haritaDuzenle(har.Text, tarih.Text, yer.Text, aciklama.Text, text.SelectedItem, yol, kaynak.Text,har.Tag);

                if (bayrak == 1)
                    MessageBox.Show("Düzenleme Başarılı", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                else if (bayrak == -100)
                    MessageBox.Show("Doldurulmayan Yerler Var", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                    MessageBox.Show("Sistem hatası", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog oku = new OpenFileDialog();
            oku.Filter = "(*.BMP; *.JPG; *.GIF; *.PNG; *.JPG)| *.BMP; *.JPG; *.GIF; *.PNG; *.JPG | All files(*.*) | *.*";
            oku.ShowDialog();
            if (oku.FileName != string.Empty)
            {
                try
                {
                    new Process
                    {
                        StartInfo = new ProcessStartInfo(oku.FileName)
                        {
                            UseShellExecute = true
                        }
                    }.Start();
                }
                catch
                {
                    MessageBox.Show("Sistem Hatası", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                yol = oku.FileName;
                string uzanti = oku.FileName.Substring(oku.FileName.Length - 4, 4);
                string yazilacak = System.IO.Path.GetFileNameWithoutExtension(oku.FileName);
                dosya.Content = yazilacak + uzanti;
            }
        }
    }
}
