using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkinLot
{
    public class TransportType
        {
        public static void ValjTransport()
            {
            int attempts = 0; // Räknare för försök

            while (attempts < 3)
            {
                Console.WriteLine("Vilken typ av transport har du? (Bil/Motorcykel/Buss)");
                string transportType = Console.ReadLine().ToLower();

                switch (transportType)
                {
                    case "bil":
                        Bil.SkapaBil();
                        break;

                    case "motorcykel":
                        Motorcykel.SkapaMotorcykel();
                        break;

                    case "buss":
                        Buss.SkapaBuss();
                        break;

                    default:
                        attempts++;
                        Console.WriteLine($"Ogiltig transporttyp. Försök igen.({3-attempts} försök kvar.)");
                        break;
                }
            }
            Console.WriteLine("Denna parkering passar inte för den typ av fordon. Var vänlig kontrollera alternativen och försök igen eller hitta en annan parkering.");
        }
        }
    }

public class Transport
{
    public string RegNumber { get; set; }
    public string Color { get; set; }
    public double Size { get; set; }

    public DateTime ArrivalTime { get; set; }

    public Transport(string regNumber, string color, double size)
    {
        RegNumber = regNumber;
        Color = color;
        Size = size;
        ArrivalTime = DateTime.Now;
    }

    public virtual string Type()
    {
        return "Transport";
    }
}

// Subklass Bil
public class Bil : Transport
{
    public bool Elbil { get; set; }

    public Bil(string regNumber, string color, double size, bool elbil)
        : base(regNumber, color, size)
    {
        Elbil = elbil;
    }

    public override string Type()
    {
        return "Bil";
    }

    public string ElbilInfo()
    {
        return Elbil ? "Elektrisk bil" : "Ej elektrisk bil";
    }

    // Metod för att hantera inmatning och utskrift för Bil
    public static Bil SkapaBil()
    {
        Console.WriteLine("Ange registreringsnummer:");
        string regNumber = Console.ReadLine();

        Console.WriteLine("Ange färg på transport:");
        string color = Console.ReadLine();
        color = char.ToUpper(color[0]) + color[1..].ToLower();

        Console.WriteLine("Har du en elektrisk bil? (JA/NEJ)");
        bool elbil = Console.ReadLine().Trim().ToUpper() == "ja"; // 

        Bil bil = new Bil(regNumber, color, 1.0, elbil);
        Console.WriteLine($"Transporttyp: {bil.Type()}, {bil.ElbilInfo()}");
        Console.WriteLine($"Registreringsnummer: {bil.RegNumber}, Färg: {bil.Color}, Ankomsttid: {bil.ArrivalTime}");
        return bil;
    }
}

// Subklass Motorcykel
public class Motorcykel : Transport
{
    public string Marke { get; set; }

    public Motorcykel(string regNumber, string color, double size, string marke)
        : base(regNumber, color, size)
    {
        Marke = marke;
    }

    public override string Type()
    {
        return "Motorcykel";
    }

    public string MotorcykelInfo()
    {
        return $"Märke: {Marke}";
    }

    // Metod för att hantera inmatning och utskrift för Motorcykel
    public static Motorcykel SkapaMotorcykel()
    {
        Console.WriteLine("Ange registreringsnummer:");
        string regNumber = Console.ReadLine();

        Console.WriteLine("Ange färg på transport:");
        string color = Console.ReadLine();
        color = char.ToUpper(color[0]) + color[1..].ToLower();

        Console.WriteLine("Vilket märke är motorcykeln?");
        string marke = Console.ReadLine();

        Motorcykel motorcykel = new Motorcykel(regNumber, color, 0.5, marke);
        Console.WriteLine($"Transporttyp: {motorcykel.Type()}, {motorcykel.MotorcykelInfo()}");
        Console.WriteLine($"Registreringsnummer: {motorcykel.RegNumber}, Färg: {motorcykel.Color}, Ankomsttid: {motorcykel.ArrivalTime}");
        return motorcykel;
    }
}

// Subklass Buss
public class Buss : Transport
{
    public int AntalPassagerare { get; set; }

    public Buss(string regNumber, string color, double size, int antalPassagerare)
        : base(regNumber, color, size)
    {
        AntalPassagerare = antalPassagerare;
    }

    public override string Type()
    {
        return "Buss";
    }

    public string BussInfo()
    {
        return $"Antal sittplatser: {AntalPassagerare}";
    }

    // Metod för att hantera inmatning och utskrift för Buss
    public static Buss SkapaBuss()
    {
        Console.WriteLine("Ange registreringsnummer:");
        string regNumber = Console.ReadLine();

        Console.WriteLine("Ange färg på transport:");
        string color = Console.ReadLine();
        color = char.ToUpper(color[0]) + color[1..].ToLower();

        Console.WriteLine("Hur många sittplatser finns i bussen?");
        int antalPassagerare = int.Parse(Console.ReadLine());

        Buss buss = new Buss(regNumber, color, 2.0, antalPassagerare);
        Console.WriteLine($"Transporttyp: {buss.Type()}, {buss.BussInfo()}");
        Console.WriteLine($"Registreringsnummer: {buss.RegNumber}, Färg: {buss.Color}, Ankomsttid: {buss.ArrivalTime}");
        return buss;
    }
}
