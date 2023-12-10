using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Dynamic;
using System.Configuration;

namespace ShopUI.Models
{
    public class ModelStock
    {
        //SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ShopConnection"].ToString());


        //public List<dynamic> GetStockList()
        //{
        //    List < dynamic > result= null;

        //    SqlCommand command =new SqlCommand("sTOCK_GetStockList",Connection);
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.CommandTimeout = 0;
        //    Connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();
        //    if (reader.HasRows)
        //    {
        //        result = new List<dynamic>();
        //        while (reader.Read())
        //        {
        //            var record = new ExpandoObject() as IDictionary<string, Object>;
        //            for(int i = 0; i < reader.FieldCount; i++)
        //            {
        //                record.Add(reader.GetName(i), reader[i].ToString());
        //            }
        //            result.Add(record);
        //        }
        //    }
        //    Connection.Close();
        //    return result;
        //}

        public string STOCKID;
        public string QUANTITY;
        public string PRICE;
        public string STOCKNAME;
        public string LICENSEYEAR;
        public string DISTRIBUTOR;
        public string DESCRIPTION;
        public string COLOR;
    }
}