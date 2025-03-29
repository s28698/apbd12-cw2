

using ConsoleApp2.Main;
using ConsoleApp2.Main.Enums;

var shipA = new Ship("EverGreen", 25, 5, 10);
var shipB = new Ship("BlackPearl", 30, 3, 5);

var liquid = new LiquidContainer(210, 160, 320, 1200, 10000);
liquid.LoadCargo(500);
shipA.AddContainer(liquid);

var gas = new GasContainer(180, 120, 250, 800, 20000, 2);
gas.LoadCargo(200);
shipB.AddContainer(gas);

shipA.ShowShipInfo();
shipB.ShowShipInfo();

shipB.UnloadContainer(gas.SerialNumber);
shipB.ShowShipInfo();

var cooled = new CooledContainer(200, 150, 300, 1000, 50000, 2);
cooled.LoadProduct(200, ProductType.Fish);
shipA.AddContainer(cooled);
shipA.ShowShipInfo();

shipA.MoveContainerTo(shipB, cooled.SerialNumber);
shipB.ShowShipInfo();

