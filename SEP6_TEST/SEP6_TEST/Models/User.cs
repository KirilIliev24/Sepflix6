﻿using System;
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
            MovieReviews = new HashSet<MovieReview>();
        }

        [Key]
        [Column("username")]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [InverseProperty(nameof(MovieReview.UsernameNavigation))]
        public virtual ICollection<MovieReview> MovieReviews { get; set; }
    }
}
