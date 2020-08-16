using EmployeeWebApi.Data;
using EmployeeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeWebApi.Controllers
{
    public class EmployeeController : ApiController
    {

        [HttpGet]
        [Route("api/Employee")]
        public IList<EmployeeModel> GetAllEmployees()
        {       
            EmployeeDAO emp = new EmployeeDAO();
            var lst = emp.SelectEmployee(0, "SelectAll");
            return lst;
        }

        [HttpGet]
        [Route("api/Employee/{id}")]
        public IList<EmployeeModel> GetEmployeeDetails(int id)
        {
            EmployeeDAO emp = new EmployeeDAO();
            var lst = emp.SelectEmployee(id, "Select");
            return lst;
        }

        [HttpGet]
        [Route("api/DeleteEmployee/{id}")]
        public int DeleteEmployeeDetails(int id)
        {
            EmployeeDAO emp = new EmployeeDAO();
            var result = emp.DeleteEmployee(id);
            return result;
        }
        
        [HttpPost]
        [Route("api/InsertEmployee")]
        public int InsertUpdateEmployee(EmployeeModel employee)
        {
            EmployeeDAO emp = new EmployeeDAO();
            var result = emp.AddEditEmployees(employee);
            return result;
        }
    }
}
