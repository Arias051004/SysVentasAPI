
using Configuration.Settings;
using Configuration.StorageProceduresNames;
using DataAccess.Base;
using DataAccessInterface.Bills;
using DataAccessInterface.ProductsByBills;
using Entities.Helpers;
using Entities.ProductsByBills;
using EntitiesInterface.ProductsByBills;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccess.ProductsByBills
{
    public class ProductsByBillsDA : BaseDA, IProductsByBillsDA
    {

        public ProductsByBillsDA()
        {
            
        }

        public DataSet GetAll(string filter)
        {
            string query = Setting.GetValue(GeneralSettings.QuerysDA.ToString(), QuerysCFG.GetAllProductsByBills.ToString());
            DataSet result = new DataSet();

            using (SqlConnection connectSql = new SqlConnection(_connection))
            {
                try
                {
                    if (!string.IsNullOrEmpty(filter))
                    {
                        query = $"{query} WHERE {filter}";
                    }

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

        public DataSet Get(int id)
        {
            string query = Setting.GetValue(GeneralSettings.QuerysDA.ToString(), QuerysCFG.GetProductsByBill.ToString());
            DataSet result = new DataSet();

            using (SqlConnection connectSql = new SqlConnection(_connection))
            {
                try
                {
                    SqlDataAdapter adapSql;

                    adapSql = new SqlDataAdapter($"{query} = {id}", connectSql);
                    adapSql.Fill(result);
                }
                catch (Exception er)
                {
                    throw er;
                }
                
            }

            return result;
        }

        public int Save(int idBill, string idsProducts, int quantity)
        {
            int result = -1;

            using (SqlConnection connectSql = new SqlConnection(_connection))
            {
                using (SqlCommand command = new SqlCommand(ProductsByBillsSP.SP_SaveProductsByBills.ToString(), connectSql))
                {
                    try
                    {
                        connectSql.Open();

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdsProducts", idsProducts);
                        command.Parameters.AddWithValue("@IdBill", idBill);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        SqlParameter outParameter = new SqlParameter("@Result", SqlDbType.Int);
                        outParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(outParameter);

                        command.ExecuteNonQuery();
                        result = (int)outParameter.Value;

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

        public int Update(int idBill, string idsProducts, int quantity)
        {
            int result = -1;

            using (SqlConnection connectSql = new SqlConnection(_connection))
            {
                using (SqlCommand command = new SqlCommand(ProductsByBillsSP.SP_UpdateProductsByBills.ToString(), connectSql))
                {
                    try
                    {
                        connectSql.Open();

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdsProducts", idsProducts);
                        command.Parameters.AddWithValue("@IdBill", idBill);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        SqlParameter outParameter = new SqlParameter("@Result", SqlDbType.Int);
                        outParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(outParameter);

                        command.ExecuteNonQuery();

                        result = (int)outParameter.Value;

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

        public int Delete(int idBill)
        {
            int result = -1;

            using (SqlConnection connectSql = new SqlConnection(_connection))
            {
                using (SqlCommand command = new SqlCommand(ProductsByBillsSP.SP_DeleteProductsByBills.ToString(), connectSql))
                {
                    try
                    {
                        connectSql.Open();

                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@IdBill", idBill);
                        SqlParameter outParameter = new SqlParameter("@Result", SqlDbType.Int);
                        outParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(outParameter);

                        command.ExecuteNonQuery();

                        result = (int)outParameter.Value;

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
