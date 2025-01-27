using Configuration.Settings;
using Configuration.StorageProceduresNames;
using DataAccess.Base;
using DataAccess.Categories;
using DataAccessInterface.Categories;
using DataAccessInterface.Products;
using Entities.Products;
using EntitiesInterface.Products;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Products
{
    public class ProductDA : BaseDA, IProductDA
    {
        private readonly ICategoryDA _categoryDA;
        public ProductDA()
        {
            _categoryDA = new CategoryDA();
        }

        public DataSet GetAll(string filter)
        {
            string query = Setting.GetValue(GeneralSettings.QuerysDA.ToString(), QuerysCFG.GetAllProducts.ToString());
            DataSet result = new DataSet();

            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                try
                {
                    if (!string.IsNullOrEmpty(filter))
                    {
                        query = $"{query} WHERE {filter}";
                    }

                    SqlDataAdapter adapSql;

                    adapSql = new SqlDataAdapter(query, sqlConnection);
                    adapSql.Fill(result);

                }
                catch (Exception er)
                {
                    throw er;
                }
            }

            return result;
        }
        public IProduct Get(int id)
        {
            IProduct product = new Product();

            using(SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                using (SqlCommand sqlCommand = new SqlCommand($"{Setting.GetValue(GeneralSettings.QuerysDA.ToString(), QuerysCFG.GetProduct.ToString())} = {id}", sqlConnection))
                {
                    try
                    {
                        SqlDataReader result;

                        sqlConnection.Open();
                        result = sqlCommand.ExecuteReader();

                        if (result.HasRows)
                        {
                            product.IdProduct = result.GetInt32(0);
                            product.ProductName = result.GetString(1);
                            product.Amount = result.GetInt32(2);
                            product.Price = result.GetInt32(3);
                            //product.Icon = result.GetBytes(4);
                            product.Category = _categoryDA.Get(result.GetInt32(5));
                            product.IsEnabled = result.GetBoolean(6);
                        }

                        sqlConnection.Close();
                    }
                    catch (Exception er)
                    {
                        throw er;
                    }

                }          
            }

            return product;

        }
        public int Save(IProduct pProduct)
        {
            int result = -1;

            using(SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                using (SqlCommand sqlCommand = new SqlCommand(ProductSP.SP_SaveProduct.ToString(), sqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@ProductName", pProduct.ProductName);
                        sqlCommand.Parameters.AddWithValue("@Amount", pProduct.Amount);
                        sqlCommand.Parameters.AddWithValue("@Price", pProduct.Price);
                        sqlCommand.Parameters.AddWithValue("@Icon", pProduct.Icon);
                        sqlCommand.Parameters.AddWithValue("@IdCategory", pProduct.Category.IdCategory);

                        sqlConnection.Open();
                        result = sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                    catch (Exception er)
                    {
                        throw er;
                    }
                }
            }

            return result;
        }
        public int Update(IProduct pProduct)
        {
            int result = -1;

            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                using (SqlCommand sqlCommand = new SqlCommand(ProductSP.SP_UpdateProduct.ToString(), sqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@ProductName", pProduct.ProductName);
                        sqlCommand.Parameters.AddWithValue("@Amount", pProduct.Amount);
                        sqlCommand.Parameters.AddWithValue("@Price", pProduct.Price);
                        sqlCommand.Parameters.AddWithValue("@Icon", pProduct.Icon);
                        sqlCommand.Parameters.AddWithValue("@IdCategory", pProduct.Category.IdCategory);

                        sqlConnection.Open();
                        result = sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();
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

            using (SqlConnection sqlConnection = new SqlConnection(_connection))
            {
                using (SqlCommand sqlCommand = new SqlCommand(ProductSP.SP_UpdateProduct.ToString(), sqlConnection))
                {
                    try
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdProduct", id);

                        sqlConnection.Open();
                        result = sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();
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
