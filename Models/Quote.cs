using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesAPI.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }
    }
}
