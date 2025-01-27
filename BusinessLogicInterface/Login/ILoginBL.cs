using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicInterface.Login
{
    public interface ILoginBL
    {
        string ValidateLogin(string username, string password);
    }
}
