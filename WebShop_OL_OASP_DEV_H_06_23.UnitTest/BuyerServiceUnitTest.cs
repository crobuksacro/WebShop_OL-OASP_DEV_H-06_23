using Shared_OL_OASP_DEV_H_06_23.Models.Binding.OrderModels;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.UnitTest
{
    public class BuyerServiceUnitTest : WebShopSetup
    {
        private readonly IBuyerService buyerService;

        public BuyerServiceUnitTest()
        {
            this.buyerService = GetBuyerService();
        }



        [Fact]
        public async void Order_GeneratesNewOrder_ReturnsViewModel()
        {

            var result = await buyerService.Order(new OrderBinding
            {
                Message = TestString,
                OrderAddress = new Shared_OL_OASP_DEV_H_06_23.Models.Binding.Common.AddressBinding
                {
                    City = TestString,
                    Country = TestString,
                    Number = TestString,
                    Street = TestString
                },
                OrderItems = ProductCategories[0].ProductItems.Select(y => new OrderItemBiding
                {
                    ProductItemId = y.Id,
                    Quantity = 5

                }).ToList()
            }, Buyer); ;

            Assert.NotNull(result);
        }



    }
}
