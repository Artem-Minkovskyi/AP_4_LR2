using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_4_LR2.Models
{
    public class Book : ContentItem
    {
        public string Author { get; set; } = string.Empty;
        public int Pages { get; set; }
    }
}
