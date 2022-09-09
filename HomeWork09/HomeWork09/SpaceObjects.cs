using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork09
{
    internal class SpaceObjects
    {
        public string name;
                
        public virtual string About()
        {
            string info="";
            return info;
        }
    }

    class Star : SpaceObjects
    {
        public int temperature;

        public Star(string name, int temperature)
        {
            this.name = name;
            this.temperature = temperature;
        }
        public override string About()
        {
            return "This is star called " + name + ", its temperature is " + temperature;
        }

    }
    class Planet : SpaceObjects
    {
        Moon[] moons;
        
        
        public Planet(string name)
        {
            this.name = name;
            moons = new Moon[0];
        }

        public Planet(string[] pl )
        {
            this.name = pl[0];
            moons = new Moon[pl.Length - 1];
            for (int i = 0; i < pl.Length-1; i++)
            {
                moons[i] = new Moon(pl[i+1], name);
            }
        }

        public Planet(string name, string[] m)
        {
            this.name=name;
            moons = new Moon[m.Length];
            for (int i = 0; i < m.Length; i++)
            {
                moons[i] = new Moon(m[i], name); 
            }
        }
        public override string About()
        {
            string info = "This is planet " + name;
            if (moons.Length == 0)
            {
                return info + " without any moon";
            }
            else
            {
                if (moons.Length == 1)
                    info = info + ", it has moon called " + moons[0].name;

                else
                {
                    info = info + ", it has several moons: ";
                    for (int i = 0; i < moons.Length; i++)
                    {
                        info += moons[i].name + " ";
                    }
                }
                return info;
            }
            
        }
    }

    class Moon : SpaceObjects
    {
        public string basePlanetName;

        public Moon(string name, string basePlanetName)
        {
            this.name = name;
            this.basePlanetName = basePlanetName;
        }

        public override string About()
        {
            return "This is moon called " + name + ", its base planet is " + basePlanetName;
        }
    }
}
