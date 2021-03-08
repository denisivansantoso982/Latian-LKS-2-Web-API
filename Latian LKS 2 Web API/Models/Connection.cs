using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Latian_LKS_2_Web_API.Models
{
    public class Connection
    {
        public static SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-QK9HLMP4\HOYIRULSQL;Initial Catalog=HotelLagi;Integrated Security=True");
    }
}