
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
    public class CommentsRepository : Repository<Comment>, ICommentsRepository
    {
        private ApplicationDbContext _db;
        public CommentsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


    }
}
