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
    public class ApiSportCategorySearchController : ApiBaseController
    {
        // Route: api/sport/category/search
        // Method: GET
        //===================================== Search Category =====================================//
        [HttpGet]
        public HttpResponseMessage Api_Sport_Category_Search( )
        {
            SportModels.ResponseModel RM = new SportModels.ResponseModel();
            SportModels.CategoryModel CM = new SportModels.CategoryModel();
            try
            {
                // ?categoryName={CategoryName}&createdDate={CreatedDate}
                var varUrlKeyValues = ControllerContext.Request.GetQueryNameValuePairs();

                // lay cac value can thiet tu queryString
                CM.CategoryName = varUrlKeyValues.LastOrDefault(x => x.Key == "categoryName").Value;
                CM.CreatedDate = Convert.ToDateTime(varUrlKeyValues.LastOrDefault(x => x.Key == "createdDate").Value);

                // 1. get data
                RM = CSport.Api_Sport_Category_Search_BLL(CM);

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
    }
}
