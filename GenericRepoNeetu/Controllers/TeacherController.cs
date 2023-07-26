using GenericRepoNeetu.GenericRepository.Contract;
using GenericRepoNeetu.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepoNeetu.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IGeneric<Teacher> _tch;
        public TeacherController(IGeneric<Teacher> tch)
        {
            _tch = tch;
        }
        public IActionResult Index()
        {
            var Teachers = _tch.GetAll();
            return View(Teachers);
        }
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Teacher tch)
        {
            if (ModelState.IsValid)
            {
                bool b = _tch.Add(tch);
                if (b == true)
                {
                    TempData["insert"] = "<script>alert('Teacher Added SuccessFully!!');</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["insert"] = "<script>alert('Teacher Failed!!');</script>";
                }
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            var Teacher = _tch.Get(id);
            if (Teacher != null)
            {
                return View(Teacher);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Teacher tch)
        {
            if (ModelState.IsValid)
            {
                bool b = _tch.Update(tch);
                if (b == true)
                {
                    TempData["update"] = "<script>alert('Teacher Updated SuccessFully!!');</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["update"] = "<script>alert('Teacher Failed!!');</script>";
                }
            }
            return View();
        }
        public IActionResult Details(int id)
        {
            var Teacher = _tch.Get(id);
            if (Teacher != null)
            {
                return View(Teacher);
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                bool b = _tch.Delete(id);
                if (b == true)
                {
                    TempData["delete"] = "<script>alert('Teacher Deleted SuccessFully!!');</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["delete"] = "<script>alert('Teacher Failed!!');</script>";
                }
            }
            return View();
        }
    }
}
