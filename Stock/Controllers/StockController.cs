using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Dynamic;
using Stock.Models;
using Newtonsoft.Json;

namespace Stock.Controllers
{
    [Route("api/Stock")]
    public class StockController : ApiController
    {
       

        ModelStock ModelStockObj = new ModelStock();
        string Url = "https://localhost:44400/Stock";
        [HttpGet]
        public List<dynamic> GetAll()
        {
            List<dynamic> StockList = ModelStockObj.GetStockList();

            return StockList;
        }

        [Route("~/api/Stock/Get")]
        public dynamic GET(string ID)
        {
            dynamic result = ModelStockObj.GetStockByID(ID);
            return result;
        }

        [HttpPost]
        public string AddStock(string id)
        {
            dynamic GetStock = JsonConvert.DeserializeObject<dynamic>(id);
            //GetStock.Quantity = GetStock.Quantity.replace("{}", "");
            string QUANTITY;
            string ID;
            string PRICE;
            String STOCKNAME;
            String LICENSEYEAR;
            String DISTRIBUTOR;
            String DESCRIPTION;
            String COLOR;
            ID = GetStock.STOCKID;
            QUANTITY = GetStock.QUANTITY;
            PRICE = GetStock.PRICE;
            STOCKNAME = GetStock.STOCKNAME;
            LICENSEYEAR = GetStock.LICENSEYEAR;
            DISTRIBUTOR = GetStock.DISTRIBUTOR;
            DESCRIPTION = GetStock.DESCRIPTION;
            COLOR = GetStock.COLOR;
            string result;
            result = ModelStockObj.InsertStock(QUANTITY, PRICE, DateTime.Now.ToString(), STOCKNAME, LICENSEYEAR,DISTRIBUTOR,
                DESCRIPTION, COLOR);

            return "id yang dihasilkan adalah " + result;
        }

        [HttpDelete]
        public string DeleteStock(string id)
        {
             ModelStockObj.DeleteStock(id);
            return "200 OK";
        }
        [HttpPut]
        public string UpdateStock(string id)
        {
            dynamic GetStock = JsonConvert.DeserializeObject<dynamic>(id);
            //GetStock.Quantity = GetStock.Quantity.replace("{}", "");
            string QUANTITY;
            string ID;
            string PRICE;
            String STOCKNAME;
            String LICENSEYEAR;
            String DISTRIBUTOR;
            String DESCRIPTION;
            String COLOR;
            ID = GetStock.STOCKID;
            QUANTITY = GetStock.QUANTITY;
            PRICE = GetStock.PRICE;
            STOCKNAME = GetStock.STOCKNAME;
            LICENSEYEAR = GetStock.LICENSEYEAR;
            DISTRIBUTOR = GetStock.DISTRIBUTOR;
            DESCRIPTION = GetStock.DESCRIPTION;
            COLOR = GetStock.COLOR;
            ID = ID.Replace("{}", "");
            QUANTITY = QUANTITY.Replace("{}", "");
            PRICE = PRICE.Replace("{}", "");

            ModelStockObj.UpdateStock(ID, QUANTITY, PRICE, DateTime.Now.ToString(), STOCKNAME,LICENSEYEAR,DISTRIBUTOR,DESCRIPTION,COLOR);

            return "200 0K ";
        }

    }



}

