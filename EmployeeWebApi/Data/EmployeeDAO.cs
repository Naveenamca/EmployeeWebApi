using EmployeeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeWebApi.Data
{
    public class EmployeeDAO
    {


        private SqlConnection con;
        private SqlCommand com;
        List<EmployeeModel> obj1 = new List<EmployeeModel>();
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["employeeconnection"].ToString();
            con = new SqlConnection(constr);
        }

        public int AddEditEmployees(EmployeeModel Emp)
        {
            int i = 0;
            try
            {
                connection();
                if (Emp.EmployeeId == 0)
                {
                    com = new SqlCommand("p_Employee_Insert_Update", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Param", "Insert");
                    com.Parameters.AddWithValue("@Emp_id", 0);
                    com.Parameters.AddWithValue("@Emp_Name", Emp.EmpFirstName);
                    com.Parameters.AddWithValue("@Last_Name", Emp.EmpLastName);
                    com.Parameters.AddWithValue("@Department", Emp.Department);
                    com.Parameters.AddWithValue("@Address1", Emp.Address1);
                    com.Parameters.AddWithValue("@Address2", Emp.Address2);
                    com.Parameters.AddWithValue("@city", Emp.City);
                    com.Parameters.AddWithValue("@State", Emp.State);
                    com.Parameters.AddWithValue("@Country", Emp.Country);
                    com.Parameters.AddWithValue("@phone", Emp.Phone);
                    con.Open();
                    i = com.ExecuteNonQuery();
                    return i;
                }
                else
                {
                    com = new SqlCommand("p_Employee_Insert_Update", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Param", "Update");
                    com.Parameters.AddWithValue("@Emp_id", Emp.EmployeeId);
                    com.Parameters.AddWithValue("@Emp_Name", Emp.EmpFirstName);
                    com.Parameters.AddWithValue("@Last_Name", Emp.EmpLastName);
                    com.Parameters.AddWithValue("@Department", Emp.Department);
                    com.Parameters.AddWithValue("@Address1", Emp.Address1);
                    com.Parameters.AddWithValue("@Address2", Emp.Address2);
                    com.Parameters.AddWithValue("@city", Emp.City);
                    com.Parameters.AddWithValue("@State", Emp.State);
                    com.Parameters.AddWithValue("@Country", Emp.Country);
                    com.Parameters.AddWithValue("@phone", Emp.Phone);
                    con.Open();
                    i = com.ExecuteNonQuery();
                    return i;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                con.Close();
            }
            return i;
        }

        public int DeleteEmployee(int empId)
        {
            connection();
            try
            {
                com = new SqlCommand("p_Employee_Delete_Select", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Param", "Delete");
                com.Parameters.AddWithValue("@Emp_id", empId);
                con.Open();
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
                return 0;
            }
            finally
            {
                con.Close();
            }
            return 1;

        }

        public IList<EmployeeModel> SelectEmployee(int empId, string param)
        {            
            DataTable dt = new DataTable();
            try
            {
                connection();
                if (param == "Select")
                {
                    com = new SqlCommand("p_Employee_Delete_Select", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Param", "Select");
                    com.Parameters.AddWithValue("@Emp_id", empId);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            EmployeeModel emp = new EmployeeModel();
                            emp.EmployeeId = Convert.ToInt32(dt.Rows[i]["Emp_Id"]);
                            emp.EmpFirstName = dt.Rows[i]["Emp_Name"].ToString();
                            emp.EmpLastName = dt.Rows[i]["Last_Name"].ToString();
                            emp.JoiningDate = dt.Rows[i]["Joining_Date"].ToString();
                            emp.Department = dt.Rows[i]["Department"].ToString();
                            emp.Address1 = dt.Rows[i]["Address1"].ToString();
                            emp.Address2 = dt.Rows[i]["Address2"].ToString();
                            emp.City = dt.Rows[i]["city"].ToString();
                            emp.State = dt.Rows[i]["State"].ToString();
                            emp.Country = dt.Rows[i]["Country"].ToString();
                            emp.Phone = dt.Rows[i]["Phone"].ToString();
                            obj1.Add(emp);
                        }
                    }
                }               
                else if (param == "SelectAll")
                {
                    com = new SqlCommand("p_Employee_Delete_Select", con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@Param", "SelectAll");
                    com.Parameters.AddWithValue("@Emp_id", 0);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            EmployeeModel emp = new EmployeeModel();
                            emp.EmployeeId = Convert.ToInt32(dt.Rows[i]["Emp_Id"]);
                            emp.EmpFirstName = dt.Rows[i]["Emp_Name"].ToString();
                            emp.EmpLastName = dt.Rows[i]["Last_Name"].ToString();
                            emp.JoiningDate = dt.Rows[i]["Joining_Date"].ToString();
                            emp.Department = dt.Rows[i]["Department"].ToString();
                            emp.Address1 = dt.Rows[i]["Address1"].ToString();
                            emp.Address2 = dt.Rows[i]["Address2"].ToString();
                            emp.City = dt.Rows[i]["city"].ToString();
                            emp.State = dt.Rows[i]["State"].ToString();
                            emp.Country = dt.Rows[i]["Country"].ToString();
                            emp.Phone = dt.Rows[i]["Phone"].ToString();
                            obj1.Add(emp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                con.Close();
            }
            return obj1;
        }

    }
}