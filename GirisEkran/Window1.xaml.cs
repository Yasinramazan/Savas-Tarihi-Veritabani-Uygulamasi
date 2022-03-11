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

namespace GirisEkran
{
    /// <summary>
    /// Window1.xaml etkileşim mantığı
    /// </summary>
    public partial class Window1 : Window
    {
        public string radio;
        public Window1()
        {
            InitializeComponent();
            
        }

        private void sec_Click(object sender, RoutedEventArgs e)
        {
            foreach (Control item in stack.Children)
            {
                RadioButton rd;
                if(item is RadioButton)
                { rd = (RadioButton)item;
                    if(rd.IsChecked==true)
                    {
                        radio = (string)rd.Tag;
                    }
                }
            }
            this.Close();
        }
    }
}
