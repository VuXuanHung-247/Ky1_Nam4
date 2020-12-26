using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLib
{
    public class CategoryModel
    {
        public int CategoryID { get; set; }                 // Mã Loại sản phẩm
        public string CategoryName { get; set; }               // Tên Loại sản phẩm
        public string CategoryURL { get; set; }                // Link Loại sản phẩm
        public DateTime CreatedDate { get; set; }             // Ngày đăng


        public CategoryModel()
        {

        }
        public CategoryModel(DataRow row)
        {
            this.CategoryID = (int)row["CategoryID"];
            this.CategoryName = (string)row["CategoryName"];
            this.CategoryURL = (string)row["CategoryURL"];
            this.CreatedDate = (DateTime)row["CreatedDate"];
        }
    }
}
