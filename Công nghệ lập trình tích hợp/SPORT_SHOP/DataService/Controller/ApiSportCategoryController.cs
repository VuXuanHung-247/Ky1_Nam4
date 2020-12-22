using BaseLib;
using DataService.DataAccess.BLL;
using DataService.DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static BaseLib.SportModels;

namespace DataService.Controller
{
    public class ApiSportCategoryController : ApiBaseController
    {
        // Route: api/sport/category
        // Method: GET
        //===================================== GetList Category =====================================//
        private static ApiSportCategoryController instance;

        public static ApiSportCategoryController Instance
        {
            get { if (instance == null) instance = new ApiSportCategoryController(); return ApiSportCategoryController.instance; }
            private set { ApiSportCategoryController.instance = value; }
        }
        private ApiSportCategoryController() { }
        [HttpGet]
        public List<CategoryModel> GetCategoryList()
        {
            List<CategoryModel> list = new List<CategoryModel>();

            string query = "select * from CATEGORY";

            DataTable data = CQuerySport.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                CategoryModel cm = new CategoryModel(item);
                list.Add(cm);
            }

            return list;
        }

        // Route: api/sport/category
        // Method: POST
        //===================================== Add Category =====================================//
        [HttpPost]
        public HttpResponseMessage Api_Sport_Category_Add(SportModels.CategoryModel CM)
        {
            SportModels.ResponseModel RM = new SportModels.ResponseModel();
            try
            {
                // 1. get data
                RM = CSport.Api_Sport_Category_Add_BLL(CM);

                // 2. return response (code 200)
                return CreateJsonResponse(RM);
            }
            catch (Exception ex)
            {
                // log error
                CLog.LogError(CBase.GetDeepCaller(), CBase.GetDetailError(ex));
                // return error code
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // Route: api/sport/category
        // Method: PUT
        //===================================== Update Category =====================================//
        [HttpPut]
        public HttpResponseMessage Api_Sport_Category_Update(SportModels.CategoryModel CM)
        {
            SportModels.ResponseModel RM = new SportModels.ResponseModel();
            try
            {
                // 1. get data
                RM = CSport.Api_Sport_Category_Update_BLL(CM);

                // 2. return response (code 200)
                return CreateJsonResponse(RM);
            }
            catch (Exception ex)
            {
                // log error
                CLog.LogError(CBase.GetDeepCaller(), CBase.GetDetailError(ex));
                // return error code
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // Route: api/sport/category
        // Method: DELETE
        //===================================== Delete Category =====================================//
        [HttpDelete]
        public HttpResponseMessage Api_Sport_Category_Delete(SportModels.CategoryModel CM)
        {
            SportModels.ResponseModel RM = new SportModels.ResponseModel();
            try
            {
                // 1. get data
                RM = CSport.Api_Sport_Category_Delete_BLL(CM);

                // 2. return response (code 200)
                return CreateJsonResponse(RM);
            }
            catch (Exception ex)
            {
                // log error
                CLog.LogError(CBase.GetDeepCaller(), CBase.GetDetailError(ex));
                // return error code
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        // End.
    }
}
