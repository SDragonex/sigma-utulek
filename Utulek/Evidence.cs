using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utulek
{
    internal class Evidence
    {
        private List<Zvire> zvirata = new List<Zvire>();
        private int nextId = 1;

        public Evidence()
        {
            // Testovací data
            PridatZvire(new Zvire
            {
                Jmeno = "Rex",
                Druh = "Pes",
                Vek = 4,
                Pohlavi = "Samec",
                DatumPrijmu = DateTime.Now.AddMonths(-2),
                ZdravotniStav = "Zdravý"
            });
        }

        public void PridatZvire(Zvire zvire)
        {
            zvire.Id = nextId++;
            zvirata.Add(zvire);
        }

        public List<Zvire> VratVsechna()
        {
            return zvirata;
        }

        public List<Zvire> Filtrovat(string druh, string jmeno, int? vekOd, int? vekDo)
        {
            return zvirata.Where(z =>
                (string.IsNullOrEmpty(druh) || z.Druh.Equals(druh, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(jmeno) || z.Jmeno.ToLower().Contains(jmeno.ToLower())) &&
                (!vekOd.HasValue || z.Vek >= vekOd) &&
                (!vekDo.HasValue || z.Vek <= vekDo)
            ).ToList();
        }

        public bool OznacitAdopci(int id)
        {
            var zvire = zvirata.FirstOrDefault(z => z.Id == id);
            if (zvire == null || zvire.Adoptovano) return false;

            zvire.Adoptovano = true;
            zvire.DatumAdopce = DateTime.Now;
            return true;
        }

        public int PocetAdoptovanych()
        {
            return zvirata.Count(z => z.Adoptovano);
        }

        public double PrumernyVek()
        {
            return zvirata.Any() ? zvirata.Average(z => z.Vek) : 0;
        }
    }
}
