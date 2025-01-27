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
    public class Message : IMessage, ISerializable
    {
        public string MessageContent { get; set; }
        public MessageTypes MessageType { get; set; }
        public Message() { }

        public Message(string pMessage, MessageTypes messageType)
        {
            MessageContent = pMessage;
            MessageType = messageType;
        }

        public Message(SerializationInfo info, StreamingContext context)
        {
            MessageContent = info.GetString("MessageContent");
            MessageType = (MessageTypes)info.GetValue("MessageType", typeof(MessageTypes));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("MessageContent", MessageContent);
            info.AddValue("MessageType", MessageType);
        }
    }
}
