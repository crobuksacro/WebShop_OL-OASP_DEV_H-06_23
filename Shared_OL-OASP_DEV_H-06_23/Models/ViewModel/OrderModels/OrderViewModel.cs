using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.Common;
using Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.UserModel;

namespace Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.OrderModels
{
    public class OrderViewModel
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public ApplicationUserViewModel? Buyer { get; set; }
        public AddressViewModel? OrderAddress { get; set; }
        public List<OrderItemViewModel>? OrderItems { get; set; }
    }
}
