using EntitiesInterface.Categories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterface.Categories
{
    public interface ICategoryDA
    {
        DataSet GetAll(string filter);

        ICategory Get(int id);

        int Save(ICategory pcategory);

        int Update(ICategory pCategory);

        int Delete(int id);
    }
}
