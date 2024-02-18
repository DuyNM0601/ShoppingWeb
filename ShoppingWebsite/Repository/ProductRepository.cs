using ShoppingWebsite.Data;
using ShoppingWebsite.Models;

namespace ShoppingWebsite.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext myDb;

        public ProductRepository(MyDbContext myDbContext)
        {
            myDb = myDbContext;
        }
        public void Create(Products product)
        {
            myDb.Products.Add(product);
        }

        public void Delete(int productId)
        {
            var checkDb = myDb.Products.FirstOrDefault(c => c.ProductId == productId);
            if (checkDb != null)
            {
                myDb.Products.Remove(checkDb);

            }
        }

        public Products GetById(int productId)
        {
            return myDb.Products.FirstOrDefault(c => c.ProductId == productId);
        }

        public List<Products> GetList()
        {
            return myDb.Products.ToList();
        }

        public void Update(Products product, int productsId)
        {
            var checkDb = myDb.Products.FirstOrDefault(c => c.ProductId == productsId);
            if (checkDb != null)
            {
                checkDb.ProductName = product.ProductName;
                checkDb.SublierId = product.SublierId;
                checkDb.CategoryId = product.CategoryId;
                checkDb.QuantityPerUnit = product.QuantityPerUnit;
                checkDb.UnitPrice = product.UnitPrice;
                checkDb.ProductImage = product.ProductImage;

            }
        }
    }
}