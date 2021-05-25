using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SEP6_TEST.Models
{
    [Keyless]
    [Table("likedMovies")]
    public partial class LikedMovie
    {
        [Required]
        [Column("username")]
        [StringLength(30)]
        public string Username { get; set; }
        [Column("movie_id")]
        public int MovieId { get; set; }

        [ForeignKey(nameof(MovieId))]
        public virtual Movie Movie { get; set; }
        [ForeignKey(nameof(Username))]
        public virtual User UsernameNavigation { get; set; }
    }
}
