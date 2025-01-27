using Entities.Helpers.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicInterface.Clients
{
    public interface IUsersBL
    {
        Response GetAll(string filter);

        Response Get(int id);

        Response Save(string token, string pClient);

        Response Update(string pClient);

        Response Delete(int id);
    }
}
