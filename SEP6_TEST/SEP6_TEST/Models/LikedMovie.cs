using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SEP6_TEST.Models
{
    [Table("likedMovies")]
    public partial class LikedMovie
    {
        [Key]
        [Column("likedMovies_id")]
        public int LikedMoviesId { get; set; }
        [Required]
        [Column("username")]
        [StringLength(30)]
        public string Username { get; set; }
        [Column("movie_id")]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("LikedMovies")]
        public virtual Movie Movie { get; set; }
        [ForeignKey(nameof(Username))]
        [InverseProperty(nameof(User.LikedMovies))]
        public virtual User UsernameNavigation { get; set; }
    }
}
