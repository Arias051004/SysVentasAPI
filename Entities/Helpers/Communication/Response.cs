using Configuration.Messages;
using EntitiesInterface.Helpers.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Helpers.Communication
{
    [Serializable]
    public class Response : ISerializable, IResponse
    {
        public object? Value {  get; set; }
        public List<IMessage> Messages { get; }

        public Response(object value, List<IMessage> messages)
        {
            this.Value = value;
            this.Messages = messages;
        }

        public Response(List<IMessage> messages)
        {
            this.Messages = messages;
        }

        protected Response(SerializationInfo info, StreamingContext context)
        {
            Value = info.GetValue("Value", typeof(object));
            Messages = (List<IMessage>)info.GetValue("Message", typeof(List<IMessage>));
        }

        public void AddMessage(IMessage message)
        {
            Messages.Add(message);
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Value", Value);
            info.AddValue("Messages", Messages);
        }
    }
}
