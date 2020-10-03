using System;
using System.Collections.Generic;
using System.Text;

namespace RejestrOsobowy
{
    class ListaOsob
    {

        public static List<Osoba> lista = new List<Osoba>();

       
        public void dodaj()
        {
            lista.Add(new Osoba("Bugi", "Sylwia", 'k'));
            lista.Add(new Osoba("Kulka", "Sasha", 'm'));
            lista.Add(new Osoba("Kurasz", "Mikołaj", 'm'));
            lista.Add(new Osoba("Swoboda", "Izabela", 'k'));
            lista.Add(new Osoba("Baniak", "Alexy", 'm'));
            lista.Add(new Osoba("Maniacki", "Bartek", 'm'));
        }
    }
}
