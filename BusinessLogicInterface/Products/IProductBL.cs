using Entities.Helpers.Communication;
using EntitiesInterface.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicInterface.Products
{
    public interface IProductBL
    {
        Response GetAll(string filter);
        Response Get(int id);
        Response Save(string pProduct);
        Response Update(string pProduct);
        Response Delete(int id);
    }
}
