
using BusinessLogicInterface.ProductsByBills;
using Configuration.Bases;
using Configuration.Messages;
using DataAccess.ProductsByBills;
using DataAccessInterface.ProductsByBills;
using Entities.Helpers.Communication;
using Entities.ProductsByBills;
using EntitiesInterface.Helpers.Communication;
using EntitiesInterface.ProductsByBills;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ProductsByBills
{
    public class ProductsByBillBL : BaseBL, IProductsByBillBL
    {
        private readonly IProductsByBillsDA _productsByBillDA;

        public ProductsByBillBL()
        {
            _productsByBillDA = new ProductsByBillsDA();
        }

        public Response GetAll(string filter)
        {
            Response response;
            DataSet result;

            try
            {
                result = _productsByBillDA.GetAll(filter);

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
            DataSet result;

            try
            {
                result = _productsByBillDA.Get(id);

                response = new Response(result, new List<IMessage> { GetMessages(this.ValidateMessage(result)) });

            }
            catch (Exception ex)
            {
                response = new Response(new List<IMessage> { GetMessages(GeneralMessages.GeneralErrorMessage) });
                response.AddMessage(new Message(ex.Message, MessageTypes.ServerError));
            }

            return response;
        }

        public Response Save(string pProductsByBill)
        {
            IProductsByBill productsByBill = JsonConvert.DeserializeObject<ProductsByBill>(pProductsByBill);
            string ids = JsonConvert.SerializeObject(productsByBill.Products);
            Response response;
            int result;

            try
            {
                result = _productsByBillDA.Save(productsByBill.Bill.IdBill, ids, productsByBill.Quantity);

                response = new Response(result, new List<IMessage> { GetMessages(this.ValidateMessage(result)) });

            }
            catch (Exception ex)
            {
                response = new Response(new List<IMessage> { GetMessages(GeneralMessages.GeneralErrorMessage) });
                response.AddMessage(new Message(ex.Message, MessageTypes.ServerError));
            }

            return response;
        }

        public Response Update(string pProductsByBill)
        {
            IProductsByBill productsByBill = JsonConvert.DeserializeObject<ProductsByBill>(pProductsByBill);
            string ids = JsonConvert.SerializeObject(productsByBill.Products);
            Response response;
            int result;

            try
            {
                result = _productsByBillDA.Update(productsByBill.Bill.IdBill, ids, productsByBill.Quantity);

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
                result = _productsByBillDA.Delete(id);

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
