using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader
{
    public class Business : Property
    {
        private String name;
        private readonly BusinessType type; //?????????
        private readonly string yearEstablished;
        private uint activeRecruitment;
        public enum BusinessType { Grocery, Bank, Repair, FastFood, DepartmentStore };

        public Business(String[] args) : base(args)
        {
            name = args[9];
            //type = ((BusinessType) args[10]).ToString();
            yearEstablished = args[11];
            activeRecruitment = Convert.ToUInt32(args[12]);

        }

        public String Name
        {
            set { name = value; }
            get { return name; }
        }

        //public String Type
        //{
        //    get { return type; }
        //}

        public String YearEstablished
        {
            get { return yearEstablished; }
        }

        public uint ActiveRecruitment
        {
            set { activeRecruitment = value; }
            get { return activeRecruitment; }
        }
    }
}
