using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Dynamic;
using System.Data;
using System.IO;
using ShopUI.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ShopUI.Controllers
{
    public class HomeController : Controller
    {
        ModelStock ModelStockObj = new ModelStock();

        //public ActionResult Index()
        //{
        //    List<dynamic> StockList = null;
        //    StockList = ModelStockObj.GetStockList();
        //    ModelStockObj.GetStockList();
        //    ViewBag.Stocklist = StockList;
        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        private readonly HttpClient _httpClient;

        public HomeController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:44400/"); /*// in case https di block pakai http://localhost:50906/ */
        }

        public async Task<ActionResult> Index()
        {
            // Make a GET request to the API
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Stock");
            
            if (response.IsSuccessStatusCode)
            {
                // Read the response content
                string content = await response.Content.ReadAsStringAsync();
                List<dynamic> StockList = JsonConvert.DeserializeObject<List<dynamic>>(content);
                ViewBag.StockList = StockList;
            }
            else
            {
                ViewBag.ApiResponse = $"API Request failed with status code {response.StatusCode}";
            }

            return View();
        }

        public async Task<ActionResult> UpdateStock(string id)
        {
            // Make a GET request to the API
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Stock/Get?id="+id);

            if (response.IsSuccessStatusCode)
            {
                // Read the response content
                string content = await response.Content.ReadAsStringAsync();
                dynamic GetStock = JsonConvert.DeserializeObject<dynamic>(content);
                ViewBag.GetStock = GetStock;
            }
            else
            {
                ViewBag.ApiResponse = $"API Request failed with status code {response.StatusCode}";
            }

            return PartialView("~/Views/Partial/UpdateStock.cshtml");
        }
        public ActionResult AddStock()
        {
            return PartialView("~/Views/Partial/AddStock.cshtml");
        }

        [HttpPost]
        public async Task<ActionResult> SubmitUpdateStock(string id,string QUANTITY,string PRICE,string STOCKNAME,string LICENSEYEAR,
            string DISTRIBUTOR,string DESCRIPTION,string COLOR)
        {
            PRICE = PRICE.Replace(",", "");
            ModelStock result = new ModelStock();
            result.QUANTITY = QUANTITY;
            result.STOCKID = id;
            result.PRICE = PRICE;
            result.STOCKNAME = STOCKNAME;
            result.LICENSEYEAR = LICENSEYEAR;
            result.DISTRIBUTOR = DISTRIBUTOR;
            result.DESCRIPTION = DESCRIPTION;
            result.COLOR = COLOR;
            String JSON= JsonConvert.SerializeObject(result);
            HttpContent content = new StringContent(JSON);
            //JSON = JSON.Replace("\\\"","");
            // Make a GET request to the API
            HttpResponseMessage response = await _httpClient.PutAsync("/api/Stock?id=" + JSON, null);

            if (response.IsSuccessStatusCode)
            {
                return Content("TRUE");
            }
            else
            {
                return Content("ALERT");
            }

            
        }

        [HttpPost]
        public async Task<ActionResult> SubmitAddStock(string QUANTITY, string PRICE, string STOCKNAME, string LICENSEYEAR,
            string DISTRIBUTOR, string DESCRIPTION, string COLOR)
        {
            PRICE = PRICE.Replace(",", "");
            ModelStock result = new ModelStock();
            result.QUANTITY = QUANTITY;
            result.PRICE = PRICE;
            result.STOCKNAME = STOCKNAME;
            result.LICENSEYEAR = LICENSEYEAR;
            result.DISTRIBUTOR = DISTRIBUTOR;
            result.DESCRIPTION = DESCRIPTION;
            result.COLOR = COLOR;
            String JSON = JsonConvert.SerializeObject(result);

            // Make a GET request to the API
            HttpResponseMessage response = await _httpClient.PostAsync("/api/Stock?id=" + JSON,null);

            if (response.IsSuccessStatusCode)
            {
                return Content("TRUE");
            }
            else
            {
                return Content("ALERT");
            }


        }

    }
}