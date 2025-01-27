using DataAccessInterface.Bills;
using EntitiesInterface.Bills;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entities.Bills;
using System.Text.RegularExpressions;
using Configuration.Settings;
using Configuration.StorageProceduresNames;
using DataAccess.Base;
using DataAccessInterface.Clients;
using DataAccess.Users;

namespace DataAccess.Bills
{
    public class BillDA : BaseDA, IBillDA
    {
        private readonly IUsersDA _clientDA;
        //private readonly ICollaboratorDA _collaboratorDA;

        public BillDA() 
        {
            _clientDA = new UsersDA();
            //_collaboratorDA = new CollaboratorDA();
        }

        public DataSet GetAll(string filter)
        {
            string query = Setting.GetValue(GeneralSettings.QuerysDA.ToString(), QuerysCFG.GetAllBills.ToString());
            DataSet result = new DataSet();

            using (SqlConnection connectSql = new SqlConnection(_connection))
            {
                try
                {
                    if (!string.IsNullOrEmpty(filter))
                    {
                        query = $"{query} where {filter}";
                    }

                    SqlDataAdapter adapSql;

                    adapSql = new SqlDataAdapter(query, connectSql);
                    adapSql.Fill(result);
                }
                catch (Exception er)
                {
                    throw new Exception("");
                }
            }

            return result;
        }

        public IBill Get(int id)
        {
            IBill bill = new Bill();

            using (SqlConnection connectSql = new SqlConnection(_connection))
            {
                using (SqlCommand command = new SqlCommand($"{Setting.GetValue(GeneralSettings.QuerysDA.ToString(), QuerysCFG.GetBill.ToString())} = {id}", connectSql))
                {
                    try
                    {
                        SqlDataReader result;
                        connectSql.Open();
                        result = command.ExecuteReader();

                        if (result.HasRows)
                        {
                            result.Read();

                            bill.IdBill = result.GetInt32(0);
                            bill.Client = _clientDA.Get(result.GetInt32(1));
                            //bill.Collaborator = _collaboratorDA.Get(result.GetInt32(2));
                            bill.DateBill = result.GetDateTime(3);
                            bill.WarrantyDate = result.GetDateTime(4);
                            bill.Iva = result.GetInt32(5);
                            bill.TotalAmount = result.GetInt32(6);               
                            bill.IsEnabled = result.GetBoolean(7);
                        }

                        connectSql.Close();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("");
                    }
                }
            }


            return bill;
        }

        public int Save(IBill bill)
        {
            int result = -1;

            using (SqlConnection connectSql = new SqlConnection(_connection))
            {
                using (SqlCommand command = new SqlCommand(BillSP.SP_SaveBill.ToString(), connectSql))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdBill", bill.IdBill);
                        command.Parameters.AddWithValue("@Client", bill.Client.IdUser);
                        //command.Parameters.AddWithValue("@Collaborator", bill.Collaborator.IdCollaborator);
                        command.Parameters.AddWithValue("@DateBill", bill.DateBill);
                        command.Parameters.AddWithValue("@WarrantyDate", bill.WarrantyDate);
                        command.Parameters.AddWithValue("@TotalAmount", bill.TotalAmount);
                        command.Parameters.AddWithValue("@Iva", bill.Client.IdUser);

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

        public int Update(IBill bill)
        {
            int result = -1;

            using (SqlConnection connectSql = new SqlConnection(_connection))
            {
                using (SqlCommand command = new SqlCommand(BillSP.SP_UpdateBill.ToString(), connectSql))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdBill", bill.IdBill);
                        command.Parameters.AddWithValue("@Client", bill.Client.IdUser);
                        //command.Parameters.AddWithValue("@Collaborator", bill.Collaborator.IdCollaborator);
                        command.Parameters.AddWithValue("@DateBill", bill.DateBill);
                        command.Parameters.AddWithValue("@WarrantyDate", bill.WarrantyDate);
                        command.Parameters.AddWithValue("@TotalAmount", bill.TotalAmount);
                        command.Parameters.AddWithValue("@Iva", bill.Client.IdUser);
                        command.Parameters.AddWithValue("@IsEnabled", bill.IsEnabled);

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
                using (SqlCommand command = new SqlCommand(BillSP.SP_DeleteBill.ToString(), connectSql))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@IdBill", id);

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
