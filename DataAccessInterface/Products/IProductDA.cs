using EntitiesInterface.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterface.Products
{
    public interface IProductDA
    {
        DataSet GetAll(string filter);
        IProduct Get(int id);
        int Save(IProduct pProduct);
        int Update(IProduct pProduct);
        int Delete(int id);
    }
}
