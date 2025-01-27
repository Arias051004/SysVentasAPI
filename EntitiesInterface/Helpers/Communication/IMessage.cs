using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesInterface.Helpers.Communication
{
    public interface IMessage
    {
         string MessageContent { get; set; }
         MessageTypes MessageType { get; set; }
    }
}
