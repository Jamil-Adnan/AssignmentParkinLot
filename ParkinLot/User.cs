using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkinLot
{
    public class User
    {
        public Transport transport { get; set; }
        public double balance { get; set; }
        public DateTime enterAt { get; set; }
        public string regNummer { get; set; }

        public User(Transport vehicle)// Constructor
        {
            transport = vehicle;
            balance = 0.0;
        }

        public void EnterParking()
        {
            enterAt = DateTime.Now;
            Console.WriteLine($"User with wehicle{transport} with registarion : {regNummer} enterd at :{enterAt}"); // add regnumer???
        }

        public void ExitParking(double pricePerSecond)
        {
            TimeSpan duration = DateTime.Now - enterAt;
            double totalCost = duration.TotalSeconds * pricePerSecond;
            balance -= totalCost;
            Console.WriteLine($"User with {transport} nummer {regNummer} exited. Total cost : {totalCost} SEK ");
        }

    }
}
