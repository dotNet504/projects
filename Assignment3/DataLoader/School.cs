using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader
{
    public class School
    {
        public string name;
        public readonly SchoolType type;
        public string yearEstablished;
        public uint enrolled;
        public enum SchoolType { Elementary, HighSchool, CommunityCollege, University }

        public School(String[] args)
        {

        }
    }
}
