using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Harita
    {
        public Guid id { get; set; }
        public string harita { get; set; }
        public string yerAdi { get; set; }
        public string tarih { get; set; }
        public string aciklama { get; set; }
        public Muharebe muharebe { get; set; }
        public string resim { get; set; }
        public string kaynak { get; set; }

        public override string ToString()
        {
            return $"{yerAdi} {muharebe}";
        }
    }
}
