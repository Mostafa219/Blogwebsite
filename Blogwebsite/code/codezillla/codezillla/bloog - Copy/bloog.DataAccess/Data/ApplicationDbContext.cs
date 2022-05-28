
using bloog.Models;
using bulkey.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bloog.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)

        {

        }

       
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogsInfo> BlogsInfo { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
  
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Reply> Replies { get; set; }

    }
}
