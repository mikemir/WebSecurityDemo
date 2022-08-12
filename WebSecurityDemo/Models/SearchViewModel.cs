using System.Collections.Generic;

namespace WebSecurityDemo.Models
{
    public class SearchViewModel
    {
        public IList<User> SearchResult { get; set; }
        public string SearchText { get; set; }
    }
}
