using ShoppingWebsite.Models;

namespace ShoppingWebsite.Repository
{
    public interface IProductRepository
    {
        void Create(Products product);
        void Update(Products product, int productsId);
        void Delete(int productId);
        List<Products> GetList();
        Products GetById(int id);
    }
}