using SolutionModelLib;
using SolutionModelLib.Enums;
using SolutionModelLib.Exceptions;

namespace ShoppingDALLib
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        async public override Task<Product> Delete(int key)
        {
            var product = await GetByKey(key);
            items.Remove(product);
            return product;
        }

        public override Task<Product> GetByKey(int key)
        {
            Product? product = items.FirstOrDefault(p => p.Id == key);

            return Task.FromResult(product ?? throw new EntityNotFoundException(Entity.Product));
        }

        async public override Task<Product> Update(Product item)
        {
            var product = await GetByKey(item.Id);

            product.Name = item.Name;
            product.Price = item.Price;
            product.QuantityInHand = item.QuantityInHand;
            product.Image = item.Image;

            return product;
        }
    }
}