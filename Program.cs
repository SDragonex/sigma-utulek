using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace utulek_konzola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpravceZvirat spravce = new SpravceZvirat();
            bool konec = false;

            while (!konec)
            {
                Console.Clear();
                Console.WriteLine("===== ÚTULEK PRO ZVÍŘATA =====");
                Console.WriteLine("1 - Přidat zvíře");
                Console.WriteLine("2 - Vypsat všechna zvířata");
                Console.WriteLine("3 - Vyhledat / filtrovat");
                Console.WriteLine("4 - Označit adopci");
                Console.WriteLine("0 - Konec");
                Console.Write("Volba: ");

                string volba = Console.ReadLine();

                if (volba == "1") PridatZvire(spravce);
                else if (volba == "2") Vypsat(spravce.VratVsechnaZvirata());
                else if (volba == "3") Filtrovat(spravce);
                else if (volba == "4") Adopce(spravce);
                else if (volba == "0") konec = true;

                Console.WriteLine("\nStiskni klávesu...");
                Console.ReadKey();
            }
        }

        static void PridatZvire(SpravceZvirat spravce)
        {
            Console.Write("Jméno: ");
            string jmeno = Console.ReadLine();

            Console.Write("Druh (pes/kočka/jiné): ");
            string druh = Console.ReadLine();

            int vek;
            do
            {
                Console.Write("Věk (≥ 0): ");
            }
            while (!int.TryParse(Console.ReadLine(), out vek) || vek < 0);

            Console.Write("Pohlaví: ");
            string pohlavi = Console.ReadLine();

            Console.Write("Zdravotní stav (nepovinné): ");
            string zdrav = Console.ReadLine();

            Console.Write("Poznámka (nepovinné): ");
            string poznamka = Console.ReadLine();

            spravce.PridatZvire(jmeno, druh, vek, pohlavi, zdrav, poznamka);
        }

        static void Vypsat(List<Zvire> zvirata)
        {
            Console.WriteLine("ID | Jméno | Druh | Věk | Datum příjmu | Adoptováno | Datum adopce");
            Console.WriteLine("----------------------------------------------------------------");

            for (int i = 0; i < zvirata.Count; i++)
            {
                Zvire z = zvirata[i];

                string datumAdopce = "-";
                if (z.DatumAdopce.HasValue)
                    datumAdopce = z.DatumAdopce.Value.ToShortDateString();

                Console.WriteLine(
                    z.Id + " | " +
                    z.Jmeno + " | " +
                    z.Druh + " | " +
                    z.Vek + " | " +
                    z.DatumPrijmu.ToShortDateString() + " | " +
                    (z.Adoptovano ? "ANO" : "NE") + " | " +
                    datumAdopce
                );
            }
        }

        static void Filtrovat(SpravceZvirat spravce)
        {
            Console.Write("Druh (Enter = vše): ");
            string druh = Console.ReadLine();

            Console.Write("Věk od (Enter = bez omezení): ");
            int.TryParse(Console.ReadLine(), out int od);
            if (od == 0) od = -1;

            Console.Write("Věk do (Enter = bez omezení): ");
            int.TryParse(Console.ReadLine(), out int doVeku);
            if (doVeku == 0) doVeku = -1;

            Console.Write("Jméno (Enter = vše): ");
            string jmeno = Console.ReadLine();

            Vypsat(spravce.Filtrovat(druh, od, doVeku, jmeno));
        }

        static void Adopce(SpravceZvirat spravce)
        {
            Console.Write("Zadej ID zvířete: ");
            int id;
            if (int.TryParse(Console.ReadLine(), out id))
            {
                spravce.OznacAdopci(id);
            }
        }
    }
}
