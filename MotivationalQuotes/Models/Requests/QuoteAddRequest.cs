using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MotivationalQuotes.Models.Requests
{
    public class QuoteAddRequest
    {
        [Required]
        public string Quote { get; set; }

        public string Author { get; set; }
    }
}