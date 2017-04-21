using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model.Entities
{
    /// <summary>
    /// This class represents a Url
    /// </summary>
    public class Url
    {
        public int id;
        public string ShortenedURL;
        public string LargeUrl;
        public string userId;
        public int clicks;
        public string lastClick;
        public string created;
    }
}
