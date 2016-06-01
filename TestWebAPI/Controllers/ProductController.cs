using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestWebAPI.Models;

namespace TestWebAPI.Controllers
{
    public class ProductController : ApiController
    {
        Product[] prods = new Product[]
        {
            new Product {Id = 1, Name = "Tomato", Category = "Groceries", Price = 1},
            new Product {Id = 2, Name = "Yo-Yo", Category = "Toys", Price = 3.75M},
            new Product {Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M},
            new Product {Id = 4, Name = "Pliers", Category = "Hardware", Price = 15.95M}
        };

        [Route("api/products/all")]
        [HttpGet]
        public HttpResponseMessage GetProductsList()
        {
            IEnumerable<Product> pList = prods;

            if (pList != null)
            {
                return Request.CreateResponse<IEnumerable<Product>>(HttpStatusCode.OK, pList);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [Route("api/product/{id}")]
        [HttpGet]
        public HttpResponseMessage GetVerfiedShipperList(int id)
        {
            var product = prods.FirstOrDefault((p) => p.Id == id);

            if (product != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
