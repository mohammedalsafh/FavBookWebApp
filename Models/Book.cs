using System.Security.Principal;

namespace FavBookWebApp.Models
{
    public class Book
    {
        public Book()
        {

        }

        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string description { get; set; }
        public string url { get; set; }

    }
}
