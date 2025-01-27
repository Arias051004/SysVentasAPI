using Entities.Helpers.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicInterface.ProductsByBills
{
    public interface IProductsByBillBL
    {
        Response GetAll(string filter);

        Response Get(int id);

        Response Save(string pProductsByBill);

        Response Update(string pProductsByBill);

        Response Delete(int id);
    }
}
