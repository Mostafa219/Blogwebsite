
using bloog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.DataAccess.Repository.IRepository
{
    public interface IBlogRepository : IRepository<Blog>
    {

        void Update(Blog obj);

        int IncrementCount(Blog BlogsInfo, int count);

    }
}
