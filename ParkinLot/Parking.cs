using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkinLot
{

    public class Parking
    {
        public int totalParking;
        public  List<List<Transport>> parkingLot;
        public Parking(int parkingAmount)
        {
            totalParking = parkingAmount;
            parkingLot = new List<List<Transport>>();
            createParkingLots();
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

        public void ViewParkingSlots()
        {

            System.Console.WriteLine("THIS");
            if (parkingLot.Count == 0)
            {
                Console.WriteLine("The parking lot is empty.");
                return;
            }

            for (int i = 0; i < parkingLot.Count; i++)
            {
                
                if (parkingLot[i].Count !=  0)
                {
                    Console.WriteLine($"Parking Row {i + 1}:");
                    foreach (var transport in parkingLot[i])
                    {
                        Console.WriteLine($"  Transport Information:");
                        Console.WriteLine($"    Registration Number: {transport.RegNumber}");
                        Console.WriteLine($"    Color: {transport.Color}");
                        Console.WriteLine($"    Size: {transport.Size}");
                        Console.WriteLine($"    Arrival Time: {transport.ArrivalTime}");
                        
                        if (transport.ExitTime.HasValue)
                        {
                            var timeNow = DateTime.Now;
                            TimeSpan diff = transport.ExitTime.Value - timeNow; 
                            Console.WriteLine($"    Exit Time: { Math.Floor(diff.TotalSeconds)} left");
                        }
                        else
                        {
                            Console.WriteLine("    Exit Time: Not exited yet");
                        }
                        
                        Console.WriteLine(); // Empty line for better readability
                    }
                }
                
                Console.WriteLine(); // Empty line between rows
            }
        }
    }
}
