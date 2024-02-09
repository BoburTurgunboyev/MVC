using FirstMvcProject.Domain.Entities;
using FirstMvcProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FirstMvcProject.Infrastructure.Repositories.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async ValueTask<bool> CreateProduct(Product product)
        {
            await _appDbContext.Products.AddAsync(product);
            var result = await _appDbContext.SaveChangesAsync();
            return result > 0;
        }

        public async ValueTask<bool> DeleteProduct(int id)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product is null)
            {
                return false;
            }

            _appDbContext.Products.Remove(product);
            var result = await _appDbContext.SaveChangesAsync();
            return result > 0;

        }

        public async ValueTask<List<Product>> GetAllProduct()
        {
            var products = await _appDbContext.Products.ToListAsync();
            return products;
        }

        public async ValueTask<Product> GetByIdProduct(int id)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        public async ValueTask<Product> UpdateProductAsync(int id, Product product)
        {
            var produc = await _appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            _appDbContext.Products.Update(produc);
            await _appDbContext.SaveChangesAsync();
            return produc;



        }

        public async Task<Product> CreateAudit(Product newProduct, Product oldProduct, string actionType, User user)
        {
            var auditTrailRecord = new ProductAudit
            {
                UserName = user.UserName,
                Action = actionType,
                ControllerName = "Product",
                DateTime = DateTime.UtcNow,
                OldValue = JsonConvert.SerializeObject(oldProduct, Formatting.Indented),
                NewValue = JsonConvert.SerializeObject(newProduct, Formatting.Indented)
            };

            _appDbContext.ProductAudits.Add(auditTrailRecord);
            try
            {
                await _appDbContext.SaveChangesAsync();
                return newProduct;
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving audit log.", ex);
            }
        }

        public async Task<Product> GetOldValueAsync(int id) => await _appDbContext.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }
}
