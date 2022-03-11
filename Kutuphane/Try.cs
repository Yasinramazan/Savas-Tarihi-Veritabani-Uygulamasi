using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane
{
    public class Try
    {
        public static int TryCatch(Action a)
        {
            int bayrak;
            try
            {
                a();
                bayrak = 1;
            }
            catch (Exception)
            {
                bayrak = -1;
            }
            return bayrak;
        }
    }
}
