using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeadManagement.Models
{
    public class LeadSourceVM
    {
        public int SourceId { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
