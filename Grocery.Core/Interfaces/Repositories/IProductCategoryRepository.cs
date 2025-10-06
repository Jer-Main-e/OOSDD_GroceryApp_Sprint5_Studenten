using Grocery.Core.Models;

public interface IProductCategoryRepository
{
    public ProductCategory Add(ProductCategory item);
    public List<ProductCategory> GetAll();
}