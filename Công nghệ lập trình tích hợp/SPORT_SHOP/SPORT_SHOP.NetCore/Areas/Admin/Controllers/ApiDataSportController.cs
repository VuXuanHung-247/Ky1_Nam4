using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseLib;
using CommonLib.Implementations;
using CommonLib.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SPORT_SHOP.NetCore.Areas.Admin.Interfaces;
using SPORT_SHOP.NetCore.Controllers;
using SystemCore.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SPORT_SHOP.NetCore.Areas.Admin.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApiDataSportController : SportBaseController
    {
        public readonly IS6GApp _cS6GApp;
        private readonly IApiDataSportShopHandler _handler;
        private IConfiguration _configuration;
       // public readonly IAccountClient _cAccountClient;


        public ApiDataSportController(IS6GApp s6GApp, IApiDataSportShopHandler handler)
           : base(s6GApp)
        {
            this._handler = handler;
            //_configuration = CS6GFactory.GetConfigInstance();
           // this._cAccountClient = accountClient;
        }

        /// <summary>
        /// Lấy danh sách loại sản phẩm
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            SportModels.CategoryModel CM = new SportModels.CategoryModel();
            try
            {
                // BEGIN: authenticate
                // AccountModel AM = await AuthenticateRequest(HttpContext);
                // input
                // lay cac value can thiet tu queryString
                // MSHDG.ClientCode = AM.LoginName;


                // 1. get data

                EResponseResult responseResult = await this._handler.Api_Category_Get_List(CM);

                // 2. return response (code 200)
                return CreateJsonResponse(responseResult);

            }
            catch (Exception ex)
            {
                // log error + buffer data
                this._s6GApp.ErrorLogger.LogError(ex);
                // return null
                return CreateJsonResponse(new EResponseResult() { Code = EGlobalConfig.__CODE_ERROR_IN_LAYER_BLL, Message = ex.Message, Data = null });
            }
        }
    }
}
