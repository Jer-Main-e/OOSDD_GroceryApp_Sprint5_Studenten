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
        foreach(var item in _productCategoryService.GetAllOnCategoryId(newValue.Id))
        {
            ProductCategories.Add(item);
        }
        GetAvailableProducts();

    }
    private void GetAvailableProducts()
    {
        AvailableProducts.Clear();
        var productCategoryIds = new HashSet<int>(ProductCategories.Select(pc => pc.ProductId));
        var allProducts = _productService.GetAll();

        var filteredProducts = allProducts
            .Where(p => p.Stock > 0
                && !productCategoryIds.Contains(p.Id)
                && (string.IsNullOrEmpty(searchText) || p.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase)));

        foreach (var product in filteredProducts)
        {
            AvailableProducts.Add(product);
        }
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
