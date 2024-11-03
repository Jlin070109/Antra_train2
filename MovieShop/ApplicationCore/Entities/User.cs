using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(256)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(1024)")]
        public string HashedPassword { get; set; }

        [Column(TypeName = "bit")]
        public bool? isLocked { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(128)")]
        public string LastName { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public string? PhoneNumber { get; set; }

        public string? ProfilePathUrl { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(1024)")]
        public string Salt { get; set; }

        public ICollection<UserRole> UserRoles { get; } = [];

        public ICollection<Favorite> Favorites { get; } = [];

        public ICollection<Review> Reviews { get; } = [];

        public ICollection<Purchase> Purchases { get; } = [];

    }
}
