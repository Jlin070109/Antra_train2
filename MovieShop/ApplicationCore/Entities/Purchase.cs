using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [PrimaryKey(nameof(MovieId), nameof(UserId))]
    public class Purchase
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime PurchaseDateTime { get; set; }

        [Required]
        [Column(TypeName = "decimal(3,2)")]
        public Decimal TotalPrice { get; set; }

        [Required]
        [Column(TypeName = "uniqueidentifier")]
        public Guid PurchaseNumber { get; set; }
    }
}
