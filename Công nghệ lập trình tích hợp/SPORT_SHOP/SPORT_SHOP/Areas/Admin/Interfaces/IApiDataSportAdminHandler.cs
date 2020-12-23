using BaseLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemCore.Entities;

namespace SPORT_SHOP.Areas.Admin.Interfaces
{
    public interface IApiDataSportAdminHandler
    {
        // Lấy danh sách loại sản phẩm
        Task<EResponseResult> Api_Margin_CEzMortgage_PayEztradeGetDetail(SportModels.CategoryModel CM);
    }
}
