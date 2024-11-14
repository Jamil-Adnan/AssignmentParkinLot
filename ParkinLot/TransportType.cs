using ParkinLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkinLot
{
    public class Transport
    {
        public string RegNumber { get; set; }
        public string Color { get; set; }
        public double Size { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime? ExitTime { get; set;}
        public double ticketFee {get; set;}
        public Transport(string regNumber, string color, double size)
        {
            RegNumber = regNumber;
            Color = color;
            Size = size;
            ArrivalTime = DateTime.Now;
            ExitTime = null;
            ticketFee = 0;

            
        }

        public bool ValidatePlate(string regNumber){
                if (regNumber.Length >= 2 && regNumber.Length <= 7 && !regNumber.Contains(" "))
                {
                    return true;
                } 
                return false; 
        }
    }

    public class Bil : Transport
    {
        public bool Elbil { get; set; }

        public Bil(string regNumber, string color, double size, bool elbil)
            : base(regNumber, color, size)
        {
            Elbil = elbil;
        }


        // Metod för att hantera inmatning och utskrift för Bil
        // public static Bil SkapaBil()
        // {
         //   SKa vi använda en sånt kod eller enklare versioner där användaren skriver in själv vilken färg har hans transport?
            //Console.WriteLine("Ange registreringsnummer:"); Gammla version
            // string regNumber = Console.ReadLine();

            /* string regNumber; 
            while (true)
            {
                Console.WriteLine("Ange registreringsnummer: ");
                regNumber = Console.ReadLine().Trim();

                if (regNumber.Length >= 2 && regNumber.Length <= 7 && !regNumber.Contains(" "))
                {
                    break; // Avsluta loopen om numret är giltigt
                }
                else
                {
                    Console.WriteLine("Ogiltigt registreringsnummer. Försök igen.");
                }
            }

            List<string> colors = new List<string>
        {
            "Röd", "Blå", "Grön", "Gul", "Svart",
            "Vit", "Orange", "Rosa", "Lila", "Brun",
            "Grå", "Turkos", "Beige", "Vinröd", "Silver",
            "Guld", "Marinblå", "Magenta", "Ljusblå", "Olivgrön"
        };

            // Visa färglistan
            Console.WriteLine("Tillgängliga färger:");
            for (int i = 0; i < colors.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {colors[i]}");
            }

            Console.Write("Ange antal färger på transport (max 3): ");
            int antalFärger = 0;
            while (!int.TryParse(Console.ReadLine(), out antalFärger) || antalFärger < 1 || antalFärger > 3)
            {
                Console.WriteLine("Ogiltig inmatning. Ange ett tal mellan 1 och 3:");
            }

            // Samla in användarens färgval
            List<string> valdaFärger = new List<string>();
            for (int i = 0; i < antalFärger; i++)
            {
                Console.Write($"Välj färg {i + 1} genom att ange motsvarande nummer: ");
                int färgNummer;
                while (!int.TryParse(Console.ReadLine(), out färgNummer) || färgNummer < 1 || färgNummer > colors.Count)
                {
                    Console.WriteLine("Ogiltigt färgnummer. Försök igen:");
                }
                valdaFärger.Add(colors[färgNummer - 1]);
            }

            // Visa valda färger
            Console.WriteLine("Valda färger för transporten:");
            Console.WriteLine(string.Join(", ", valdaFärger));
        
    
    Console.WriteLine("Har du en elektrisk bil? (Ja=1/Nej=2)");
            string elbilVal = Console.ReadLine().Trim();

            bool elbil = elbilVal == "1"; // 

            Bil bil = new Bil(regNumber, string.Join(", ", valdaFärger), 1.0, elbil);
            Console.WriteLine($"Transporttyp: {bil.Type()}, {bil.ElbilInfo()}");
            Console.WriteLine($"Registreringsnummer: {bil.RegNumber}, Färg: {bil.Color}, Ankomsttid: {bil.ArrivalTime}");
            return bil;
        }
        
*/
    }
    public class Motorcykel : Transport
    {
        public string Marke { get; set; }

        public Motorcykel(string regNumber, string color, double size, string marke)
            : base(regNumber, color, size)
        {
            Marke = marke;
        }

    }

    public class Buss : Transport
    {
        public int AntalPassagerare { get; set; }

        public Buss(string regNumber, string color, double size, int antalPassagerare)
            : base(regNumber, color, size)
        {
            AntalPassagerare = antalPassagerare;
        }

    }
}
