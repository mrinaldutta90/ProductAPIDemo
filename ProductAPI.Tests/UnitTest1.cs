using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductAPI.Controllers;
using ProductAPI.Models;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace ProductAPI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        /// <summary>
        /// Deleteing all objects, posts two objects and gets using filters
        /// </summary>
        public void TestMethod_ProductsTesting()
        {
            var controller = new Controllers.ProductsController();
            var payload = controller.Get();
            var conResult = payload as OkNegotiatedContentResult<List<Product>>;

            //Delete All Products
            foreach (var Product in conResult.Content)
            {
                controller.Delete(Product.Id);
            }

            payload = controller.Get();
            conResult = payload as OkNegotiatedContentResult<List<Product>>;

            Assert.AreEqual(conResult.Content.Count, 0);
            Product product1 = new Product { Brand = "Samsung", Description = "Samsung Phone", Model = "Galaxy S8" };
            controller.Post(product1);
            Product product2 = new Product { Brand = "Apple", Description = "Apple Ipad", Model = "Apple Ipad Pro 9.7" };
            controller.Post(product2);

            payload = controller.Get();
            conResult = payload as OkNegotiatedContentResult<List<Product>>;

            Assert.AreEqual(conResult.Content.Count, 2);

           
            payload = controller.Get("Brand", "Samsung");
            conResult = payload as OkNegotiatedContentResult<List<Product>>;

            Assert.AreEqual(conResult.Content.Count, 1);


        }

    }
}
