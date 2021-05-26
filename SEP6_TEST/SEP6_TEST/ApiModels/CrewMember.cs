using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_TEST.ApiModels
{
    public class CrewMember
    {
        public int id { get; set; }
        public string name { get; set; }
        public string profile_path { get; set; }
        public string job { get; set; }
    }
}
