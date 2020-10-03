using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RejestrOsobowy
{
    class Menu : IWybor
    {
        private byte wybor;
        private List<bool> listaPomocniczaTrueFalse = new List<bool>();
        private Regex wyrazenie;
        public Menu()
        {
            WyswietlMenu();
        }

        private void WyswietlMenu()
        {
            Console.WriteLine("Witaj użytkowniku!\n" +
                "Wybierz z listy poniżej co chcesz zrobić:\n\n" +
                "1) Wyświetlić wszystkie osoby w rejestrze;\n" +
                "2) Dodać nową osobę do rejestru;\n" +
                "3) Zmodyfikować osobę zapisaną w rejestrze;\n" +
                "4) Usunąć osobę z rejestru;\n" +
                "5) Wyszukać osobę w rejestrze;\n" +
                "0) Wyjść z programu;" +
                "\n" +
                "Twój wybór: ");
        }

        public void fiveSearchPerson()
        {
            Console.WriteLine("Pięć");
            Console.WriteLine("Podaj litery, które kojarzysz, że mają być w imieniu: ");
            string t = Console.ReadLine();

            //--------------
            Console.WriteLine("Chcesz zignorować wielkość liter? (Jeśli tak: t, jeśli nie:dowolna litera)");
            char upperOrLowerCase = Char.Parse(Console.ReadLine());
            if (upperOrLowerCase == 't')
            {
                wyrazenie = new Regex(t, RegexOptions.IgnoreCase);
            }
            else
            {
                wyrazenie = new Regex(t);
            }

            //----------------

            Console.WriteLine("Wszystkie imiona, w którym występuje / {0} / to:\n", t);
            
            WypelnijListeOsobKtorePasujaDoWzorcaBool();
            WypiszOsobyPasujaceDoWzorca();

        }

        private void WypiszOsobyPasujaceDoWzorca()
        {
            for (int i = 0; i < listaPomocniczaTrueFalse.Count; i++)
            {
                if (listaPomocniczaTrueFalse[i])
                {
                    Console.WriteLine(ListaOsob.lista[i].Imie);
                }
            }
        }

        private void WypelnijListeOsobKtorePasujaDoWzorcaBool()
        {
            
            for (int i = 0; i < ListaOsob.lista.Count; i++)
            {
                listaPomocniczaTrueFalse.Add(wyrazenie.IsMatch(ListaOsob.lista[i].Imie));
            }
        }

        public void fourRemovePerson()
        {
            Console.WriteLine("Cztery\n" +
                "Podaj którego użytkownika chcesz usunąć: ");
            byte x = Byte.Parse(Console.ReadLine());
            ListaOsob.lista.RemoveAt(x+1);
        }

        public void oneGetAllPersons()
        {
            Console.Clear();
            Console.WriteLine("Jeden\nWszystkie osoby w rejestrze to:\n");
            int i=0;
            foreach(var x in ListaOsob.lista)
            {
                i++;
                Console.WriteLine(i + ". "+ x.Imie + ", "+ x.Nazwisko);
            }
        }

        public void threeModifiedPerson()
        {
            byte t;
            Console.WriteLine("Trzy");
            Console.WriteLine("Wybierz którą osobę chcesz zmodyfikować(od 1 w górę)");
            t = Byte.Parse(Console.ReadLine());
            
            Console.WriteLine("OK!\nPodaj nazwisko: ");
            string x = Console.ReadLine();
            Console.WriteLine("Podaj imię: ");
            string y = Console.ReadLine();
            Console.WriteLine("Podaj płeć: ");
            char z = Char.Parse(Console.ReadLine());
            ListaOsob.lista[t-1] = new Osoba(x,y,z);

            Console.WriteLine("Osoba zmodyfikowana!");

        }

        public void twoAddNewPerson()
        {
            Console.WriteLine("Dwa");
            try
            {
                Console.WriteLine("Podaj nazwisko: ");
                string x = Console.ReadLine();
                Console.WriteLine("Podaj imię: ");
                string y = Console.ReadLine();
                Console.WriteLine("Podaj płeć(k/m): ");
                char z = Char.Parse(Console.ReadLine());
                ListaOsob.lista.Add(new Osoba(x, y, z));
                Console.WriteLine("Osoba dodana!");
            }
            catch
            {
                Console.WriteLine("Podałeś niewłaściwe dane..");
            }
        }

        public void DopasujDoMetod()
        {
            switch (wybor)
            {
                case 0: zeroExitFromProgram();
                    break;
                case 1:
                    oneGetAllPersons();
                    break;
                case 2:
                    twoAddNewPerson();
                    break;
                case 3:
                    threeModifiedPerson();
                    break;
                case 4:
                    fourRemovePerson();
                    break;
                case 5:
                    fiveSearchPerson();
                    break;
                default: break;
            }
        }
        public void Wybor()
        {
            try
            {
                wybor = Byte.Parse(Console.ReadLine());
                Console.WriteLine("Przyjąłem! Twój wybór to:" + wybor);
            } catch(Exception e) {
                Console.WriteLine("Wpisz cyfrę...");
                Console.ReadKey();
                Console.Clear();
                WyswietlMenu();
                Wybor();
            }
        }

        public void zeroExitFromProgram()
        {
            Environment.Exit(0);
        }
    }
}