using blog.DataAccess.Repository.IRepository;
using blog.Models;
using bloog.Models;
using bulkey.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blog.Areas.Admin.Controllers
{
    [Area("Admin")]
 
    public class BlogController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Blog> objBlogList = _unitOfWork.Blogs.GetAll();
            return View(objBlogList);
        }
        [Authorize(Roles = SD.Role_User_Admin + "," + SD.Role_User_Special)]
        public IActionResult Create()
        {

            return View();
        }

        //create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog obj)
        {
         
            if (ModelState.IsValid)
            {

                _unitOfWork.Blogs.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Blog created sucessfully";

                return RedirectToAction("Index");
            }
            return View();
        }
        //edit
        [Authorize(Roles = SD.Role_User_Admin)]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // var BlogFromDb = _db.Categories.Find(id);
            var BlogFromDb = _unitOfWork.Blogs.GetFirstOrDefault(u => u.Id == id);
            if (BlogFromDb == null)
            {
                return NotFound();
            }
            return View(BlogFromDb);
        }
        [Authorize(Roles = SD.Role_User_Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Blog obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("CusromError", "name and display order can't be the same");
            //}
            if (ModelState.IsValid)
            {

                _unitOfWork.Blogs.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Blog edited sucessfully";

                return RedirectToAction("Index");
            }
            return View();
        }
        //delete
        [Authorize(Roles = SD.Role_User_Admin)]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            // var BlogFromDb = _db.GetFirstOrDefault(id);
            var BlogFromDb = _unitOfWork.Blogs.GetFirstOrDefault(u => u.Id == id);
            if (BlogFromDb == null)
            {
                return NotFound();
            }
            return View(BlogFromDb);
        }
        [Authorize(Roles = SD.Role_User_Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {


            var obj = _unitOfWork.Blogs.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Blogs.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Blog deleted sucessfully";

            return RedirectToAction("Index");

        }


        
    }
}
