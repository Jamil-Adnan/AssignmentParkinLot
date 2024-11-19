using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkinLot
{
    public static class Menu
    {

        public static void OwnerMenu(Parking parking){
            System.Console.WriteLine("[1] View Parking \n[2] See Income");
            int choice = int.Parse(System.Console.ReadLine());

            if (choice == 1){
                parking.ViewParkingSlots();} 
            if (choice ==2){
                System.Console.WriteLine($"{parking.Income:C}");
            }
        }
        public static void GuardMenu(Parking parking){

            System.Console.WriteLine("[1] View Parking \n[2] Give Ticket");
            int choice = int.Parse(System.Console.ReadLine());

            if (choice == 1){
                parking.ViewParkingSlots();}
            if (choice == 2){

                System.Console.Write("Type Registration Number: ");
                string regNumber = System.Console.ReadLine();
                
                Vehicle vehicle = parking.FindVehicleByRegNumber(regNumber);
                
                if (vehicle == null)
                { 
                    System.Console.WriteLine($"No vehicle is found with registration number {regNumber}");
                    return;
                }
                if (parking.GetTimespan(vehicle) > 0){
                    System.Console.WriteLine("ATTENTION!! VEHICLE STILL HAS TIME LEFT FOR PARKING");
                    return;
                }
                System.Console.Write("How much penalty to charge?: ");
                double fee = double.Parse(System.Console.ReadLine());

                vehicle.ticketFee += fee;             
                
            }
        }
        public static Vehicle? ParkingMenu(Parking parking)
        {
            string regNumber;
            Console.Write("Insert Registration Number: ");
            regNumber = Console.ReadLine().Trim();
            
            var vehicleParked = parking.FindVehicleByRegNumber(regNumber);
            if (vehicleParked != null){
                parking.ExitVehicle(regNumber);
                return null;
            }


            Console.Write("Insert the Color: ");
            string color = Console.ReadLine();

            Console.WriteLine("Please choose the number correspondiong to your vehicle: \n[1] Car\n[2] Motorcykel\n[3] Bus");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    bool elCar = false;
                    Console.WriteLine("Is it an Electric Car?\n[1] Yes\n[2] No");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1) { elCar = true;}

                    Car bil = new Car(regNumber, color, 1, elCar); 
                    bil.ExitTime = HanteraParkering(bil);
                    return bil;

                case "2":
                    System.Console.Write("What brand is it?: ");
                    string brand = Console.ReadLine();
                    
                    Motorcykel motorcykel = new Motorcykel(regNumber, color, 0.5, brand);
                    motorcykel.ExitTime = HanteraParkering(motorcykel);

                    return motorcykel;

                case "3":
                    System.Console.Write("How many sits the bus has: ");
                    int passengers = int.Parse(Console.ReadLine()); 
                    Bus buss = new Bus(regNumber, color, 2, passengers);
                    buss.ExitTime = HanteraParkering(buss);
                    return buss;

                default:
                    // attempts++;
                    Console.WriteLine($"Wrong input,. Please try again.");
                    return null;
            }

        }

        public static DateTime HanteraParkering(Vehicle vehicle)
        {
            Console.Write("For how long do you wish to park? Please insert the time in seconds: ");
            double parkingTime;
            while (!double.TryParse(Console.ReadLine(), out parkingTime) || parkingTime <= 0)
            {
                Console.WriteLine("Wrong input. Please insert a valid time in seconds.");
            }

            DateTime exitTime = vehicle.ArrivalTime.AddSeconds(parkingTime);
            Console.WriteLine($"Your parkingtime ends : {exitTime}. We wish you a great parking experience with us.");

            return exitTime;
        }


        
    }
}
