using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Latian_LKS_2_Web_API.Models;
using System.Data.SqlClient;

namespace Latian_LKS_2_Web_API.Controllers
{
    public class FDCheckOutController : ApiController
    { 

        [HttpPost]
        [Route("api/FDCheckOut")]
        public string[] Post(FDCheckOutModel fdCheckOut)
        {
            try
            {
                String sql = "INSERT INTO FDCheckOut VALUES(" + fdCheckOut.ReservationRoomID + ", " + fdCheckOut.FDID + ", " + fdCheckOut.Qty + ", " + fdCheckOut.TotalPrice + ", " + fdCheckOut.EmployeeID + ")";
                SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-QK9HLMP4\HOYIRULSQL;Initial Catalog=HotelLagi;Integrated Security=True");

                if (fdCheckOut != null)
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();

                    connection.Close();
                } else
                {
                    return new string[] { "Can't be null" };
                }

                return new string[] { "Success" };

            } catch (Exception ex)
            {
                return new string[] { ex.Message };
            }
        }
    }
}