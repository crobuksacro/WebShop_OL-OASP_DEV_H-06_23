using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.UserModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels;

namespace Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.OrderModels
{
    public class OrderViewModel: OrderBase
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public ApplicationUserViewModel? Buyer { get; set; }
        public AddressViewModel? OrderAddress { get; set; }
        public List<OrderItemViewModel>? OrderItems { get; set; }
        [Required(ErrorMessage = "Total price is required.")]
        [Column(TypeName = "decimal(7, 2)")]
        public decimal Total { get; set; }
    }
}
