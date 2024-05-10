using Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels;
using Shared_OL_OASP_DEV_H_06_23.Models.Binding.Common;

namespace Shared_OL_OASP_DEV_H_06_23.Models.Binding.OrderModels
{
    public class OrderBinding: OrderBase
    {
        public AddressBinding? OrderAddress { get; set; }
        public List<long>? OrderItemIds { get; set; }
    }
}
