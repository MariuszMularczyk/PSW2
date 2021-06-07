using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MongoDBPSW
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient(@"mongodb://localhost:27017");
            var database = client.GetDatabase("MongoDBPSW");
            IMongoCollection<Detainee>  datetainees = database.GetCollection<Detainee>("Detainees");
            int quit = 0;
            while (quit == 0)
            {

                Console.WriteLine("wybierz akcje");
                Console.WriteLine("-------------------------");
                Console.WriteLine("1 - Wyswietl wszystko");
                Console.WriteLine("2 - pokaż zatrzymanego");
                Console.WriteLine("3 - Dodaj");
                Console.WriteLine("4 - edytuj");
                Console.WriteLine("5 - usun");
                Console.WriteLine("6 - liczba zatrzymanych");
                Console.WriteLine("7 - Quit");


                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":

                        Console.WriteLine("wszyscy: ");
                        List<Detainee> datetainees1 = datetainees.Find(x => true).ToList();
                        foreach (var datetainee in datetainees1)
                        {
                            Console.WriteLine(datetainee.ToString());
                        }
                        break;
                    case "2":
                        Console.WriteLine("podaj  imie");
                        string name6 = Console.ReadLine();
                        Console.WriteLine("podaj  nazwisko");
                        string name5 = Console.ReadLine();
                        Detainee objectToDisplay = datetainees.Find(x => x.FirstName.Equals(name6) && x.LastName.Equals(name5)).FirstOrDefault();
                        if (objectToDisplay == null)
                        {
                            Console.WriteLine("Nie znaleziono zatrzymanego");

                        }
                        else
                        {
                            Console.WriteLine(objectToDisplay.ToString());
                        }
                        break;
                    case "3":
                        Console.WriteLine("podaj imie ");
                        string name = Console.ReadLine();
                        Console.WriteLine("podaj nazwisko");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("podaj powód zatrzymania");
                        string reasonForTheDetention = Console.ReadLine();

                        Detainee detainee1 = new Detainee()
                        {
                            FirstName = name,
                            LastName = lastName,
                            ReasonForTheDetention = reasonForTheDetention
                        };
                        datetainees.InsertOne(detainee1);

                        break;
                    case "4":
                        Console.WriteLine("wpisz id do edycji");
                        string idToEdit = Console.ReadLine();
                        Detainee objectToEdit = datetainees.Find(x => x.Id.Equals(idToEdit)).FirstOrDefault();
                        if (objectToEdit == null)
                        {
                            Console.WriteLine("Nie znaleziono zatrzymanego o podanym ID");
                            
                        }
                        else
                        {
                            int endEdit = 0;
                            while (endEdit == 0)
                            {

                                Console.WriteLine("co chcesz edytować");
                                Console.WriteLine("-------------------------");
                                Console.WriteLine("1 - imie");
                                Console.WriteLine("2 - nazwisko");
                                Console.WriteLine("3 - powód zatrzymania");
                                Console.WriteLine("4 - zakończ edycje");

                                string choice2 = Console.ReadLine();

                                switch (choice2)
                                {
                                    case "1":

                                        Console.WriteLine("podaj nowe imie");
                                        string name2 = Console.ReadLine();
                                        objectToEdit.FirstName = name2;
                                        break;
                                    case "2":
                                        Console.WriteLine("podaj nowe nazwisko");
                                        string name3 = Console.ReadLine();
                                        objectToEdit.LastName = name3;
                                        break;
                                    case "3":
                                        Console.WriteLine("podaj nowy powód zatrzymania");
                                        string reasonForTheDetention2 = Console.ReadLine();
                                        objectToEdit.ReasonForTheDetention = reasonForTheDetention2;
                                        break;
                                    case "4":
                                        endEdit = 1;
                                        break;
                                    default:
                                        Console.WriteLine("zły numer");
                                        break;
                                }

                            }

                            datetainees.ReplaceOne(x => x.Id.Equals(objectToEdit.Id), objectToEdit);
                        }

                        break;
                    case "5":

                        Console.WriteLine("Podaj id zatrzymanego do usunięcia");
                        string id = Console.ReadLine();
                        Detainee datetaine = datetainees.Find(x => x.Id.Equals(id)).FirstOrDefault();
                        if (datetaine == null)
                        {
                            Console.WriteLine("Nie znaleziono zatrzymanego o podanym id");
                           
                        }
                        else
                        {
                            datetainees.DeleteOne(x => x.Id.Equals(id));
                        }
                        break;
                    case "6":
                        Console.WriteLine("liczba zatrzymanych {0}", datetainees.Count(x => true));
                        break;
                    case "7":
                        quit = 1;
                        Console.WriteLine("Wyjscie");
                        break;
                    default:
                        Console.WriteLine("zły numer");
                        break;
                }
            }
            
        }
    }
}
