using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utulek_konzola
{
    internal class SpravceZvirat
    {
        private List<Zvire> zvirata = new List<Zvire>();
        private int dalsiId = 1;

        public void PridatZvire(string jmeno, string druh, int vek, string pohlavi, string zdravotniStav, string poznamka)
        {
            Zvire z = new Zvire();
            z.Id = dalsiId++;
            z.Jmeno = jmeno;
            z.Druh = druh;
            z.Vek = vek;
            z.Pohlavi = pohlavi;
            z.ZdravotniStav = zdravotniStav;
            z.Poznamka = poznamka;
            z.DatumPrijmu = DateTime.Now;
            z.Adoptovano = false;
            z.DatumAdopce = null;

            zvirata.Add(z);
        }

        public List<Zvire> VratVsechnaZvirata()
        {
            return zvirata;
        }

        public void OznacAdopci(int id)
        {
            for (int i = 0; i < zvirata.Count; i++)
            {
                if (zvirata[i].Id == id && !zvirata[i].Adoptovano)
                {
                    zvirata[i].Adoptovano = true;
                    zvirata[i].DatumAdopce = DateTime.Now;
                }
            }
        }

        public List<Zvire> Filtrovat(string druh, int vekOd, int vekDo, string jmeno)
        {
            List<Zvire> vysledek = new List<Zvire>();

            for (int i = 0; i < zvirata.Count; i++)
            {
                Zvire z = zvirata[i];
                bool vyhovuje = true;

                if (druh != "" && z.Druh != druh)
                    vyhovuje = false;

                if (vekOd != -1 && z.Vek < vekOd)
                    vyhovuje = false;

                if (vekDo != -1 && z.Vek > vekDo)
                    vyhovuje = false;

                if (jmeno != "" && !z.Jmeno.ToLower().Contains(jmeno.ToLower()))
                    vyhovuje = false;

                if (vyhovuje)
                    vysledek.Add(z);
            }

            return vysledek;
        }
    }
}
