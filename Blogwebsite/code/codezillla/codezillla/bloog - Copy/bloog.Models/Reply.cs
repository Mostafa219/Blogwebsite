using bulkey.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bloog.Models
{
    public class Reply

    {
        [Key]
        public int Id { get; set; }


        public string? Text { get; set; }
        public DateTime? CreateOn { get; set; }
        public string? ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]


        public virtual ApplicationUser ApplicationUsers { get; set; }

        [NotMapped]
        public string? CId { get; set; }

        [ForeignKey("CId")]



        public virtual Comment Comment { get; set; }
    }
}
