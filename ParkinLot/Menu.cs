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

        public static void GuardMenu(Parking parking){

            System.Console.WriteLine("1. View Parking \n 2. Give Ticket");
            int choice = int.Parse(System.Console.ReadLine());

            if (choice == 1){
                System.Console.WriteLine("PRINTING PARKING");
                System.Console.WriteLine(parking.parkingLot.Count);
                parking.ViewParkingSlots();}
        }
        public static Transport ParkingMenu()
        {
            string regNumber;
            Console.WriteLine("Ange registreringsnummer: ");
            regNumber = Console.ReadLine().Trim();

            Console.WriteLine("Ange färg på transport:");
            string color = Console.ReadLine();

            Console.WriteLine("Välj din transporttyp genom att trycka på rätt siffra: \n1. Bil \n2. Motorcykel \n3. Buss");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    bool elCar = false;
                    Console.WriteLine("Har du el bil? \n 1. Ja \n 2. Nej");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1) { elCar = true;}

                    Bil bil = new Bil(regNumber, color, 1, elCar); 
                    bil.ExitTime = HanteraParkering(bil);
                    return bil;

                case "2":
                    System.Console.WriteLine("What brand is it?");
                    string brand = Console.ReadLine();
                    
                    Motorcykel motorcykel = new Motorcykel(regNumber, color, 0.5, brand);
                    motorcykel.ExitTime = HanteraParkering(motorcykel);

                    return motorcykel;

                case "3":
                    System.Console.WriteLine("How many people u have in buss");
                    int passengers = int.Parse(Console.ReadLine()); 
                    Buss buss = new Buss(regNumber, color, 2, passengers);
                    buss.ExitTime = HanteraParkering(buss);
                    return buss;

                default:
                    // attempts++;
                    Console.WriteLine($"Ogiltigt val. Försök igen.");
                    return null;
            }

        }

        public static DateTime HanteraParkering(Transport transport)
        {
            Console.WriteLine("Hur länge planerar du att stå parkerad? Ange tid i sekunder:");
            double parkingTime;
            while (!double.TryParse(Console.ReadLine(), out parkingTime) || parkingTime <= 0)
            {
                Console.WriteLine("Ogiltig inmatning. Vänligen ange en giltig tid i sekunder:");
            }

            DateTime exitTime = transport.ArrivalTime.AddSeconds(parkingTime);
            Console.WriteLine($"Din parkering tid utgår kl: {exitTime}. Vi önskar dig en trevlig vistelse!");

            return exitTime;
        }


        public static void CheckExceededTime(DateTime exitTime){
            DateTime NowTime = DateTime.Now;
            

            if (NowTime > exitTime)
            {
                TimeSpan overtid = NowTime - exitTime;
                double overtidMinuter = (double)overtid.TotalMinutes;
                double bot = overtidMinuter * 15;

                Console.WriteLine($"Övertid: {overtidMinuter} minuter. Du får en bot på {bot} kronor.");
            }
            else
            {
                Console.WriteLine("Hoppas vi ses igen. Ha trevligt resa!");
            }

        }
    }
}
