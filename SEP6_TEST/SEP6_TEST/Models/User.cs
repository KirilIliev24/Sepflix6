using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SEP6_TEST.Models
{
    [Table("user")]
    public partial class User
    {
        public User()
        {
            LikedMovies = new HashSet<LikedMovie>();
            MovieReviews = new HashSet<MovieReview>();
            UserRatings = new HashSet<UserRating>();
            Watchlists = new HashSet<Watchlist>();
        }

        [Key]
        [Column("username")]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [InverseProperty(nameof(LikedMovie.UsernameNavigation))]
        public virtual ICollection<LikedMovie> LikedMovies { get; set; }
        [InverseProperty(nameof(MovieReview.UsernameNavigation))]
        public virtual ICollection<MovieReview> MovieReviews { get; set; }
        [InverseProperty(nameof(UserRating.UsernameNavigation))]
        public virtual ICollection<UserRating> UserRatings { get; set; }
        [InverseProperty(nameof(Watchlist.UsernameNavigation))]
        public virtual ICollection<Watchlist> Watchlists { get; set; }
    }
}
