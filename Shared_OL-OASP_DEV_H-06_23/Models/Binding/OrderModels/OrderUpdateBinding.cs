using Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.Common;

namespace Shared_OL_OASP_DEV_H_06_23.Models.Binding.OrderModels
{
    public class OrderUpdateBinding: OrderBase
    {
        public long Id { get; set; }
        public AddressUpdateBinding? OrderAddress { get; set; }
        public List<OrderItemUpdateBiding>? OrderItemIds { get; set; }
    }
}
