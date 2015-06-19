using System;
using System.Collections.Generic;

namespace WpfPractices.TesterApp.Models
{
    public interface IDataService
    {
        List<Product> GetProducts();
    }
}
