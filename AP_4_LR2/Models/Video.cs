using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_4_LR2.Models
{
    public class Video : ContentItem
    {
        public int Duration { get; set; }
        public string Resolution { get; set; } = string.Empty;
    }
}
