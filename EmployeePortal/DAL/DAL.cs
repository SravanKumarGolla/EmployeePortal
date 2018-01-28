using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using EmployeePortal.Models;

namespace EmployeePortal.DAL
{
   
    public class DAL
    {
        string ConnString = string.Empty;
        public DAL()
        {
            ConnString = WebConfigurationManager.AppSettings["connString"].ToString();
        }

        public int InsertEmployee(Employee e)
        {
            SqlConnection con = null;
            int result = -1;
            try
            {
                using (con = new SqlConnection(ConnString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[dbo].[USP_InsertEmployeeInfo]";

                        cmd.Parameters.Add(new SqlParameter("@EmpName", e.Name));
                        cmd.Parameters.Add(new SqlParameter("@EmpNameArabic", e.NameArabic));
                        cmd.Parameters.Add(new SqlParameter("@Age", e.Age));
                        cmd.Parameters.Add(new SqlParameter("@Doj", e.DateOfJoin));
                        cmd.Parameters.Add(new SqlParameter("@Address", e.LstAddress.ElementAt(0).Address));
                        cmd.Parameters.Add(new SqlParameter("@MobileNumber", e.LstAddress.ElementAt(0).MobileNumber));
                        cmd.Parameters.Add(new SqlParameter("@EmailId", e.LstAddress.ElementAt(0).Email));
                        cmd.Parameters.Add(new SqlParameter("@CompanyName", e.LstExp.ElementAt(0).Company));
                        cmd.Parameters.Add(new SqlParameter("@NumberOfYears", e.LstExp.ElementAt(0).NumberOfYears));

                        result = cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
           
        }
        public IEnumerable<Employee> GetEmployees()
        {
            SqlConnection con = null;
            DataSet ds = new DataSet();
            List<Employee> result = new List<Employee>();
            try
            {
                using (con = new SqlConnection(ConnString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[dbo].[usp_GetEmployeesData]";


                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;

                        da.Fill(ds);

                        result = (from DataRow dr in ds.Tables[0].Rows
                                  select new Employee
                                  {
                                      NameArabic = dr["NameArabic"].ToString(),
                                      Name = dr["Name"].ToString(),
                                      Id = Convert.ToInt32(dr["Id"]),
                                      Age = Convert.ToInt32(dr["Age"]),
                                      DateOfJoin = Convert.ToDateTime(dr["DateOfJoin"]),
                                      LstAddress = new List<EmployeeAddress> { new EmployeeAddress { Address = dr["Address"].ToString(), AddressId = Convert.ToInt32(dr["EmployeeAdress"]), Email=dr["EmailId"].ToString(), MobileNumber =Convert.ToInt64( dr["MobileNumber"] ) } },
                                      LstExp = new List<EmployeeExperience> { new EmployeeExperience { Company = dr["CompanyName"].ToString(),NumberOfYears = Convert.ToInt32(dr["NumberOfYears"]), Id= Convert.ToInt32(dr["EmployeeExpId"]) } }
                                  }
                                      ).ToList<Employee>();

                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;
        }

        public int UpdateEmployee(Employee e)
        {
            SqlConnection con = null;
            int result = -1;
            try
            {
                using (con = new SqlConnection(ConnString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[dbo].[USP_UpdateEmployeeInfo]";

                        cmd.Parameters.Add(new SqlParameter("@EmpId", e.Id));
                        cmd.Parameters.Add(new SqlParameter("@EmpName", e.Name));
                        cmd.Parameters.Add(new SqlParameter("@EmpNameArabic", e.NameArabic));
                        cmd.Parameters.Add(new SqlParameter("@Age", e.Age));
                        cmd.Parameters.Add(new SqlParameter("@EmailId", e.LstAddress.ElementAt(0).Email));
                        cmd.Parameters.Add(new SqlParameter("@Address", e.LstAddress.ElementAt(0).Address));
                        cmd.Parameters.Add(new SqlParameter("@MobileNumber", e.LstAddress.ElementAt(0).MobileNumber));
                        cmd.Parameters.Add(new SqlParameter("@CompanyName", e.LstExp.ElementAt(0).Company));
                        cmd.Parameters.Add(new SqlParameter("@NumberOfYears", e.LstExp.ElementAt(0).NumberOfYears));
                        cmd.Parameters.Add(new SqlParameter("@EmpAddrId", e.LstAddress.ElementAt(0).AddressId));
                        cmd.Parameters.Add(new SqlParameter("@EmpExpId", e.LstExp.ElementAt(0).Id));

                   

                        result = cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public int DeleteEmployee(Employee e)
        {
            SqlConnection con = null;
            int result = -1;
            try
            {
                using (con = new SqlConnection(ConnString))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[dbo].[USP_DeleteEmployee]";

                        cmd.Parameters.Add(new SqlParameter("@EmpId", e.Id));


                        result = cmd.ExecuteNonQuery();

                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return result;

        }
    }
}