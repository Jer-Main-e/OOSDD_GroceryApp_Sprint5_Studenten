using Grocery.Core.Models;

public interface IProductCategoryService
{
    public ProductCategory Add(ProductCategory item);
    public List<ProductCategory> GetAll();
    public List<ProductCategory> GetAllOnCategoryId(int id);
}