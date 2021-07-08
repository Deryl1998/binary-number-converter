using System;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    class Program
    {

        public class Liczba_binarna
        {
            private byte[] tablica;
            public void wpisz_liczbe()
            {
                string pattern = @"^[0-1]*$";
                Regex regex = new Regex(pattern);
                string text;
                do
                {
                    Console.Write("Wpisz ciag binarny : ");
                    text = Console.ReadLine();
                } while (regex.IsMatch(text) == false);

                tablica = new byte[text.Length];
                int liczba;
                for (int i = 0; i < text.Length; i++)
                {   // Wpisuje do tablicy bity z ciagu
                    liczba = int.Parse(text[i].ToString());
                    tablica[i] = Convert.ToByte(liczba);
                }
            }

            public int na_dziesietny()
            {
                int a = 1;
                int wynik = 0;
                for (int i = tablica.Length - 1; i >= 0; i--)
                {
                    if (tablica[i] == 1) wynik += a;
                    a *= 2;
                }
                return wynik;
            }

            public string na_osemkowy()
            {
                int a = 1, licz_a = 0, j = 1;
                string wynik = null;
                for (int i = tablica.Length - 1; i >= 0; i--, j++)
                {
                    if (tablica[i] == 1) licz_a += a;
                    a *= 2;

                    if (i == 0 || j % 3 == 0)
                    {

                        wynik = licz_a.ToString() + wynik;
                        a = 1;
                        licz_a = 0;
                    }
                }
                return wynik;
            }

            enum szesnastkowy { A = 10, B = 11, C = 12, D = 13, E = 14, F = 15 }
            public string na_szesnastkowy()
            {
                int a = 1, licz_a = 0, j = 1;
                string wynik = null;
                szesnastkowy wyliczeniowy = 0;
                for (int i = tablica.Length - 1; i >= 0; i--, j++)
                {
                    if (tablica[i] == 1) licz_a += a;
                    a *= 2;

                    if (i == 0 || j % 4 == 0)
                    {
                        wyliczeniowy = (szesnastkowy)licz_a; // konwertuje liczbe a na enum
                        switch (wyliczeniowy)
                        {
                            case szesnastkowy.A: wynik = szesnastkowy.A + wynik; break;
                            case szesnastkowy.B: wynik = szesnastkowy.B + wynik; break;
                            case szesnastkowy.C: wynik = szesnastkowy.C + wynik; break;
                            case szesnastkowy.D: wynik = szesnastkowy.D + wynik; break;
                            case szesnastkowy.E: wynik = szesnastkowy.E + wynik; break;
                            case szesnastkowy.F: wynik = szesnastkowy.F + wynik; break;
                            default: wynik = licz_a.ToString() + wynik; break;
                        }
                        a = 1;
                        licz_a = 0;
                    }
                }
                return wynik;
            }
          

            public string na_piatkowy()
            {
                int liczba = this.na_dziesietny();
                string wynik = null;
                while (liczba>0)
                {
                    wynik =(liczba % 5).ToString()+wynik;
                    liczba=liczba/5;
                }
                return wynik;
            }

        }

        static void Main(string[] args)
        {
            string wybor = null;
            Liczba_binarna liczba = new Liczba_binarna();
            liczba.wpisz_liczbe();
            Console.WriteLine("Wpisz 1 aby przekonwertowac na 10-tkowy : ");
            Console.WriteLine("Wpisz 2 aby przekonwertowac na 8-mkowy : ");
            Console.WriteLine("Wpisz 3 aby przekonwertowac na 16-stkowy : ");
            Console.WriteLine("Wpisz 4 aby przekonwertowac na 5-tkowy : ");
            Console.WriteLine("Wpisz 0 aby wyjsc : ");
            wybor = Console.ReadLine();
            switch (wybor)
                {
                    case "1": Console.WriteLine("w 10: " + liczba.na_dziesietny()); goto default;
                    case "2": Console.WriteLine("w 8: " + liczba.na_osemkowy()); goto default;
                    case "3": Console.WriteLine("w 16: " + liczba.na_szesnastkowy()); goto default;
                    case "4": Console.WriteLine("w 5: " + liczba.na_piatkowy()); goto default;
                    default: return; 
                }
            
        }
    }
}
