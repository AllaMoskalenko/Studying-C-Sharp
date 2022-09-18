using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15
{
    public class ReactiveEngine : IEngine
    {
        public int Weight { get; set; }
        public int Power { get; set; }
        public int Cost { get; set; }
        public double FuelWeight { get; set; }
        public int FuelCost { get; set; }
        public ReactiveEngine() 
        {
            Weight = 300;
            Power = 10000;
            Cost = 900000;
            FuelWeight = 1;
            FuelCost = 180;
        }
        public double CommonWeight()
        {
            return Weight;
        }
        public string Info()
        {
            return "Reactive Engine is pushing the rocket. ";
        }
        public override string ToString()
        {
            return "ReactiveEngine";
        }
    }

    public class DetonationEngine : IEngine
    {
        public int Weight { get; set; }
        public int Power { get; set; }
        public int Cost { get; set; }
        public double FuelWeight { get; set; }
        public int FuelCost { get; set; }
        public DetonationEngine()
        {
            Weight = 800;
            Power = 25000;
            Cost = 3900000;
            FuelWeight = 4;
            FuelCost = 200;
        }
        public double CommonWeight()
        {
            return Weight;
        }
        public string Info()
        {
            return "Detonation Engine is halping to jump. ";
        }
        public override string ToString()
        {
            return "DetonationEngine";
        }
    }

    public class PlasmaEngine : IEngine
    {
        public int Weight { get; set; }
        public int Power { get; set; }
        public int Cost { get; set; }
        public double FuelWeight { get; set; }
        public int FuelCost { get; set; }
        public PlasmaEngine ()
        {
            Weight = 200;
            Power = 5000;
            Cost = 450000;
            FuelWeight = 0.4;
            FuelCost = 150;
        }
        public double CommonWeight()
        {
            return Weight;
        }
        public string Info()
        {
            return "The rocket moves with the Plasma Engine. ";
        }
        public override string ToString()
        {
            return "PlasmaEngine";
        }
    }

    public class SmallBody : IBody
    {
        public int Weight { get; set; }
        public int Cost { get; set; }
        public int NumOfAstronauts { get; set; }

        public SmallBody ()
        {
            Weight = 1000;
            Cost = 150000;
            NumOfAstronauts = 1;
        }
        public double CommonWeight()
        {
            return (Weight + 95);
        }
        public string Info()
        {
            return "Only one astronaut in this rocket. ";
        }
        public override string ToString()
        {
            return "SmallBody";
        }
    }

    public class MiddleBody : IBody
    {
        public int Weight { get; set; }
        public int Cost { get; set; }
        public int NumOfAstronauts { get; set; }

        public MiddleBody()
        {
            Weight = 5000;
            Cost = 300000;
            NumOfAstronauts = 3;
        }
        public double CommonWeight()
        {
            return (Weight + 285);
        }
        public string Info()
        {
            return "Three astronauts are needed to service this rocket. ";
        }
        public override string ToString()
        {
            return "MiddleBody";
        }
    }

    public class BigBody : IBody
    {
        public int Weight { get; set; }
        public int Cost { get; set; }
        public int NumOfAstronauts { get; set; }

        public BigBody()
        {
            Weight = 15000;
            Cost = 500000;
            NumOfAstronauts = 10;
        }
        public double CommonWeight()
        {
            return (Weight + 950);
        }
        public string Info()
        {
            return "Ten astronauts are needed to service this rocket. ";
        }
        public override string ToString()
        {
            return "BigBody";
        }
    }

    public class SmallReservoir : IFuelReservoir
    {
        public int Weight { get; set; }
        public int Cost { get; set; }
        public int FuelVolume { get; set; }

        public SmallReservoir()
        {
            Weight = 700;
            Cost = 7000;
            FuelVolume = 200;
        }
        public  double CommonWeight()
        {
            return Weight;
        }
        public string Info()
        {
            return "Reservoir contains 200t of fuel. ";
        }
        public override string ToString()
        {
            return "SmallReservoir";
        }
    }
    public class MiddleReservoir : IFuelReservoir
    {
        public int Weight { get; set; }
        public int Cost { get; set; }
        public int FuelVolume { get; set; }

        public MiddleReservoir()
        {
            Weight = 1000;
            Cost = 15000;
            FuelVolume = 500;
        }
        public double CommonWeight()
        {
            return Weight;
        }
        public string Info()
        {
            return "Reservoir contains 500t of fuel. ";
        }
        public override string ToString()
        {
            return "MiddleReservoir";
        }
    }
    public class BigReservoir : IFuelReservoir
    {
        public int Weight { get; set; }
        public int Cost { get; set; }
        public int FuelVolume { get; set; }

        public BigReservoir()
        {
            Weight = 3500;
            Cost = 35000;
            FuelVolume = 1500;
        }
        public double CommonWeight()
        {
            return Weight;
        }
        public string Info()
        {
            return "Reservoir contains 1500l of fuel. ";
        }
        public override string ToString()
        {
            return "BigReservoir";
        }
    }

}
