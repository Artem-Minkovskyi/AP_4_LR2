using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BookBusinessModel
    {
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public int Pages { get; set; }
        public int StorageLocationId { get; set; }
    }

}
