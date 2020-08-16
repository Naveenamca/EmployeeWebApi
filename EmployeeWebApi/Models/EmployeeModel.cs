using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeWebApi.Models
{
    /*
    public class EmployeeInformation
    {
        public EmployeeModel Employee { get; set; }
        public EmployeeAddressModel EmployeeAddress { get; set; }
    }
    */
    public class EmployeeModel
    {
        public int EmployeeId
        {
            get;
            set;
        }
        public string EmpFirstName
        {
            get;
            set;
        }
        public string EmpLastName
        {
            get;
            set;
        }
        public string JoiningDate
        {
            get;
            set;
        }
        public string Department
        {
            get;
            set;
        }
        public int AddressId
        {
            get;
            set;
        }
        public string Address1
        {
            get;
            set;
        }
        public string Address2
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public string State
        {
            get;
            set;
        }
        public string Country
        {
            get;
            set;
        }
        public string Phone
        {
            get;
            set;
        }

    }

    /*
    public class EmployeeAddressModel
    {
        public int AddressId
        {
            get;
            set;
        }
        public string Address1
        {
            get;
            set;
        }
        public string Address2
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public string State
        {
            get;
            set;
        }
        public string Country
        {
            get;
            set;
        }
        public string Phone
        {
            get;
            set;
        }

    }
    */
}