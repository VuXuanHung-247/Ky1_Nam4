using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApi_Sport;
using WebAppMVC_Sport.Models;

namespace WebAppMVC_Sport.Controllers
{
    public class CategoryController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:1234/api");
        HttpClient client;

        public CategoryController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        // Route: http://localhost:5678/Category/Index
        // GET: Lấy danh sách loại sản phẩm
        public ActionResult Index()
        {
            List<CategoryViewModel> category = new List<CategoryViewModel>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/category").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
               category = JsonConvert.DeserializeObject<List<CategoryViewModel>>(data);
            }
            return View(category);
        }


        // Route: http://localhost:5678/Category/Create
        // POST: Thêm loại sản phẩm mới
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CategoryViewModel category)
        {
            string data = JsonConvert.SerializeObject(category);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/category", content).Result;

            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        // Route: http://localhost:5678/Category/Edit
        // PUT: Sửa loại sản phẩm 
        public ActionResult Edit(int id)
        {
            CategoryViewModel category = new CategoryViewModel();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/category/"+ id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<CategoryViewModel>(data);
            }
            return View("Edit",category);
        }
        [HttpPost]
        public ActionResult Edit(CategoryViewModel category)
        {
            string data = JsonConvert.SerializeObject(category);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/category/" + category.CategoryID, content).Result;

            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Edit", category);
        }


        // Route: http://localhost:5678/Category/Delete
        // PUT: Xóa loại sản phẩm 
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/category/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // Route: http://localhost:5678/Category/Delete
        // Get: Chi tiết 1 loại sản phẩm 
        public ActionResult Details(int id)
        {
            CategoryViewModel category = new CategoryViewModel();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/category/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                category = JsonConvert.DeserializeObject<CategoryViewModel>(data);
            }
            return View("Details", category);
        }

        //End.
    }
}