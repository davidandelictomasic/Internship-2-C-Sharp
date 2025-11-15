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
            while (true) { 
            
            Console.Clear();
            Console.WriteLine("APLIKACIJA ZA EVIDENCIJU GORIVA\n1 - Korisnici \n2 - Putovanja\n3 - Statistika \n0 - Izlazak iz aplikacije\n");
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
                    case 3:
                        ShowStatisticsMenu();
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
            Console.Clear();
            Console.WriteLine("UPRAVLJANJE PUTOVANJIMA\n1 - Unos novog putovanja\n2 - Brisanje putovanja\n3 - Uređivanje putovanja\n4 - Pregled svih putovanja\n5 - Izvještaji i analize\n0 - Porvratak na glavni izbronik\n  ");
            Console.Write("Odabir: ");
            if (int.TryParse(Console.ReadLine(), out int userChoice))
            {
                switch (userChoice)
                {
                    case 1:
                        var newTrip = AddNewTrip();
                        AllTrips.Add(newTrip);
                        Console.WriteLine("\nUnos uspješan. Pritisnite enter za nastavak");
                        Console.ReadKey();
                        ShowTravelMenu();

                        break;
                    case 2:
                        DeleteTrip();
                        break;
                    case 3:
                        UpdateTravelInfo();
                        break;
                    case 4:
                        ShowAllTrips();
                        break;
                    case 5:
                        ShowReports();
                        break;
                    case 0:
                        ShowStartingMenu();
                        break;
                    default:
                        Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                        Console.ReadKey();
                        ShowTravelMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                Console.ReadKey();
                ShowTravelMenu();

            }
        }
        static void ShowStatisticsMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("STATISTIKA\n1 - Korisnik s najvećim ukupnim troškom goriva\n2 - Korisnik s najviše putovanja\n3 - Prosječan broj putovanja po korisniku\n4 - Ukupan broj prijeđenih kilometara svih korisnika\n0 - Povratak na glavni izbornik\n");
                Console.Write("Odabir: ");
                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            HighestTotalCostUser();
                            break;
                        case 2:
                            MostTripsUser();
                            break;
                        case 3:
                            AverageTrips();
                            break;
                        case 4:
                            TotalDistance();
                            break;

                        case 0:
                            return;
                        default:
                            Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                            Console.ReadKey();
                            continue;
                    }
                }
                else
                {
                    Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                    Console.ReadKey();
                    continue;

                }
            }
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
            else if (dateofbirth > DateOnly.FromDateTime(DateTime.Now))
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
            if (Users.Count == 0) {
                Console.WriteLine("Ne postoji ni jedan korisnik, pritisnite bilo koji tipku za nastavak.");
                Console.ReadKey();
                ShowUserMenu();
            }
            var SortedUsersByUsername = Users.OrderBy(user => user.Surname).ToList();

            foreach (var user in SortedUsersByUsername)
                Console.WriteLine($"{user.Id} - {user.Name} - {user.Surname} - {user.DateOfBirth}");

            Console.WriteLine("\nISPIS SVIH KORISNIKA (GODINE > 20)");

            foreach (var user in SortedUsersByUsername)
                if (DateOnly.FromDateTime(DateTime.Now).Year - user.DateOfBirth.Year > 20)
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
            if (userToUpdate.Id == 0)
                Users.Find(user => user.Surname == userInput);

            if (!int.TryParse(userInput, out int idToUpdate) && userToUpdate.Id == 0)
            {
                Console.WriteLine("Korisnik nije pronađen , pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowUserMenu();

            }
            if (userToUpdate.Id == 0)
                userToUpdate = Users.Find(user => user.Id == idToUpdate);
            if (userToUpdate.Id == 0)
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
        static Trip AddNewTrip()
        {
            Console.Clear();
            Console.WriteLine("UREĐIVANJE PUTOVANJA");
            Console.Write("Unesite korisnika kojem želite dodati putovanje (ID ili ime): ");
            var userInput = Console.ReadLine();
            var userToUpdate = Users.Find(user => user.Name == userInput);

            if (!int.TryParse(userInput, out int idToUpdate) && userToUpdate.Id == 0)
            {
                Console.WriteLine("Korisnik nije pronađen , pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowUserMenu();

            }
            if (userToUpdate.Id == 0)
                userToUpdate = Users.Find(user => user.Id == idToUpdate);
            if (userToUpdate.Id == 0)
            {
                Console.WriteLine("Korisnik nije pronađen , pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowUserMenu();
            }
            Console.WriteLine($"Korisnik pronaden: {userToUpdate.Id} - {userToUpdate.Name} - {userToUpdate.Surname}");

            var trip = new Trip();
            int id = AllTrips.Count + 1;

            Console.Write("Unesite datum putovanja (YYYY-MM-DD): ");
            if (!DateOnly.TryParse(Console.ReadLine(), out DateOnly dateoftrip))
            {
                Console.WriteLine("Pogrešan unos datuma, pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowTravelMenu();
            }
            else if (dateoftrip > DateOnly.FromDateTime(DateTime.Now))
            {
                Console.WriteLine("Datum rođenja ne može biti u budućnosti, pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowTravelMenu();
            }
            Console.Write("Unesite kilometražu: ");
            if (!double.TryParse(Console.ReadLine(), out double distance))
            {
                Console.WriteLine("Pogrešan unos , pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowTravelMenu();

            }
            Console.Write("Unesite potrošeno gorivo (L): ");
            if (!double.TryParse(Console.ReadLine(), out double fuelConsumed))
            {
                Console.WriteLine("Pogrešan unos, pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowTravelMenu();

            }
            Console.Write("Unesite cijenu po litri: ");
            if (!double.TryParse(Console.ReadLine(), out double costOfFuelPerLiter))
            {
                Console.WriteLine("Pogrešan unos, pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowTravelMenu();

            }
            if (costOfFuelPerLiter < 0)
            {
                Console.WriteLine("Pogrešan unos, pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowTravelMenu();
            }
            trip.DateOfTrip = dateoftrip;
            trip.Distance = distance;
            trip.FuelConsumed = fuelConsumed;
            trip.CostOfFuelPerLiter = costOfFuelPerLiter;
            trip.TotalCost = fuelConsumed * costOfFuelPerLiter;
            userToUpdate.Trips.Add(trip);
            return trip;
        }

        static void ShowAllTrips()
        {
            Console.Clear();
            Console.WriteLine("ISPIS SVIH PUTOVANJA\n");
            var allTrips = AllTrips.OrderBy(trip => trip.Id).ToList();

            foreach (var trip in allTrips)
                Console.WriteLine($"Putovanje #{trip.Id}\nDatum: {trip.DateOfTrip}\nKilometri: {trip.Distance}\nGorivo: {trip.FuelConsumed}\nCijena po litri: {trip.CostOfFuelPerLiter}\nUkupno: {trip.TotalCost}\n");


            var tripsSortedTotalCost = AllTrips.OrderBy(trip => trip.TotalCost).ToList();
            var tripsSortedTotalCostDESC = AllTrips.OrderByDescending(trip => trip.TotalCost).ToList();
            var tripsSortedDistance = AllTrips.OrderBy(trip => trip.Distance).ToList();
            var tripsSortedDistanceDESC = AllTrips.OrderByDescending(trip => trip.Distance).ToList();
            var tripsSortedDateOfTrip = AllTrips.OrderBy(trip => trip.DateOfTrip).ToList();
            var tripsSortedDateOfTripDESC = AllTrips.OrderByDescending(trip => trip.DateOfTrip).ToList();
            Console.WriteLine("\nISPIS SVIH PUTOVANJA (ASC TROŠAK)");
            foreach (var trip in tripsSortedTotalCost)
                Console.WriteLine($"Putovanje #{trip.Id}\nDatum: {trip.DateOfTrip}\nKilometri: {trip.Distance}\nGorivo: {trip.FuelConsumed}\nCijena po litri: {trip.CostOfFuelPerLiter}\nUkupno: {trip.TotalCost}\n");
            Console.WriteLine("ISPIS SVIH PUTOVANJA (DESC TROŠAK)\n");
            foreach (var trip in tripsSortedTotalCostDESC)
                Console.WriteLine($"Putovanje #{trip.Id}\nDatum: {trip.DateOfTrip}\nKilometri: {trip.Distance}\nGorivo: {trip.FuelConsumed}\nCijena po litri: {trip.CostOfFuelPerLiter}\nUkupno: {trip.TotalCost}\n");
            Console.WriteLine("ISPIS SVIH PUTOVANJA (ASC KILOMETRI)\n");
            foreach (var trip in tripsSortedDistance)
                Console.WriteLine($"Putovanje #{trip.Id}\nDatum: {trip.DateOfTrip}\nKilometri: {trip.Distance}\nGorivo: {trip.FuelConsumed}\nCijena po litri: {trip.CostOfFuelPerLiter}\nUkupno: {trip.TotalCost}\n");
            Console.WriteLine("ISPIS SVIH PUTOVANJA (DESC KILOMETRI)\n");
            foreach (var trip in tripsSortedDistanceDESC)
                Console.WriteLine($"Putovanje #{trip.Id}\nDatum: {trip.DateOfTrip}\nKilometri: {trip.Distance}\nGorivo: {trip.FuelConsumed}\nCijena po litri: {trip.CostOfFuelPerLiter}\nUkupno: {trip.TotalCost}\n");
            Console.WriteLine("ISPIS SVIH PUTOVANJA (ASC DATE)\n");
            foreach (var trip in tripsSortedDateOfTrip)
                Console.WriteLine($"Putovanje #{trip.Id}\nDatum: {trip.DateOfTrip}\nKilometri: {trip.Distance}\nGorivo: {trip.FuelConsumed}\nCijena po litri: {trip.CostOfFuelPerLiter}\nUkupno: {trip.TotalCost}\n");
            Console.WriteLine("ISPIS SVIH PUTOVANJA (DESC DATE)\n");
            foreach (var trip in tripsSortedDateOfTripDESC)
                Console.WriteLine($"Putovanje #{trip.Id}\nDatum: {trip.DateOfTrip}\nKilometri: {trip.Distance}\nGorivo: {trip.FuelConsumed}\nCijena po litri: {trip.CostOfFuelPerLiter}\nUkupno: {trip.TotalCost}\n");
            Console.WriteLine("\nPritisnite bilo koju tipku za povratak na izbornik korisnika.");
            Console.ReadKey();
            ShowTravelMenu();



        }
        static void DeleteTrip()
        {
            Console.Clear();
            Console.WriteLine("BRISANJE PUTOVANJA");
            Console.Write("Unesite način brisanja\n(1 - ID , 2 - Sva putovanja skuplja od unesenog broja , 3 - Sva putovanja jeftinija od unesenog broja): ");
            if (!int.TryParse(Console.ReadLine(), out int userChoice))
            {
                Console.WriteLine("Pogrešan unos , pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowTravelMenu();
                return;

            }
            switch (userChoice)
            {
                case 1:
                    Console.Write("Unesite ID putovanja kojeg želite izbrisati: ");
                    if (!int.TryParse(Console.ReadLine(), out int idToDelete))
                    {
                        Console.WriteLine("Pogrešan unos, pritisnite bilo koju tipku za nastavak.");
                        Console.ReadKey();
                        ShowTravelMenu();
                        return;

                    }
                    var tripToDelete = AllTrips.Find(trip => trip.Id == idToDelete);
                    if (tripToDelete.Id == 0)
                    {
                        Console.WriteLine("ID putovanja nije pronaden, pritisnite bilo koju tipku za nastavak.");
                        Console.ReadKey();
                        ShowTravelMenu();
                        return;

                    }

                    Console.WriteLine($"Jeste li sigurni da zelite obrisati putovanje {idToDelete} (Pritisnite ENTER za potrvdru)");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {

                        if (AllTrips.Remove(AllTrips.Find(trip => trip.Id == idToDelete)))
                        {

                            Console.WriteLine($"Putovanje uspješno obrisano. Pritisnite bilo koju tipku za nastavak.");
                            Console.ReadKey();
                            ShowTravelMenu();
                            return;
                        }
                    }
                    else
                        ShowTravelMenu();
                    return;

                case 2:
                    Console.Write("Unesite od koje cijene želite izbrisati sva skuplja putovanja: ");
                    if (!double.TryParse(Console.ReadLine(), out double priceToDelHigher))
                    {
                        Console.WriteLine("Pogrešan unos , pritisnite bilo koju tipku za nastavak.");
                        Console.ReadKey();
                        ShowTravelMenu();

                    }
                    Console.WriteLine($"Jeste li sigurni da zelite obrisati putovanja skuplja od unesene cijene (Pritisnite ENTER za potrvdru)");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        AllTrips.RemoveAll(trip => trip.TotalCost > priceToDelHigher);
                        Console.WriteLine($"Putovanje uspješno obrisano. Pritisnite bilo koju tipku za nastavak.");
                        Console.ReadKey();
                        ShowTravelMenu();
                        return;

                    }
                    else
                        ShowTravelMenu();
                    return;

                case 3:
                    Console.Write("Unesite od koje cijene želite izbrisati sva jeftinija putovanja: ");
                    if (!double.TryParse(Console.ReadLine(), out double priceToDelLower))
                    {
                        Console.WriteLine("Pogrešan unos , pritisnite bilo koju tipku za nastavak.");
                        Console.ReadKey();
                        ShowTravelMenu();
                        return;

                    }
                    Console.WriteLine($"Jeste li sigurni da zelite obrisati putovanja jeftinije od unesene cijene (Pritisnite ENTER za potrvdru)");
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        AllTrips.RemoveAll(trip => trip.TotalCost > priceToDelLower);
                        Console.WriteLine($"Putovanje uspješno obrisano. Pritisnite bilo koju tipku za nastavak.");
                        Console.ReadKey();
                        ShowTravelMenu();
                        return;

                    }
                    else
                        ShowTravelMenu();
                    return;

                default:
                    Console.WriteLine("Pogrešan unos , pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    ShowTravelMenu();
                    return;


            }




        }
        static void UpdateTravelInfo()
        {
            Console.Clear();
            Console.WriteLine("UREĐIVANJE PUTOVANJA");
            Console.Write("Unesite ID putovanja kojeg želite urediti: ");
            var userInput = Console.ReadLine();


            if (!int.TryParse(userInput, out int idToUpdate))
            {
                Console.WriteLine("Korisnik nije pronađen, pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowTravelMenu();

            }
            var tripToUpdate = AllTrips.Find(trip => trip.Id == idToUpdate);
            if (tripToUpdate.Id == 0)
            {
                Console.WriteLine("Putovanje nije pronađen0, pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowTravelMenu();
            }

            Console.WriteLine($"Putovanje pronađeno: {tripToUpdate.Id} - {tripToUpdate.DateOfTrip}");
            Console.Write("Unesite koji podatak želite urediti (1 - Datum, 2 - Kilometraža, 3 - Gorivo, 4 - Cijena goriva): ");
            if (!int.TryParse(Console.ReadLine(), out int fieldToUpdate))
            {
                Console.WriteLine("Pogrešan unos , pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowTravelMenu();
            }
            int index = AllTrips.FindIndex(trip => trip.Id == tripToUpdate.Id);

            switch (fieldToUpdate)
            {
                case 1:
                    Console.Write("Unesite novi datum: ");
                    if (!DateOnly.TryParse(Console.ReadLine(), out DateOnly newdateoftrip))
                    {
                        Console.WriteLine("Pogrešan unos datuma, pritisnite bilo koju tipku za nastavak.");
                        Console.ReadKey();
                        ShowTravelMenu();
                    }
                    else if (newdateoftrip > DateOnly.FromDateTime(DateTime.Now))
                    {
                        Console.WriteLine("Datum rođenja ne može biti u budućnosti, pritisnite bilo koju tipku za nastavak.");
                        Console.ReadKey();
                        ShowTravelMenu();
                    }


                    Console.WriteLine("Jeste li sigurni da želite promijeniti navedene podatke? (Pritisnite ENTER za potrvdu)");

                    if (Console.ReadKey().Key != ConsoleKey.Enter)
                        ShowTravelMenu();
                    tripToUpdate.DateOfTrip = newdateoftrip;
                    AllTrips[index] = tripToUpdate;
                    Console.WriteLine($"Podaci putovanja su ažurirani. Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    ShowTravelMenu();

                    break;
                case 2:
                    Console.Write("Unesite novu kilometrazi: ");
                    if (!double.TryParse(Console.ReadLine(), out double newDistanceOfTrip) || newDistanceOfTrip <= 0)
                    {
                        Console.WriteLine("Pogrešan unos, pritisnite bilo koju tipku za nastavak");
                        Console.ReadKey();
                        ShowTravelMenu();


                    }
                    tripToUpdate.Distance = newDistanceOfTrip;
                    Console.WriteLine("Jeste li sigurni da želite promijeniti navedene podatke? (Pritisnite ENTER za potrvdu)");

                    if (Console.ReadKey().Key != ConsoleKey.Enter)
                        ShowTravelMenu();
                    AllTrips[index] = tripToUpdate;
                    Console.WriteLine($"Podaci putovanja su ažurirani. Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    ShowTravelMenu();

                    break;
                case 3:
                    Console.Write("Unesite novi iznos potrošenog goriva: ");
                    if (!double.TryParse(Console.ReadLine(), out double newFuelConsumed) || newFuelConsumed <= 0)
                    {
                        Console.WriteLine("Pogrešan unos, pritisnite bilo koju tipku za nastavak");
                        Console.ReadKey();
                        ShowTravelMenu();


                    }
                    tripToUpdate.FuelConsumed = newFuelConsumed;
                    tripToUpdate.TotalCost = newFuelConsumed * tripToUpdate.CostOfFuelPerLiter;
                    Console.WriteLine("Jeste li sigurni da želite promijeniti navedene podatke? (Pritisnite ENTER za potrvdu)");

                    if (Console.ReadKey().Key != ConsoleKey.Enter)
                        ShowTravelMenu();

                    AllTrips[index] = tripToUpdate;
                    Console.WriteLine($"Podaci putovanja su ažurirani. Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    ShowTravelMenu();

                    break;
                case 4:
                    Console.Write("Unesite novu cijenu goriva: ");
                    if (!double.TryParse(Console.ReadLine(), out double newCostOfFuel) || newCostOfFuel <= 0)
                    {
                        Console.WriteLine("Pogrešan unos, pritisnite bilo koju tipku za nastavak");
                        Console.ReadKey();
                        ShowTravelMenu();


                    }
                    tripToUpdate.CostOfFuelPerLiter = newCostOfFuel;
                    tripToUpdate.TotalCost = newCostOfFuel * tripToUpdate.Distance;

                    Console.WriteLine("Jeste li sigurni da želite promijeniti navedene podatke? (Pritisnite ENTER za potrvdu)");

                    if (Console.ReadKey().Key != ConsoleKey.Enter)
                        ShowTravelMenu();
                    AllTrips[index] = tripToUpdate;
                    Console.WriteLine($"Podaci putovanja su ažurirani. Pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    ShowTravelMenu();



                    break;

                default:
                    Console.WriteLine("Pogrešan unos , pritisnite bilo koju tipku za nastavak.");
                    Console.ReadKey();
                    ShowUserMenu();
                    break;

            }

            ShowUserMenu();
        }
        static void ShowReports()
        {
            Console.Clear();
            Console.WriteLine("IZVJEŠTAJ PUTOVANJA");
            Console.Write("Unesite korisnika za kojeg želite izvještaj (ID, ime , prezime): ");
            var userInput = Console.ReadLine();
            var userForReport = Users.Find(user => user.Name == userInput);
            if (userForReport.Id == 0)
                userForReport = Users.Find(user => user.Surname == userInput);

            if (!int.TryParse(userInput, out int idToUpdate) && userForReport.Id == 0)
            {
                Console.WriteLine("Korisnik nije pronađen , pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowTravelMenu();

            }
            if (userForReport.Id == 0)
                userForReport = Users.Find(user => user.Id == idToUpdate);
            if (userForReport.Id == 0)
            {
                Console.WriteLine("Korisnik nije pronađen , pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowTravelMenu();
            }

            Console.WriteLine($"Korisnik pronaden: {userForReport.Id} - {userForReport.Name}");
            double totalFuelConsumed = 0;
            double totalCostOfTravels = 0;
            double totalDisance = 0;
            foreach (var trip in userForReport.Trips)
            {
                totalFuelConsumed += trip.FuelConsumed;
                totalCostOfTravels += trip.TotalCost;
                totalDisance += trip.Distance;
            }
            double avgFuelConsumed = (totalFuelConsumed / totalDisance) * 100;
            Console.WriteLine($"Ukupna potrošnja goriva: {totalFuelConsumed}\nUkupni troškovi goriva: {totalCostOfTravels}\nProsječna potrošnja goriva L/100km: {avgFuelConsumed}");
            Console.Write("Unesite datum na koji želite potražiti putovanja:");
            if (!DateOnly.TryParse(Console.ReadLine(), out DateOnly dateToSearch))
            {
                Console.WriteLine("Pogrešan unos datuma, pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowTravelMenu();
            }
            var tripFiltered = userForReport.Trips.FindAll(trip => trip.DateOfTrip == dateToSearch).ToArray();
            if (tripFiltered.Length == 0)
            {
                Console.WriteLine("Ni jedno putovanje nije pronađeno, pritisnite bilo koju tipku za nastavak.");
                Console.ReadKey();
                ShowTravelMenu();
            }
            foreach (var trip in tripFiltered)
            {
                Console.WriteLine($"Putovanje pronađeno: ID {trip.Id} - {trip.DateOfTrip}");
            }

            Console.ReadKey();
            ShowTravelMenu();

        }
        static void HighestTotalCostUser()
        {
            Console.Clear();

            double maxTotal = 0;
            var highestCostUser = new User();
            foreach (var user in Users)
            {
                double userTotal = 0;

                foreach (var trip in user.Trips)
                {

                    userTotal += trip.TotalCost;
                }


                if (userTotal > maxTotal)
                {
                    highestCostUser = Users.Find(u => u.Id == user.Id);
                    maxTotal = userTotal;
                }
            }
            Console.WriteLine($"Korisnik sa najvećim troškom goriva {highestCostUser.Name} - {highestCostUser.Surname} - Iznos: {maxTotal}");
            Console.WriteLine("Pritisnite bilo koju tipku za povratak na izbornik statistike.");
            Console.ReadKey();
            return;
        }
        static void MostTripsUser()
        {
            Console.Clear();
            int maxTrips = 0;
            var mostTripsUser = new User();

            foreach (var user in Users)
            {
                if (user.Trips.Count > maxTrips)
                {
                    mostTripsUser = Users.Find(u => u.Id == user.Id);
                    maxTrips = user.Trips.Count;
                }
            }
            Console.WriteLine($"Korisnik sa najvećim brojem putovanja {mostTripsUser.Name} - {mostTripsUser.Surname} - Iznos: {maxTrips}");
            Console.WriteLine("Pritisnite bilo koju tipku za povratak na izbornik statistike.");
            Console.ReadKey();
            return;
        }
        static void AverageTrips()
        {
            Console.Clear();
            double totalTrips = 0;
            foreach (var user in Users)
            {
                totalTrips += user.Trips.Count;
            }
            double averageTrips = totalTrips / Users.Count;
            Console.WriteLine($"Prosječan broj putovanja po korisniku: {averageTrips}");
            Console.WriteLine("Pritisnite bilo koju tipku za povratak na izbornik statistike.");
            Console.ReadKey();
            return;
        }
        static void TotalDistance()
        {
            Console.Clear();
            double totalDistance = 0;
            foreach (var user in Users)
            {
                foreach (var trip in user.Trips)
                {
                    totalDistance += trip.Distance;
                }
            }
            Console.WriteLine($"Ukupan broj prijeđenih kilometara svih korisnika: {totalDistance}");
            Console.WriteLine("Pritisnite bilo koju tipku za povratak na izbornik statistike.");
            Console.ReadKey();
            return;
        }
    }
}
