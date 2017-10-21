using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Configuration;
using System.Web.Http;
using System.Web.Http.Results;

namespace ProductAPI.Models
{
    /// <summary>
    /// The Product Class
    /// </summary> 
    public class Product
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }




        /// <summary>
        /// Write the list of products into the the source database/file        
        /// </summary>
        public bool SaveProducts(List<Product> products)
        {
            try
            {            
                
                string productJSON = JsonConvert.SerializeObject(products);
                //write string to file
                System.IO.File.WriteAllText(ConfigurationManager.AppSettings["LocalJSONPath"], productJSON);
                return true;
            }

            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.InnerException);
                return false;

            }
        }



        /// <summary>
        /// Reads the file and returns the list of Products from the object
        /// </summary>
        public List<Product> ReadProducts()
        {
            
            var products = new List<Product>();
            using (StreamReader r = new StreamReader(ConfigurationManager.AppSettings["LocalJSONPath"]))
            {
                string json = r.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<Product>>(json).OrderBy(o=>o.Id).ToList();

            }
            return products;
        }

     

    }

  

 
}