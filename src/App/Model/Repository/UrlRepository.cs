using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace App.Model.Repository
{
    /// <summary>
    /// This class is responsible for the url repository.
    /// </summary>
    public class UrlRepository
    {

        string connStr = @"Server=localhost;Database=pickurl;User Id=root;Password=secret;";

        /// <summary>
        /// Add a new url generated into data base.
        /// </summary>
        /// <param name="user">Object: MvcUser to add.</param>
        public void AddUrl(Entities.Url url)
        {
            string sql = "INSERT INTO  url (shortenedURL, url, userId, clicks, created)"+
                " VALUES('" + url.ShortenedURL+"','"+url.LargeUrl+"'," + url.userId + ","+ url.clicks +", NOW())";

            MySqlConnection connection = new MySqlConnection(connStr);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
            return;
        }


       
    }
}
