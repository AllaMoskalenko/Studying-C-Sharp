using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15
{
    public interface IEngine
    {
        int Weight { get; set; }
        int Power { get; set; }
        int Cost { get; set; }
        double FuelWeight { get; set; } //massa topliva na 1 ob'ema
        int FuelCost { get; set; }
        double CommonWeight();
        string Info();
    }

    public interface IBody
    {
        int Weight { get; set; }
        int Cost { get; set; }
        int NumOfAstronauts { get; set; }
        double CommonWeight();
        string Info();

    }

    public interface IFuelReservoir
    {
        int Weight { get; set; }
        int Cost { get; set; }
        int FuelVolume { get; set; }
        double CommonWeight();
        string Info();

    }
}
