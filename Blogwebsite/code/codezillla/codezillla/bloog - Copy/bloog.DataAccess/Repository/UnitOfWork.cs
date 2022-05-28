
using blog.DataAccess.Repository.IRepository;
using bloog.DataAccess.Data;
using bulkey.DataAccess.Repository;
using bulkey.DataAccess.Repository.IRepository;
using bulkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace blog.DataAccess.Repository
{
    public class UnitOfWork :IUnitOfWork
    {

        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)

        {
            _db = db;
            
        
            Blogs = new BlogRepository(_db);
            BlogsInfo = new detailsBlogRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            Comments = new CommentsRepository(_db);
            Replies = new ReplyRepository(_db);




        }





        public IBlogRepository Blogs { get; private set; }
        public IdetailsBlogRepository BlogsInfo { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }


        public ICommentsRepository Comments { get; private set; }
        public IReplyRepository Replies { get; private set; }




        public void Save()
        {
           _db.SaveChanges();
        }
    }
}
