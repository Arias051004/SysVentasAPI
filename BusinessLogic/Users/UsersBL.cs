using BusinessLogicInterface.Clients;
using Configuration.Bases;
using Configuration.Messages;
using DataAccess.Users;
using DataAccessInterface.Clients;
using Entities.Users;
using Entities.Helpers.Communication;
using EntitiesInterface.Helpers.Communication;
using EntitiesInterface.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BusinessLogic.Users
{
    public class UsersBL : BaseBL, IUsersBL
    {
        private readonly IUsersDA _clientDA;

        public UsersBL()
        {
            _clientDA = new UsersDA();
        }

        public Response GetAll(string filter)
        {
            Response response;
            DataSet result;
            DataTable data;
            List<object> users = new List<object>();

            try
            {
                result = _clientDA.GetAll(filter);

                data = result.Tables[0];

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    User user = new User();

                    user.IdUser = (int)data.Rows[i].ItemArray[0];
                    user.Name = data.Rows[i].ItemArray[1].ToString();
                    user.LastName = data.Rows[i].ItemArray[2].ToString();
                    user.Number = data.Rows[i].ItemArray[3].ToString();
                    user.Dni = data.Rows[i].ItemArray[4].ToString();
                    user.Email = data.Rows[i].ItemArray[5].ToString();
                    user.IsEnabled = (bool)data.Rows[i].ItemArray[6];

                    users.Add(user);
                }

                response = new Response(users, new List<IMessage> { GetMessages(this.ValidateMessage(result)) });

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
            IUser result;

            try
            {
                result = _clientDA.Get(id);

                response = new Response(result, new List<IMessage> { GetMessages(this.ValidateMessage(result)) });

            }
            catch (Exception ex)
            {
                response = new Response(new List<IMessage> { GetMessages(GeneralMessages.GeneralErrorMessage) });
                response.AddMessage(new Message(ex.Message, MessageTypes.ServerError));
            }

            return response;
        }

        public Response Save(string token, string pUser)
        {
            IUser client = JsonConvert.DeserializeObject<User>(pUser);
            Response response;
            int result;

            try
            {
                result = _clientDA.Save(client);

                response = new Response(result, new List<IMessage> { GetMessages(this.ValidateMessage(result)) });

            }
            catch (Exception ex)
            {
                response = new Response(new List<IMessage> { GetMessages(GeneralMessages.GeneralErrorMessage) });
                response.AddMessage(new Message(ex.Message, MessageTypes.ServerError));
            }

            return response;
        }

        public Response Update(string pClient)
        {
            IUser client = JsonConvert.DeserializeObject<User>(pClient);
            Response response;
            int result;

            try
            {
                result = _clientDA.Update(client);

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
                result = _clientDA.Delete(id);

                response = new Response(result, new List<IMessage> { GetMessages(this.ValidateMessage(result)) });

            }
            catch (Exception ex)
            {
                response = new Response(new List<IMessage> { GetMessages(GeneralMessages.GeneralErrorMessage) });
                response.AddMessage(new Message(ex.Message, MessageTypes.ServerError));
            }

            return response;
        }

        //public string GetUsers(DataTable data)
        //{

        //    for (int i = 0; i < data.Rows.Count; i++)
        //    {

        //    }

        //    return "";
        //}

    }
}
