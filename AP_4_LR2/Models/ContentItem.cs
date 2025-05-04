using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_4_LR2.Models
{
    public abstract class ContentItem
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Format { get; set; } = string.Empty;

        public int StorageLocationId { get; set; }
        [ForeignKey("StorageLocationId")]
        public StorageLocation? StorageLocation { get; set; }
    }
}
