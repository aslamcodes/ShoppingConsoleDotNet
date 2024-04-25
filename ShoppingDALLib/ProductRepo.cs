using SolutionModelLib;
using SolutionModelLib.Enums;
using SolutionModelLib.Exceptions;

namespace ShoppingDALLib
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        public override Product Delete(int key)
        {
            Product? product = GetByKey(key);
            items.Remove(product);
            return product;
        }

        public override Product GetByKey(int key)
        {
            Product? product = items.FirstOrDefault(p => p.Id == key);

            return product ?? throw new EntityNotFoundException(Entity.Product);
        }

        public override Product Update(Product item)
        {
            Product? product = GetByKey(item.Id);

            product.Name = item.Name;
            product.Price = item.Price;
            product.QuantityInHand = item.QuantityInHand;
            product.Image = item.Image;

            return product;
        }
    }
}