using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLib.Implementations;
using CommonLib.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SPORT_SHOP.NetCore.Areas.Admin.Interfaces;
using SPORT_SHOP.NetCore.Controllers;

namespace SPORT_SHOP.NetCore.Areas.Admin.Controllers
{
    public class CategoryController : SportBaseController
    {
        // vars
        public readonly IS6GApp _cS6GApp;
        private readonly IApiDataSportShopHandler _handler;
        /// <summary>
        /// constructor: inject
        /// </summary>
        /// <param name="s6GApp"></param>
        public CategoryController(IS6GApp s6GApp, IApiDataSportShopHandler handler) : base(s6GApp)
        {
            //this._cS6GApp = CS6GFactory.GetS6GAppInstance();
            this._handler = handler;
        }

        [Route("CategoryList")]
        public async Task<IActionResult> CategoryList()
        {
            return View();
        }
    }
}