using Application.Data;
using ApplicationService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Application.WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        private IProductService productservice = new ProductService();

        //Called from routeTemplate: "api/{controller}/{action}/{id}",
        public IEnumerable<Product> GetProducts()
        {
            return productservice.GetProducts();
        }

        public IEnumerable<Product> Get()
        {
            return productservice.GetProducts();
        }

        //Called from routeTemplate: "api/{controller}/{action}/{id}",
        public IHttpActionResult GetProduct(int id)
        {
            var product = productservice.GetProduct(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        public IHttpActionResult Get(int id)
        {
            var product = productservice.GetProduct(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        public IHttpActionResult Post(Product product)
        {
            var issave = productservice.SaveProduct(product);
            if (issave == true)
                return Ok();
            return BadRequest();
        }

        public IHttpActionResult Put(Product product)
        {
            var isupdated = productservice.UpdateProduct(product.Id,product);
            if (isupdated == true)
                return Ok();
            return BadRequest();
        }

        public IHttpActionResult Delete(int id)
        {
            var isdeleted = productservice.DeleteProduct(id);
            if (isdeleted == true)
                return Ok();
            return BadRequest();
        }
    }
}
