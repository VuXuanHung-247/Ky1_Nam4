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
        //===================================== GetList Category =====================================//
        

        //===================================== Add Category =====================================//
        static public SportModels.ResponseModel Api_Sport_Category_Add_BLL(SportModels.CategoryModel CM)
        {
            SportModels.ResponseModel RM = new SportModels.ResponseModel();

            try
            {
                //lay du lieu tu DAL, return                
                SportModels.DALOutput DALO = new SportModels.DALOutput();

                DALO = CSqlSport.Api_Sport_Category_Add_DAL(CM);

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

        //===================================== Update Category =====================================//
        static public SportModels.ResponseModel Api_Sport_Category_Update_BLL(SportModels.CategoryModel CM)
        {
            SportModels.ResponseModel RM = new SportModels.ResponseModel();

            try
            {
                //lay du lieu tu DAL, return                
                SportModels.DALOutput DALO = new SportModels.DALOutput();

                DALO = CSqlSport.Api_Sport_Category_Update_DAL(CM);

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

        //===================================== Delete Category =====================================//
        static public SportModels.ResponseModel Api_Sport_Category_Delete_BLL(SportModels.CategoryModel CM)
        {
            SportModels.ResponseModel RM = new SportModels.ResponseModel();

            try
            {
                //lay du lieu tu DAL, return                
                SportModels.DALOutput DALO = new SportModels.DALOutput();

                DALO = CSqlSport.Api_Sport_Category_Delete_DAL(CM);

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



        //End.
    }
}