using Configuration.Settings;
using Configuration.StorageProceduresNames;
using DataAccess.Base;
using DataAccessInterface.Categories;
using Entities.Categories;
using Entities.Users;
using EntitiesInterface.Categories;
using EntitiesInterface.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Categories
{
    public class CategoryDA : BaseDA, ICategoryDA
    {
        private readonly ICategoryDA categoryDA;
        public CategoryDA() { }

        public DataSet GetAll(string filter)
        {
            string query = Setting.GetValue(GeneralSettings.QuerysDA.ToString(), QuerysCFG.GetAllCategories.ToString());
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

        public ICategory Get(int id)
        {
            ICategory category = new Category();

            using (SqlConnection connectSql = new SqlConnection(_connection))
            {
                using (SqlCommand command = new SqlCommand($"{Setting.GetValue(GeneralSettings.QuerysDA.ToString(), QuerysCFG.GetCategory.ToString())} = {id}", connectSql))
                {
                    try
                    {
                        SqlDataReader result;

                        connectSql.Open();
                        result = command.ExecuteReader();

                        if (result.HasRows)
                        {
                            result.Read();

                            category.IdCategory = result.GetInt32(0);
                            category.Name = result.GetString(1);
                            category.IsEnabled = result.GetBoolean(6);
                        }

                        connectSql.Close();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            return category;
        }

        public int Save(ICategory pcategory)
        {
            int result = -1;

            using (SqlConnection connectSql = new SqlConnection(_connection))
            {
                using (SqlCommand command = new SqlCommand(CategorySP.SP_SaveCategory.ToString(), connectSql))
                {
                    try
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@CategoryName", pcategory.Name);

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

        public int Update(ICategory pCategory)
        {
            int result = -1;

            using (SqlConnection connectSql = new SqlConnection(_connection))
            {
                using (SqlCommand sqlCommand = new SqlCommand(CategorySP.SP_SaveCategory.ToString(), connectSql))
                {
                    try
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdCategory", pCategory.IdCategory);
                        sqlCommand.Parameters.AddWithValue("@CategoryName", pCategory.Name);

                        connectSql.Open();

                        result = sqlCommand.ExecuteNonQuery();

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

            using(SqlConnection connectSql = new SqlConnection(_connection))
            {
                using(SqlCommand sqlCommand = new SqlCommand(CategorySP.SP_DeleteCategory.ToString(), connectSql))
                {
                    try
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@IdCategory", id);

                        connectSql.Open();
                        result = sqlCommand.ExecuteNonQuery();
                        connectSql.Close();
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }

            return result - 1;
        }
    }
}
