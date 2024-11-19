using ParkinLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ParkingSpace
{
    public bool IsPremium { get; set; }
    public List<Vehicle> Vehicles { get; set; }
    public double OccupiedSpace { get; private set; }

    public ParkingSpace(bool isPremium)
    {
        IsPremium = isPremium;
        Vehicles = new List<Vehicle>();
        OccupiedSpace = 0;
    }

    public bool CanPark(Vehicle vehicle)
    {
        return OccupiedSpace + vehicle.Size <= 1.0;
    }

    public void ParkVehicle(Vehicle vehicle)
    {
        Vehicles.Add(vehicle);
        OccupiedSpace += vehicle.Size;
    }

    public void RemoveVehicle(Vehicle vehicle)
    {
        Vehicles.Remove(vehicle);
        OccupiedSpace -= vehicle.Size;
    }

}

public class Parking
{
    public int TotalParking { get; private set; }
    public List<ParkingSpace> ParkingLot { get; private set; }
    public double Income { get; private set; } = 0;
    public int PremiumSpaces { get; private set; }
    public double PricePerSecond = 1.5;
    public double PremiumMultiplier = 2; 

    public Parking(int parkingAmount, int premiumSpaces)
    {
        TotalParking = parkingAmount;
        PremiumSpaces = premiumSpaces;
        ParkingLot = new List<ParkingSpace>();
        CreateParkingLots();
    }

    private void CreateParkingLots()
    {
        for (int i = 0; i < TotalParking; i++)
        {
            bool isPremium = i < PremiumSpaces;
            ParkingLot.Add(new ParkingSpace(isPremium));
        }
    }

    public bool ParkVehicle(Vehicle vehicle)
    {
        double spacesNeeded = vehicle.Size;
        List<int> notPremiumAvailableSpaces = FindAvailableSpaces(vehicle);
        List<int> premiumAvailableSpaces = FindPremiumAvailableSpaces(vehicle);

        if (premiumAvailableSpaces.Count != 0)
        {
            System.Console.WriteLine($"Do you want premuim place? It costs 50% more.\n[1] Yes \n[2] No");
            var choice = int.Parse(Console.ReadLine().Trim());
            if (choice == 1)
            {
                ParkingLot[premiumAvailableSpaces[0]].ParkVehicle(vehicle);
                return true;
            }
        }
        

        if (notPremiumAvailableSpaces.Count >= spacesNeeded)
        {
            for (int i = 0; i < spacesNeeded; i++)
            {   
                ParkingLot[notPremiumAvailableSpaces[i]].ParkVehicle(vehicle);
                if (spacesNeeded == 2.0){
                    ParkingLot[notPremiumAvailableSpaces[i+1]].ParkVehicle(vehicle);
                }
            }
            Console.WriteLine($"Vehicle with registration number {vehicle.RegNumber}is parked on Parking number {notPremiumAvailableSpaces[0] + 1}" +
                              $"{(spacesNeeded > 1 ? $" and {notPremiumAvailableSpaces[1] + 1}" : "")}. " +
                              $"{(ParkingLot[notPremiumAvailableSpaces[0]].IsPremium ? "Premium parking." : "Standard parking.")}");
            return true;
        }

        Console.WriteLine($"Sorry. The parking is full for your type of vehicle.");
        return false;
    }

    private List<int> FindAvailableSpaces(Vehicle vehicle)
    {
        List<int> availableSpaces = new List<int>();

        for (int i = 0; i < ParkingLot.Count; i++)
        {
            if (ParkingLot[i].CanPark(vehicle) && !ParkingLot[i].IsPremium)
            {
                availableSpaces.Add(i);
            }
        }

        return availableSpaces;
    }
    private List<int> FindPremiumAvailableSpaces(Vehicle vehicle)
    {
        List<int> availableSpaces = new List<int>();

        for (int i = 0; i < ParkingLot.Count; i++)
        {
            if (vehicle.Size == 1.0 && ParkingLot[i].CanPark(vehicle) && ParkingLot[i].IsPremium)
            {
                availableSpaces.Add(i);
            }
        }

        return availableSpaces;
    }

    public void ViewParkingSlots()
    {
        if (ParkingLot.All(space => space.Vehicles.Count == 0))
        {
            Console.WriteLine("The parking lot is empty.");
            return;
        }

        for (int i = 0; i < ParkingLot.Count; i++)
        {
            var space = ParkingLot[i];
            if (space.Vehicles.Count > 0)
            {
                Console.WriteLine($"Parking number {i + 1} ({(space.IsPremium ? "Premium" : "Standard")}):");
                foreach (var vehicle in space.Vehicles)
                {
                    Console.WriteLine($"   Information:");                    
                    Console.WriteLine($"    Registration Number: {vehicle.RegNumber}");
                    Console.WriteLine($"    Color: {vehicle.Color}");
                    Console.WriteLine($"    Arrival Time: {vehicle.ArrivalTime}");
                    
                    if (vehicle.ExitTime.HasValue)
                    {
                        Console.WriteLine($"    Time Left: {GetTimespan(vehicle)} seconds");
                    }
                    else
                    {
                        Console.WriteLine("    Exit Time: Not exited yet");
                    }

                    if (vehicle.ticketFee > 0)
                    {
                        Console.WriteLine($"    Fee: {vehicle.ticketFee}");
                    }
                    
                    Console.WriteLine();
                }
            }
        }
    }

    public Vehicle FindVehicleByRegNumber(string regNumber)
    {
        if (string.IsNullOrWhiteSpace(regNumber))
        {
            throw new ArgumentException("Registration number cannot be null or empty.", nameof(regNumber));
        }

        regNumber = regNumber.Trim();

        foreach (var space in ParkingLot)
        {
            var vehicle = space.Vehicles.FirstOrDefault(v => v.RegNumber == regNumber);
            if (vehicle != null)
            {
                return vehicle;
            }
        }

        return null;
    }

    public void ExitVehicle(string regNumber)
    {
        var vehicle = FindVehicleByRegNumber(regNumber);
        if (vehicle != null)
        {
            var spaces = ParkingLot.Where(s => s.Vehicles.Contains(vehicle)).ToList();
            foreach (var space in spaces)
            {
                space.RemoveVehicle(vehicle);
            }


            
            double fee = PricePerSecond * Math.Abs(GetTimespan(vehicle));
            if (spaces[0].IsPremium)
            {
                fee *= PremiumMultiplier;
            }


            Income += fee + vehicle.ticketFee;

            Console.WriteLine($"Vehicle with registration number {regNumber} has left the parking. \nParking fee: {fee:C} \nFine: {vehicle.ticketFee:C}\nTotal amount: {fee+vehicle.ticketFee:C}\n");
        }
        else
        {
            Console.WriteLine($"There is no vehicle found with the registration number {regNumber}");
        }
    }

    public double GetTimespan(Vehicle vehicle)
    {
        var timeNow = DateTime.Now;
        TimeSpan diff = vehicle.ExitTime.Value - timeNow;
        return Math.Floor(diff.TotalSeconds);
    }
}