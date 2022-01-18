using System;
using System.Collections.Generic;
using System.Text;

namespace Társalgó
{
    class Artist
    {
        public Artist(int iD)
        {
            ID = iD;
            Count = 1;
        }

        public int ID { get; set; }
        public int Count { get; set; }
    }
}
