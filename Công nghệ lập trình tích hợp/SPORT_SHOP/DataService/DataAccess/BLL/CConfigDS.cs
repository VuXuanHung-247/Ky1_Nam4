using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DataService.DataAccess.BLL
{
    public class CConfigDS
    {
        // web.config
        public static string CONNECTION_STRING_SQL_SPORT_SHOP = ConfigurationManager.ConnectionStrings["CONNECTION_STRING_SQL_SPORT_SHOP"].ConnectionString.ToString();
        public static string CONNECTION_STRING_SQL_QUAN_CA_PHE = ConfigurationManager.ConnectionStrings["CONNECTION_STRING_SQL_SPORT_SHOP"].ConnectionString.ToString();


        // tat ca response tra ve phai la dang JSON
        public const string RESPONSE_CONTENT_TYPE_JSON = "application/json";
        public const int RESPONSE_CODE_SUCCESS = 0;
        public const string RESPONSE_MSG_SUCCESS = "SUCCESS";
        public const int RESPONSE_CODE_INIT = -1;
        public const string RESPONSE_MSG_INIT = "INIT";
        public const int RESPONSE_CODE_ACCESS_DENIED = -123456;
        public const string RESPONSE_MSG_ACCESS_DENIED = "ACCESS_DENIED";
        public const string RESPONSE_DATA_NULL = null;

        // common
        internal const string CHAR_CRLF = "\r\n";
        internal const string CHAR_TAB = "\t";
        internal const string STRING_BLANK = "";
        internal const string STRING_TRANS_ID_DEFAULT = "0";

        //SP SPORT_CATEGORY
        //public const string STUDENTS_SQL_SP_APP_STUDENTS_LIST = "select * from SinhVienView";
        public const string SPORT_SHOP_SQL_SP_CATEGORY_ADD = "sp_category_add";
        public const string SP_QUAN_CAPHE_LOGIN = "sp_category_add";
        public const string SP_QUAN_CAPHE_DRINK_SEARCH = "sp_category_add";
    }
}