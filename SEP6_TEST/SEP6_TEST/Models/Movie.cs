using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SEP6_TEST.Models
{
    [Table("movies")]
    public partial class Movie
    {
        public Movie()
        {
            MovieReviews = new HashSet<MovieReview>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("title", TypeName = "text")]
        public string Title { get; set; }
        [Column("year")]
        public int Year { get; set; }

        [InverseProperty(nameof(MovieReview.Movie))]
        public virtual ICollection<MovieReview> MovieReviews { get; set; }
    }
}
