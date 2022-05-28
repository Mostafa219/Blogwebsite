
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
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        private ApplicationDbContext _db;
        public BlogRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Blog obj)
        {
            _db.Blogs.Update(obj);
        }

        public int IncrementCount(Blog blogsInfo, int count)
        {
            blogsInfo.Likes += count;
            return blogsInfo.Likes;

        }
    }
}
