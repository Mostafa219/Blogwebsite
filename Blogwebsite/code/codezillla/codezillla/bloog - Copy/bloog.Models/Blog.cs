
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bloog.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string Description { get; set; } = "";
       
        public int Likes { get; set; }

        [Required]
      
        public string Category { get; set; }


        
    }
}
