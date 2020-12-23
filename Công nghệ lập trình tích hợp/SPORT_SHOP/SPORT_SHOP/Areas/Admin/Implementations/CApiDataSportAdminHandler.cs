using BaseLib;
using CommonLib.Interfaces;
using Newtonsoft.Json;
using SPORT_SHOP.Areas.Admin.Data;
using SPORT_SHOP.Areas.Admin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SystemCore.Entities;

namespace SPORT_SHOP.Areas.Admin.Implementations
{
    public class CApiDataSportAdminHandler : IApiDataSportAdminHandler
    {
        private readonly IS6GApp _s6GApp;

        /// <summary>
        /// abc
        /// </summary>
        /// <param name="s6GApp"></param>
        public CApiDataSportAdminHandler(IS6GApp s6GApp)
        {
            this._s6GApp = s6GApp;
        }
        /// <summary>
        /// Lấy danh sách loại sản phẩm
        /// </summary>
        /// <param name="CM"></param>
        /// <returns></returns>
        /// 

        public async Task<EResponseResult> Api_Sport_Category(SportModels.CategoryModel CM)
        {

            // setup request
            string URL = $"{CApiDataSportAdminConfig.URL_DS_SPORT_SHOP_HOST}/{CApiDataSportAdminConfig.URL_DS_SPORT_CATEGORY}";
            var tsk = await (new HttpClient()).GetAsync(URL);
            string strResponse = await tsk.Content.ReadAsStringAsync(); // async 


            // convert json string >> class
            EResponseResult RM = JsonConvert.DeserializeObject<EResponseResult>(strResponse);

            // return 
            return RM;

        }
    }
}
