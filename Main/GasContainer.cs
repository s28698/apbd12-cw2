using ConsoleApp2.Main.Interfaces;

namespace ConsoleApp2.Main;

public class GasContainer : Container, IHazardNotifier
{
    public double AtmosphericPressure { get; set; }
    public GasContainer(double cargoMass, double heightCm, double selfWeight, double depthCm, double maxCapacityKg, double atmosphericPressure) : base(cargoMass, heightCm, selfWeight, depthCm, maxCapacityKg, "G")
    {
        AtmosphericPressure = atmosphericPressure;
    }
    
    public void SendHazardNotification(string s)
    {
        Console.WriteLine($"[HazardNotification] {s}");
    }
    
    public override void LoadCargo(double mass)
    {
        if (CargoMass + mass > MaxCapacityKg)
        {
            SendHazardNotification($"Próba przekroczenia ładowności w kontenerze (Serial: {SerialNumber}).");
            throw new OverfillException($"Przekroczono maksymalną ładowność ({MaxCapacityKg} kg) w GasContainer.");
        }

        base.LoadCargo(mass);
    }
    
    
    public override void UnloadCargo()
    {
        if (CargoMass > 0)
        {
            CargoMass *= 0.05;
        }
    }
}