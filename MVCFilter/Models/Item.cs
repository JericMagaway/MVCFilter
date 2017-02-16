using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCFilter.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string  Name { get; set; }
        public string Description { get; set; }
        [Required]
        [DataType(DataType.DateTime, ErrorMessage="Required Date")]
        public DateTime Date { get; set; }

    }
}