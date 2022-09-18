using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork15
{
    public class Rocket
    {
        public string Name;
        public int NumOfStages;
        public IEngine[] engine;// { get; set; }
        public IBody body;
        public IFuelReservoir[] fuelReservoir;

        public Rocket (string name, int stages, IEngine[] engines, IBody bodies, IFuelReservoir[] fuelReservoirs)
        {
            this.Name = name;
            this.NumOfStages = stages;
            engine = new IEngine[stages];
            this.body = bodies;
            fuelReservoir = new IFuelReservoir[stages];
            for (int i = 0; i < stages; i++)
            {
                this.engine[i] = engines[i];
                this.fuelReservoir[i] = fuelReservoirs[i];
            }
        }

        public Rocket(string[] inform)
        {
            this.Name = inform[0];
            if (inform[1] == "SB") this.body = new SmallBody();
            if (inform[1] == "MB") this.body = new MiddleBody();
            if (inform[1] == "BB") this.body = new BigBody();
            this.NumOfStages = Convert.ToInt32(inform[2]);
            
            fuelReservoir = new IFuelReservoir[NumOfStages];
            engine = new IEngine[NumOfStages];
            
            for (int i = 0; i < NumOfStages; i++)
            {
                if (inform[i + 3] == "RE") this.engine[i] = new ReactiveEngine();
                if (inform[i + 3] == "DE") this.engine[i] = new DetonationEngine() ;
                if (inform[i + 3] == "PE") this.engine[i] = new PlasmaEngine();
            }
            for (int i = 0; i < NumOfStages; i++)
            {
                if (inform[i + 3 + NumOfStages] == "SR") this.fuelReservoir[i] = new SmallReservoir();
                if (inform[i + 3 + NumOfStages] == "MR") this.fuelReservoir[i] = new MiddleReservoir();
                if (inform[i + 3 + NumOfStages] == "BR") this.fuelReservoir[i] = new BigReservoir();
            }

        }
        public string CanFly () // to do
           {
            double a = 0, b;
            for (int i = 0; i < NumOfStages; i++)
            {
                a += engine[i].Power * fuelReservoir[i].FuelVolume;
            }
            b = CommonWeight() / a * 1000;
            if (b < 1) return "This rocket can fly!";
            else return "This rocket can't fly!";
        }
        public double CommonWeight ()
        {
            double w = body.Weight;
            for (int i = 0; i < NumOfStages; i++)
            {
                w += engine[i].Weight;
                w += fuelReservoir[i].Weight;
                w += fuelReservoir[i].FuelVolume * engine[i].FuelWeight;
            }
            
            return w;
        }
        public double MaxSpeed()
        {
            double speed = 0;
            for (int i = 0; i < NumOfStages; i++)
            {
                speed += engine[i].Power * fuelReservoir[i].FuelVolume;
            }
            return Math.Round(speed/CommonWeight(),1);
        }
        public int CountCost()
        {
            int count = body.Cost;
            for (int i = 0; i < NumOfStages; i++)
            {
                count += engine[i].Cost + fuelReservoir[i].Cost;
                count += engine[i].FuelCost * fuelReservoir[i].FuelVolume;
            }
            return count;
        }
        public string Info()     
        {
            StringBuilder enginfo = new StringBuilder();
            enginfo.Append("Engines:\n");
            for (int i = 0; i < NumOfStages; i++)
            {
                enginfo.Append((i+1).ToString() + ". " + engine[i].Info() + "\n");
            }
            StringBuilder reservoirinfo = new StringBuilder();
            reservoirinfo.Append("Fuel containers:\n");
            for (int i = 0; i < NumOfStages; i++)
            {
                reservoirinfo.Append((i+1).ToString() + ". "+ fuelReservoir[i].Info() + "\n");
            }

                return "This rocket's name is " + Name + ". \nAmount of stages: " + NumOfStages +"\n" 
                    + enginfo + reservoirinfo + body.Info() +"\n"+ "This rocket costs " + CountCost() +
                    "\nMax speed of this rocket is " + MaxSpeed() + "\n" + CanFly();
        }

    }
}
