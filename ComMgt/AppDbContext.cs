using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComMgt
{
    public class AppDbContext
    {
        public void AddEmployee(Employee employee)
        {
            string cs = ConfigurationManager.ConnectionStrings["ComMgt"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("addEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramBirthdate = new SqlParameter();
                paramBirthdate.ParameterName = "@Birthdate";
                paramBirthdate.Value = employee.Birthdate;
                cmd.Parameters.Add(paramBirthdate);

                SqlParameter paramEmail = new SqlParameter();
                paramEmail.ParameterName = "@Email";
                paramEmail.Value = employee.Email;
                cmd.Parameters.Add(paramEmail);

                SqlParameter paramDateCreated = new SqlParameter();
                paramDateCreated.ParameterName = "@DateCreated";
                paramDateCreated.Value = employee.CreateDate;
                cmd.Parameters.Add(paramDateCreated);

                SqlParameter paramAddress = new SqlParameter();
                paramAddress.ParameterName = "@Address";
                paramAddress.Value = employee.Address;
                cmd.Parameters.Add(paramAddress);

                SqlParameter paramRoleId = new SqlParameter();
                paramRoleId.ParameterName = "@RoleId";
                paramRoleId.Value = employee.RoleId;
                cmd.Parameters.Add(paramRoleId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IEnumerable<Employee> Employees
        {
            get
            {
                string cs = ConfigurationManager.ConnectionStrings["ComMgt"].ConnectionString;
                List<Employee> employees = new List<Employee>();
                using (SqlConnection con = new SqlConnection(cs))
                {
                    SqlCommand cmd = new SqlCommand("selectEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = Convert.ToInt32(rdr["Id"]);
                        employee.Name = rdr["Name"].ToString();
                        employee.Gender = rdr["Gender"].ToString();
                        employee.Email = rdr["Email"].ToString();
                        employee.Birthdate = Convert.ToDateTime(rdr["Birthdate"]);
                        employee.Address = rdr["Address"].ToString();
                        employee.Role = rdr["Role"].ToString();
                        employee.CreateDate = Convert.ToDateTime(rdr["DateCreated"]);

                        employees.Add(employee);
                    }
                }
                return employees;
            }
        }
    }
    
}
