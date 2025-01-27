using BusinessLogicInterface.Login;
using Configuration.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Login
{
    public class LoginBL : BaseBL, ILoginBL
    {
        public string ValidateLogin(string username, string password)
        {
            return "";
        }
    }
}
