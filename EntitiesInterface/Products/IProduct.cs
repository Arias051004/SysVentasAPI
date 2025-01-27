using EntitiesInterface.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesInterface.Products
{
    public interface IProduct
    {
        int IdProduct { get; set; }
        string ProductName { get; set; }
        int Amount { get; set; }
        int Price { get; set; }
        byte[] Icon { get; set; }
        ICategory Category { get; set; }
        bool IsEnabled { get; set; }
    }
}
