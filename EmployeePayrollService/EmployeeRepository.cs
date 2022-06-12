using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollService
{
    public class EmployeeRepository
    {
        private SqlConnection con;
        private void Connection()
        {
            string connectingString = "Data Source=(localdb)\\MSSQLLocaldb;Initial Catalog=payroll_service";
            con = new SqlConnection(connectingString);
        }
        public bool AddEmployee(EmployeeDetails obj)
        {
            Connection();
            SqlCommand command = new SqlCommand("AddEmployee", con);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@EmpId", obj.EmpId);
            command.Parameters.AddWithValue("@Name", obj.Name);
            command.Parameters.AddWithValue("@Salary", obj.Salary);
            command.Parameters.AddWithValue("@StartDate", obj.Startdate);
            command.Parameters.AddWithValue("@Gender", obj.Gender);
            command.Parameters.AddWithValue("@PhoneNumber", obj.PhoneNumber);
            command.Parameters.AddWithValue("@Department", obj.Department);
            command.Parameters.AddWithValue("@Deduction", obj.Deduction);
            command.Parameters.AddWithValue("@Taxable_Pay", obj.Taxable_Pay);
            command.Parameters.AddWithValue("@Net_Pay", obj.Net_Pay);
            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<EmployeeDetails> RetrieveEmployeeData()
        {
            Connection();
            List<EmployeeDetails> EmployeeList = new List<EmployeeDetails>();
            SqlCommand commmand = new SqlCommand("spGetAllEmployees", con);
            commmand.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(commmand);
            DataTable table = new DataTable();
            con.Open();
            da.Fill(table);
            con.Close();
            foreach (DataRow data in table.Rows)
            {
                EmployeeList.Add(
                    new EmployeeDetails
                    {
                        EmpId = Convert.ToInt32(data["Id"]),
                        Name = Convert.ToString(data["Name"]),
                        Salary = Convert.ToInt32(data["Salary"]),
                        Startdate = Convert.ToDateTime(data["StartDate"]),
                        Gender = Convert.ToString(data["Gender"]),
                        PhoneNumber = Convert.ToInt32(data["PhoneNumber"]),
                        Department = Convert.ToString(data["Department"]),
                        Deduction = Convert.ToInt32(data["Deductions"]),
                        Taxable_Pay = Convert.ToInt32(data["Taxable_Pay"]),
                        Net_Pay = Convert.ToInt32(data["Net_Pay"]),
                    }
                    );
            }
            return EmployeeList;
        }
        public bool UpdateEmployeeSalary(EmployeeDetails obj)
        {
            Connection();
            SqlCommand com = new SqlCommand("UpdateEmployee", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", obj.EmpId);
            com.Parameters.AddWithValue("@Salary", obj.Salary);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DeleteEmployeeDetails(EmployeeDetails emp)
        {
            Connection();
            SqlCommand command = new SqlCommand("spDeleteEmployee", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", emp.EmpId);
            command.Parameters.AddWithValue("@Name", emp.Name);
            con.Open();
            int result = command.ExecuteNonQuery();
            con.Close();
            if (result >= 1)
            {
                Console.WriteLine("Employee details deleted successfully");
            }
            else
            {
                Console.WriteLine("Failed to delete employee details");
            }
        }
    }
}
