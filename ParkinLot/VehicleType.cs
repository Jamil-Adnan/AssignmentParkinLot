using ParkinLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkinLot
{
    public class Vehicle
    {
        public string RegNumber { get; set; }
        public string Color { get; set; }
        public double Size { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime? ExitTime { get; set;}
        public double ticketFee {get; set;}
        public Vehicle(string regNumber, string color, double size)
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

    public class Car : Vehicle
    {
        public bool Elbil { get; set; }

        public Car(string regNumber, string color, double size, bool elbil)
            : base(regNumber, color, size)
        {
            Elbil = elbil;
        }
    }
    public class Motorcykel : Vehicle
    {
        public string Marke { get; set; }

        public Motorcykel(string regNumber, string color, double size, string marke)
            : base(regNumber, color, size)
        {
            Marke = marke;
        }

    }

    public class Bus : Vehicle
    {
        public int AntalPassagerare { get; set; }

        public Bus(string regNumber, string color, double size, int antalPassagerare)
            : base(regNumber, color, size)
        {
            AntalPassagerare = antalPassagerare;
        }

    }
}
