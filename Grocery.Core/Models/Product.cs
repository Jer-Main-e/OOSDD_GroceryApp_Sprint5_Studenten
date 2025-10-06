using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public partial class Product : Model
    {
        [ObservableProperty]
        public int stock;
        public DateOnly ShelfLife { get; set; }
        [ObservableProperty]
        public decimal price;
        public Product(int id, string name, int stock, decimal price) : this(id, name, stock, default, price) { }

        public Product(int id, string name, int stock, DateOnly shelfLife, decimal price) : base(id, name)
        {
            Stock = stock;
            ShelfLife = shelfLife;
            Price = price;
        }
        public override string? ToString()
        {
            return $"{Name} - {Stock} op voorraad";
        }
    }
}
