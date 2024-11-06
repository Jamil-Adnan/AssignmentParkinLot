using System.Reflection.Metadata;

namespace ParkinLot
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Parking parking = new Parking(25);
            parking.createParkingLots();
            System.Console.WriteLine(parking.parkingLot.Count());
            
            // Helpers.Usertype();
        }
    }
}
