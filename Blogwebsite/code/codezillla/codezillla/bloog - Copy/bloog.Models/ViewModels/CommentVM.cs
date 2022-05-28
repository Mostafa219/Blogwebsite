using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bloog.Models.ViewModels
{
    public class CommentVM
    {
        public IEnumerable<Comment> comments { get; set; }
        public IEnumerable<Reply> Replies { get; set; }
    }
}
