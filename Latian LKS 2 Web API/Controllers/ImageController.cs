using Latian_LKS_2_Web_API.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace Latian_LKS_2_Web_API.Controllers
{
    public class ImageController : ApiController
    {
        imageTutorialApiEntities row = new imageTutorialApiEntities();
        
        [HttpPost]
        [Route("api/image")]
        public IHttpActionResult Post([FromBody]ImageModel imageModel)
        {
            if (imageModel == null)
            {
                return Ok("Can't be null");
            }

            try
            {
                SqlConnection connection = new SqlConnection(@"Data Source=LAPTOP-QK9HLMP4\HOYIRULSQL;Initial Catalog=imageTutorialApi;Integrated Security=True");
                connection.Open();

                byte[] file = Convert.FromBase64String(imageModel.image);

                SqlCommand cmd = new SqlCommand("INSERT INTO images VALUES(@file)", connection);
                cmd.Parameters.AddWithValue("@file", file);
                cmd.ExecuteNonQuery();

                connection.Close();

                return Ok("Success");

            } catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        public image Get([FromUri]int id)
        {
            image photo = row.images.Find(id);
            if (photo == null)
            {
                return null;
            }

            return photo;
        }
    }
}