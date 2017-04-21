using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace App.Model.Repository
{
    /// <summary>
    /// This class is responsible for the user's repository
    /// </summary>
    public class UserRepository
    {

        ///TODO: hacer que esta palabra se guarde en el archivo de configuracion del site.
        string connStr = @"Server=localhost;Database=pickurl;User Id=root;Password=secret;";

        /// <summary>
        /// Add a new user into data base.
        /// </summary>
        /// <param name="user">Object: MvcUser to add.</param>
        public void AddUser(Entities.User user)
        {
            string sql = "INSERT INTO users (lastName, firstName, username, password, nationality)"
                + "VALUES('" + user.lastName + "','" + user.firstName + "','" + user.username + "','" + user.password + "','"
                + user.nationality + "')";

            MySqlConnection connection = new MySqlConnection(connStr);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
            return;
        }

        /// <summary>
        /// verify is exist an username into data base.
        /// </summary>
        /// <param name="userName">string: MvcUser name.</param>
        /// <returns>True: If exist, false: not exist.</returns>
        public bool HasUser(string username)
        {
            string sql = "SELECT* FROM users WHERE username = '" + username + "'";

            Entities.User user = new Entities.User();

            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user.username = reader.GetString(3);
                    }
                }
            }

            if (user != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method get user information by user name.
        /// </summary>
        /// <param name="username">string: username.</param>
        public Entities.User GetIdByUsername(string username)
        {
            

            return null;
        }

        /// <summary>
        /// This method verify the username and password in data base.
        /// </summary>
        /// <param name="username">string: username.</param>
        /// <param name="password">string: password</param>
        /// <returns>object: user.</returns>
        public Model.Entities.User Login(string username, string password)
        {
            string sql = "SELECT* FROM users WHERE username = '" + username + "' and password = '" + password + "'";

            Entities.User user = new Entities.User();

            using (MySqlConnection connection = new MySqlConnection(connStr))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {

                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        user.id = reader.GetInt32(0); 
                        user.lastName = reader.GetString(1);  
                        user.firstName = reader.GetString(2);
                        user.username = reader.GetString(3);
                        user.password = reader.GetString(4);
                        user.nationality = reader.GetString(5);
                    }
                }
            }

            return user;
        }
        
        
    }
}
