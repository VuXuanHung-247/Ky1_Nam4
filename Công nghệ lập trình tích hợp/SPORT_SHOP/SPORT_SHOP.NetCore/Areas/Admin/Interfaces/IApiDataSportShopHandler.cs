using BaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemCore.Entities;

namespace SPORT_SHOP.NetCore.Areas.Admin.Interfaces
{
    public interface IApiDataSportShopHandler
    {
        Task<EResponseResult> Api_Category_Get_List(SportModels.CategoryModel CM);
    }
}
