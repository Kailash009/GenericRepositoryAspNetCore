using GenericRepoNeetu.GenericRepository.Contract;
using Microsoft.AspNetCore.Mvc;
using GenericRepoNeetu.Models;

namespace GenericRepoNeetu.Controllers
{
    public class StudentController : Controller
    {
        private readonly IGeneric<Student> _stu;
        public StudentController(IGeneric<Student> stu)
        {
            _stu = stu;
        }
        public IActionResult Index()
        {
            var students = _stu.GetAll();
            return View(students);
        }
        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Student stu)
        {
            if (ModelState.IsValid)
            {
                bool b = _stu.Add(stu);
                if (b == true)
                {
                    TempData["insert"] = "<script>alert('Student Added SuccessFully!!');</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["insert"] = "<script>alert('Student Failed!!');</script>";
                }
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            var student=_stu.Get(id);
            if(student!=null)
            {
                return View(student);
            }
           return View();
        }

        [HttpPost]
        public IActionResult Edit(Student stu)
        {
            if (ModelState.IsValid)
            {
                bool b = _stu.Update(stu);
                if (b == true)
                {
                    TempData["update"] = "<script>alert('Student Updated SuccessFully!!');</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["update"] = "<script>alert('Student Failed!!');</script>";
                }
            }
            return View();
        }
        public IActionResult Details(int id)
        {
            var student = _stu.Get(id);
            if (student != null)
            {
                return View(student);
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                bool b = _stu.Delete(id);
                if (b == true)
                {
                    TempData["delete"] = "<script>alert('Student Deleted SuccessFully!!');</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["delete"] = "<script>alert('Student Failed!!');</script>";
                }
            }
            return View();
        }
    }
}
