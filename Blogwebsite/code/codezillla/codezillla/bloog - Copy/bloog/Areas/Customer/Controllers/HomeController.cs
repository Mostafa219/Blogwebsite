using blog.DataAccess.Repository.IRepository;
using blog.Models;
using bloog.DataAccess.Data;
using bloog.Models;
using bloog.Models.ViewModels;
using bulkey.Models;
using bulkey.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace bloog.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;


        public BlogsInfo BlogsInfo { get; set; }
        public BlogsInfoVM BlogsVM { get; set; }

        public StaticsVM StaticsVM { get; set; }
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, ApplicationDbContext db)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            ISession session = HttpContext.Session;
            session.SetInt32("ApplicationUserId", 0);
            IEnumerable<Blog> productList = _unitOfWork.Blogs.Shink();
            return View(productList);
        }



        public IActionResult Details(int BlogId)
        {
            BlogsInfoVM cartObj = new()
            {

                BlogId = BlogId,
                Blog = _unitOfWork.Blogs.GetFirstOrDefault(u => u.Id == BlogId),
               
               
                
            
            };
            return View(cartObj);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public async Task<IActionResult> DetailsAsync(BlogsInfo BlogsInfo)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            BlogsInfo.ApplicationUserId = claim.Value;

            BlogsInfo cartFromDb = _unitOfWork.BlogsInfo.GetFirstOrDefault(
                u => u.ApplicationUserId == claim.Value && u.BlogId == BlogsInfo.BlogId);


            if (cartFromDb == null)
            {

                _unitOfWork.BlogsInfo.Add(BlogsInfo);

                _unitOfWork.Save();
                HttpContext.Session.SetInt32(SD.SessionCart,
                    _unitOfWork.BlogsInfo.GetAll(u => u.ApplicationUserId == claim.Value).ToList().Count);
            }
            else
            {
                
                _unitOfWork.Save();
            }


            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult Photo(ApplicationUser ApplicationUser)
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //ApplicationUser.Id = claim.Value;

            ApplicationUser cartFromDb = _unitOfWork.ApplicationUser.GetFirstOrDefault(
              u => u.Id == claim.Value );

            return View(cartFromDb);
        }









          public async Task<IActionResult> Search(string searchString)
        {
            var products = from m in _db.Blogs
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Description!.Contains(searchString));
                
            }

            return View(await products.ToListAsync());
        }

























        public IActionResult Plus(int BlogId)
        {


            //BlogsInfo cart = new BlogsInfo();
            var cart = _unitOfWork.Blogs.GetFirstOrDefault(u => u.Id == BlogId);
            _unitOfWork.Blogs.IncrementCount(cart, 1);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Statics()
        {
            StaticsVM = new StaticsVM()
            {
                ApplicationUser = _unitOfWork.ApplicationUser.GetAll(),
                Blogs = _unitOfWork.Blogs.GetAll(),
                comments = _unitOfWork.Comments.GetAll(),
                ListBlogs = _unitOfWork.BlogsInfo.GetAll(),
                Replies = _unitOfWork.Replies.Shink()

            };

            return View(StaticsVM);
        }













        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}