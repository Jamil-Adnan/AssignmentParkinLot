using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkinLot
{
    public static class TransportMenu
    {
        public static void ValjaTransportMenu()
        {
            int attempts = 0;

            while (attempts < 3)
            {
                Console.WriteLine("Välj din transporttyp genom att trycka på rätt siffra:");
                Console.WriteLine("1. Bil");
                Console.WriteLine("2. Motorcykel");
                Console.WriteLine("3. Buss");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Bil bil = Bil.SkapaBil();
                        HanteraParkering(bil);
                        return;

                    case "2":
                        Motorcykel motorcykel = Motorcykel.SkapaMotorcykel();
                        HanteraParkering(motorcykel);
                        return;

                    case "3":
                        Buss buss = Buss.SkapaBuss();
                        HanteraParkering(buss);
                        return;

                    default:
                        attempts++;
                        Console.WriteLine($"Ogiltigt val. Försök igen. ({3 - attempts} försök kvar.)");
                        break;
                }
            }

            Console.WriteLine("Denna parkering passar inte för den typ av fordon. Var vänlig kontrollera alternativen och försök igen eller hitta en annan parkering.");
        }

        public static void HanteraParkering(Transport transport)
        {
            Console.WriteLine("Hur länge planerar du att stå parkerad? Ange tid i minuter:");
            double parkeringstid;
            while (!double.TryParse(Console.ReadLine(), out parkeringstid) || parkeringstid <= 0)
            {
                Console.WriteLine("Ogiltig inmatning. Vänligen ange en giltig tid i minuter:");
            }

            DateTime ExitTime = transport.ArrivalTime.AddMinutes(parkeringstid);
            Console.WriteLine($"Din parkering tid utgår kl: {ExitTime}. Vi önskar dig en trevlig vistelse!");

            Console.ReadLine();

            DateTime NowTime = DateTime.Now;
            Console.WriteLine($"Du lämnade parkeringen kl: {NowTime}");

            if (NowTime > ExitTime)
            {
                TimeSpan overtid = NowTime - ExitTime;
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
