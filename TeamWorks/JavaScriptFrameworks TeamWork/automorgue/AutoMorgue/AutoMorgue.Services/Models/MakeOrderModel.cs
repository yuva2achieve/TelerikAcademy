using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoMorgue.Services.Models
{
    public class MakeOrderModel
    {
        public int UserId { get; set; }
        public int AutoPartId { get; set; }
        public int Quantity { get; set; }
    }
}