using BusinessLogicInterface.Products;
using Configuration.Bases;
using Configuration.Messages;
using DataAccess.Products;
using DataAccessInterface.Products;
using Entities.Helpers.Communication;
using Entities.Products;
using EntitiesInterface.Helpers.Communication;
using EntitiesInterface.Products;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessLogic.Products
{
    public class ProductBL : BaseBL, IProductBL
    {
        private readonly IProductDA _productDA;

        public ProductBL()
        {
            _productDA = new ProductDA();
        }

        public Response GetAll(string filter)
        {
            Response response;
            DataSet result;

            try
            {
                result = _productDA.GetAll(filter);
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
            IProduct result;

            try
            {
                result = _productDA.Get(id);
                response = new Response(result, new List<IMessage> { GetMessages(this.ValidateMessage(result)) });
            }
            catch (Exception ex)
            {
                response = new Response(new List<IMessage> { GetMessages(GeneralMessages.GeneralErrorMessage) });
                response.AddMessage(new Message(ex.Message, MessageTypes.ServerError));
            }

            return response;
        }

        public Response Save(string pProduct)
        {
            Response response;
            IProduct product = JsonConvert.DeserializeObject<Product>(pProduct);
            int result;

            try
            {
                result = _productDA.Save(product);
                response = new Response(result, new List<IMessage> { GetMessages(this.ValidateMessage(result)) });
            }
            catch (Exception ex)
            {
                response = new Response(new List<IMessage> { GetMessages(GeneralMessages.GeneralErrorMessage) });
                response.AddMessage(new Message(ex.Message, MessageTypes.ServerError));
            }

            return response;
        }

        public Response Update(string pProduct)
        {
            Response response;
            IProduct product = JsonConvert.DeserializeObject<Product>(pProduct);
            int result;

            try
            {
                result = _productDA.Update(product);
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
                result = _productDA.Delete(id);
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
