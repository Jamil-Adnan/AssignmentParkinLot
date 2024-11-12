using System.Reflection.Metadata;

namespace ParkinLot
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Parking parkingHouse = new Parking();
            List<Transport> vehicles = new List<Transport>
            {
                //  Gabi skapa några vehicle här och testa om det fungerar
            };

            foreach (Transport vehicle in vehicles)
            {
                if (parkingHouse.ParkVehicle(vehicle, out int? parkingNumber))
                {
                    if (vehicle is Buss)
                    {
                        Console.WriteLine($"{vehicle.GetType().Name} Vänligen parkera på parkering plats {parkingNumber}-{parkingNumber + 1}");
                    }
                    Console.WriteLine($"{vehicle.GetType().Name} Vänligen  parkera på parkerings plats  {parkingNumber}");
                }
                else
                {
                    Console.WriteLine($"{vehicle.GetType().Name} Parkeringen är fullt för denna typ av vehiecle.");
                }
            }
            parkingHouse.DisplayParkingStatus();   //Gabi!!!!   du kan använda sammamethod DisplayParkingStatus som ligger i parking class from din Vaktare class. 









            ///Gamla code. Låt stå
            /*
            Parking parking = new Parking(25);
            parking.createParkingLots();
            System.Console.WriteLine(parking.parkingLot.Count());
            */
            // Helpers.Usertype();
        }
    }
}
