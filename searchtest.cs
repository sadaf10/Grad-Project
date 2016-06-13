using System;
using System.Collections.Generic;

namespace searchtest
{
    public class Search
    {
        public Search()
        {
        }

        public string publisher { get; set; }
        public string f2f_url { get; set; }
        public string title { get; set; }
        public string source_url { get; set; }
        public string recipe_id { get; set; }
        public string image_url { get; set; }
        public decimal social_rank { get; set; }
        public string publisher_url { get; set; }
    }

    public class RootObject
    {
        public int count { get; set; }
        public List<Search> recipes { get; set; }
    }
}
