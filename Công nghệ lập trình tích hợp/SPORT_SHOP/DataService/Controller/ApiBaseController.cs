using BaseLib;
using DataService.DataAccess.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace DataService.Controller
{
    public class ApiBaseController : ApiController
    {
        protected HttpResponseMessage CreateJsonResponse(object objData)
        {
            try
            {
                // header/contentType - JSON
                MediaTypeHeaderValue MTHV = new MediaTypeHeaderValue(CConfigDS.RESPONSE_CONTENT_TYPE_JSON);
                // create response, code 200
                HttpResponseMessage HRM = Request.CreateResponse(HttpStatusCode.OK, objData, MTHV);
                // return
                return HRM;
            }
            catch (Exception ex)
            {
                // log error
                CLog.LogError(CBase.GetDeepCaller(), CBase.GetDetailError(ex));
                // create response, code 500
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// kiem tra request hop le, co quyen truy cap du lieu ko
        /// </summary>
        /// <returns></returns>
        protected bool AuthenticateRequest()
        {
            try
            {
                // check header (token) => se them trong tuong lai
                // ......
                // ......
                // ......
                // ......

                // return
                return true;
            }
            catch (Exception ex)
            {
                // log error
                CLog.LogError(CBase.GetDeepCaller(), CBase.GetDetailError(ex));
                // false
                return false;
            }
        }

        /// <summary>
        /// 
        /// tao response ko co quyen, tra ve client
        /// </summary>
        /// <returns></returns>
        protected HttpResponseMessage CreateAccessDeniedResponse()
        {
            try
            {
                return CreateJsonResponse(
                    new SportModels.ResponseModel()
                    {
                        Code = CConfigDS.RESPONSE_CODE_ACCESS_DENIED,
                        Message = CConfigDS.RESPONSE_MSG_ACCESS_DENIED,
                        Data = CConfigDS.RESPONSE_DATA_NULL
                    }
                );
            }
            catch (Exception ex)
            {
                // log error
                CLog.LogError(CBase.GetDeepCaller(), CBase.GetDetailError(ex));
                // create response, code 500
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
