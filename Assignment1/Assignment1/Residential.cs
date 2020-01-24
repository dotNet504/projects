using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Residential : Property
    {
        private uint bedrooms;
        private uint baths;
        private uint sqft;

        public Residential(string[] args) : base(args) //modified by Xuezhi, I think this part still has problem
        {
            bedrooms = Convert.ToUInt32(args[9]);
            baths = Convert.ToUInt32(args[10]);
            sqft = Convert.ToUInt32(args[11]);
        }

        public uint Bedrooms
        {
            set { bedrooms = value; }
            get { return bedrooms; }
        }

        public uint Baths
        {
            set { baths = value; }
            get { return baths; }
        }

        public uint Sqft
        {
            set { sqft = value; }
            get { return sqft; }
        }
    }

}
