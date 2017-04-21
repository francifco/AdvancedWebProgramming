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
        int id;
        string shortenedURL;
        string url;
        string userId;
        int clicks;
        DateTime lastClick;
        DateTime created;
    }
}
