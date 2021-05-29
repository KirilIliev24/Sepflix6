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
            LikedMovies = new HashSet<LikedMovie>();
            MovieReviews = new HashSet<MovieReview>();
            Watchlists = new HashSet<Watchlist>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("title", TypeName = "text")]
        public string Title { get; set; }
        [Column("year")]
        public int Year { get; set; }
        [Column("poster")]
        public string Poster { get; set; }

        [InverseProperty(nameof(LikedMovie.Movie))]
        public virtual ICollection<LikedMovie> LikedMovies { get; set; }
        [InverseProperty(nameof(MovieReview.Movie))]
        public virtual ICollection<MovieReview> MovieReviews { get; set; }
        [InverseProperty(nameof(Watchlist.Movie))]
        public virtual ICollection<Watchlist> Watchlists { get; set; }
    }
}
