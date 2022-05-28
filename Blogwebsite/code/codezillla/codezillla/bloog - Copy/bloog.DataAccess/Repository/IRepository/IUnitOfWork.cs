
using blog.DataAccess.Repository.IRepository;
using bulkey.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.DataAccess.Repository.IRepository
{
public interface IUnitOfWork
    {
        //ICategoryRepository Category { get; }
   
        IBlogRepository Blogs { get; }
        IdetailsBlogRepository BlogsInfo { get; }
        IApplicationUserRepository ApplicationUser { get; }

        ICommentsRepository Comments { get; }
        IReplyRepository Replies { get; }



        void Save();
    }
}
