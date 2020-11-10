using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLib
{
    public class SportModels
    {
        // response cho tat ca request
        public class ResponseModel
        {
            public const string RESPONSE_CONTENT_TYPE_JSON = "application/json";
            public const long RESPONSE_CODE_SUCCESS = 0;
            public const string RESPONSE_MSG_SUCCESS = "SUCCESS";
            public const long RESPONSE_CODE_INIT = -1;
            public const string RESPONSE_MSG_INIT = "INIT";
            public const long RESPONSE_CODE_ACCESS_DENIED = -123456;
            public const string RESPONSE_MSG_ACCESS_DENIED = "ACCESS_DENIED";
            public const string RESPONSE_DATA_NULL = null;
            public const long RESPONSE_CODE_INVALID_TRADING_PASSWORD = -10;
            public const long RESPONSE_CODE_INVALID_DATA = -20;

            public long Code { get; set; }    // error code tra ra tu sp
            public string Message { get; set; }    // error message tra ra tu sp => khong phai dung msg nay de show ra cho end-user xem, msg nay chi giup cho debug
            public object Data { get; set; }    // data object co the la DataSet hoac DataTable hoac NULL .... tuy vao context

            // 2018-05-21 10:44:22 ngocta2
            // khi tao instance, default gan cho cac gia tri sau
            public ResponseModel()
            {
                Code = RESPONSE_CODE_INIT;
                Message = RESPONSE_MSG_INIT;
                Data = RESPONSE_DATA_NULL;
            }
        }
        // DAL return obj nay cho BLL
        public class DALOutput
        {
            public long ErrorCode { get; set; }          // error code tra ra tu sp
            public string ErrorMessage { get; set; }    // error message tra ra tu sp
            public object SqlData { get; set; }      // data tra ra tu oracle db
        }
        public class ProductModel
        {
            public string ProductID { get; set; }               // Mã sản phẩm
            public string ProductName { get; set; }             // Tên sản phẩm
            public string ProductDescription { get; set; }      // Mô tả sản phẩm
            public string ProductPrice { get; set; }            // Giá sản phẩm
            public string PromotionPrice { get; set; }          // Giá khuyển mại
            public string Rating { get; set; }                  // Tỷ lệ
            public string ProductImage { get; set; }            //Ảnh sản phẩm
            public string ProductStock { get; set; }            // Tồn kho
            public string ProductURL { get; set; }              // Link sản phẩm
            public string Viewcount { get; set; }               // Lượt xem
            public string ProductStatus { get; set; }           // Trạng thái sản phẩm
            public string CreatedDate { get; set; }             // Ngày đăng
            public string BrandID { get; set; }                 // Loại sản phẩm
        }
        public class CategoryModel
        {
            public string CategoryID { get; set; }                 // Mã Loại sản phẩm
            public string CategoryName { get; set; }               // Tên Loại sản phẩm
            public string CategoryURL { get; set; }                // Link Loại sản phẩm
            public string CreatedDate { get; set; }             // Ngày đăng
        }
        public class Properties
        {
            public string PropertiesID { get; set; }            // Mã thuộc tính
            public string Color { get; set; }                   // Màu sắc
            public string Size { get; set; }                    // Kích cỡ
            public string DetailDescription { get; set; }       // Mô tả chi tiết
            public string ProductID { get; set; }               // Mã sản phẩm
        }
        public class Customer
        {
            public string CustomerID { get; set; }             // Mã khách hàng
            public string CustomerUsername { get; set; }       // Tài khoản kh
            public string CustomerPassword { get; set; }       // Mật khẩu kh
            public string CustomerEmail { get; set; }          // Email kh
            public string CustomerName { get; set; }           // Tên khách hàng
            public string CustomerPhone { get; set; }          // Số điện thoại
            public string CustomerAddress { get; set; }        // Địa chỉ
            public string CreatedDate { get; set; }            // Ngày đăng ký
        }
        public class Order
        {
            public string OrderID { get; set; }                // Mã đơn hàng
            public string OrderDate { get; set; }              // Ngày đặt hàng
            public string Total { get; set; }                  // Tổng tiền
            public string CustomerName { get; set; }           // Tên khách hàng
            public string CustomerPhone { get; set; }          // Số điện thoại
            public string CustomerAddress { get; set; }        // Địa chỉ
            public string OrderStatusID { get; set; }          // Mã trạng thái đơn hàng
            public string CustomerID { get; set; }             // Mã khách hàng
        }
        public class OrderStatus
        {
            public string StatusID { get; set; }                // Mã Trạng thái đơn hàng
            public string StatusName { get; set; }              // Tên trạng thái đơn hàng
            public string CreatedDate { get; set; }             // Ngày tạo
        }
        public class OrderDetail
        {
            public string DetailID { get; set; }                // Mã chi tiết đơn hàng
            public string Quantity { get; set; }                // Số lượng
            public string OrderID { get; set; }                 // Mà đơn hàng
            public string ProductID { get; set; }               // Mã sản phẩm
        }
        public class Admin
        {
            public string UserId { get; set; }                  // Mã tài khoản
            public string UserUsername { get; set; }            // Tên tài khoản
            public string UserPassword { get; set; }            // Mật khẩu
            public string UserName { get; set; }                // Tên user
            public string CreatedDate { get; set; }             // Ngày tạo
        }
    }
}
