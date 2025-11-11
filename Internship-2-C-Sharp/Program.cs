namespace Internship_2_C_Sharp
{
    struct User
    {
        public int Id;
        public string Name;
        public string Surname;
        public DateOnly DateOfBirth;
        public List<Trip> Trips;

    }
    struct Trip
    {
        public int Id;
        public DateOnly DateOfTrip;
        public double Distance;
        public double FuelConsumed;
        public double CostOfFuelPerLiter;
        public double TotalCost;

    }

    internal class Program
    {



        static List<User> Users = new List<User>();
        static List<Trip> AllTrips = new List<Trip>();
        static void Main(string[] args)

        {
            AllTrips.Add(new Trip
            {
                Id = 1,
                DateOfTrip = new DateOnly(2022, 1, 15),
                Distance = 150.5,
                FuelConsumed = 10.2,
                CostOfFuelPerLiter = 12.5,
                TotalCost = 127.5
            });
            AllTrips.Add(new Trip
            {
                Id = 2,
                DateOfTrip = new DateOnly(2023, 2, 20),
                Distance = 200.0,
                FuelConsumed = 15.0,
                CostOfFuelPerLiter = 13.0,
                TotalCost = 195.0
            });
            AllTrips.Add(new Trip
            {
                Id = 3,
                DateOfTrip = new DateOnly(2023, 3, 10),
                Distance = 120.0,
                FuelConsumed = 8.5,
                CostOfFuelPerLiter = 12.0,
                TotalCost = 102.0
            });
            AllTrips.Add(new Trip
            {
                Id = 4,
                DateOfTrip = new DateOnly(2019, 4, 5),
                Distance = 180.0,
                FuelConsumed = 12.0,
                CostOfFuelPerLiter = 14.0,
                TotalCost = 168.0
            });
            AllTrips.Add(new Trip
            {
                Id = 5,
                DateOfTrip = new DateOnly(2023, 5, 18),
                Distance = 220.0,
                FuelConsumed = 16.5,
                CostOfFuelPerLiter = 13.5,
                TotalCost = 222.75
            });

            Users.Add(new User
            {
                Id = 1,
                Name = "Ivan",
                Surname = "Horvat",
                DateOfBirth = new DateOnly(1990, 5, 12),
                Trips = new List<Trip> { AllTrips[0], AllTrips[1] }
            });

            Users.Add(new User
            {
                Id = 2,
                Name = "Ana",
                Surname = "Kovač",
                DateOfBirth = new DateOnly(1985, 11, 3),
                Trips = new List<Trip> { AllTrips[2], AllTrips[3], AllTrips[4] }
            });

            Users.Add(new User
            {
                Id = 3,
                Name = "Marko",
                Surname = "Novak",
                DateOfBirth = new DateOnly(2000, 8, 21),
                Trips = new List<Trip> { AllTrips[1], AllTrips[3], AllTrips[4], AllTrips[0] }
            });
            

            ShowStartingMenu();


        }
        static void ShowStartingMenu()
        {
            Console.Clear();
            Console.WriteLine("APLIKACIJA ZA EVIDENCIJU GORIVA\n1 - Korisnici \n2 - Putovanja \n0 - Izlazak iz aplikacije\n");
            Console.Write("Odabir: ");

            if (int.TryParse(Console.ReadLine(), out int userChoice))
            {
                switch (userChoice)
                {
                    case 1:
                        ShowUserMenu();
                        break;
                    case 2:
                        ShowTravelMenu();
                        break;
                    case 0:
                        Console.WriteLine("Izlazak iz aplikacije...");
                        break;
                    default:
                        Console.WriteLine("Pogrešan unos, pritisnite bilo koju tipku za nastavak.");
                        Console.ReadKey();
                        ShowStartingMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Pogrešan unos, pokušajte ponovo.");

            }
        }
        static void ShowUserMenu()
        {
            Console.Clear();
            Console.WriteLine("UPRAVLJANJE KORISNICIMA\n1 - Unos novog korisnika\n2 - Brisanje korisnika\n3 - Uređivanje korisnika\n4 - Pregled svih korsnika\n0 - Porvratak na glavni izbronik\n  ");
            Console.Write("Odabir: ");
            if (int.TryParse(Console.ReadLine(), out int userChoice))
            {
                switch (userChoice)
                {
                    case 1:
                        var newUser = AddNewUser();
                        Users.Add(newUser);
                        Console.WriteLine("\nUnos uspješan. Pritisnite enter za nastavak");
                        Console.ReadKey();
                        ShowUserMenu();

                        break;
                    case 2:
                        DeleteUser();
                        break;
                    case 3:
                        UpdateUserInfo();
                        break;
                    case 4:
                        ShowAllUsers();
                        break;
                    case 0:
                        ShowStartingMenu();
                        break;
                    default:
                        Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Pogrešan unos, pokušajte ponovo.");

            }
        }
        static void ShowTravelMenu()
        {

        }
        static User AddNewUser()
        {
            var user = new User { Trips = new List<Trip>() };
            
            Console.Clear();
            int id = 1;
            foreach (var iduser in Users)
                if (id == iduser.Id)
                    id++;
            
            Console.Write("UNOS NOVOG KORISNIKA\nUnesite ime: ");
            string username = Console.ReadLine() ?? string.Empty;
            Console.Write("Unesite prezime: ");
            string usersurname = Console.ReadLine() ?? string.Empty;
            Console.Write("Unesite datum rođenja (YYYY-MM-DD): ");
            if (!DateOnly.TryParse(Console.ReadLine(), out DateOnly dateofbirth))
            {
                Console.WriteLine("Pogrešan unos datuma, pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowUserMenu();
            }
            else if( dateofbirth > DateOnly.FromDateTime(DateTime.Now))
            {
                Console.WriteLine("Datum rođenja ne može biti u budućnosti, pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowUserMenu();
            }
            Console.WriteLine("Unesite putovanja korisnika (po id-u odvojeni zarezom, npr. 1,2,3): ");
            string tripsInput = Console.ReadLine() ?? string.Empty;
            int[] inputTripIds = Array.ConvertAll(tripsInput.Split(','), s => int.Parse(s.Trim()));
            foreach (int tripId in inputTripIds)
                    user.Trips.Add(AllTrips.Find(trip => trip.Id == tripId));



            user.Name = username;
            user.Surname = usersurname;
            user.Id = id;
            user.DateOfBirth = dateofbirth;




            return user;
        }
        static void ShowAllUsers()
        {
            Console.Clear();
            Console.WriteLine("\nISPIS SVIH KORISNIKA");
            var SortedUsersByUsername = Users.OrderBy(user => user.Surname).ToList();

            foreach (var user in SortedUsersByUsername)
                Console.WriteLine($"{user.Id} - {user.Name} - {user.Surname} - {user.DateOfBirth}");

            Console.WriteLine("\nISPIS SVIH KORISNIKA (GODINE > 20)");
            
            foreach (var user in SortedUsersByUsername)
                if(DateOnly.FromDateTime(DateTime.Now).Year - user.DateOfBirth.Year > 20)
                    Console.WriteLine($"{user.Id} - {user.Name} - {user.Surname} - {user.DateOfBirth}");

            Console.WriteLine("\nISPIS SVIH KORISNIKA (PUTOVANJA > 2)");

            foreach (var user in SortedUsersByUsername)
                if (user.Trips.Count > 2)
                    Console.WriteLine($"{user.Id} - {user.Name} - {user.Surname} - {user.DateOfBirth}");
            Console.WriteLine("\nPritisnite bilo koju tipku za povratak na izbornik korisnika.");
            Console.ReadKey();
            ShowUserMenu();
            
            

        }
        static void DeleteUser()
        {
            Console.Clear();
            Console.WriteLine("BRISANJE KORISNIKA");
            Console.Write("Unesite ID korisnika kojeg želite obrisati: ");
            if (!int.TryParse(Console.ReadLine(), out int idToDelete))
            {
                Console.WriteLine("Pogrešan unos , pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowUserMenu();
               
            }
            var userToDelete = Users.Find(user => user.Id == idToDelete);
            if (userToDelete.Id == 0)
            {
                Console.WriteLine("ID korisnika nije pronaden , pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowUserMenu();
                
            }
            
            Console.WriteLine($"Jeste li sigurni da zelite obrisati korisnika {idToDelete} (Pritisnite ENTER za potrvdru)");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Users.Remove(Users.Find(user => user.Id == idToDelete));
                Console.WriteLine($"Korisnik {idToDelete} je obrisan. Pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowUserMenu();

            }
            else
                ShowUserMenu();
            
        }
        static void UpdateUserInfo()
        {
            Console.Clear();
            Console.WriteLine("UREĐIVANJE KORISNIKA");
            Console.Write("Unesite korisnika kojeg želite urediti (ID, ime , prezime): ");
            var userInput = Console.ReadLine();
            var userToUpdate = Users.Find(user => user.Name == userInput);
            if(userToUpdate.Id == 0)    
                Users.Find(user => user.Surname == userInput);
            
            if (!int.TryParse(userInput, out int idToUpdate) && userToUpdate.Id == 0)
            {
                Console.WriteLine("Korisnik nije pronađen , pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowUserMenu();

            }
            if (userToUpdate.Id == 0)
                userToUpdate = Users.Find(user => user.Id == idToUpdate);
            if(userToUpdate.Id == 0)
            {
                Console.WriteLine("Korisnik nije pronađen , pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowUserMenu();
            }

            Console.WriteLine($"Korisnik pronaden: {userToUpdate.Id} - {userToUpdate.Name} - {userToUpdate.Surname} - {userToUpdate.DateOfBirth}");
            Console.Write("Unesite koji podatak želite urediti (1 - Ime, 2 - Prezime, 3 - Datum rođenja, 4 - Putovanja): ");
            if (!int.TryParse(Console.ReadLine(), out int fieldToUpdate))
            {
                Console.WriteLine("Pogrešan unos , pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowUserMenu();
            }
                int index = Users.FindIndex(user => user.Id == userToUpdate.Id);

                switch (fieldToUpdate)
            {
                case 1:
                    Console.Write("Unesite novo ime: ");
                    
                    userToUpdate.Name = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Jeste li sigurni da želite promijeniti navedene podatke? (Pritisnite ENTER za potrvdu)");

                    if (Console.ReadKey().Key != ConsoleKey.Enter)
                        ShowUserMenu();

                    Users[index] = userToUpdate;
                    Console.WriteLine($"Korisnikovi podaci su ažurirani. Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();


                    break;
                case 2:
                    Console.Write("Unesite novo prezime: ");
                    
                    userToUpdate.Surname = Console.ReadLine() ?? string.Empty;
                    Console.WriteLine("Jeste li sigurni da želite promijeniti navedene podatke? (Pritisnite ENTER za potrvdu)");

                    if (Console.ReadKey().Key != ConsoleKey.Enter)
                        ShowUserMenu();
                    Users[index] = userToUpdate;
                    Console.WriteLine($"Korisnikovi podaci su ažurirani. Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                   break;
                case 3:
                    Console.Write("Unesite novi datum rođenja (YYYY-MM-DD): ");
                    if (!DateOnly.TryParse(Console.ReadLine(), out DateOnly newDateOfBirth))
                    {
                        Console.WriteLine("Pogrešan unos datuma, pritisnite bilo koju tipku za nastavak.");
                        Console.ReadKey();
                        ShowUserMenu();
                    }
                    Console.WriteLine("Jeste li sigurni da želite promijeniti navedene podatke? (Pritisnite ENTER za potrvdu)");

                    if (Console.ReadKey().Key != ConsoleKey.Enter)
                        ShowUserMenu();
                    userToUpdate.DateOfBirth = newDateOfBirth;
                    Users[index] = userToUpdate;
                    Console.WriteLine($"Korisnikovi podaci su ažurirani. Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    
                    break;
                case 4:
                    Console.WriteLine("Unesite putovanja korisnika (po id-u odvojeni zarezom, npr. 1,2,3): ");
                    string tripsInput = Console.ReadLine() ?? string.Empty;
                    int[] inputTripIds = Array.ConvertAll(tripsInput.Split(','), s => int.Parse(s.Trim()));
                    foreach (int tripId in inputTripIds)
                        userToUpdate.Trips.Add(AllTrips.Find(trip => trip.Id == tripId));
                    Console.WriteLine("Jeste li sigurni da želite promijeniti navedene podatke? (Pritisnite ENTER za potrvdu)");
                    if (Console.ReadKey().Key != ConsoleKey.Enter)
                        ShowUserMenu();
                    Users[index] = userToUpdate;
                    Console.WriteLine($"Korisnikovi podaci su ažurirani. Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    
                   

                    break;
                
                 default:
                    Console.WriteLine("Pogrešan unos , pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    ShowUserMenu();
                    break;

            }

            ShowUserMenu();
        }
    }
}
