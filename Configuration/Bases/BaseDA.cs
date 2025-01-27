
using Configuration.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Base
{
    public class BaseDA
    {
        protected readonly string _connection;

        protected BaseDA()
        {
            _connection = Setting.GetValue(GeneralSettings.ConnectionString.ToString());
        }
    }
}
