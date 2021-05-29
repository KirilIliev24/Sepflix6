using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SEP6_TEST.Models
{
    [Table("ratings")]
    public partial class Rating
    {
        [Column("movie_id")]
        public int MovieId { get; set; }
        [Column("rating")]
        public double Rating1 { get; set; }
        [Column("votes")]
        public int Votes { get; set; }
        [Key]
        [Column("rating_Id")]
        public int RatingId { get; set; }
    }
}
