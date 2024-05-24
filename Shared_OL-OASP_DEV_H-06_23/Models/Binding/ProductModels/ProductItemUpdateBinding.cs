using Shared_OL_OASP_DEV_H_06_23.Models.Base.ProductModels;
using System.ComponentModel.DataAnnotations;

namespace Shared_OL_OASP_DEV_H_06_23.Models.Binding.ProductModels
{
    public class ProductItemUpdateBinding: ProductItemBase
    {
        public long Id { get; set; }

        [Display(Name = "Mjerna jedinica")]
        public long? QuantityTypeId { get; set; }
    }
}
