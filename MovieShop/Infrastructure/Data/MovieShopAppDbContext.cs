using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MovieShopAppDbContext: DbContext
    {
        public MovieShopAppDbContext(DbContextOptions<MovieShopAppDbContext> options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCast>()
            .HasKey(mc => new { mc.CastId, mc.MovieId, mc.Character }); // Composite primary key

            modelBuilder.Entity<MovieCast>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.MovieCasts)
                .HasForeignKey(mc => mc.MovieId);
            modelBuilder.Entity<MovieCast>()
                .HasOne(mc => mc.Cast)
                .WithMany(c => c.MovieCasts)
                .HasForeignKey(mc => mc.CastId);
            // Optional: Specify the name of the join table
            modelBuilder.Entity<MovieCast>()
                .ToTable("MovieCasts"); // Name of the table


            modelBuilder.Entity<MovieGenre>()
            .HasKey(mg => new { mg.MovieId, mg.GenreId }); // Composite primary key
            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Movie)
                .WithMany(m => m.MovieGenres)
                .HasForeignKey(mg => mg.MovieId);
            modelBuilder.Entity<MovieGenre>()
                .HasOne(mg => mg.Genre)
                .WithMany(c => c.MovieGenres)
                .HasForeignKey(mg => mg.GenreId);
            // Optional: Specify the name of the join table
            modelBuilder.Entity<MovieGenre>()
                .ToTable("MovieGenres"); // Name of the table


            modelBuilder.Entity<Favorite>()
            .HasKey(f => new { f.MovieId, f.UserId }); // Composite primary key
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Movie)
                .WithMany(m => m.Favorites)
                .HasForeignKey(f => f.MovieId);
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId);
            // Optional: Specify the name of the join table
            modelBuilder.Entity<Favorite>()
                .ToTable("Favorites"); // Name of the table


            modelBuilder.Entity<Purchase>()
            .HasKey(f => new { f.MovieId, f.UserId }); // Composite primary key
            modelBuilder.Entity<Purchase>()
                .HasOne(f => f.Movie)
                .WithMany(m => m.Purchases)
                .HasForeignKey(f => f.MovieId);
            modelBuilder.Entity<Purchase>()
                .HasOne(f => f.User)
                .WithMany(u => u.Purchases)
                .HasForeignKey(f => f.UserId);
            // Optional: Specify the name of the join table
            modelBuilder.Entity<Purchase>()
                .ToTable("Purchases"); // Name of the table


            modelBuilder.Entity<Review>()
            .HasKey(f => new { f.MovieId, f.UserId }); // Composite primary key
            modelBuilder.Entity<Review>()
                .HasOne(f => f.Movie)
                .WithMany(m => m.Reviews)
                .HasForeignKey(f => f.MovieId);
            modelBuilder.Entity<Review>()
                .HasOne(f => f.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(f => f.UserId);
            // Optional: Specify the name of the join table
            modelBuilder.Entity<Review>()
                .ToTable("Reviews"); // Name of the table


            modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId }); // Composite primary key
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);
            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
            // Optional: Specify the name of the join table
            modelBuilder.Entity<UserRole>()
                .ToTable("UserRoles"); // Name of the table
        }


        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
