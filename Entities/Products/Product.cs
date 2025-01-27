using EntitiesInterface.Categories;
using EntitiesInterface.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Products
{
    [Serializable]
    public class Product : ISerializable, IProduct
    {
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public byte[] Icon { get; set; }
        public ICategory Category { get; set; }
        public bool IsEnabled { get; set; }

        public Product()
        {

        }
        public Product(IProduct pProduct)
        {
            this.IdProduct = pProduct.IdProduct;
            this.ProductName = pProduct.ProductName;
            this.Amount = pProduct.Amount;
            this.Price = pProduct.Price;
            this.Icon = pProduct.Icon;
            this.Category = pProduct.Category;
            this.IsEnabled = pProduct.IsEnabled;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
