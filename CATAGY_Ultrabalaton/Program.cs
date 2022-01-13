using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CATAGY_Ultrabalaton
{
    internal class Program
    {
        static List<Futo> futok = new List<Futo>();

        static void Main(string[] args)
        {
            Beolvasas();
            F03();
            F04();
            F05();
            F07();
            F08();

        }

        private static void F08()
        {
            var gyoztesNo = futok.Where(x => !x.Kategoria && x.TavSzazalek == 100).OrderBy(y => y.IdoOraban).First();
            var gyoztesFerfi = futok.Where(x => x.Kategoria && x.TavSzazalek == 100).OrderBy(y => y.IdoOraban).First();

            Console.WriteLine("8. Feladat: Verseny győztesei");
            Console.WriteLine($"\tNők: {gyoztesNo.Nev} ({gyoztesNo.Rajtszam}) - {gyoztesNo.Ido}");
            Console.WriteLine($"\tFérfiak: {gyoztesFerfi.Nev} ({gyoztesFerfi.Rajtszam}) - {gyoztesFerfi.Ido}");
        }

        private static void F07()
        {
            var tttf = futok.Where(x => x.Kategoria && x.TavSzazalek == 100).Average(y => y.IdoOraban);
            Console.WriteLine($"7. Feladat: Átlagos idő: {tttf} óra");
        }

        private static void F05()
        {
            Console.Write("5. Feladat: Kérem a sportoló nevét: ");
            var megadottnev = Console.ReadLine();
            var indultE = futok.Where(x => x.Nev == megadottnev).FirstOrDefault();
            bool indult = !(indultE is null);
            Console.WriteLine($"\tIndult egyéniben a sportoló? {(indult ? "Igen" : "Nem")}");
            if (indult)
            {
                Console.WriteLine($"\tTeljesítette a teljes távot? {(indultE.TavSzazalek == 100 ? "Igen" : "Nem")}");
            }
        }

        private static void F04()
        {
            var teljesTavotTeljesitoNoiSportolok = futok.Where(x => !x.Kategoria && x.TavSzazalek == 100).Count();
            Console.WriteLine($"4. Feladat: Célba érkező női sportolók: {teljesTavotTeljesitoNoiSportolok} fő");
        }

        private static void F03()
        {
            var egyeniSportolokSzama = futok.Count;
            Console.WriteLine($"3. Egyéni indulók: {egyeniSportolokSzama} fő");
        }

        private static void Beolvasas()
        {
            using (var sr = new StreamReader(@"..\..\RES\ub2017egyeni.txt", Encoding.UTF8))
            {
                var fejlec = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    futok.Add(new Futo(sr.ReadLine()));
                }
            }

        }
    }
}
