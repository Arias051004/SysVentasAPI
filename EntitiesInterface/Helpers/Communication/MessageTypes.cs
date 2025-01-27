using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesInterface.Helpers.Communication
{
    public enum MessageTypes
    {
        Sucess = 200,
        Created = 201,
        NoContent = 204,
        ClientError = 400,
        Unauthorized = 401,
        NotFound = 404,
        ServerError = 500
    }
}
