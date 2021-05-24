using System;
using System.Collections.Generic;

#nullable disable

namespace SEP6_TEST.Models
{
    public partial class Rating
    {
        public int MovieId { get; set; }
        public double Rating1 { get; set; } = 0.0;
        public int Votes { get; set; } = 0;
    }
}
