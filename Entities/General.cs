using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class General:Kisi
    {
        public Guid generalId { get; set; }
        public Guid devletId { get; set; }
        public string ad { get; set; }
        public string  soyad { get; set; }
        public string dogumTarihi { get; set; }
        public string dogumYeri { get; set; }
        public string olumTarihi { get; set; }
        public string  olumYeri { get; set; }
        public List<Savaslar> girdigiSavaslar { get; set; }
        public string HizmetYillari { get; set; }
        public string  aciklama { get; set; }
        public string foto { get; set; }
        public string  kaynak { get; set; }
        public bool general { get; set; }
        public bool devletAdami { get; set; }

        public override string ToString()
        {
            return $"{ad} {soyad}";
        }

    }
}
