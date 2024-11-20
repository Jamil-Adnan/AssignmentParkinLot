﻿    using System.Reflection.Metadata;

    namespace ParkinLot
    {
        public class Program
        {
            static void Main(string[] args)

            {
            
                Parking parkingHouse = new Parking(25, 3);
            /*
                Vehicle car = new Vehicle("ABC123", "Red", 1);
                Vehicle bike1 = new Vehicle("XYZ789", "Blue", 0.5);
                Vehicle bike2 = new Vehicle("DEF456", "Green", 0.5);
                // Vehicle bus = new Vehicle("BUS001", "Yellow", 2);

                parkingHouse.ParkVehicle(car);
                parkingHouse.ParkVehicle(bike1);
                parkingHouse.ParkVehicle(bike2);
                // parkingHouse.ParkVehicle(bus);
                */    
                
                System.Console.WriteLine("\n                WELCOME TO PARKINGLOT");
                Console.WriteLine("******************************************************");
                Console.WriteLine("=> 1.5 SEK per second for cars and Motor Cycles (Standard parking).\n=> 3 SEK per second for Buses\n            !!! Cheapest in town!!!\n******************************************************");
                Console.WriteLine();
                
                while (true) {
                    System.Console.WriteLine("Press [1] to check IN/OUT your vehicle.\nPress [2] for Parking Attendant menu.\nPress [3] for Owner menu.\nPress [4] to exit the program");
                    int choice = int.Parse(System.Console.ReadLine());

                    if (choice == 1){ 
                        // var emptySlots = parkingHouse.FindEmptyParkingSlots();
                        // if (emptySlots.Count <= 0)
                        // {
                        //     System.Console.WriteLine("FUCK YOU. Sorry there are no place in parking.");
                        //     continue;
                        // }
                        Vehicle vehicle = Menu.ParkingMenu(parkingHouse);
                        if (vehicle != null){
                        parkingHouse.ParkVehicle(vehicle);
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
