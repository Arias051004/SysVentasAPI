using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesInterface.Helpers.Communication
{
    public interface IResponse
    {
         object? Value { get; set; }
         List<IMessage> Messages { get; }
         void AddMessage(IMessage message);
    }
}
