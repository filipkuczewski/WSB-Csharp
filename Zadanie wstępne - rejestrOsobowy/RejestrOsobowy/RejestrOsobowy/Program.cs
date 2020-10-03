using System;
using System.Collections.Generic;

namespace RejestrOsobowy
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            for (; ; )
            {

                Menu menu = new Menu();
                //Tworzenie Bazy osob w rejestrze:
                if (x == 0)
                {
                    ListaOsob ls = new ListaOsob();
                    ls.dodaj();
                    x = 1;
                }
                //Koniec tworzenia bazy

                menu.Wybor();
                menu.DopasujDoMetod();
            
                Console.ReadKey();
                Console.Clear();

            }
        }
    }
}
