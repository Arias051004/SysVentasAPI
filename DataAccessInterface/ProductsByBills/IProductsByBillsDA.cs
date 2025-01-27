
using EntitiesInterface.ProductsByBills;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterface.ProductsByBills
{
    public interface IProductsByBillsDA
    {
        DataSet GetAll(string filter);

        DataSet Get(int id);

        int Save(int idBill, string idsProducts, int quantity);

        int Update(int idBill, string idsProducts, int quantity);

        int Delete(int id);
    }
}
