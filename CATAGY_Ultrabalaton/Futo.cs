using System;

namespace CATAGY_Ultrabalaton
{
    class Futo
    {
        public string Nev { get; set; }
        public int Rajtszam { get; set; }
        public bool Kategoria { get; set; }
        public TimeSpan Ido { get; set; }
        public int TavSzazalek { get; set; }

        public double IdoOraban => Ido.TotalHours;

        public Futo(string sor)
        {
            var buffer = sor.Split(';');
            Nev = buffer[0];
            Rajtszam = int.Parse(buffer[1]);
            Kategoria = buffer[2] == "Ferfi";
            var ido = buffer[3].Split(':');
            Ido = new TimeSpan(
                hours: int.Parse(ido[0]),
                minutes: int.Parse(ido[1]),
                seconds: int.Parse(ido[2]));
            TavSzazalek = int.Parse(buffer[4]);

        }
    }
}
