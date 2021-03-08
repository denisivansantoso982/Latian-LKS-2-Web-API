using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Latian_LKS_2_Web_API.Models
{
    public class FDCheckOutModel
    {
        //public int ID { get; set; }
        public int ReservationRoomID { get; set; }
        public int FDID { get; set; }
        public int Qty { get; set; }
        public int TotalPrice { get; set; }
        public int EmployeeID { get; set; }
    }
}