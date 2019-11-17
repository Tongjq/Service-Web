using SchoolService;
using SchoolService.DTO;
using SchoolWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolWeb.Controllers
{
    public class HomeController : Controller
    {
        // 测试提交
        // GET: Home
        public ActionResult Index()
        {
            StudentService stuService = new StudentService();
            //var students = stuService.GetByClassId(1);
            var students = stuService.GetAll();
            return View(students);
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            MinZuService mzService = new MinZuService();
            ClassService clsService = new ClassService();
            var classes = clsService.GetAll();
            var minzus = mzService.GetAll();
            SelectList slMinZus = new SelectList(minzus, nameof(MinZuDTO.Id), nameof(MinZuDTO.Name));
            SelectList slClasses = new SelectList(classes, nameof(ClassDTO.Id), nameof(ClassDTO.Name));

            SelectListViewModel selectListViewModel = new SelectListViewModel
            {
                Classes = slClasses,
                MinZus = slMinZus
            };
            return View(selectListViewModel);
        }

        [HttpPost]
        public ActionResult AddNew(string name, int age, long classId, long minZuId)
        {
            StudentService stuService = new StudentService();
            stuService.AddNew(name, age, minZuId, classId);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Delete(long id)
        {
            StudentService s = new StudentService();
            s.Delete(id);
            return Redirect("/Home/Index");
        }
    }
}