using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.App.ViewModels;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Services;
using System.Collections.ObjectModel;

[QueryProperty(nameof(Category), nameof(Category))]
public partial class ProductCategoriesViewModel : BaseViewModel
{
    private readonly IProductCategoryService _productCategoryService;
    private readonly IProductService _productService;
    private string searchText = "";
    public ObservableCollection<ProductCategory> ProductCategories { get; set; } = [];
    public ObservableCollection<Product> AvailableProducts { get; set; } = [];

    [ObservableProperty]
    Category category;
    public ProductCategoriesViewModel(IProductCategoryService productCategoryService, IProductService productService)
    {
        _productCategoryService = productCategoryService;
        _productService = productService;
    }
    partial void OnCategoryChanged(Category? oldValue, Category newValue)
    {
        ProductCategories.Clear();
        List<ProductCategory> list = _productCategoryService.GetAllOnCategoryId(newValue.Id);
        foreach (var item in list)
        {
            ProductCategories.Add(item);
        }
    }
    private void GetAvailableProducts()
    {
        AvailableProducts.Clear();
        foreach (Product p in _productService.GetAll())
            if (ProductCategories.FirstOrDefault(p => p.ProductId == p.Id) == null && p.Stock > 0 && (searchText == "" || p.Name.ToLower().Contains(searchText.ToLower())))
                AvailableProducts.Add(p);
    }
    [RelayCommand]
    public void AddProduct(Product product) 
    {

    }
    
    [RelayCommand]
    public void PerformSearch(string searchText)
    {
        this.searchText = searchText;
        GetAvailableProducts();
    }
}
