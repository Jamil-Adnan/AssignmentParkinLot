using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkinLot
{
    public class Parking
    {
        public double[] parkingLot;
        public int? parkingNumber;  // a nullable integer
        public Parking()
        {
            parkingLot = new double[25];
            parkingLot[1] = 3;      // just to block some parking sport
            parkingLot[5] = 3;
            parkingLot[9] = 3;
            parkingLot[11] = 3;
            parkingLot[17] = 3;
            parkingLot[18] = 3;
            parkingLot[21] = 3;
            parkingLot[28] = 3;
           
        }



        // Method to check if a transport can fit and to park it if possible
        public bool ParkVehicle(Transport vehicle, out int? parkingNumber)  // method that returns 2 different values. a bool value if place is free then returns true. and also returns the parking place number as an integer
        {
            parkingNumber = null;
            if (vehicle.Size == 1) // Car
            {
                for (int i = 0; i < parkingLot.Length; i++)
                {
                    if (parkingLot[i] == 0) // Empty spot for a car
                    {
                        parkingLot[i] = vehicle.Size;
                        parkingNumber = i + 1;
                        return true;
                    }
                }
            }
            else if (vehicle.Size == 2) // Bus
            {
                for (int i = 0; i < parkingLot.Length - 1; i++)
                {
                    // Check two consecutive empty spots for a bus
                    if (parkingLot[i] == 0 && parkingLot[i + 1] == 0)
                    {
                        parkingLot[i] = vehicle.Size / 2; // Occupy two spots
                        parkingLot[i + 1] = vehicle.Size / 2;
                        parkingNumber = i + 1;
                        return true;
                    }
                }
            }
            else if (vehicle.Size == 0.5) // Motorcycle
            {
                for (int i = 0; i < parkingLot.Length; i++)
                {
                    if (parkingLot[i] == 0) // Empty spot for a motorcycle
                    {
                        parkingLot[i] += vehicle.Size; // Add motorcycle size
                        parkingNumber = i + 1;
                        return true;
                    }
                    else if (parkingLot[i] == 0.5) // Half-filled spot (one motorcycle already there)
                    {
                        parkingLot[i] += vehicle.Size; // Complete the spot with second motorcycle
                        parkingNumber = i + 1;
                        return true;
                    }
                }
            }

            // If no spots were found for the vehicle, return false
            return false;
        }

        // Method to print parking lot status
        public void DisplayParkingStatus()
        {
            Console.WriteLine("Parking lot status:");
            for (int i = 0; i < parkingLot.Length; i++)
            {
                Console.WriteLine($"Parkingplats {i + 1}: {(parkingLot[i] == 0 ? "Användbar" : $"Upptagen")}");
            }
        }
    }














    /*  Gammal code. Låt stå
     *  
     *  
     * internal class Parking
    {
        public int totalParking;
        public  List<List<Transport>> parkingLot;
        public Parking(int parkingAmount)
        {
            totalParking = parkingAmount;
            parkingLot = new List<List<Transport>>();
        }
        public double CheckParking()
        {
            double occupiedParking = 0;
            foreach (List<Transport> parking in parkingLot)
            {
                foreach (Transport transport  in parking){
                    if (transport is null){

                    }                    
                }
            }
            return totalParking - occupiedParking;
        }

        public List<int> FindEmptyParkingSlots()
        {
        List<int> emptySlots = new List<int>();
        for (int i = 0; i < parkingLot.Count; i++)
        {
            if (parkingLot[i].Count == 0)
            {
                emptySlots.Add(i);
            }
        }
        return emptySlots;
        }
        
        public bool ParkVehicle(Transport vehicle)
        {
        List<int> emptySlots = FindEmptyParkingSlots();
        if (emptySlots.Count > 0)
        {
            int slotIndex = emptySlots[0]; // Get the first empty slot
            parkingLot[slotIndex].Add(vehicle);
            Console.WriteLine($"Fordonet har parkerats på plats {slotIndex + 1}.");
            return true;
        }
        Console.WriteLine("Det finns inte tillräckligt med plats för att parkera fordonet.");
        return false;
        }

        public void createParkingLots(){
            for (int i = 0; i < totalParking; i++ ){
                parkingLot.Add(new List<Transport>());
            };
        }
    } */



}
