using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkinLot
{
    internal class Parking
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
    } 

    
   
}
