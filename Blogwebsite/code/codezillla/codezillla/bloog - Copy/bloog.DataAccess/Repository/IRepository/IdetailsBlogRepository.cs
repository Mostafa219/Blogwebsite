
using bloog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.DataAccess.Repository.IRepository
{
    public interface IdetailsBlogRepository : IRepository<BlogsInfo>
    {


      int IncrementCount(BlogsInfo BlogsInfo, int count);


    }
}
