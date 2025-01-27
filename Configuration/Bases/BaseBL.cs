using Configuration.Messages;
using Configuration.Settings;
using Entities.Helpers.Communication;
using EntitiesInterface.Helpers.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Bases
{
    public class BaseBL
    {

        protected BaseBL() { }

        protected GeneralMessages ValidateMessage(int value)
        {
            switch (value)
            {
                case -1:
                case 0:
                    return GeneralMessages.GeneralErrorMessage;
                case 1:
                    return GeneralMessages.GeneralSucessMessage;
                case 2:
                    return GeneralMessages.ErrorRepeated;
                case 3:
                    return GeneralMessages.ErrorSaving;
                case 4:
                    return GeneralMessages.ErrorUpdating;
                case 5:
                    return GeneralMessages.ErrorDeleting;
                default:
                    return GeneralMessages.GeneralErrorMessage;
            }
        }

        protected GeneralMessages ValidateMessage(object value)
        {
            return value != null ? GeneralMessages.GeneralSucessMessage : GeneralMessages.GeneralErrorMessage;
        }

        protected static IMessage GetMessages(GeneralMessages generalType)
        {
            IMessage message = new Message();

            message.MessageContent = Setting.GetValue(GeneralSettings.GeneralMessages.ToString(),
                generalType.ToString());

            switch (generalType)
            {
                case GeneralMessages.GeneralErrorMessage:
                    message.MessageType = MessageTypes.NotFound;
                    break;
                case GeneralMessages.GeneralSucessMessage:
                    message.MessageType = MessageTypes.Sucess;
                    break;
                case GeneralMessages.ErrorSaving:
                case GeneralMessages.ErrorUpdating:
                case GeneralMessages.ErrorDeleting:
                    message.MessageType = MessageTypes.ClientError;
                    break;
                case GeneralMessages.ErrorRepeated:
                    message.MessageType = MessageTypes.NoContent;
                    break;
            }

            return message;
        }
    }
}
