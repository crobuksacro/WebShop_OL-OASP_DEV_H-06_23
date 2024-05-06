using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_OL_OASP_DEV_H_06_23.Services.Implementations;
using WebShop_OL_OASP_DEV_H_06_23.Services.Interfaces;

namespace WebShop_OL_OASP_DEV_H_06_23.UnitTest
{
    public class ProductServiceUnitTest: WebShopSetup
    {
        private readonly IProductService productService;

        public ProductServiceUnitTest()
        {
            this.productService = GetProductService();
        }



        [Fact]
        public async void GetProductCategories_FetchesAllCategorysBasedOnSearch_ReturnsList()
        {

            var response = await productService.GetProductCategories(1, TestString);

            Assert.NotEmpty(response.ProductCategorys);
            Assert.Single(response.ProductCategorys);

            response = await productService.GetProductCategories(1,offset: 30);

            Assert.NotEmpty(response.ProductCategorys);
            Assert.Equal(30, response.ProductCategorys.Count);


        }

    }
}
