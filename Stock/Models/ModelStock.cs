using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Dynamic;
using System.Configuration;

namespace Stock.Models
{
    public class ModelStock
    {
        SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ShopConnection"].ToString());


        public List<dynamic> GetStockList()
        {
            List < dynamic > result= null;

            SqlCommand command =new SqlCommand("Stock_GetStockList",Connection);
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                result = new List<dynamic>();
                while (reader.Read())
                {
                    var record = new ExpandoObject() as IDictionary<string, Object>;
                    for(int i = 0; i < reader.FieldCount; i++)
                    {
                        record.Add(reader.GetName(i), reader[i].ToString());
                    }
                    result.Add(record);
                }
            }
            Connection.Close();
            return result;
        }
        public dynamic GetStockByID(string id)
        {
            var result = null as IDictionary<string, Object>;
            SqlCommand command = new SqlCommand("Stock_GetStockByID", Connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("id", id);
            command.CommandTimeout = 0;

            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                result = new ExpandoObject();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    result.Add(reader.GetName(i), reader[i].ToString());
                }
            }
            Connection.Close();
            return result;
        }

        public string InsertStock(string QUANTITY,string PRICE,string CREATEDON,
            string STOCKNAME,string LICENSEYEAR,string DISTRIBUTOR,string DESCRIPTION,string COLOR)
        {
            string outputIDMemo;
            SqlCommand command = new SqlCommand("Stock_InsertStock", Connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("QUANTITY", QUANTITY);
            command.Parameters.AddWithValue("PRICE", PRICE);
            command.Parameters.AddWithValue("CREATEDON", CREATEDON);
            command.Parameters.AddWithValue("STOCKNAME", STOCKNAME);
            command.Parameters.AddWithValue("LICENSEYEAR", LICENSEYEAR);
            command.Parameters.AddWithValue("DISTRIBUTOR", DISTRIBUTOR);
            command.Parameters.AddWithValue("DESCRIPTION", DESCRIPTION);
            command.Parameters.AddWithValue("COLOR", COLOR);
      

            command.CommandTimeout = 0;


            Connection.Open();
            outputIDMemo = command.ExecuteScalar().ToString();
            Connection.Close();
            return outputIDMemo;
        }

        public bool UpdateStock(string StockID,string QUANTITY, string PRICE, string CREATEDON,
    string STOCKNAME, string LICENSEYEAR, string DISTRIBUTOR, string DESCRIPTION, string COLOR)
        {
            SqlCommand command = new SqlCommand("Stock_UpdateStock", Connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("ID", StockID);
            command.Parameters.AddWithValue("QUANTITY", QUANTITY);
            command.Parameters.AddWithValue("PRICE", PRICE);
            command.Parameters.AddWithValue("CREATEDON", CREATEDON);
            command.Parameters.AddWithValue("STOCKNAME", STOCKNAME);
            command.Parameters.AddWithValue("LICENSEYEAR", LICENSEYEAR);
            command.Parameters.AddWithValue("DISTRIBUTOR", DISTRIBUTOR);
            command.Parameters.AddWithValue("DESCRIPTION", DESCRIPTION);
            command.Parameters.AddWithValue("COLOR", COLOR);


            command.CommandTimeout = 0;


            Connection.Open();
            command.ExecuteNonQuery();
            Connection.Close();
            return true;
        }

        public bool DeleteStock(string id)
        {
            
            SqlCommand command = new SqlCommand("Stock_DeleteStock", Connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("id", id);
            command.CommandTimeout = 0;

            Connection.Open();
            command.ExecuteNonQuery();
            Connection.Close();
            return true;
        }



    }

   

}