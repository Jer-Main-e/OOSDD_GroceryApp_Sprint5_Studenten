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
        //BoughtProductsList.Clear();
        //List<BoughtProducts> list = _boughtProductsService.Get(newValue.Id);
        //foreach (var item in list)
        //{
        //    BoughtProductsList.Add(item);
        //}
    }
    private void GetAvailableProducts()
    {

    }
    [RelayCommand]
    public void AddProduct(Product product) { }
    [RelayCommand]
    public void PerformSearch(string searchText) { }
}
