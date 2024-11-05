using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkinLot
{
    internal class Helpers
    {
        public static string Usertype()
        {
            Console.WriteLine("Welcome to Gabis Parking Lot!");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Please press 1 if you want to park");
            Console.WriteLine("Press 2 if you are a parking attendant");
            Console.WriteLine("Press 3 for Administrative access");
            char.TryParse(Console.ReadLine(), out char menu);
            switch (menu) 
            {
                case '1':
                    ParkinLot.TransportType.ValjTransport();
                    return "Welcome customer!";
                    
                case '2':
                    return "Welcome parking attendant!";
                    
                case '3':
                    return "welcome Administrator!";
                    
                default:
                    return "Please chose a valid menu";
            }
        }
    }
}
