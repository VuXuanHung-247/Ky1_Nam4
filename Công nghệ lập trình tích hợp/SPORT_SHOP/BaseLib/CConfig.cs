using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLib
{
    internal class CConfig
    {
        internal static string BASE_APP_NAME = ConfigurationManager.AppSettings["BASE_APP_NAME"].ToString();
        internal static string BASE_LOG_ERROR = ConfigurationManager.AppSettings["BASE_LOG_ERROR"].ToString();
        internal static string BASE_LOG_SQL = ConfigurationManager.AppSettings["BASE_LOG_SQL"].ToString();
        internal static string BASE_LOG_MULTI_THREAD = ConfigurationManager.AppSettings["BASE_LOG_MULTI_THREAD"].ToString();
        internal static string BASE_LOG_PATH_ERROR = ConfigurationManager.AppSettings["BASE_LOG_PATH_ERROR"].ToString();
        internal static string BASE_LOG_PATH_SQL = ConfigurationManager.AppSettings["BASE_LOG_PATH_SQL"].ToString();
        internal static string BASE_LOG_PATH_TEXT = ConfigurationManager.AppSettings["BASE_LOG_PATH_TEXT"].ToString();
        internal static string BASE_LOG_PATH_EX = ConfigurationManager.AppSettings["BASE_LOG_PATH_EX"].ToString();
        internal static string BASE_TEMPLATE_LOG_EX_FILENAME = ConfigurationManager.AppSettings["BASE_TEMPLATE_LOG_EX_FILENAME"].ToString();


        internal static string NO_LOG_SET = "0";
        internal static string SINGLE_THREAD = "0";

        internal static string TEMPLATE_LOG_DATA = "(Time)|(Title)|(Detail)";
        internal static string LOG_EXT = ".txt";
        internal static string LOG_EXT_SQL = ".sql";

        internal const string CHAR_CRLF = "\r\n";
        internal const string CHAR_TAB = "\t";

        internal const string FORMAT_DATETIME = "yyyy-MM-dd HH:mm:ss";

        public const string RIGHT_EXERCISE_ADVANCE_TIME_BEGIN = "08:00:00";
        public const string RIGHT_EXERCISE_ADVANCE_TIME_END = "16:00:00"; //"19:00:00";

    }
}
