using Microsoft.Win32;
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
using System.IO;
using System.Drawing;

namespace GirisEkran
{
    /// <summary>
    /// UserControl1.xaml etkileşim mantığı
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        Kutuphane.BusinessLogicLayer BLL;
        string image;

        public UserControl1()
        {
            InitializeComponent();
            BLL = new BusinessLogicLayer();
        }

        public event EventHandler Clicked;

        protected virtual void OnClicked(EventArgs e)
        {
            EventHandler eh = Clicked;
            if (eh != null)
            {
                eh(this, e);
            }
        }
        private void resim2_Click(object sender, EventArgs e)
        {

            OnClicked(e);
            OpenFileDialog oku = new OpenFileDialog();
            oku.Filter = "(*.BMP; *.JPG; *.GIF; *.PNG; *.JPG)| *.BMP; *.JPG; *.GIF; *.PNG; *.JPG | All files(*.*) | *.*";
            oku.ShowDialog();
            if (oku.FileName != string.Empty) 
                resim.Source = new BitmapImage(new Uri(oku.FileName));
            image = oku.FileName;
        }

        private void window_Loaded(object sender,RoutedEventArgs e)
        {
            savas.ItemsSource = BLL.savasVer();
        }

        private void kaydet_Click(Object sender, EventArgs e)
        {
            OnClicked(e);
            string general = null;
            string devlet = null;

            if (DevletAdamıTablo.a == false)
            {
                if (gen.IsChecked == true)
                    general = (string)gen.Content;
                if (dev.IsChecked == true)
                    devlet = (string)dev.Content;
                
                int bayrak = BLL.yeniEkle(ad.Text, soyad.Text, dog.Text, ol.Text, savas.SelectedItems, hizmet.Text, aciklama.Text, general, devlet, image, dogYer.Text, olYer.Text, kaynak.Text);

                if (bayrak == -2)
                    MessageBox.Show("Sistem Hatası", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                else if (bayrak == -199)
                    MessageBox.Show("Doldurulmayan yerler var", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                else if (bayrak == 102)
                    MessageBox.Show("Meslek seçiniz", "Dikkat", MessageBoxButton.OK, MessageBoxImage.Question);
                else if (bayrak == 52)
                    MessageBox.Show("Kayıt Başarıyla Eklendi", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                else if (bayrak == 2)
                    MessageBox.Show("Kayıt Başarıyla Eklendi", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (gen.IsChecked == true)
                    general = (string)gen.Content;
                if (dev.IsChecked == true)
                    devlet = (string)dev.Content;
                
                int bayrak=0;
                int bayrak2 = 0;
                
                if (gen.IsChecked == false && dev.IsChecked == false)
                    MessageBox.Show("Lütfen meslek seçiniz.", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                {
                    if (GeneralTablo.b == true && soyad.Tag != null && gen.Tag != null)
                    {
                        if (gen.IsChecked == false && dev.IsChecked == false)
                            MessageBox.Show("Lütfen meslek seçiniz.", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                        else
                        {
                            if (gen.IsChecked == true)
                                bayrak = BLL.generalDuzenle(ad.Text, soyad.Text, dog.Text, ol.Text, savas.SelectedItems, hizmet.Text, aciklama.Text, general, devlet, image, dogYer.Text, olYer.Text, kaynak.Text, gen.Tag, soyad.Tag);
                            else
                            {
                                MessageBox.Show("Bu işlemi burada yapamazsınız", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                                bayrak = -1;
                            }

                            if (dev.IsChecked == true && gen.IsChecked!=false)
                                bayrak2 = BLL.devletAdamiDuzenle(ad.Text, soyad.Text, dog.Text, ol.Text, savas.SelectedItems, hizmet.Text, aciklama.Text, general, devlet, image, dogYer.Text, olYer.Text, kaynak.Text, soyad.Tag, gen.Tag);
                            else if(dev.IsChecked==false)
                            {
                                int k = BLL.kisiDevletAdamiSil(soyad.Tag);
                                bayrak2 = -2;
                                if (k == -1)
                                    MessageBox.Show("Bu işlemi burada yapamazsınız", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                            int bayrak3 = bayrak2 + bayrak;

                            if (bayrak3 == 88)
                                MessageBox.Show("Sistem Hatası", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                            else if (bayrak3 == -200)
                                MessageBox.Show("Doldurulmayan yerler var", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                            else if (bayrak3 == -101)
                                MessageBox.Show("Doldurulmayan yerler var", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                            else if (bayrak3 == 102)
                                MessageBox.Show("Meslek seçiniz", "Dikkat", MessageBoxButton.OK, MessageBoxImage.Question);
                            else if (bayrak3 == 2)               
                                MessageBox.Show("Kayit Başarıyla Düzenlendi", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                            else if (bayrak3 == -1)
                                MessageBox.Show("Kayit Başarıyla Düzenlendi", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);

                        }
                    }

                    else if (DevletAdamıTablo.b == true && soyad.Tag!=null && dev.Tag!=null)
                    {
                        if (gen.IsChecked == true)
                            general = (string)gen.Content;
                        if (dev.IsChecked == true)
                            devlet = (string)dev.Content;
                        if (gen.IsChecked == false && dev.IsChecked == false)
                            MessageBox.Show("Lütfen meslek seçiniz.", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                        else
                        {
                            if (gen.IsChecked == true && dev.IsChecked==true)
                                bayrak = BLL.generalDuzenle(ad.Text, soyad.Text, dog.Text, ol.Text, savas.SelectedItems, hizmet.Text, aciklama.Text, general, devlet, image, dogYer.Text, olYer.Text, kaynak.Text, soyad.Tag, dev.Tag);
                            else if(gen.IsChecked==false)
                            {
                                bayrak = BLL.kisiGeneralSil(soyad.Tag);

                            }
                            if (dev.IsChecked == true)
                                bayrak2 = BLL.devletAdamiDuzenle(ad.Text, soyad.Text, dog.Text, ol.Text, savas.SelectedItems, hizmet.Text, aciklama.Text, general, devlet, image, dogYer.Text, olYer.Text, kaynak.Text, dev.Tag, soyad.Tag);
                            else
                            {
                                MessageBox.Show("Bu işlemi burada yapamazsınız", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                                bayrak2 = -1;
                            }
                            int bayrak3 = bayrak2 + bayrak;

                            if (bayrak3 == 88)
                                MessageBox.Show("Sistem Hatası", "Hata", MessageBoxButton.OK, MessageBoxImage.Error);
                            else if (bayrak3 == -200)
                                MessageBox.Show("Doldurulmayan yerler var", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                            else if (bayrak3 == -101)
                                MessageBox.Show("Doldurulmayan yerler var", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                            else if (bayrak3 == 102)
                                MessageBox.Show("Meslek seçiniz", "Dikkat", MessageBoxButton.OK, MessageBoxImage.Question);
                            else if (bayrak3 == 2)
                                MessageBox.Show("Kayit Başarıyla Düzenlendi", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Parametre hatası. Tekrar deneyiniz.", "hata", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
