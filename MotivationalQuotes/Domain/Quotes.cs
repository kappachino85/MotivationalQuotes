using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotivationalQuotes.Domain
{
    public class Quotes
    {
        public int Id { get; set; }

        public string Quote { get; set; }

        public string Author { get; set; }
    }
}