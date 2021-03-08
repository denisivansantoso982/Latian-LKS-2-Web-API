using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using Latian_LKS_2_Web_API.Models;

namespace Latian_LKS_2_Web_API.Controllers
{
    public class RoomController : ApiController
    {
        private HotelLagiEntities row = new HotelLagiEntities();

        [HttpGet]
        [Route("api/room")]
        public List<RoomDataModel> get()
        {
            List<RoomDataModel> data = new List<RoomDataModel>();
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-QK9HLMP4\HOYIRULSQL;Initial Catalog=HotelLagi;Integrated Security=True");

            connection.Open();

            SqlCommand command = new SqlCommand("select ReservationID, RoomNumber from ReservationRoom inner join Room on ReservationRoom.RoomID = Room.ID", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                data.Add(new RoomDataModel()
                {
                    reservationId = Convert.ToInt32(reader[0]),
                    roomNumber = Convert.ToInt32(reader[1])
                });
            }

            connection.Close();

            return data;
        }

    }
}
