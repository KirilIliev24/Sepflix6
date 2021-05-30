using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SEP6_TEST.Models
{
    [Table("userRating")]
    public partial class UserRating
    {
        [Key]
        [Column("userRating_Id")]
        public int UserRatingId { get; set; }
        [Required]
        [Column("username")]
        [StringLength(30)]
        public string Username { get; set; }
        [Column("movie_id")]
        public int MovieId { get; set; }
        [Column("ratingGiven")]
        public int RatingGiven { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("UserRatings")]
        public virtual Movie Movie { get; set; }
        [ForeignKey(nameof(Username))]
        [InverseProperty(nameof(User.UserRatings))]
        public virtual User UsernameNavigation { get; set; }
    }
}
