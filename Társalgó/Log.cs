using System;
using System.Collections.Generic;
using System.Text;

namespace Társalgó
{
    class Log
    {
        public Log(int óra, int perc, int iD, bool directionIsInside)
        {
            Óra = óra;
            Perc = perc;
            ID = iD;
            DirectionIsInside = directionIsInside;
        }

        public int Óra { get; set; }
        public int Perc { get; set; }
        public int ID { get; set; }
        public bool DirectionIsInside { get; set; }
    }
}
