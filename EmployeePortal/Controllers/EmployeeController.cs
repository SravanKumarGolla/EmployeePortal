using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeePortal.Models;
using EmployeePortal.DAL;
using EmployeePortal.Filters;
namespace EmployeePortal.Controllers
{
    [CustomExceptionFilter]
    public class EmployeeController : ApiController
    {
        public IEnumerable<Employee> Get()
        {
            if (ModelState.IsValid)
            {
                DAL.DAL dal = new DAL.DAL();
                IEnumerable<Employee> ienum = dal.GetEmployees();
                return ienum;
            }
            else
                return null;

        }

        public HttpResponseMessage Post(Employee emp)
        {

            DAL.DAL dal = new DAL.DAL();
            int empInserted = dal.InsertEmployee(emp);
            if(empInserted > 1)
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,new Exception("Invalid Employee details"));

        }
        public HttpResponseMessage Put(Employee emp)
        {
            DAL.DAL dal = new DAL.DAL();
            int empInserted = dal.UpdateEmployee(emp);
            if (empInserted >= 1)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new Exception("Not able to update Employee details"));

        }
        public HttpResponseMessage Delete(Employee emp)
        {
            DAL.DAL dal = new DAL.DAL();
            int empInserted = dal.DeleteEmployee(emp);
            if (empInserted > 1)
            {
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            else
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, new Exception("Invalid Employee details"));

        }
    }
}
