using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkinLot
{
    internal class Parking
    {
        static int totalParking = 25;
        static private List<Transport> parkingLot;
        public Parking()
        {
            parkingLot = new List<Transport>();
        }
        static double CheckParking()
        {
            double occupiedParking = 0;
            foreach (Transport transport in parkingLot)
            {
                occupiedParking += transport.Size;                     
            }
            return totalParking - occupiedParking;
        }
        public bool ParkVehicle(Transport vehicle) 
        {
            if (CheckParking() > vehicle.Size)
            {
                parkingLot.Add(vehicle);
                Console.WriteLine("Fordonet går att parkera på parkering.");
                return true;
            }
           
            return false;
           
            
        }
    } 

    
   
}
