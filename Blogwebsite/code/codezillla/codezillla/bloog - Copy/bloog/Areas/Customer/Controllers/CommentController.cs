using blog.DataAccess.Repository.IRepository;
using bloog.Models;
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
    public class ChatRoomController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSender _emailSender;
       

        private readonly Random _random = new Random();
        [BindProperty]
        public BlogsInfoVM BlogsInfoVM { get; set; }
        public CommentVM CommentVM { get; set; }
        public ChatRoomController(IUnitOfWork unitOfWork, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            CommentVM = new CommentVM()
            {
                comments =_unitOfWork.Comments.GetAll(),
                Replies= _unitOfWork.Replies.GetAll(),

            };



            return View(CommentVM);
           
        }

        [HttpPost]
        public async Task<IActionResult> PostReply(ReplyVM obj)
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            obj.CID = claim.Value;

            Reply r = new Reply();
            r.Text = obj.Reply;
            r.CId = obj.CID;
            r.ApplicationUserId = obj.CID;
            r.CreateOn = DateTime.Now;
            _unitOfWork.Replies.Add(r);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        //Post:ChatRoom/PostComment


        [HttpPost]
        public ActionResult PostComment(string CommentText)
        {

           int x= _random.Next(1, 500);





            Comment c = new Comment();
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            c.ApplicationUserId = claim.Value;

            c.Text = CommentText;
            c.CreateOn = DateTime.Now;
            c.ApplicationUserId = claim.Value;
            c.Id = claim.Value + x.ToString();
            _unitOfWork.Comments.Add(c);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }









    }
}


