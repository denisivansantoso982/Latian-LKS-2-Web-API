using Latian_LKS_2_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Latian_LKS_2_Web_API.Controllers
{
    public class FDController : ApiController
    {
        private HotelLagiEntities row = new HotelLagiEntities();

        public List<FDModel> Get()
        {
            List<FDModel> fds = new List<FDModel>();
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-QK9HLMP4\HOYIRULSQL;Initial Catalog=HotelLagi;Integrated Security=True");
            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT ID, Name, Type, Price FROM FoodsAndDrinks", connection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                fds.Add(new FDModel() {
                    ID = Convert.ToInt32(reader[0]),
                    Name = Convert.ToString(reader[1]),
                    Type = Convert.ToString(reader[2]),
                    Price = Convert.ToInt32(reader[3])
                });
            }

            connection.Close();

            return fds;
        }
        
        public FDModel Get(int id)
        {
            FDModel fd = new FDModel();
            SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-QK9HLMP4\HOYIRULSQL;Initial Catalog=HotelLagi;Integrated Security=True");
            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT ID, Name, Type, Price FROM FoodsAndDrinks WHERE ID = " + id, connection);
            SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            if (reader.HasRows)
            {
                fd.ID = Convert.ToInt32(reader[0]);
                fd.Name = Convert.ToString(reader[1]);
                fd.Type = Convert.ToString(reader[2]);
                fd.Price = Convert.ToInt32(reader[3]);
            } else
            {
                return null;
            }

            connection.Close();

            return fd;
        }
    }
}
