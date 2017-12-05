using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WEB_API_FromBody_FromUri.Models;

namespace WEB_API_FromBody_FromUri.Controllers
{
    public class EmployeeController : ApiController
    {
        private WEBAPI_ProjectsEntities db = new WEBAPI_ProjectsEntities();


        public IEnumerable<Employee> Get()
        {
            return db.Employees.ToList();
        }

        //burası from body ve from uri ile gelen degerler

        public  HttpResponseMessage Post( [FromUri] Employee emp)
        { 
            try
            {
                db.Employees.Add(emp);
                if (db.SaveChanges() > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, emp);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Veri ekelenmedi");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, $"{emp.FirstName} hata olustu");
            }
        }

    }
}
