using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLib.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportShopBase.Controllers
{
    [Route("api/[controller]")]
    public class SportShopBaseController : Controller
    {
        // vars
        public readonly IS6GApp _s6GApp;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="s6GApp"></param>
        public SportShopBaseController(IS6GApp s6GApp)
        {
            this._s6GApp = s6GApp;
        }
    }
}
