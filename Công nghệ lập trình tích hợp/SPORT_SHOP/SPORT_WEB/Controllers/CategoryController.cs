using BaseLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SPORT_WEB.Controllers
{
    public class CategoryController : Controller
    {
        HttpClient client;
        // Url Api
        string URL = $"{"http://localhost:1234/api/sport/category"}";

        public CategoryController()
        {
            client = new HttpClient();
        }
        // GET: Lấy danh sách danh mục
        [HttpGet]
        public ActionResult CategoryList()
        {
            List<CategoryModel> category = new List<CategoryModel>();
            
            HttpResponseMessage response = client.GetAsync(URL).Result;

            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<List<BaseLib.CategoryModel>>(data);
            }
            return View(category);
        }

        // POST: Thêm danh mục mới
        public ActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CategoryAdd(CategoryModel category)
        {
            string data = JsonConvert.SerializeObject(category);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL,content).Result;

            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }

            return View(category);
        }

        // PUT: Sửa danh mục 
        public ActionResult CategoryUpdate()
        {
            CategoryModel category = new CategoryModel();

            HttpResponseMessage response = client.GetAsync(URL).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<CategoryModel>(data);
            }
            return View("CategoryAdd",category);
        }

        [HttpPut]
        public ActionResult CategoryUpdate(CategoryModel category)
        {
            string data = JsonConvert.SerializeObject(category);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync(URL, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }

            return View("CategoryAdd", category);
        }
    }
}