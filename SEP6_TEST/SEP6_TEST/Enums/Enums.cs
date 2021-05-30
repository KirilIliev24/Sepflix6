using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_TEST.Enums
{
    public enum CrewJobs
    {
        [Description("Executive Producer")] ExecutiveProducer = 1,
        [Description("Costume Design")] CostumeDesign = 2,
        [Description("Producer")] Producer = 3,
        [Description("Director")] Director = 4
    }

    public enum OrderMovies
    {
        [Description("None")] None = 1,
        [Description("High To Low")] HighToLow = 2,
        [Description("Low To High")] LowToHigh = 3
    }
}
