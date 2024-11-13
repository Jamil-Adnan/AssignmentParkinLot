    using System.Reflection.Metadata;

    namespace ParkinLot
    {
        public class Program
        {
            static void Main(string[] args)

            {
                Parking parkingHouse = new Parking(25);
                    
                
                System.Console.WriteLine("WELLCOME TO PARKING");
                while (true) {
                    System.Console.WriteLine("WHO ARE U MAN? \n 1. USER \n 2. GUARD \n 3. OWNER ");
                    System.Console.ReadLine();
                
                    var emptySlots = parkingHouse.FindEmptyParkingSlots();
                    if (emptySlots.Count <= 0)
                    {
                        System.Console.WriteLine("FUCK YOU. Sorry there are no place in parking.");
                        break; 
                    }



                }
                
                Transport vehicle = Menu.ParkingMenu();
                
                parkingHouse.ParkVehicle(vehicle);
                parkingHouse.PrintAllParkedTransports();
            }

        }
    }
