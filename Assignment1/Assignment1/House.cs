using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class House : Residential
    {
        private bool garage;
        private bool attachedGarage;
        private uint floors;


        public bool Garage
        {
            set { garage = value; }
            get { return garage; }
        }

        public bool AttachedGarage
        {
            set { attachedGarage = value; }
            get { return attachedGarage; }
        }

        public uint Floors
        {
            set { floors = value; }
            get { return floors; }
        }

        /*
         * unique ID | ownerID | x | y | streetAddr | city | state | zip |
         * forSale | bedrooms | baths | sqft | garage | attachedGarage | floors
         */
        /*
         * 98213	0	250	250	6000 Mayor St.	DeKalb	Illinois	
         * 60115	F	3	2	5000	T	T	2
        */
 
        public House(string[] args):base(args)
        {
           
            garage = base.StringToBool(args[12]); //Convert.ToBoolean(args[12]);
            attachedGarage = base.StringToBool(args[13]);//Convert.ToBoolean(args[13]);
            floors = Convert.ToUInt32(args[14]);


        }
        
        public override string ToString()
        {
            string ret = String.Format("Id    : {0 , -10 }\n", Id);
            ret += String.Format("OwnerID  : {0}\n", OwnerID);
            ret += String.Format("Forsale   : {0}\n", ForSale);
            ret += String.Format("garage   : {0}\n", Garage);
            ret += String.Format("Floors   : {0}\n", floors);

            return ret;
        }
    }
}
