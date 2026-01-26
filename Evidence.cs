using System;
using System.Collections.Generic;
using System.Linq;

namespace sigmautulek
{
    public class Evidence
    {
        private List<Zvire> zvirata = new List<Zvire>();
        private int dalsiId = 1;

        public Evidence()
        {
            // testovací data
            PridatZvire(new Zvire
            {
                Jmeno = "Rex",
                Druh = "Pes",
                Vek = 5,
                Pohlavi = "Samec",
                DatumPrijmu = DateTime.Today
            });

            PridatZvire(new Zvire
            {
                Jmeno = "Micka",
                Druh = "Kočka",
                Vek = 3,
                Pohlavi = "Samice",
                DatumPrijmu = DateTime.Today
            });
        }

        public void PridatZvire(Zvire zvire)
        {
            zvire.Id = dalsiId++;
            zvirata.Add(zvire);
        }

        public List<Zvire> ZiskatVse()
        {
            return zvirata;
        }

        public Zvire NajdiPodleId(int id)
        {
            return zvirata.FirstOrDefault(z => z.Id == id);
        }

        public List<Zvire> Filtrovat(string druh, int? vekOd, int? vekDo, string jmeno)
        {
            return zvirata.Where(z =>
                (string.IsNullOrEmpty(druh) || z.Druh.ToLower().Contains(druh.ToLower())) &&
                (!vekOd.HasValue || z.Vek >= vekOd.Value) &&
                (!vekDo.HasValue || z.Vek <= vekDo.Value) &&
                (string.IsNullOrEmpty(jmeno) || z.Jmeno.ToLower().Contains(jmeno.ToLower()))
            ).ToList();
        }

        public bool OznacitAdopci(int id)
        {
            Zvire zvire = NajdiPodleId(id);
            if (zvire == null || zvire.Adoptovano)
                return false;

            zvire.Adoptovano = true;
            zvire.DatumAdopce = DateTime.Today;
            return true;
        }

        public int PocetAdoptovanych()
        {
            return zvirata.Count(z => z.Adoptovano);
        }

        public double PrumernyVek()
        {
            return zvirata.Count == 0 ? 0 : zvirata.Average(z => z.Vek);
        }
    }
}
