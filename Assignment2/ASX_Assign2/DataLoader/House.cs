using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader
{
    //House class, it stores info a house could possess  
    //house class is the son of Residential class 
    public class House : Residential
    {
        //Attributes of the House class
        private bool garage;
        private bool? attachedGarage;
        private uint floors;

        // Property for garage attr
        // allows: set && get
        public bool Garage
        {
            set { garage = value; }
            get { return garage; }
        }
        // Property for attachedGarage attr
        // allows: set && get
        public bool? AttachedGarage
        {
            set { attachedGarage = value; }
            get { return attachedGarage; }
        }
        // Property for floors attr
        // allows: set && get
        public uint Floors
        {
            set { floors = value; }
            get { return floors; }
        }


        // constructor for the House class
        // @params: String Array, broken down within the 
        //          constructor to fill attr values
        //Other fields are filled in its base class
        public House(string[] args) : base(args)
        {

            garage = base.StringToBool(args[12]); //Convert.ToBoolean(args[12]);
            if (garage == false)
                attachedGarage = null;
            else
                attachedGarage = base.StringToBool(args[13]);//Convert.ToBoolean(args[13]);
            floors = Convert.ToUInt32(args[14]);


        }
        // Tostring method for the House class
        // The purpose of the ToString is to output some fields 
        //         and to test whether house class het all the fields
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
