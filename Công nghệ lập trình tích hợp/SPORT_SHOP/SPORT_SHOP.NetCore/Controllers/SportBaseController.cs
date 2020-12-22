using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLib.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemCore.Entities;
using SystemCore.Temporaries;

namespace SPORT_SHOP.NetCore.Controllers
{
    public class SportBaseController : Controller
    {
        // vars
        public readonly IS6GApp _s6GApp;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="s6GApp"></param>
        public SportBaseController(IS6GApp s6GApp)
        {
            this._s6GApp = s6GApp;
        }

        //------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// 2018-05-22 14:04:43 ngocta2
        /// kiem tra request hop le, co quyen truy cap du lieu ko
        /// 2020-02-07 11:28:42 ngocta2 => DS run noi bo, ko public, ko can check quyen
        /// </summary>
        /// <returns></returns>
        public bool AuthenticateRequest()
        {
            try
            {
                //string actionName     = this.ControllerContext.RouteData.Values["action"].ToString();
                //string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                // return
                return true;
            }
            catch (Exception ex)
            {
                // log error
                // this._s6GApp.ErrorLogger.LogError(ex);
                // false
                return false;
            }
        }

        /// <summary>
        /// 2019-11-27 11:28:14 ngocta2
        /// tao response StatusCodes.Status403Forbidde
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateAccessDeniedResponse()
        {
            //await Task.Run(() => { }); // them code nay de xoa warning khi build => xau
            return new StatusCodeResult(StatusCodes.Status403Forbidden);
        }

        /// <summary>
        /// 2019-11-27 13:13:33 ngocta2
        /// tao response tra data json 
        /// The sample download returns the list of authors. Using the F12 browser developer tools or Postman with the previous code:
        /// The response header containing content-type: application/json; charset=utf-8 is displayed.
        /// The request headers are displayed.For example, the Accept header.The Accept header is ignored by the preceding code.
        /// To return plain text formatted data, use Content and the Content helper:
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public IActionResult CreateJsonResponse(object data)
        {
            string json = this._s6GApp.Common.SerializeObject(data);
            // NotSupportedException: The collection type 'System.Data.DataRelationCollection' on 'System.Data.DataSet.Relations' is not supported.
            TExecutionContext ec = this._s6GApp.DebugLogger.WriteBufferBegin($"{EGlobalConfig.__STRING_BEFORE} data={json}", true);

            try
            {
                // return
                //return Ok(0); // NotSupportedException: The collection type 'System.Data.DataRelationCollection' on 'System.Data.DataSet.Relations' is not supported.
                return Content(json); // OK
            }
            catch (Exception ex)
            {
                // log error + buffer data
                this._s6GApp.ErrorLogger.LogErrorContext(ex, ec);
                // create response, code 500
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// 2020-02-11 15:10:32 ngocta2
        /// </summary>
        /// <returns></returns>
        public EServerVars GetServerVars()
        {
            // cac param khac
            EServerVars serverVars = new EServerVars();

            // if de run ok trong unit test
            if (Request != null)
            {
                serverVars.HttpUserAgent = Request.Headers[EGlobalConfig.__STRING_HEADER_USER_AGENT].ToString();
                serverVars.LocalAddr = Request.HttpContext.Connection.LocalIpAddress != null ? Request.HttpContext.Connection.LocalIpAddress.ToString() : EGlobalConfig.__STRING_NULL;
                serverVars.RemoteAddr = Request.HttpContext.Connection.RemoteIpAddress != null ? Request.HttpContext.Connection.RemoteIpAddress.ToString() : EGlobalConfig.__STRING_NULL;
            };

            // return 
            return serverVars;
        }
    }
}