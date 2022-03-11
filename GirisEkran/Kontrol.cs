using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Drawing;

namespace GirisEkran
{
    public static class Kontrol
    {
        public static void kontrol(Grid grd,UserControl uc)
        {
            if(grd.Children.Count>0)
            {
                grd.Children.Clear();
            }
            grd.Children.Add(uc);
            
        }
       
    }
}
