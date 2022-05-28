
using blog.DataAccess.Repository.IRepository;
using bloog.DataAccess.Data;
using bloog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog.DataAccess.Repository
{
    public class detailsBlogRepository : Repository<BlogsInfo>, IdetailsBlogRepository
    {
        private ApplicationDbContext _db;
        public detailsBlogRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public int IncrementCount(BlogsInfo blogsInfo, int count)
        {
            blogsInfo.Likes += count;
            return blogsInfo.Likes;

        }
    }
}
