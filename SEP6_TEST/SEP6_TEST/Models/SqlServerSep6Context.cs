using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SEP6_TEST.Models
{
    public partial class SqlServerSep6Context : DbContext
    {
        public SqlServerSep6Context()
        {
        }

        public SqlServerSep6Context(DbContextOptions<SqlServerSep6Context> options)
            : base(options)
        {
        }

        public virtual DbSet<LikedMovie> LikedMovies { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MovieReview> MovieReviews { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Watchlist> Watchlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=35.240.12.17;Initial Catalog=SqlServerSep6;User ID=sqlserver;Password=kiril2403;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<LikedMovie>(entity =>
            {
                entity.HasKey(e => e.LikedMoviesId)
                    .HasName("PK__likedMov__4A6AC53F947648D5");

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.LikedMovies)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__likedMovi__movie__57DD0BE4");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.LikedMovies)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__likedMovi__usern__56E8E7AB");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MovieReview>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PK__movieRev__60883D90DC7491D2");

                entity.Property(e => e.ReviewText).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieReviews)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__movieRevi__movie__5BAD9CC8");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.MovieReviews)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__movieRevi__usern__5AB9788F");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__user__F3DBC573EC90BE72");

                entity.Property(e => e.Username).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);
            });

            modelBuilder.Entity<Watchlist>(entity =>
            {
                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Watchlists)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__watchlist__movie__503BEA1C");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Watchlists)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__watchlist__usern__4F47C5E3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
