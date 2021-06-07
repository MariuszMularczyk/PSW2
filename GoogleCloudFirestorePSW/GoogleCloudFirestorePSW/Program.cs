using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoogleCloudFirestorePSW
{
    class Program
    {
        async static Task Main(string[] args)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"pswtest-315321-fc4544adde8e.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
            string project = "pswtest-315321";
            FirestoreDb db = FirestoreDb.Create(project);
            Console.WriteLine("Created Cloud Firestore client with project ID: {0}", project);
            CollectionReference collection = db.Collection("detainees");

            int quit = 0;
            while (quit == 0)
            {

                Console.WriteLine("wybierz akcje");
                Console.WriteLine("-------------------------");
                Console.WriteLine("1 - Wyswietl wszystko");
                Console.WriteLine("2 - Wyswietl liczbe zatrzymanych");
                Console.WriteLine("3 - Dodaj");
                Console.WriteLine("4 - edytuj");
                Console.WriteLine("5 - usun");
                Console.WriteLine("6 - wyświetl powód zatrzymania");
                Console.WriteLine("7 - Quit");


                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":

                        Console.WriteLine("wszyscy: ");

                        QuerySnapshot querySnapshot = await collection.GetSnapshotAsync();
                        foreach (DocumentSnapshot queryResult in querySnapshot.Documents)
                        {

                            string firstName3 = queryResult.GetValue<string>("FirstName");
                            string lastName3 = queryResult.GetValue<string>("LastName");
                            string reasonForTheDetention123 = queryResult.GetValue<string>("ReasonForTheDetention");
                            Console.WriteLine($"{queryResult.Id} => {firstName3} {lastName3}, powód zatrzymania {reasonForTheDetention123}");
                        }
                        break;
                    case "2":
                        QuerySnapshot querySnapshot123 = await collection.GetSnapshotAsync();
                        Console.WriteLine($"liczba zatrzymanych {querySnapshot123.Documents.Count}");

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
                        await collection.AddAsync(detainee1);

                        break;
                    case "4":
                        Console.WriteLine("wpisz id do edycji");
                        string idToEdit = Console.ReadLine();

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
                                    await collection.Document(idToEdit).UpdateAsync("FirstName", name2);
                                    endEdit = 1;
                                    break;
                                case "2":
                                    Console.WriteLine("podaj nowe nazwisko");
                                    string name3 = Console.ReadLine();
                                    await collection.Document(idToEdit).UpdateAsync("LastName", name3);
                                    endEdit = 1;
                                    break;
                                case "3":
                                    Console.WriteLine("podaj nowy powód zatrzymania");
                                    string reasonForTheDetention2 = Console.ReadLine();
                                    await collection.Document(idToEdit).UpdateAsync("ReasonForTheDetention", reasonForTheDetention2); ;
                                    endEdit = 1;
                                    break;
                                case "4":
                                    endEdit = 1;
                                    break;
                                default:
                                    Console.WriteLine("zły numer");
                                    break;
                            }

                        }

                        break;
                    case "5":

                        Console.WriteLine("wpisz id do usuniecia");
                        string docToDelete = Console.ReadLine();
                        await collection.Document(docToDelete).DeleteAsync();

                        break;
                    case "6":
                        Console.WriteLine("podaj  imie");
                        string name29 = Console.ReadLine();
                        Console.WriteLine("podaj  nazwisko");
                        string name39 = Console.ReadLine();
                        Query query = collection.WhereEqualTo("FirstName", name29).WhereEqualTo("LastName", name39);
                        QuerySnapshot querySnapshot33 = await query.GetSnapshotAsync();
                        foreach (DocumentSnapshot documentSnapshot in querySnapshot33.Documents)
                        {
                            string firstName3 = documentSnapshot.GetValue<string>("FirstName");
                            string lastName3 = documentSnapshot.GetValue<string>("LastName");
                            string reasonForTheDetention123 = documentSnapshot.GetValue<string>("ReasonForTheDetention");
                            Console.WriteLine($"{documentSnapshot.Id} => {firstName3} {lastName3}, powód zatrzymania {reasonForTheDetention123}");
                        }
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
