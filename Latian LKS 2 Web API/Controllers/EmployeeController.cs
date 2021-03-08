using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data;
using System.Data.SqlClient;
using Latian_LKS_2_Web_API.Models;

namespace Latian_LKS_2_Web_API.Controllers
{
    public class EmployeeController : ApiController
    {
        private HotelLagiEntities row = new HotelLagiEntities();

        [Route("api/login")]
        [ResponseType(typeof(Employee))]
        public IHttpActionResult Post(Employee employee)
        {
            string encrypted = employee.Password;
            using (SHA256Managed manage = new SHA256Managed())
            {
                var converted = manage.ComputeHash(Encoding.UTF8.GetBytes(encrypted));
                encrypted = Convert.ToBase64String(converted);
            }

            String sql = "SELECT * FROM Employee WHERE Username = '" + employee.Username + "' AND Password = '" + encrypted + "'";
            var user = row.Employees.SqlQuery(sql).FirstOrDefault();

            //return row.Employees.Where(e => e.Username == employee.Username && e.Password == encrypted);

            if (user != null)
            {
                EmployeeModel e = new EmployeeModel();
                e.ID = user.ID;
                e.Username = user.Username;
                e.Name = user.Name;
                e.Email = user.Email;
                e.Address = user.Address;
                e.DateOfBirth = user.DateOfBirth;
                e.JobID = user.JobID;
                return Ok(e);
            }

            return Ok(user);
        }
    }
}
