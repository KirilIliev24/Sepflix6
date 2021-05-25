using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace SEP6_TEST.Models
{
    [Table("movieReview")]
    public partial class MovieReview
    {
        [Key]
        [Column("review_id")]
        public int ReviewId { get; set; }
        
        [Column("user_id")]
        public int UserId { get; set; }
        
        [Column("movie_id")]
        public int MovieId { get; set; }
        
        [Column("reviewText")]
        [StringLength(255)]
        public string ReviewText { get; set; }
        
        [Column("rating", TypeName = "decimal(10, 1)")]
        public decimal? Rating { get; set; }
        
        [Column("votes")]
        public int? Votes { get; set; }

        [ForeignKey(nameof(MovieId))]
        [InverseProperty("MovieReviews")]
        public virtual Movie Movie { get; set; }
        
        [ForeignKey(nameof(UserId))]
        [InverseProperty("MovieReviews")]
        public virtual User User { get; set; }
    }
}
