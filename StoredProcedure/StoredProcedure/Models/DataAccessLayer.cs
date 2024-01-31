using System.Data;
using System.Data.SqlClient;

namespace StoredProcedure.Models
{
    public class DataAccessLayer
    {
        public void Save(Users user,IConfiguration configuration)
        {
            using(SqlConnection connection=new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                connection.Open();

                using(SqlCommand command=new SqlCommand("InsertRecord",connection)) 
                {
                    command.CommandType=CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Email", user.Email);
                
                    command.ExecuteNonQuery();
                
                }
            }
        }

        public List<Users> GetUsers(IConfiguration configuration) 
        {
            List<Users> users = new List<Users>();

            using(SqlConnection connection=new SqlConnection(configuration.GetConnectionString("DBCS").ToString())) 
            {
                connection.Open ();

                using(SqlCommand cmd=new SqlCommand("DisplayRecord", connection))
                {
                    cmd.CommandType=CommandType.StoredProcedure;

                    using(SqlDataReader reader=cmd.ExecuteReader()) 
                    {
                        while (reader.Read()) 
                        {
                            Users user=new Users();
                            user.Id =Convert.ToInt32( reader["Id"]);
                            user.Name = Convert.ToString(reader["Name"]);
                            user.Email = Convert.ToString(reader["email"]);

                            users.Add(user);
                        }
                    }
                }
            }
            return users;
        }

        public Users GetUser(long id,IConfiguration configuration)
        {
            Users user = new Users();
            using(SqlConnection connection=new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                connection.Open();
                using(SqlCommand cmd=new SqlCommand("GetUserById", connection))
                {
                    cmd.CommandType= CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id",id);


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            user.Id = Convert.ToInt32(reader["Id"]);
                            user.Name = Convert.ToString(reader["Name"]);
                            user.Email = Convert.ToString(reader["email"]);

                            
                        }
                    }
                }
            }
            return user;
        }

        public void UpdateUser(long id,IConfiguration configuration,Users user)
        {
            using(SqlConnection connection=new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                connection.Open();

                using(SqlCommand command=new SqlCommand("UpdateUser",connection))
                {
                    command.CommandType= CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id",id);
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Email", user.Email);

                    command.ExecuteNonQuery();  
                }
            }
        }


        public void DeleteUser(long id,IConfiguration configuration)
        {
            using(SqlConnection connection=new SqlConnection(configuration.GetConnectionString("DBCS").ToString()))
            {
                connection.Open();

                using(SqlCommand cmd=new SqlCommand("DeleteUser", connection))
                {
                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
