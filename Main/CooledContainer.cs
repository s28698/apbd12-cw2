using ConsoleApp2.Main.Enums;
using System;

namespace ConsoleApp2.Main;

public class CooledContainer : Container
{
    
    private static Dictionary<ProductType, double> requiredTemperatures = new Dictionary<ProductType, double>
        {
            { ProductType.Bananas, 13.3 },
            { ProductType.Chocolate, 18 },
            { ProductType.Fish, 2 },
            { ProductType.Meat, -15 },
            { ProductType.IceCream, -18 },
            { ProductType.FrozenPizza, -30 },
            { ProductType.Cheese, 7.2 },
            { ProductType.Sausages, 5 },
            { ProductType.Butter, 20.5 },
            { ProductType.Eggs, 19 },
        };
    public double ContainerTemperature { get; set; }
    public ProductType? CurrentProductType { get; set; }

    public CooledContainer(double cargoMass, double heightCm, double selfWeight, double depthCm, double maxCapacityKg, double containerTemperature) : base(cargoMass, heightCm, selfWeight, depthCm, maxCapacityKg, "C")
    {
        ContainerTemperature = containerTemperature; 
    }
    
    public void LoadProduct(double mass, ProductType productType)
    {
        if (!CurrentProductType.HasValue)
        {
            CurrentProductType = productType;

            double required = requiredTemperatures[productType];
            if (ContainerTemperature < required)
            {
                throw new Exception($"Kontener ma temperaturę {ContainerTemperature}°C, a {productType} wymaga co najmniej {required}\u00b0C.");
            }
        }
        else
        {
            if (CurrentProductType.Value != productType)
            {
                throw new Exception($"Kontener chłodniczy może przechowywać wyłącznie produkty typu {CurrentProductType.Value}. Nie można dodać {productType}");
            }
        }

        base.LoadCargo(mass);
    }

    public void SetContainerTemperature(double newTemperature)
    {
        if (CurrentProductType.HasValue)
        {
            double required = requiredTemperatures[CurrentProductType.Value];
            if (newTemperature < required)
            {
                throw new Exception($"Nowa temperatura {newTemperature}\u00b0C jest zbyt niska dla produktu {CurrentProductType.Value} (wymagane minimum: {required}\u00b0C).");
            }
        }

        ContainerTemperature = newTemperature;
    }
}