using BaseLib;
using DataService.DataAccess.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataService.Controller
{
    public class ApiSportCategoryController : ApiBaseController
    {
        [HttpPost]
        public HttpResponseMessage Api_Sport_Category_Add(SportModels.CategoryModel CM)
        {
            SportModels.ResponseModel RM = new SportModels.ResponseModel();
            try
            {
                // 1. get data
                RM = CSport.Api_Sport_Category_Add_BLL(CM);

                // 2. return response (code 200)
                return CreateJsonResponse(CM);
            }
            catch (Exception ex)
            {
                // log error
                CLog.LogError(CBase.GetDeepCaller(), CBase.GetDetailError(ex));
                // return error code
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
