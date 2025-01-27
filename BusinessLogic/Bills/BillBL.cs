using BusinessLogicInterface.Bills;
using Configuration.Bases;
using Configuration.Messages;
using DataAccess.Bills;
using DataAccessInterface.Bills;
using Entities.Bills;
using Entities.Helpers.Communication;
using EntitiesInterface.Bills;
using EntitiesInterface.Helpers.Communication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Bills
{
    public class BillBL : BaseBL, IBillBL
    {
        private readonly IBillDA _billDA;

        public BillBL()
        {
            _billDA = new BillDA();
        }

        public Response GetAll(string filter)
        {
            Response response;
            DataSet result;

            try
            {
                result = _billDA.GetAll(filter);

                response = new Response(result, new List<IMessage> { GetMessages(this.ValidateMessage(result)) });

            }
            catch (Exception ex)
            {
                response = new Response(new List<IMessage> { GetMessages(GeneralMessages.GeneralErrorMessage) });
                response.AddMessage(new Message(ex.Message, MessageTypes.ServerError));
            }

            return response;
        }

        public Response Get(int id)
        {
            Response response;
            IBill result;

            try
            {
                result = _billDA.Get(id);

                response = new Response(result, new List<IMessage> { GetMessages(this.ValidateMessage(result)) });

            }
            catch (Exception ex)
            {
                response = new Response(new List<IMessage> { GetMessages(GeneralMessages.GeneralErrorMessage) });
                response.AddMessage(new Message(ex.Message, MessageTypes.ServerError));
            }

            return response;
        }

        public Response Save(string pBill)
        {
            IBill bill = JsonConvert.DeserializeObject<Bill>(pBill);
            Response response;
            int result;

            try
            {
                result = _billDA.Save(bill);

                response = new Response(result, new List<IMessage> { GetMessages(this.ValidateMessage(result)) });

            }
            catch (Exception ex)
            {
                response = new Response(new List<IMessage> { GetMessages(GeneralMessages.GeneralErrorMessage) });
                response.AddMessage(new Message(ex.Message, MessageTypes.ServerError));
            }

            return response;
        }

        public Response Update(string pBill)
        {
            IBill bill = JsonConvert.DeserializeObject<Bill>(pBill);
            Response response;
            int result;

            try
            {
                result = _billDA.Update(bill);

                response = new Response(result, new List<IMessage> { GetMessages(this.ValidateMessage(result)) });

            }
            catch (Exception ex)
            {
                response = new Response(new List<IMessage> { GetMessages(GeneralMessages.GeneralErrorMessage) });
                response.AddMessage(new Message(ex.Message, MessageTypes.ServerError));
            }

            return response;
        }

        public Response Delete(int id)
        {
            Response response;
            int result;

            try
            {
                result = _billDA.Delete(id);

                response = new Response(result, new List<IMessage> { GetMessages(this.ValidateMessage(result)) });

            }
            catch (Exception ex)
            {
                response = new Response(new List<IMessage> { GetMessages(GeneralMessages.GeneralErrorMessage) });
                response.AddMessage(new Message(ex.Message, MessageTypes.ServerError));
            }

            return response;
        }


    }
}
