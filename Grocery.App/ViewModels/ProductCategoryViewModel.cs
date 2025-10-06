using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;
using Grocery.App.ViewModels;

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
    public ProductCategoriesViewModel(IProductCategoryService productCategoryService, IProductService productService) { }
    partial void OnCategoryChanged(Category? oldValue, Category newValue) { }
    private void GetAvailableProducts() { }
    [RelayCommand]
    public void AddProduct(Product product) { }
    [RelayCommand]
    public void PerformSearch(string searchText) { }
}
