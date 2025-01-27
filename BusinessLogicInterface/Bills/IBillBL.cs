using Entities.Helpers.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicInterface.Bills
{
    public interface IBillBL
    {
        Response GetAll(string filter);

        Response Get(int id);

        Response Save(string pBill);

        Response Update(string pBill);

        Response Delete(int id);
    }
}
