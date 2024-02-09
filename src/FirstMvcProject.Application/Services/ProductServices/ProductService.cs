using FirstMvcProject.Domain.Entities;
using FirstMvcProject.Infrastructure.Repositories.ProductRepo;

namespace FirstMvcProject.Application.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public ValueTask<bool> CreateProduct(Product product)
        {
            if (product == null)

            {
                throw new ArgumentNullException(nameof(product));
            }
            var productt = new Product()
            {
                Title = product.Title,
                Quantiy = product.Quantiy,
                Price = product.Price,
            };

            try
            {
                var result = _repository.CreateProduct(productt);
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while creating the product.", ex);
            }
        }

        public async ValueTask<bool> DeleteProduct(int id)
        {
            try
            {
                var result = await _repository.DeleteProduct(id);
                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while deleting the task.", ex);
            }
        }

        public async ValueTask<List<Product>> GetAllProduct()
        {
            try
            {
                var result = await _repository.GetAllProduct();
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetProducts: {ex.Message}");
                throw;
            }
        }

        public async ValueTask<Product> GetByIdProduct(int id)
        {
            try
            {
                var result = await _repository.GetByIdProduct(id);
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetByIdProduct: {ex.Message}");
                throw;
            }
        }

        public async ValueTask<Product> UpdateProduct(int id, Product product)
        {
            var result = await _repository.GetByIdProduct(id);


            result.Title = product.Title;
            result.Quantiy = product.Quantiy;
            result.Price = product.Price;
            try
            {
                var res = await _repository.UpdateProductAsync(id, product);
                return res;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error occurred while updating the task.", ex);
            }

        }
    }
}
