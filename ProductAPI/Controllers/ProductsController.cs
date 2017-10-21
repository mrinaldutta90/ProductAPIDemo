using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [BasicAuthentication]
    public class ProductsController : ApiController
    {
        // GET api/products

        /// <summary>
        /// Returns the list of all products from the database
        /// </summary>
        
        public IHttpActionResult Get()
        {
            var products = new Product().ReadProducts();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        /// <summary>
        /// Returns the list of all products from the database based on filter criteria
        /// </summary>
        public IHttpActionResult Get(string filter, string filtervalue)
        {
            var products = new Product().ReadProducts();
            List<Product> filteredProducts = new List<Product>();

            if (filter=="Brand")
            
                filteredProducts = products.FindAll(product => product.Brand == filtervalue);
            
            else if (filter == "Description")

                filteredProducts= products.FindAll(product => product.Description == filtervalue);

            else if (filter == "Model")

                filteredProducts= products.FindAll(product => product.Model == filtervalue);

            if (filteredProducts == null)
            {
                return NotFound();
            }
            return Ok(filteredProducts);
        }

        // GET api/products/5
        /// <summary>
        /// Returns a product from the database/file based on the ID passed to it
        /// </summary>
        public IHttpActionResult  Get(string id)
        {
            var product = new Product().ReadProducts().FirstOrDefault(i => i.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/products
        /// <summary>
        ///Posts a Product object to the database/file 
        /// </summary>
        public IHttpActionResult Post([FromBody]Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var products = new List<Product>();
            products = new Product().ReadProducts();

            // Fetching the maximum product ID and incrementing it, if no Products exist setting the first product ID as 1
            if ((products == null)||products.Count==0)
            {
                products = new List<Product>();
                product.Id = "1"; 
            }
            else
            {
                product.Id = Convert.ToString(Convert.ToInt32(products.OrderByDescending(item => item.Id).First().Id) + 1);
            }

            products.Add(product);
            bool response = new Product().SaveProducts(products);

            if (response)
                return Ok();
            else
                return BadRequest("Error Updating List of Products");


        }

        // PUT api/products/5

        /// <summary>
        /// Updates a product object -In this case deleted the object with the ID of the object passed and creates a new object with the new details
        /// </summary>
        public IHttpActionResult Put([FromBody]Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var products = new List<Product>();
            products = new Product().ReadProducts();
            products.RemoveAll(x => x.Id == product.Id);
            products.Add(product);
            bool response = new Product().SaveProducts(products);

            if (response)
                return Ok();
            else
                return BadRequest("Error Updating List of Products");


        }

        // DELETE api/products/5
        /// <summary>
        /// Deletes a product object from the database based on the id passed to it.
        /// </summary>
        public IHttpActionResult Delete(string id)
        {
            var products = new Product().ReadProducts();
            products.RemoveAll(x => x.Id == id);
            bool response = new Product().SaveProducts(products);

            if (response)
                return Ok();
            else
                return BadRequest("Error Updating List of Products");
        }


    }
}
