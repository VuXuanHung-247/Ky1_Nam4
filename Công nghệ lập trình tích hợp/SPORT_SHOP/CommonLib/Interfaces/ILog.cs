using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Interfaces
{
    /// <summary>
    /// 2019-01-09 10:10:13 ngocta2
    /// created class
    /// 2019-01-24 14:08:01 ngocta2 
    /// them thread, task
    /// </summary>
    public interface ILog
    {
		/// <summary>
		/// prop: full path cua file log
		/// D:\WebLog\S6G\CommonLib.Tests\SQL\20190926.js
		/// </summary>
		string FullLogPath { get; }

		/// <summary>
		/// D:\WebLog\S6G\CommonLib.Tests
		/// </summary>
		string LogRootPath { get; }

		/// <summary>
		/// D:\WebLog\S6G\CommonLib.Tests\DEBUG
		/// path cua log folder (4 loai log)
		/// </summary>
		string LogDirPath { get; }
	}
}
