
using EntitiesInterface.Bills;
using EntitiesInterface.ProductsByBills;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ProductsByBills
{
    [Serializable]
    public class ProductsByBill : IProductsByBill, ISerializable
    {
        public int IdProductsByBill { get; set; }
        public List</*IProduct*/object> Products { get; set; }
        public IBill Bill { get; set; }
        public int Quantity { get; set; }
        public bool IsEnabled { get; set; }

        public ProductsByBill() { }

        public ProductsByBill(IProductsByBill productsByBill)
        {
            Products = productsByBill.Products;
            Bill = productsByBill.Bill;
            Quantity = productsByBill.Quantity;
            IsEnabled = productsByBill.IsEnabled;
        }

        protected ProductsByBill(SerializationInfo info, StreamingContext context)
        {
            Products = (List</*IProduct*/object>)info.GetValue("Products", typeof(List</*IProduct*/object>));
            Bill = (IBill)info.GetValue("Products", typeof(IBill));
            Quantity = info.GetInt32("Quantity");
            IsEnabled = info.GetBoolean("IsEnabled");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Products", Products);
            info.AddValue("Bill", Bill);
            info.AddValue("Quantity", Quantity);
            info.AddValue("IsEnabled", IsEnabled);
        }
    }
}
