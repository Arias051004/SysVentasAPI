
using EntitiesInterface.Bills;

namespace EntitiesInterface.ProductsByBills
{
    public interface IProductsByBill
    {
        int IdProductsByBill { get; set; }
        List</*IProduct*/object> Products  { get; set; }
        IBill Bill { get; set; }
        int Quantity { get; set; }
        bool IsEnabled { get; set; }
    }
}
