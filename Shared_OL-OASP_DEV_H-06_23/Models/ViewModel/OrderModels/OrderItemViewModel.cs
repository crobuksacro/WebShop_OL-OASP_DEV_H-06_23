using Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels;

namespace Shared_OL_OASP_DEV_H_06_23.Models.ViewModel.OrderModels
{
    public class OrderItemViewModel: OrderItemBase
    {
        public long Id { get; set; }
        public long? ProductItemId { get; set; }
    }
}
