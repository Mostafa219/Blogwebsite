using bulkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bloog.Models.ViewModels
{
   public class StaticsVM
    {
        public IEnumerable<BlogsInfo> ListBlogs { get; set; }

        public IEnumerable<Comment> comments { get; set; }
        public IEnumerable<Reply> Replies { get; set; }

        public IEnumerable<ApplicationUser> ApplicationUser { get; set; }

        public IEnumerable<Blog> Blogs { get; set; }

       

    }
}
