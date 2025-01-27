using BusinessLogicInterface.Categories;
using Configuration.Bases;
using Configuration.Messages;
using DataAccess.Categories;
using DataAccessInterface.Categories;
using Entities.Categories;
using Entities.Helpers.Communication;
using EntitiesInterface.Categories;
using EntitiesInterface.Helpers.Communication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Categories
{
    public class CategoryBL : BaseBL, ICategoryBL
    {
        private readonly ICategoryDA _categoryDA;
        public CategoryBL()
        {
            _categoryDA = new CategoryDA();
        }

        public Response GetAll(string filter)
        {
            Response response;
            DataSet result;

            try
            {
                result = _categoryDA.GetAll(filter);
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
            ICategory result;

            try
            {
                result = _categoryDA.Get(id);
                response = new Response(result, new List<IMessage> { GetMessages(this.ValidateMessage(result)) });
            }
            catch (Exception ex)
            {
                response = new Response(new List<IMessage> { GetMessages(GeneralMessages.GeneralErrorMessage) });
                response.AddMessage(new Message(ex.Message, MessageTypes.ServerError));
            }

            return response;
        }
        public Response Save(string pCategory)
        {
            Response response;
            ICategory category = JsonConvert.DeserializeObject<Category>(pCategory);
            int result;

            try
            {
                result = _categoryDA.Save(category);
                response = new Response(result, new List<IMessage> { GetMessages(this.ValidateMessage(result)) });
            }
            catch (Exception ex)
            {
                response = new Response(new List<IMessage> { GetMessages(GeneralMessages.GeneralErrorMessage) });
                response.AddMessage(new Message(ex.Message, MessageTypes.ServerError));
            }

            return response;
        }

        public Response Update(string pCategory)
        {
            Response response;
            ICategory category = JsonConvert.DeserializeObject<Category>(pCategory);
            int result;

            try
            {
                result = _categoryDA.Update(category);
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
                result = _categoryDA.Delete(id);
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
