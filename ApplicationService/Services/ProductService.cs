using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Application.Data;
using System.Data;

namespace ApplicationService.Services
{
    public class ProductService : IProductService
    {
        private ProductDbEntities db = new ProductDbEntities();

        public bool DeleteProduct(int id)
        {
            try
            {
                var product = db.Products.Where(x => x.Id == id).FirstOrDefault();
                if (product == null) return false;
                db.Entry(product).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public Product GetProduct(int id)
        {
            return db.Products.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public bool SaveProduct(Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateProduct(int id, Product product)
        {
            try
            {
                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}