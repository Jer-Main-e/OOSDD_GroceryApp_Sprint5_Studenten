using CommunityToolkit.Mvvm.Input;
using Grocery.App.ViewModels;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;
using Grocery.App.Views;

public partial class CategoriesViewModel : BaseViewModel
{
    private readonly ICategoryService _categoryService;
    public ObservableCollection<Category> Categories { get; set; }

    public CategoriesViewModel(ICategoryService categoryService)
    {
        _categoryService = categoryService;
        Categories = new(_categoryService.GetAll());
    }
    [RelayCommand]
    public async Task SelectProductCategory(Category category)
    {
        Dictionary<string, object> paramater = new() { { nameof(Category), category } };
        await Shell.Current.GoToAsync($"{nameof(ProductCategoriesView)}", true, paramater);
    }
}
