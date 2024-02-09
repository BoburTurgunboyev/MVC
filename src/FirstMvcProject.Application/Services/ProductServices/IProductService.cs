using FirstMvcProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMvcProject.Application.Services.ProductServices
{
    public interface IProductService
    {
        public ValueTask<bool> CreateProduct(Product product);
        public ValueTask<Product> UpdateProduct(int id, Product product);
        public ValueTask<bool> DeleteProduct(int id);
        public ValueTask<Product> GetByIdProduct(int id);
        public ValueTask<List<Product>> GetAllProduct();
    }
}
