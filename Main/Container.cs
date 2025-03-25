namespace ConsoleApp2.Main;

public class Container
{
    public double CargoMass { get; set; }
    public double HeightCm { get; set; }
    public double SelfWeight { get; set; }
    public double DepthCm { get; set; }
    public string SerialNumber { get;}
    public double MaxCapacityKg { get; set; }

    public Container(double cargoMass, double heightCm, double selfWeight, double depthCm, double maxCapacityKg, string containterTypeCode)
    {
        CargoMass = cargoMass;
        HeightCm = heightCm;
        SelfWeight = selfWeight;
        DepthCm = depthCm;
        MaxCapacityKg = maxCapacityKg;
        
        SerialNumber = GeneratorSerialNumber.GenerateSerialNumber(containterTypeCode);
    }

    public virtual void LoadCargo(double mass)
    {
        if (CargoMass + mass > MaxCapacityKg)
        {
            throw new OverfillException($"Przekroczono pojemność kontenera ({MaxCapacityKg} kg).");
        }
        else
        {
            CargoMass += mass;
        }
    }

    public void UnloadCargo()
    {
        CargoMass = 0;
    }
}