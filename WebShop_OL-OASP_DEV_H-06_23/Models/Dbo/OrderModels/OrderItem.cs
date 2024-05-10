using Shared_OL_OASP_DEV_H_06_23.Interfaces;
using Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels;
using System.ComponentModel.DataAnnotations;
using WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.ProductModels;

namespace WebShop_OL_OASP_DEV_H_06_23.Models.Dbo.OrderModels
{
    public class OrderItem: OrderItemBase, IBaseTableAtributes
    {
        [Key]
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool Valid { get; set; }
        public ProductItem? ProductItem { get; set; }
        public long? ProductItemId { get; set; }

    }
}
