using CarGoRent.Entity;
using Microsoft.Data.SqlClient;
using System.Data;
using CarGoRent.Constant;

namespace CarGoRent.Service
{
    public class LoginService
    {
        public static Customer register(Customer usr)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=KTjune23;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            con.Open();

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Customer values ( @Fname, @Lname, @Contact, @Email, @Password )";

                // cmd.Parameters.AddWithValue("@UserId", usr.UserId);
                cmd.Parameters.AddWithValue("@Fname", usr.Fname);
                cmd.Parameters.AddWithValue("@Lname", usr.Lname);
                cmd.Parameters.AddWithValue("@Contact", usr.Contact);
                cmd.Parameters.AddWithValue("@Email", usr.Email);
                cmd.Parameters.AddWithValue("@Password", usr.Password);

                cmd.ExecuteNonQuery();


            }
            catch(SqlException ex ) {
                if (ex.Message.Contains(Constant.Constant.DuplicateEmailMsg)){
                    throw new Exception("409");   
                }
                throw new Exception(ex.Message); 
            }
            catch (Exception ex) { throw; }
            
            finally { con.Close(); }
            return usr;
        }
    }
}
