using System;

namespace Zadanie_Z_Zajęć
{
    enum KlasaRzadkosci
    {
        Powrzechny,
        Rzadki,
        Unikalny,
        Epicki
    }
    enum TypPrzedmiotu
    {
        Bron,
        Zbroja,
        Amulet,
        Pierscien,
        Helm,
        Tarcza,
        Buty
    }
    struct Przedmiot
    {
        public float Waga;
        public int Wartosc;
        public string Nazwa;
        public KlasaRzadkosci Rzadkosc;
        public TypPrzedmiotu Typ;
    }
    class Program
    {
        static void Wypelnij(ref Przedmiot PrzedmiotDoWypelnienia, float Waga, int Wartosc, string Nazwa, KlasaRzadkosci Rzadkosc, TypPrzedmiotu Typ)
        {
            if (Waga > 0)
            {
                PrzedmiotDoWypelnienia.Waga = Waga;
            }
            else
            {
                PrzedmiotDoWypelnienia.Waga = 0;
            }

            if (Wartosc > 0)
            {
                PrzedmiotDoWypelnienia.Wartosc = Wartosc;
            }
            else
            {
                PrzedmiotDoWypelnienia.Wartosc = 0;
            }

            PrzedmiotDoWypelnienia.Nazwa = Nazwa;
            PrzedmiotDoWypelnienia.Rzadkosc = Rzadkosc;
            PrzedmiotDoWypelnienia.Typ = Typ;

        }
        static void Wyswietl(Przedmiot Przedmiot)
        {
            Console.WriteLine($"Przedmiot: {Przedmiot.Nazwa}");
            Console.WriteLine($"Wartosc: {Przedmiot.Wartosc}");
            Console.WriteLine();
        }
        static Przedmiot LosujPrzedmiot(Przedmiot[] Skrzynka)
        {
            Random random = new Random();

            Array.Sort(Skrzynka, PorownajPrzedmioty);

            int SumaRzadkosci = 0;
            foreach (Przedmiot przedmiot in Skrzynka)
            {
                SumaRzadkosci += (int)przedmiot.Rzadkosc;
            }

            int LosowanaRzadkosc = random.Next(1, SumaRzadkosci + 1);
            int AktualnaSuma = 0;

            foreach (var przedmiot in Skrzynka)
            {
                AktualnaSuma += (int)przedmiot.Rzadkosc;
                if (AktualnaSuma >= LosowanaRzadkosc)
                {
                    return przedmiot;
                }
            }
            return Skrzynka[0];
        }
        static int PorownajPrzedmioty(Przedmiot p1, Przedmiot p2)
        {
            if (p1.Rzadkosc < p2.Rzadkosc)
                return -1;
            else if (p1.Rzadkosc == p2.Rzadkosc)
                return 0;
            else
                return 1;
        }
        static void Main(string[] args)
        {
            Przedmiot[] przedmioty = new Przedmiot[4];

            Wypelnij(ref przedmioty[0], 0.5f, 3, "Poręczna patelnia", KlasaRzadkosci.Powrzechny, TypPrzedmiotu.Bron);
            Wypelnij(ref przedmioty[1], 1.5f, 2136, "Szybkochody", KlasaRzadkosci.Rzadki, TypPrzedmiotu.Buty);
            Wypelnij(ref przedmioty[2], 2.5f, 4209, "Naszyjnik tajnej mocy", KlasaRzadkosci.Rzadki, TypPrzedmiotu.Amulet);
            Wypelnij(ref przedmioty[3], 3.5f, 21150, "Zbroja wuja Aligatora", KlasaRzadkosci.Unikalny, TypPrzedmiotu.Zbroja);
            Wypelnij(ref przedmioty[4], 4.5f, 500000, "Super fajny epicki niesamowity miecz pro plus 5G+", KlasaRzadkosci.Epicki, TypPrzedmiotu.Bron);

            Przedmiot wylosowany = LosujPrzedmiot(przedmioty);

            Wyswietl(wylosowany);
        }
    }
}
