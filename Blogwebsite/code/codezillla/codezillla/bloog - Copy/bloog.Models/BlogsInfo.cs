using bulkey.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bloog.Models
{
    public class BlogsInfo
    {

        [BindNever]
        public int Id { get; set; }


        [ValidateNever]

        public int BlogId { get; set; }
        [ForeignKey("BlogId")]
        [ValidateNever]
        public Blog Blog { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        public int Likes { get; set; }
        
    }
}
