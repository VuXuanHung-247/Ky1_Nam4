using BaseLib;
using DataService.DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataService.DataAccess.BLL
{
    public class CSport
    {
        //===================================== Add Brand =====================================//
        static public SportModels.ResponseModel Api_Sport_Brand_Add_BLL(SportModels.BrandModel BM)
        {
            SportModels.ResponseModel RM = new SportModels.ResponseModel();

            try
            {
                //lay du lieu tu DAL, return                
                SportModels.DALOutput DALO = new SportModels.DALOutput();

                DALO = CSqlSport.Api_Sport_Brand_Add_DAL(BM);

                // response info (success)
                RM.Code = DALO.ErrorCode;
                RM.Message = DALO.ErrorMessage;
                RM.Data = DALO.SqlData;
            }
            catch (Exception ex)
            {
                // log error
                CLog.LogError(CBase.GetDeepCaller(), CBase.GetDetailError(ex));
                // response info (error)
                RM.Code = CBase.GetLayerErrorCode(CBase.LAYER.BLL);
                RM.Message = ex.Message;
                RM.Data = null;
            }

            // return
            return RM;
        }
    }
}