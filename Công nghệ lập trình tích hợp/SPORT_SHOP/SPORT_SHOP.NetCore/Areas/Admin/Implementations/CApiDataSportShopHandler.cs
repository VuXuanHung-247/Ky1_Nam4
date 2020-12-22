using BaseLib;
using CommonLib.Interfaces;
using Newtonsoft.Json;
using SPORT_SHOP.NetCore.Areas.Admin.Data;
using SPORT_SHOP.NetCore.Areas.Admin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SystemCore.Entities;

namespace SPORT_SHOP.NetCore.Areas.Admin.Implementations
{
    public class CApiDataSportShopHandler : IApiDataSportShopHandler
    {
        private readonly IS6GApp _s6GApp;

        /// <summary>
        /// Admin
        /// </summary>
        /// <param name="s6GApp"></param>
        public CApiDataSportShopHandler(IS6GApp s6GApp)
        {
            this._s6GApp = s6GApp;
        }
        // Lấy danh sách loại sản phẩm
        public async Task<EResponseResult> Api_Category_Get_List(SportModels.CategoryModel CM)
        {

            // setup request
            string URL = $"{CApiDataSportShopConfig.URL_DS_SPORT_SHOP_HOST}/{CApiDataSportShopConfig.URL_DS_SPORT_SHOP_CATEGORY}";
            var tsk = await (new HttpClient()).GetAsync(URL);
            string strResponse = await tsk.Content.ReadAsStringAsync(); // async 


            // convert json string >> class
            EResponseResult RM = JsonConvert.DeserializeObject<EResponseResult>(strResponse);

            // return 
            return RM;

        }
    }
}
