using BaseLib;
using DataService.DataAccess.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DataService.DataAccess.DAL
{
    internal class CSqlSport
    {
        //===================================== Add Brand =====================================//
        public static SportModels.DALOutput Api_Sport_Brand_Add_DAL(SportModels.BrandModel BM)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] arrParams = new SqlParameter[3];

                // input params
                arrParams[0] = new SqlParameter("brandName", SqlDbType.NVarChar, 50);
                arrParams[0].Direction = ParameterDirection.Input;
                arrParams[0].Value = BM.BrandName;

                // input params
                arrParams[1] = new SqlParameter("brandURL", SqlDbType.NVarChar, 200);
                arrParams[1].Direction = ParameterDirection.Input;
                arrParams[1].Value = BM.BrandURL;

                // input params
                arrParams[2] = new SqlParameter("createdDate", SqlDbType.Date);
                arrParams[2].Direction = ParameterDirection.Input;
                arrParams[2].Value = BM.CreatedDate;

                // exec
                SqlHelper.ExecuteDataset(CConfigDS.CONNECTION_STRING_SQL_SPORT_SHOP, CommandType.StoredProcedure, CConfigDS.SPORT_SHOP_SQL_SP_BRAND_ADD, arrParams);

                // return (neu sp ko tra error code,msg thi tu gan default)
                return new SportModels.DALOutput() { ErrorCode = CConfigDS.RESPONSE_CODE_SUCCESS, ErrorMessage = CConfigDS.RESPONSE_MSG_SUCCESS, SqlData = "OK" + BM.BrandName };
            }
            catch (Exception ex)
            {
                // log error
                CLog.LogError(CBase.GetDeepCaller(), CBase.GetDetailError(ex));
                // error => return null
                return new SportModels.DALOutput() { ErrorCode = CBase.GetLayerErrorCode(CBase.LAYER.DAL), ErrorMessage = ex.Message, SqlData = null };
            }
        }
    }
}