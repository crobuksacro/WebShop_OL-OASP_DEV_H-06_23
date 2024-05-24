using Shared_OL_OASP_DEV_H_06_23.Models.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared_OL_OASP_DEV_H_06_23.Models.Base.ProductModels
{
    public abstract class ProductItemBase
    {
        [Required]
        [StringLength(200, MinimumLength = 10)]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "decimal(9,2)")]
        public decimal Quantity { get; set; }
        [Display(Name="Mjerna jedinica")]
        public QuantityType? QuantityType { get; set; }
    }
}
