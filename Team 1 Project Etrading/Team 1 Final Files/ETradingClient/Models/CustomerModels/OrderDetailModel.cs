﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETradingClient.Models
{
    public class OrderDetailModel
    {
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public int VendorID { get; set; }
    }
}