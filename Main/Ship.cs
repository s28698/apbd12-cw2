namespace ConsoleApp2.Main;

using System;
using System.Collections.Generic;
using System.Linq;


public class Ship
{
    public int MaxContainers { get; set; }
    public double MaxTransportMassTons { get; set; }
    public string Name { get; set; }
    public double MaxSpeedKnots { get; set; }

    private  List<Container> containers = new List<Container>();
    
    public Ship(string name, double maxSpeedKnots, int maxContainers, double maxTransportMassTons)
    {
        Name = name;
        MaxSpeedKnots = maxSpeedKnots;
        MaxContainers = maxContainers;
        MaxTransportMassTons = maxTransportMassTons;
    }
    
    public void AddContainer(Container container)
    {
        if (containers.Count >= MaxContainers)
        {
            throw new Exception($"Nie można dodać kontenera: przekroczono limit {MaxContainers} kontenerów dla statku {Name}.");
        }

        double currentMassKg = GetTotalMassOfAllContainersKg();
        double newTotalMassKg = currentMassKg + container.SelfWeight + container.CargoMass;

        if (newTotalMassKg > MaxTransportMassTons * 1000)
        {
            throw new Exception($"Nie można dodać kontenera: masa przekracza maksymalny limit {MaxTransportMassTons} ton.");
        }

        if (containers.Any(c => c.SerialNumber == container.SerialNumber))
        {
            throw new Exception($"Kontener {container.SerialNumber} jest już na statku {Name}.");
        }

        containers.Add(container);
    }
    
    public void RemoveContainer(string containerSerialNumber)
    {
        var container = containers.FirstOrDefault(c => c.SerialNumber == containerSerialNumber);
        if (container == null)
        {
            throw new Exception($"Nie znaleziono kontenera o numerze {containerSerialNumber} na statku {Name}.");
        }

        containers.Remove(container);
    }
    
    public void ReplaceContainer(string existingSerialNumber, Container newContainer)
    {
        RemoveContainer(existingSerialNumber);

        AddContainer(newContainer);
    }
    
    public void MoveContainerTo(Ship targetShip, string containerSerialNumber)
    {
        var container = containers.FirstOrDefault(c => c.SerialNumber == containerSerialNumber);
        if (container == null)
        {
            throw new Exception($"Kontener {containerSerialNumber} nie istnieje na statku {Name}.");
        }

        targetShip.AddContainer(container);
        
        containers.Remove(container);
    }
    
    public void UnloadContainer(string containerSerialNumber)
    {
        var container = containers.FirstOrDefault(c => c.SerialNumber == containerSerialNumber);
        if (container == null)
        {
            throw new Exception($"Kontener {containerSerialNumber} nie istnieje na statku {Name}.");
        }

        container.UnloadCargo();
    }
    
    public void ShowShipInfo()
    {
        Console.WriteLine($"=== Statek: {Name} ===");
        Console.WriteLine($"Maks. prędkość: {MaxSpeedKnots} węzłów");
        Console.WriteLine($"Limit kontenerów: {MaxContainers}");
        Console.WriteLine($"Limit masy (tony): {MaxTransportMassTons}");
        Console.WriteLine($"Aktualnie kontenerów: {containers.Count}");
        Console.WriteLine($"Całkowita masa kontenerów (kg): {GetTotalMassOfAllContainersKg()}");

        Console.WriteLine("Lista kontenerów:");
        foreach (var c in containers)
        {
            Console.WriteLine($" - {c.SerialNumber}, SelfWeight={c.SelfWeight} kg, CargoMass={c.CargoMass} kg");
        }
        Console.WriteLine("=======================");
    }
    
    public double GetTotalMassOfAllContainersKg()
    {
        double sum = 0;
        foreach (var container in containers)
        {
            sum += container.SelfWeight + container.CargoMass;
        }
        return sum;
    }
}