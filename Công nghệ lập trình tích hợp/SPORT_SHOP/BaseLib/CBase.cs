using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.IO;
using System.Globalization;     //language
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace BaseLib
{
    static public class CBase
    {
        // --------------------------
        static public string GetBuildDate()
        {
            return Assembly.GetExecutingAssembly().GetLinkerTime().ToString(CConfig.FORMAT_DATETIME);
        }

        public static DateTime GetLinkerTime(this Assembly assembly, TimeZoneInfo target = null)
        {
            var filePath = assembly.Location;


            //https://stackoverflow.com/questions/1185378/how-do-i-get-modified-date-from-file-in-c-sharp-on-windows-mobile
            FileInfo fileName = new FileInfo(filePath);
            return fileName.LastWriteTime;
        }


        //convert du lieu , thuong dung voi data select tu db ra
        /// http://weblogs.asp.net/psheriff/archive/2013/01/29/building-collections-of-entity-classes-using-a-datareader.aspx


        public static string Right(string value, int length)
        {
            return value.Substring(value.Length - length);
        }




        //truy van URL 
        // strURL = http://liveprice.fpts.com.vn/monitor.asp?k=MW2_SRV_HTML_STOCK_INFO_1_ABT
        // strURL = https://172.16.0.11/mw/4g/monitor.asp?k=MW2_SRV_HTML_STOCK_INFO_1_ABT


        public static string GetCaller(int level = 2)
        {
            var m = new StackTrace().GetFrame(level).GetMethod();

            if (m.DeclaringType == null) return "";
            // .Name is the name only, .FullName includes the namespace
            var className = m.DeclaringType.FullName;

            //the method/function name you are looking for.
            var methodName = m.Name;

            //returns a composite of the namespace, class and method name.
            return className + "->" + methodName;
        }

        // current function name
        public static string GetCurrentMethod()
        {
            return System.Reflection.MethodBase.GetCurrentMethod().Name;
        }

        // .net 4.0 ko ghi chi tiet duoc error
        // .net 4.5 ghi chi tiet den loi tai dong nao
        public static string GetDetailError(Exception ex)
        {
            string strDetailError = "" +
                "\r\nSource\t\t= " + ex.Source +
                "\r\nTargetSite\t= " + ex.TargetSite +
                "\r\nMessage\t\t= " + ex.Message +
                "\r\nStackTrace\t= " + ex.StackTrace;
            return strDetailError;
        }

        // https://stackoverflow.com/questions/6893165/how-to-get-exception-error-code-in-c-sharp

        public enum LAYER
        {
            Controller, BLL, DAL
        }
        public static int GetLayerErrorCode(LAYER ly = LAYER.DAL)
        {
            switch (ly)
            {
                case LAYER.DAL: return -9998;           // DAL
                case LAYER.BLL: return -9997;           // BLL
                case LAYER.Controller: return -9996;    // controller : tai day thuong return HttpStatusCode.InternalServerError (500)
                default: return -9995;                  // unknown (co the ko bao gio vao duoc day)
            }
        }


        public static string GetDeepCaller()
        {
            string strCallerName = "";
            for (int i = 3; i >= 2; i--)
                strCallerName += GetCaller(i) + "=>";

            //returns a composite of the namespace, class and method name.
            return strCallerName;
        }

        public static bool CompareTime(string strTimeBegin, string strTimeEnd)
        {
            //TimeSpan ts = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            double dblNow = (new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second)).TotalSeconds;
            double dblBegin = TimeSpan.Parse(strTimeBegin).TotalSeconds;
            double dblEnd = TimeSpan.Parse(strTimeEnd).TotalSeconds;
            if (dblNow >= dblBegin && dblNow <= dblEnd)
                return true;
            else
                return false;
        }

        //true-thu 7
        //false-ko phai thu 7
        public static bool IsSaturday()
        {
            return (DateTime.Now.DayOfWeek == DayOfWeek.Saturday);
        }


        //true-sunday
        //false-ko phai sunday
        public static bool IsSunday()
        {
            return (DateTime.Now.DayOfWeek == DayOfWeek.Sunday);
        }
        //'true trong khoang 8h-16h
        //'false trong thoi gian con lai	
        //false neu t7,cn
        public static bool InWorkingTime()
        {
            if (CBase.IsSaturday()) return false;
            if (CBase.IsSunday()) return false;
            return CBase.CompareTime(CConfig.RIGHT_EXERCISE_ADVANCE_TIME_BEGIN, CConfig.RIGHT_EXERCISE_ADVANCE_TIME_END);
        }

    }

}
