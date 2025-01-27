
using Configuration.Settings;
using Configuration.StorageProceduresNames;
using DataAccess.Base;
using DataAccessInterface.Clients;
using Entities.Bills;
using Entities.Users;
using EntitiesInterface.Bills;
using EntitiesInterface.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Users
{
    public class UsersDA : BaseDA, IUsersDA
    {
        
        public UsersDA()
        {

        }

        public DataSet GetAll(string filter)
        {
            string query = Setting.GetValue(GeneralSettings.QuerysDA.ToString(), QuerysCFG.GetAllClients.ToString());
            DataSet result = new DataSet();

            using (SqlConnection connectSql = new SqlConnection(_connection))
            {
                try
                {
                    //if (!string.IsNullOrEmpty(filter))
                    //{
                    //    query = $"{query} WHERE {filter}";
                    //}

                    SqlDataAdapter adapSql;

                    adapSql = new SqlDataAdapter(query, connectSql);
                    adapSql.Fill(result);
                }
                catch (Exception er)
                {
                    throw er;
                }
            }

            return result;
        }

        public IUser Get(int id)
        {
            IUser client = new User();

            using (SqlConnection connectSql = new SqlConnection(_connection))
            {
                using (SqlCommand command = new SqlCommand($"{Setting.GetValue(GeneralSettings.QuerysDA.ToString(), QuerysCFG.GetClient.ToString())} = {id}", connectSql))
                {
                    try
                    {
                        SqlDataReader result;

                        connectSql.Open();
                        result = command.ExecuteReader();

                        if (result.HasRows)
                        {
                            result.Read();

                            client.IdUser = result.GetInt32(0);
                            client.Name = result.GetString(1);
                            client.LastName = result.GetString(2);
                            client.Number = result.GetString(3);
                            client.Dni = result.GetString(4);
                            //client.Email = result.GetString(5);
                            client.IsEnabled = result.GetBoolean(6);
                        }

                        connectSql.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            return client;
        }

        public int Save(IUser client)
        {
            int result = -1;

            using (SqlConnection connectSql = new SqlConnection(_connection))
            {
                using SqlCommand command = new SqlCommand(UsersSP.SP_SaveUser.ToString(), connectSql);
                try
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", client.Name);
                    command.Parameters.AddWithValue("@LastName", client.LastName);
                    command.Parameters.AddWithValue("@PhoneNumber", client.Number);
                    //command.Parameters.AddWithValue("@Email", client.Email);
                    command.Parameters.AddWithValue("@Dni", client.Dni);
                    command.Parameters.AddWithValue("@IdRol", 5);

                    connectSql.Open();

                    result = command.ExecuteNonQuery();

                    connectSql.Close();
                }
                catch (Exception er)
                {
                    throw er;
                }
            }

            return result;
        }

        public int Update(IUser client)
        {
            int result = -1;

            using (SqlConnection connectSql = new SqlConnection(_connection))
            {
                using (SqlCommand command = new SqlCommand(UsersSP.SP_UpdateClient.ToString(), connectSql))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ClientName", client.Name);
                        command.Parameters.AddWithValue("@LastName", client.LastName);
                        command.Parameters.AddWithValue("@PhoneNumber", client.Number);
                        command.Parameters.AddWithValue("@Email", client.Email);
                        command.Parameters.AddWithValue("@Dni", client.Dni);

                        SqlParameter resultParam = new SqlParameter("@Result", SqlDbType.Int);
                        resultParam.Direction = ParameterDirection.Output;
                        command.Parameters.Add(resultParam);

                        connectSql.Open();

                        result = command.ExecuteNonQuery();

                        connectSql.Close();
                    }
                    catch (Exception er)
                    {
                        throw er;
                    }
                }
            }

            return result;
        }

        public int Delete(int id)
        {
            int result = -1;

            using (SqlConnection connectSql = new SqlConnection(_connection))
            {
                using (SqlCommand command = new SqlCommand(UsersSP.SP_DeleteClient.ToString(), connectSql))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdClient", id);

                        connectSql.Open();

                        result = command.ExecuteNonQuery();

                        connectSql.Close();
                    }
                    catch (Exception er)
                    {
                        throw er;
                    }
                }
            }

            return result;
        }
    }
}
