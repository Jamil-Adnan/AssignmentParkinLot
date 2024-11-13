using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkinLot
{
    public static class Helpers
    {
        public static void Usertype()
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

                    Console.WriteLine("Welcome customer!");
                    // TransportMenu.ValjaTransportMenu();
                    break;

                case '2':
                    Console.WriteLine("Welcome parking attendant!");
                    break;
                    
                case '3':
                    Console.WriteLine("welcome Administrator!");
                    break;
                      
                    
                default:
                    Console.WriteLine( "Please chose a valid menu");
                    break;
            }
        }
    }
}
