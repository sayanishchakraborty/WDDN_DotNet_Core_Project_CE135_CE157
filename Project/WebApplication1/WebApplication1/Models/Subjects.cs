using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Subjects
    {
        [Key]
        public string SubID { get; set; }
        
        public string Subject { get; set; }

    }
}
