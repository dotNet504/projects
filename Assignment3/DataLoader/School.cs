using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader
{
    public class School : Property
    {
        private string name;
        private readonly SchoolType type;
        private string yearEstablished;
        private uint enrolled;
        public enum SchoolType { Elementary, HighSchool, CommunityCollege, University }

        public School(string[] args) : base(args)
        {
            name = args[9];
            yearEstablished = args[10];
            enrolled = Convert.ToUInt32(args[11]);
        }

        public String Name
        {
            set { name = value; }
            get { return name; }
        }

        public String YearEstablished
        {
            get { return yearEstablished; }
        }

        public uint Enrolled
        {
            set { enrolled = value; }
            get { return enrolled; }
        }
    }
}
