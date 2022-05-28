using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bloog.Models.ViewModels
{
   public class BlogsInfoVM
    {

        public IEnumerable<BlogsInfo> ListBlogs{ get; set; }
        public BlogsInfo BlogsInfo { get; set; }

        public int BlogId { get; set; }
        [ForeignKey("BlogId")]
        [ValidateNever]
        public Blog Blog { get; set; }

    }
}
