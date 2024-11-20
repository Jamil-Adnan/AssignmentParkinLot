    using System.Reflection.Metadata;

    namespace ParkinLot
    {
        public class Program
        {
            static void Main(string[] args)
            {            
                Parking parkingHouse = new Parking(25, 3);
            
                System.Console.WriteLine("\n                WELCOME TO PARKINGLOT");
                Console.WriteLine("******************************************************");
                Console.WriteLine("=> 1.5 SEK per second for cars and Motor Cycles (Standard parking).\n=> 3 SEK per second for Buses\n            !!! Cheapest in town!!!\n******************************************************");
                Console.WriteLine();
                
                while (true) {
                    System.Console.WriteLine("Press [1] to check IN/OUT your vehicle.\nPress [2] for Parking Attendant menu.\nPress [3] for Owner menu.\nPress [4] to exit the program");
                    int choice = int.Parse(System.Console.ReadLine());

                    if (choice == 1)
                    {                        
                        Vehicle vehicle = Menu.ParkingMenu(parkingHouse);
                        if (vehicle != null)
                        {
                            parkingHouse.ParkVehicle(vehicle);
                            Console.WriteLine($"Your parkingtime ends :             {vehicle.ExitTime}. We wish you a great parking experience with us.");
                        }
                    }
                    if (choice == 2){Menu.GuardMenu(parkingHouse);}
                    if (choice == 3){Menu.OwnerMenu(parkingHouse);}
                    if (choice == 4) 
                    {
                        Console.WriteLine("Thank you for using our parking service. Have a safe journey home.");
                        break;
                    }  
                }
            }
        }
    }
