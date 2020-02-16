using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader
{
    public class Business : Property
    {
        public String name;
        public readonly BusinessType type; //?????????
        public readonly string yearEstablished;
        public uint activeRecruitment;
        public enum BusinessType { Grocery, Bank, Repair, FastFood, DepartmentStore };

        public Business(String[] args){
            name = args[0];
            yearEstablished = args[1];
            activeRecruitment = Convert.ToUInt32(args[2]);

        }

        public String Name
        {
            set { Name = value; }
            get { return Name; }
        }

        public String YearEstablished //?????????????
        {
            //set { Name = value; }
            get { return YearEstablished; }
        }
    }
}
