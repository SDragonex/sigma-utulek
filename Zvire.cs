using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigmautulek
{
    public class Zvire
    {
        public int Id { get; set; }
        public string Jmeno { get; set; }
        public string Druh { get; set; }
        public int Vek { get; set; }
        public string Pohlavi { get; set; }
        public DateTime DatumPrijmu { get; set; }
        public string ZdravotniStav { get; set; }
        public string Poznamka { get; set; }
        public bool Adoptovano { get; set; }
        public DateTime? DatumAdopce { get; set; }

        public override string ToString()
        {
            return $"{Id,-3} {Jmeno,-10} {Druh,-8} {Vek,-4} {(Adoptovano ? "ANO" : "NE"),-5}";
        }
    }
}
