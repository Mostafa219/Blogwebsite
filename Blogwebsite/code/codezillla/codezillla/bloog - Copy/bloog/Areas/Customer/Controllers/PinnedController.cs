using blog.DataAccess.Repository.IRepository;
using bloog.Models.ViewModels;
using bulkey.DataAccess.Repository.IRepository;
using bulkey.Models;

using bulkey.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;


namespace bulkey.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class PinnedController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
        [BindProperty]
        public BlogsInfoVM BlogsInfoVM { get; set; }
        public PinnedController(IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            BlogsInfoVM = new BlogsInfoVM()
            {
                ListBlogs = _unitOfWork.BlogsInfo.GetAll(u => u.ApplicationUserId == claim.Value,
                includeProperties: "Blog"),
                
            };
           
            return View(BlogsInfoVM);
        }

       
    }
}


