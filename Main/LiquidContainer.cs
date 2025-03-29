using ConsoleApp2.Main.Enums;
using ConsoleApp2.Main.Interfaces;

namespace ConsoleApp2.Main;

public class LiquidContainer : Container, IHazardNotifier
{
    public CargoType CargoType { get; set; }
    
    public LiquidContainer(double cargoMass, double heightCm, double selfWeight, double depthCm, double maxCapacityKg) : base(cargoMass, heightCm, selfWeight, depthCm, maxCapacityKg, "L")
    {
        CargoType = CargoType.Normal;
    }
    

    public void SendHazardNotification(string s)
    {
        Console.WriteLine($"[HazardNotification] {s}");
    }

    public override void LoadCargo(double mass)
    {
        double LimitByType = 0;
        if (CargoType == CargoType.Normal)
        {
            LimitByType = CargoMass * 0.9;
        }
        else if (CargoType == CargoType.Hazardous)
        {
            LimitByType = CargoMass * 0.5;
        }

        if (CargoMass + mass > LimitByType)
        {
            SendHazardNotification($"Próba przekroczenia limitu dla ładunku {CargoType} | ${SerialNumber}");
            throw new OverflowException("Przekroczono limit");
        }
        
        base.LoadCargo(mass);
    }
    
    public void SetCargoType(CargoType type)
    {
        CargoType = type;
    }
    
    
    
}