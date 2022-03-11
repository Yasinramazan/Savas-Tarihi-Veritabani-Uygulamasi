using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Savaslar
    {
        public Guid id { get; set; }
        public string ad { get; set; }
        public string baslangic { get; set; }
        public string bitis { get; set; }
        public List<string> kazananlar { get; set; }
        public List<String> kaybedenler { get; set; }
        public List<string> kazananZayiati { get; set; }
        public List<string> kaybedenZayiati { get; set; }
        public List<General> kazananGeneraller { get; set; }
        public List<General> kaybedenGeneraller { get; set; }
        public string aciklama { get; set; }
        public string  kaynak { get; set; }

        public override string ToString()
        {
            return $"{ad} {baslangic}-{bitis}";
        }

    }
}
