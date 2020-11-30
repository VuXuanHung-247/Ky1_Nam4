using BaseLib;
using DataService.DataAccess.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static BaseLib.SportModels;

namespace DataService.DataAccess.DAL
{
    internal class CSqlSport
    {
        //===================================== GetList Category =====================================//
        

        //===================================== Add Category =====================================//
        public static SportModels.DALOutput Api_Sport_Category_Add_DAL(SportModels.CategoryModel CM)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] arrParams = new SqlParameter[3];

                // input params
                arrParams[0] = new SqlParameter("categoryName", SqlDbType.NVarChar, 50);
                arrParams[0].Direction = ParameterDirection.Input;
                arrParams[0].Value = CM.CategoryName;

                // input params
                arrParams[1] = new SqlParameter("categoryURL", SqlDbType.NVarChar, 200);
                arrParams[1].Direction = ParameterDirection.Input;
                arrParams[1].Value = CM.CategoryURL;

                // input params
                arrParams[2] = new SqlParameter("createdDate", SqlDbType.DateTime);
                arrParams[2].Direction = ParameterDirection.Input;
                arrParams[2].Value = CM.CreatedDate;

                // exec
                SqlHelper.ExecuteDataset(CConfigDS.CONNECTION_STRING_SQL_SPORT_SHOP, CommandType.StoredProcedure, CConfigDS.SPORT_SHOP_SQL_SP_CATEGORY_ADD, arrParams);

                // return (neu sp ko tra error code,msg thi tu gan default)
                return new SportModels.DALOutput() { ErrorCode = CConfigDS.RESPONSE_CODE_SUCCESS, ErrorMessage = CConfigDS.RESPONSE_MSG_SUCCESS, SqlData = ds };
            }
            catch (Exception ex)
            {
                // log error
                CLog.LogError(CBase.GetDeepCaller(), CBase.GetDetailError(ex));
                // error => return null
                return new SportModels.DALOutput() { ErrorCode = CBase.GetLayerErrorCode(CBase.LAYER.DAL), ErrorMessage = ex.Message, SqlData = null };
            }
        }

        //===================================== Update Category =====================================//
        public static SportModels.DALOutput Api_Sport_Category_Update_DAL(SportModels.CategoryModel CM)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] arrParams = new SqlParameter[4];

                // input params
                arrParams[0] = new SqlParameter("categoryID", SqlDbType.Int);
                arrParams[0].Direction = ParameterDirection.Input;
                arrParams[0].Value = CM.CategoryID;

                // input params
                arrParams[1] = new SqlParameter("categoryName", SqlDbType.NVarChar, 50);
                arrParams[1].Direction = ParameterDirection.Input;
                arrParams[1].Value = CM.CategoryName;

                // input params
                arrParams[2] = new SqlParameter("categoryURL", SqlDbType.NVarChar, 200);
                arrParams[2].Direction = ParameterDirection.Input;
                arrParams[2].Value = CM.CategoryURL;

                // input params
                arrParams[3] = new SqlParameter("createdDate", SqlDbType.DateTime);
                arrParams[3].Direction = ParameterDirection.Input;
                arrParams[3].Value = CM.CreatedDate;

                // exec
                SqlHelper.ExecuteDataset(CConfigDS.CONNECTION_STRING_SQL_SPORT_SHOP, CommandType.StoredProcedure, CConfigDS.SPORT_SHOP_SQL_SP_CATEGORY_UPDATE, arrParams);

                // return (neu sp ko tra error code,msg thi tu gan default)
                return new SportModels.DALOutput() { ErrorCode = CConfigDS.RESPONSE_CODE_SUCCESS, ErrorMessage = CConfigDS.RESPONSE_MSG_SUCCESS, SqlData = ds };
            }
            catch (Exception ex)
            {
                // log error
                CLog.LogError(CBase.GetDeepCaller(), CBase.GetDetailError(ex));
                // error => return null
                return new SportModels.DALOutput() { ErrorCode = CBase.GetLayerErrorCode(CBase.LAYER.DAL), ErrorMessage = ex.Message, SqlData = null };
            }
        }

        //===================================== Delete Category =====================================//
        public static SportModels.DALOutput Api_Sport_Category_Delete_DAL(SportModels.CategoryModel CM)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] arrParams = new SqlParameter[1];

                // input params
                arrParams[0] = new SqlParameter("categoryID", SqlDbType.Int);
                arrParams[0].Direction = ParameterDirection.Input;
                arrParams[0].Value = CM.CategoryID;
                
                // exec
                SqlHelper.ExecuteDataset(CConfigDS.CONNECTION_STRING_SQL_SPORT_SHOP, CommandType.StoredProcedure, CConfigDS.SPORT_SHOP_SQL_SP_CATEGORY_DELETE, arrParams);

                // return (neu sp ko tra error code,msg thi tu gan default)
                return new SportModels.DALOutput() { ErrorCode = CConfigDS.RESPONSE_CODE_SUCCESS, ErrorMessage = CConfigDS.RESPONSE_MSG_SUCCESS, SqlData = ds };
            }
            catch (Exception ex)
            {
                // log error
                CLog.LogError(CBase.GetDeepCaller(), CBase.GetDetailError(ex));
                // error => return null
                return new SportModels.DALOutput() { ErrorCode = CBase.GetLayerErrorCode(CBase.LAYER.DAL), ErrorMessage = ex.Message, SqlData = null };
            }
        }

        // End.
    }
}