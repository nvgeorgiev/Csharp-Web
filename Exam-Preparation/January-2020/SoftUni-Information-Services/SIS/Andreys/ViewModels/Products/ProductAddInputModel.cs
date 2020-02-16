namespace Andreys.ViewModels.Products
{
    public class ProductAddInputModel // Copied directly from the Model.Product
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; } // Server wont be able to map the enums so we make them as a string

        public string Gender { get; set; }
    }
}
