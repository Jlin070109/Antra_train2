using ApplicationCore.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace MovieShop.Models
{
    public class PurchaseModel
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

    public class PurchaseModelValidator: AbstractValidator<PurchaseModel>
    {
        public PurchaseModelValidator()
        {
            RuleFor(x=>x.PurchaseDateTime.Date).GreaterThanOrEqualTo(DateTime.Now.Date);
        }
    }
}