using System;

namespace ShoppingCartApp
{
    public enum ProductCategory
    {
        Clothing,
        Electronics,
        Home,
        Beauty,
        Groceries
    }

    public class Product
    {
        private string name;
        private double price;
        private ProductCategory category;

        public string Name { get { return name; } }
        public double Price { get { return price; } }
        public ProductCategory Category { get { return category; } }

        public Product(string name, double price, ProductCategory category)
        {
            this.name = name;
            this.price = price;
            this.category = category;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine($"Name: {name}, Price: {price}, Category: {category}");
        }
    }

    public class ClothingProduct : Product
    {
        private readonly string size;
        private readonly string color;

        public string Size { get { return size; } }
        public string Color { get { return color; } }

        public ClothingProduct(string name, double price, ProductCategory category, string size, string color)
            : base(name, price, category)
        {
            this.size = size;
            this.color = color;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Size: {size}, Color: {color}");
        }
    }

    public class ElectronicsProduct : Product
    {
        private readonly string brand;
        private readonly string model;

        public string Brand { get { return brand; } }
        public string Model { get { return model; } }

        public ElectronicsProduct(string name, double price, ProductCategory category, string brand, string model)
            : base(name, price, category)
        {
            this.brand = brand;
            this.model = model;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Brand: {brand}, Model: {model}");
        }
    }

    public class ShoppingCart
    {
        private readonly Product[] products;
        private int itemCount;

        public Product[] Products { get { return products; } }
        public int ItemCount { get { return itemCount; } }

        public ShoppingCart(int capacity)
        {
            products = new Product[capacity];
            itemCount = 0;
        }

        public void AddProduct(Product product)
        {
            if (itemCount < products.Length)
            {
                products[itemCount] = product;
                itemCount++;
            }
            else
            {
                Console.WriteLine("The shopping cart is full.");
            }
        }

        public void RemoveProduct(Product product)
        {
            for (int i = 0; i < itemCount; i++)
            {
                if (products[i] == product)
                {
                    // Shift elements to fill the gap
                    for (int j = i; j < itemCount - 1; j++)
                    {
                        products[j] = products[j + 1];
                    }
                    products[itemCount - 1] = null; // Remove reference to the last element
                    itemCount--;
                    return;
                }
            }
            Console.WriteLine("Product not found in the shopping cart.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example usage
            ShoppingCart cart = new ShoppingCart(5);

            ClothingProduct shirt = new ClothingProduct("T-Shirt", 19.99, ProductCategory.Clothing, "M", "Blue");
            ElectronicsProduct phone = new ElectronicsProduct("Smartphone", 599.99, ProductCategory.Electronics, "Apple", "iPhone 13");

            cart.AddProduct(shirt);
            cart.AddProduct(phone);

            Console.WriteLine("Products in the shopping cart:");
            foreach (Product product in cart.Products)
            {
                if (product != null)
                {
                    product.GetInfo();
                }
            }
        }
    }
}
