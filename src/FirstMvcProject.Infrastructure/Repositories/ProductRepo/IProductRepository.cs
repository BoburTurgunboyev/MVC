using FirstMvcProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMvcProject.Infrastructure.Repositories.ProductRepo
{
    public interface IProductRepository
    {
        public ValueTask<bool> CreateProduct(Product product);
        public ValueTask<Product> UpdateProductAsync(int id, Product product);
        public ValueTask<bool> DeleteProduct(int id);
        public ValueTask<Product> GetByIdProduct(int id);
        public ValueTask<List<Product>> GetAllProduct();
        public Task<Product> CreateAudit(Product entity, Product oldValue, string actionType, User user);
        public Task<Product> GetOldValueAsync(int id);
    }
}
