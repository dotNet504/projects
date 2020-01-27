using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    //Swathi - made class public due to visibility issue in Community class
    public class Property : IComparable
    {
        private readonly uint id;
        private uint ownerID;
        private readonly uint x;
        private readonly uint y;
        private string streetAddr;
        private string city;
        private string state;
        private string zip;
        private bool forSale;

        private uint addressNumer;
        private string addressStreetName;


        public Property()
        {
            id = 0;
            ownerID = 0;
            x = 0;
            y = 0;
            streetAddr = "";
            city = "";
            state = "";
            zip = "";
            forSale = false;
        }

        public bool StringToBool(string boolString)
        {
            bool trueorfalse;
            if (boolString.CompareTo("T") ==0 )
            {
                trueorfalse = true;
            }
            else
            {
                trueorfalse = false;
            }
            return trueorfalse;

        }
        public Property(string[] args)
        {
  
  
            id = Convert.ToUInt32(args[0]);
            ownerID = Convert.ToUInt32(args[1]);
            x = Convert.ToUInt32(args[2]);
            y = Convert.ToUInt32(args[3]);
            streetAddr = args[4];
            city = args[5]; 
            state = args[6]; 
            zip = args[7];
            forSale = StringToBool(args[8]); //Convert.ToBoolean(args[8]); 

            string[] addressStringArr = streetAddr.Split();
            addressNumer = Convert.ToUInt32(addressStringArr[0]);
            addressStreetName = addressStringArr[1] + " " + addressStringArr[2];




        }

        public int CompareTo(Object alpha)
        {


            if (alpha == null) throw new ArgumentNullException("Person object being compared with is NULL");

            Property rightOp = alpha as Property;


            if (rightOp != null)
            {
                if ( State.CompareTo(rightOp.State) == 0)
                {
                    if (City.CompareTo(rightOp.City) == 0)
                    {
                        if (AddressStreetName.CompareTo(rightOp.AddressStreetName) == 0)
                        {
                            if (AddressNumer.CompareTo(rightOp.AddressNumer) == 0)
                            {
                                return 0;
                            }
                            else
                                return AddressNumer.CompareTo(rightOp.AddressNumer);
                        }
                        else
                            return AddressStreetName.CompareTo(rightOp.AddressStreetName);


                    }
                    else
                        return City.CompareTo(rightOp.City);
                }

                else 
                    return State.CompareTo(rightOp.State);
            }
            else
                throw new ArgumentNullException("Person object being compared with is NULL");
            //return 0;
        }

        public uint Id =>id; 

        public uint OwnerID
        {
            set { ownerID = value; }
            get => ownerID;
        }

        public uint X => x;

        public uint Y => y;

        public string StreetAddr
        {
            set { streetAddr = value; }
            get => streetAddr;
        }
        public string City
        {
            set { city = value; }
            get => city;
        }
        public string State
        {
            set { state = value; }
            get => state;
        }
        public string Zip
        {
            set { zip = value; }
            get => zip; 
        }
        public bool ForSale
        {
            set { forSale = value; }
            get { return forSale; }
        }


        public uint AddressNumer
        {
            set { addressNumer = value; }
            get { return addressNumer;  }
        }

        public string AddressStreetName
        {
            set { addressStreetName = value; }
            get { return addressStreetName; }
        }


    }
}
