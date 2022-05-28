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
    public class Comment

    {

        [Key]
        [BindNever]
       
        public string Id { get; set; }

        [Required]
        public string Text { get; set; }
        public DateTime? CreateOn { get; set; }
        [BindNever]
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        [BindNever]
        
        public virtual ApplicationUser ApplicationUsers { get; set; }

        public ICollection<Reply> Replies { get; set; }
        public int Wed { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}
