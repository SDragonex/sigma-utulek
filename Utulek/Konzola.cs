using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utulek
{
    internal class Konzola
    {
        private Evidence evidence;

        public Konzola(Evidence evidence)
        {
            this.evidence = evidence;
        }

        public void Spustit()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== ÚTULEK PRO ZVÍŘATA =====");
                Console.WriteLine("1) Přidat zvíře");
                Console.WriteLine("2) Vypsat všechna zvířata");
                Console.WriteLine("3) Vyhledat / filtrovat");
                Console.WriteLine("4) Označit adopci");
                Console.WriteLine("5) Statistiky");
                Console.WriteLine("0) Konec");
                Console.Write("Volba: ");

                switch (Console.ReadLine())
                {
                    case "1": PridatZvire(); break;
                    case "2": Vypsat(); break;
                    case "3": Filtrovat(); break;
                    case "4": Adopce(); break;
                    case "5": Statistiky(); break;
                    case "0": return;
                }
            }
        }

        private void PridatZvire()
        {
            Console.Write("Jméno: ");
            string jmeno = Console.ReadLine();

            Console.Write("Druh: ");
            string druh = Console.ReadLine();

            Console.Write("Věk: ");
            int vek;
            while (!int.TryParse(Console.ReadLine(), out vek) || vek < 0)
                Console.Write("Zadej platný věk: ");

            evidence.PridatZvire(new Zvire
            {
                Jmeno = jmeno,
                Druh = druh,
                Vek = vek,
                DatumPrijmu = DateTime.Now
            });
        }

        private void Vypsat()
        {
            Console.WriteLine("ID | Jméno | Druh | Věk | Adoptováno");
            foreach (var z in evidence.VratVsechna())
            {
                Console.WriteLine($"{z.Id} | {z.Jmeno} | {z.Druh} | {z.Vek} | {(z.Adoptovano ? "ANO" : "NE")}");
            }
            Console.ReadKey();
        }

        private void Filtrovat()
        {
            Console.Write("Druh (nebo Enter): ");
            string druh = Console.ReadLine();

            var vysledek = evidence.Filtrovat(druh, null, null, null);
            foreach (var z in vysledek)
                Console.WriteLine($"{z.Id} | {z.Jmeno} | {z.Druh} | {z.Vek}");

            Console.ReadKey();
        }

        private void Adopce()
        {
            Console.Write("ID zvířete: ");
            int id = int.Parse(Console.ReadLine());

            if (evidence.OznacitAdopci(id))
                Console.WriteLine("Adopce označena.");
            else
                Console.WriteLine("Nelze provést adopci.");

            Console.ReadKey();
        }

        private void Statistiky()
        {
            Console.WriteLine($"Adoptovaných: {evidence.PocetAdoptovanych()}");
            Console.WriteLine($"Průměrný věk: {evidence.PrumernyVek():0.0}");
            Console.ReadKey();
        }
    }
}
