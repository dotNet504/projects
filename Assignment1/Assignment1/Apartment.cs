using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Apartment : Resident 
    {
        private string unit;


        public string Unit
        {
            set { unit = value; }
            get { return unit; }
        }
        public Apartment(string[] args) : base(args)
        {
            unit = args[12];
        }
        public override string ToString()
        {
            string ret = String.Format("Id         : {0 , -10 }\n", Id);
            ret += String.Format("OwnerID  : {0}\n", OwnerID);
            ret += String.Format("Unit   : {0}\n", unit);
            return ret;
        }



    }
}
