using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesInterface.Bills;

namespace DataAccessInterface.Bills
{
    public interface IBillDA
    {
        DataSet GetAll(string filter);

        IBill Get(int id);

        int Save(IBill bill);

        int Update(IBill bill);

        int Delete(int id);
    }
}
