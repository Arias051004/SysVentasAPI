using Entities.Helpers.Communication;
using EntitiesInterface.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicInterface.Categories
{
    public interface ICategoryBL
    {
        Response GetAll(string filter);
        Response Get(int id);
        Response Save(string pCategory);
        Response Update(string pCategory);
        Response Delete(int id);

    }
}
