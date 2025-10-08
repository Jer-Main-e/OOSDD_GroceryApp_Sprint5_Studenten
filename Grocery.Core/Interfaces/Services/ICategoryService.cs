using Grocery.Core.Models;

public interface ICategoryService
{
    public Category? Get(int id);
    public List<Category> GetAll();
}