using System;
using System.Collections.Generic;
using System.Text;

namespace RejestrOsobowy
{
    class Osoba
    {
       
        public string Nazwisko { get; set; }
        public string Imie { get; set; }

        public char Plec { get; set; }


        public Osoba(string nazwisko, string imie, char plec)
        {
            Nazwisko = nazwisko;
            Imie = imie;
            Plec = plec;
        }
    }
}
