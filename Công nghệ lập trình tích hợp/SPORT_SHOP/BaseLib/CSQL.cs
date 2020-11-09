using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLib
{
    public class CSQL
    {

        private const string PARAM_INPUT_TRADING_PASSWORD = "p_aTradePass";
        private const string PARAM_NAME_MATCH_ACCOUNTNO_1 = "loginname";
        private const string PARAM_NAME_MATCH_ACCOUNTNO_2 = "clientcode";
        private const string ACCOUNTNO_UNKNOWN = "UNKNOWN";

        /// <summary>
        /// 2018-05-18 13:47:27 ngocta2
        /// lay thong tin chi tiet cac param de ghi log
        /// </summary>
        /// <param name="arrParams"></param>
        /// <returns>
        //pclientcode='058C108101',
        //pbuysell='ALL',
        //pexchange='ALL',
        //pstockcode='ALL',
        //ptradingaccount='ALL',
        //rs='',
        /// </returns>
        public static string GetParamInfo(SqlParameter[] arrParams)
        {
            string strInfo = CConfig.CHAR_CRLF;
            for (int i = 0; i < arrParams.Length; i++)
            {
                if (arrParams[i].ParameterName == PARAM_INPUT_TRADING_PASSWORD)  // DataService.AppCode.DAL.COracleStockV1.Api_Auth_Validate_Trading_Pass_V
                    strInfo += CConfig.CHAR_TAB + arrParams[i].ParameterName + "='******'," + CConfig.CHAR_CRLF; // khong ghi password vao log file
                else
                    strInfo += CConfig.CHAR_TAB + arrParams[i].ParameterName + "='" + arrParams[i].Value + "'," + CConfig.CHAR_CRLF; // ko phai password thi ghi log binh thuong
            }

            return strInfo;
        }

        /// <summary>
        /// 2018-08-27 11:07:43 ngocta2
        /// lay gia tri so tai khoan tu 1 array cac param
        /// co tat ca 4 loai ten param luu so tai khoan
        //pa_loginname
        //p_aclientcode
        //paclientcode
        //pClientCode
        /// </summary>
        /// <param name="arrParams"></param>
        /// <returns>058C108101</returns>
        public static string GetAccountNo(SqlParameter[] arrParams)
        {
            for (int i = 0; i < arrParams.Length; i++)
            {
                string strParameterName = arrParams[i].ParameterName.ToLower();
                if (strParameterName.IndexOf(PARAM_NAME_MATCH_ACCOUNTNO_1) != -1 || strParameterName.IndexOf(PARAM_NAME_MATCH_ACCOUNTNO_2) != -1)
                    return arrParams[i].Value.ToString();
            }

            return ACCOUNTNO_UNKNOWN;
        }
    }
}
