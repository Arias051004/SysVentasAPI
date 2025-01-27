using EntitiesInterface.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterface.Clients
{
    public interface IUsersDA
    {
        DataSet GetAll(string filter);

        IUser Get(int id);

        int Save(IUser client);

        int Update(IUser client);

        int Delete(int id);
    }
}
