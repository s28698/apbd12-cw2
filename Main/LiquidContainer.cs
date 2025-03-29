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
        double limitFactor = (CargoType == CargoType.Normal) ? 0.9 : 0.5;
        double limitByType = MaxCapacityKg * limitFactor;

        if (CargoMass + mass > limitByType)
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