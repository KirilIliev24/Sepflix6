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
                entity.HasKey(e => e.LikedId)
                    .HasName("PK__likedMov__CAA59091B5BFED9B");

                entity.Property(e => e.LikedId).ValueGeneratedNever();

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.LikedMovies)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__likedMovi__movie__2DE6D218");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.LikedMovies)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__likedMovi__usern__2CF2ADDF");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MovieReview>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PK__movieRev__60883D901AF4A952");

                entity.Property(e => e.ReviewId).ValueGeneratedNever();

                entity.Property(e => e.ReviewText).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.MovieReviews)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__movieRevi__movie__31B762FC");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.MovieReviews)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__movieRevi__usern__30C33EC3");
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
                entity.Property(e => e.WatchlistId).ValueGeneratedNever();

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Watchlists)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__watchlist__movie__2B0A656D");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Watchlists)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__watchlist__usern__2A164134");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
