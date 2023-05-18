using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kektura
{
    internal class Szakasz
    {
        int sorzsam;
        string leiras;
        double tavolsag;
        int magassag;
        int teljeseites;

        public Szakasz(int sorzsam, string leiras, double tavolsag, int magassag, int teljeseites)
        {
            this.sorzsam = sorzsam;
            this.leiras = leiras;
            this.tavolsag = tavolsag;
            this.magassag = magassag;
            this.teljeseites = teljeseites;
        }

        public int Sorzsam { get => sorzsam; }
        public string Leiras { get => leiras; }
        public double Tavolsag { get => tavolsag; }
        public int Magassag { get => magassag; }
        public int Teljeseites { get => teljeseites; }

        public string nehezseg(Szakasz ut)
        {
            if (ut.tavolsag > 9)
            {
                return "Nehéz";
            }
            else if (ut.magassag < 6)
            {
                return "Könnyű";
            }
            else
            {
                return "Közepes";
            }
        }
    }
}
