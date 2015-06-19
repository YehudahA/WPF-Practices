using System.Collections.Generic;

namespace WpfPractices.TesterApp.Models
{
    public class DataService : IDataService
    {
        public List<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new Product{Id = 1, Name = "Table"},
                new Product{Id = 2, Name = "Chair"},
                new Product{Id = 2, Name = "Capboard"}
            };

            return products;
        }
    }
}
