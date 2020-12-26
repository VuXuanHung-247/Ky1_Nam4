using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppMVC_Sport.Models
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryURL { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}