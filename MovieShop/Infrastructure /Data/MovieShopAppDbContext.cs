using ApplicationCore.entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Trailer> Trailers { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<MovieCrew> MovieCrews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite Key for MovieGenre
            modelBuilder.Entity<MovieGenre>()
                .HasKey(mg => new { mg.MovieId, mg.GenreId });

            // Composite Key for MovieCast
            modelBuilder.Entity<MovieCast>()
                .HasKey(mc => new { mc.MovieId, mc.CastId });

            // Composite Key for UserRole
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            // Composite Key for Review
            modelBuilder.Entity<Review>()
                .HasKey(r => new { r.MovieId, r.UserId });

            // Composite Key for Favorite
            modelBuilder.Entity<Favorite>()
                .HasKey(f => new { f.MovieId, f.UserId });

            // Composite Key for MovieCrew
            modelBuilder.Entity<MovieCrew>()
                .HasKey(mc => new { mc.MovieId, mc.CrewId });

            base.OnModelCreating(modelBuilder);
        }
    }
}