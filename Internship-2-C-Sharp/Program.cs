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
        }
        static void ShowTravelMenu()
        {

        }
        
        
    }
}
