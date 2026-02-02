using System;

namespace sigmautulek
{
    public class KonzoleUI
    {
        private Evidence evidence;

        public KonzoleUI(Evidence evidence)
        {
            this.evidence = evidence;
        }

        public void Spust()
        {
            while (true)
            {
                Console.Clear();
                VypisMenu();

                string volba = Console.ReadLine();

                switch (volba)
                {
                    case "1":
                        PridatZvire();
                        break;
                    case "2":
                        VypisVse();
                        break;
                    case "3":
                        Filtrovat();
                        break;
                    case "4":
                        OznacitAdopci();
                        break;
                    case "5":
                        Statistiky();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Neplatná volba.");
                        break;
                }

                Console.WriteLine("\nStiskni libovolnou klávesu...");
                Console.ReadKey();
            }
        }

        private void VypisMenu()
        {
            Console.WriteLine("===== ÚTULEK PRO ZVÍŘATA =====");
            Console.WriteLine("1) Přidat zvíře");
            Console.WriteLine("2) Vypsat všechna zvířata");
            Console.WriteLine("3) Vyhledat / filtrovat");
            Console.WriteLine("4) Označit adopci");
            Console.WriteLine("5) Statistiky");
            Console.WriteLine("0) Konec");
            Console.Write("Volba: ");
        }

        private void PridatZvire()
        {
            Zvire z = new Zvire();

            Console.Write("Jméno: ");
            z.Jmeno = Console.ReadLine();

            Console.Write("Druh (pes/kočka/jiné): ");
            z.Druh = Console.ReadLine();

            z.Vek = NactiInt("Věk: ");

            Console.Write("Pohlaví: ");
            z.Pohlavi = Console.ReadLine();

            z.DatumPrijmu = DateTime.Today;

            Console.Write("Zdravotní stav (volitelné): ");
            z.ZdravotniStav = Console.ReadLine();

            Console.Write("Poznámka (volitelné): ");
            z.Poznamka = Console.ReadLine();

            evidence.PridatZvire(z);
            Console.WriteLine("Zvíře přidáno.");
        }

        private void VypisVse()
        {
            Console.WriteLine("ID  Jméno       Druh     Věk  Adopce");
            Console.WriteLine("-----------------------------------");
            foreach (Zvire z in evidence.ZiskatVse())
            {
                Console.WriteLine(z);
            }
        }

        private void Filtrovat()
        {
            Console.Write("Druh (nebo Enter): ");
            string druh = Console.ReadLine();

            Console.Write("Věk od (nebo Enter): ");
            int? od = NactiNullableInt();

            Console.Write("Věk do (nebo Enter): ");
            int? doVeku = NactiNullableInt();

            Console.Write("Jméno (nebo Enter): ");
            string jmeno = Console.ReadLine();

            var vysledek = evidence.Filtrovat(druh, od, doVeku, jmeno);

            foreach (Zvire z in vysledek)
            {
                Console.WriteLine(z);
            }
        }

        private void OznacitAdopci()
        {
            int id = NactiInt("Zadej ID zvířete: ");
            bool ok = evidence.OznacitAdopci(id);

            Console.WriteLine(ok
                ? "Adopce označena."
                : "Zvíře nenalezeno nebo už adoptováno.");
        }

        private void Statistiky()
        {
            Console.WriteLine($"Počet zvířat: {evidence.ZiskatVse().Count}");
            Console.WriteLine($"Počet adoptovaných: {evidence.PocetAdoptovanych()}");
            Console.WriteLine($"Průměrný věk: {evidence.PrumernyVek():0.0}");
        }

        private int NactiInt(string text)
        {
            int value;
            while (true)
            {
                Console.Write(text);
                if (int.TryParse(Console.ReadLine(), out value) && value >= 0)
                    return value;

                Console.WriteLine("Zadej číslo ≥ 0.");
            }
        }

        private int? NactiNullableInt()
        {
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                return null;

            if (int.TryParse(input, out int value))
                return value;

            return null;
        }
    }
}
