using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Sport.DataAccess;

namespace WebApi_Sport.Controllers
{
    public class CategoryController : ApiController
    {
        DB_Sport db = new DB_Sport();
        /// <summary>
        /// Dịch vụ lấy toàn bộ loại sản phẩm
        /// Route: api/category
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<CATEGORY> GetCategoryLists()
        {
            return db.CATEGORies.ToList();
        }



        /// <summary>
        /// Lấy 1 loại sản phẩm theo khóa chính nào đó
        /// Route: api/category/id
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        [HttpGet]
        public CATEGORY GetCategory(int id)
        {
            return db.CATEGORies.FirstOrDefault(x => x.CategoryID == id);
        }


        ///<summary>
        /// Thêm mới 1 loại sản phẩm, các thông số gửi từ client lên
        /// Route: api/category
        /// </summary>
        /// <param name="categoryName">tên </param>
        /// <param name="categoryURL">link(ảnh)</param>
        /// <param name="createdDate"> ngày đăng</param>
        /// <returns>true thành công, false thất bại</returns>
        [HttpPost]
        public HttpResponseMessage InsertNewCategory(CATEGORY category)
        {
            try
            {
                db.CATEGORies.Add(category);
                db.SaveChanges();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);

                return response;
            }
            catch(Exception ex)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }


        /// <summary>
        /// Chỉnh sửa thông tin
        /// Route: api/category/id
        /// </summary>
        /// <param name="categoryID">mã loại sản phẩm muốn sửa</param>
        /// <param name="categoryName">tên mới</param>
        /// <param name="categoryURL">link mới</param>
        /// <param name="createdDate">ngày đăng mới</param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage UpdateCategory(int id, CATEGORY category)
        {
            try
            {
                if(id == category.CategoryID)
                {
                    db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

                    return response;
                }
                else
                {
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotModified);
                    return response;
                }
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotModified);
                return response;
            }
        }
        /// <summary>
        /// Xóa loại sản phẩm có id
        /// Route: api/category/id
        /// </summary>
        /// <param name="categoryID">id muốn xóa</param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteCategory(int id)
        {
            CATEGORY category = db.CATEGORies.Find(id);
            if (category != null)
            {
                db.CATEGORies.Remove(category);
                db.SaveChanges();
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                return response;
            }
            else
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound);
                return response;
            }
        }
    }
}
