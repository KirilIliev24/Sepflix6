using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SEP6_TEST.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }

        [NotMapped]
        public Rating rating { get; set; }
    }
}
