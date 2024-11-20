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
        if (IsPremium)
        {
            return vehicle.Size == 1.0 && OccupiedSpace == 0;
        }
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
        var (standardSpaces, premiumSpaces) = FindAvailableSpaces(vehicle);

        if (vehicle is Car && premiumSpaces.Count > 0)
        {
            Console.WriteLine("Do you want a premium parking space? It costs 50% more.");
            Console.WriteLine("[1] Yes");
            Console.WriteLine("[2] No");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice == 1)
            {
                ParkInSpace(vehicle, premiumSpaces[0], true);
                
                return true;
            }
        }

        if (standardSpaces.Count >= vehicle.Size)
        {
            double remainingSize = vehicle.Size;
            foreach (int spaceIndex in standardSpaces)
            {
                double availableSpace = 1.0 - ParkingLot[spaceIndex].OccupiedSpace;
                double sizeTopark = Math.Min(remainingSize, availableSpace);
            
                ParkInSpace(vehicle, spaceIndex, false);
                remainingSize -= sizeTopark;
                if (remainingSize <= 0) break;
            }
            return true;
        }

        Console.WriteLine("Sorry, the parking is full for your type of vehicle.");
        return false;
    }

    private void ParkInSpace(Vehicle vehicle, int spaceIndex, bool isPremium)
    {
        ParkingLot[spaceIndex].ParkVehicle(vehicle);
        string parkingType = isPremium ? "Premium" : "Standard";
        Console.WriteLine($"Your vehicle with registration number {vehicle.RegNumber} is parked in {parkingType} space {spaceIndex + 1}.");
    }

    private (List<int> standardSpaces, List<int> premiumSpaces) FindAvailableSpaces(Vehicle vehicle)
    {
        List<int> standardSpaces = new List<int>();
        List<int> premiumSpaces = new List<int>();

        for (int i = 0; i < ParkingLot.Count; i++)
        {
            if (ParkingLot[i].CanPark(vehicle))
            {
                if (ParkingLot[i].IsPremium)
                {
                    premiumSpaces.Add(i);
                }
                else
                {
                    standardSpaces.Add(i);
                }
            }
            // For buses, we need to ensure two adjacent spaces`
            if (vehicle.Size == 2.0)
            {
                if (i < ParkingLot.Count - 1 && 
                        !ParkingLot[i].IsPremium && !ParkingLot[i + 1].IsPremium &&
                        ParkingLot[i].OccupiedSpace == 0 && ParkingLot[i + 1].OccupiedSpace == 0)
                    {
                        standardSpaces.Add(i);
                        standardSpaces.Add(i+1);
                        i++; // Skip the next space as it's part of the bus parking
                    }
            }
        }


        return (standardSpaces, premiumSpaces);
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
                    Console.WriteLine($"   Information: {vehicle.GetType().Name} with Registration Number {vehicle.RegNumber}");
                    Console.WriteLine($"   Color: {vehicle.Color}");
                    Console.WriteLine($"   Arrival Time: {vehicle.ArrivalTime}");
                    
                    if (vehicle.ExitTime.HasValue)
                    {
                        Console.WriteLine($"   Time Left: {GetTimespan(vehicle)} seconds");
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
            if (vehicle.Size == 2.0){fee *= 2.0;}
            if (spaces[0].IsPremium)
            {
                fee *= PremiumMultiplier;
            }


            Income += fee + vehicle.ticketFee;

            Console.WriteLine($"Vehicle with registration number {regNumber} is checking out. \nParking fee: {fee:C} \nFine: {vehicle.ticketFee:C}\nTotal amount to pay is : {fee+vehicle.ticketFee:C}\n");
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