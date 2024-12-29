using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Task_Managment.Models;

namespace Task_Managment.Controllers
{
    public class ProjectController : Controller
    {
        DBcontext db = new DBcontext();
        public IActionResult Index()
        {
            List<Projects> list = db.projects.ToList();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string name, int description ,DateTime startdate , DateTime enddate)
        {
            Projects projects = new Projects()
            {
                Name = name,
                Description = description,
                Startdate = startdate,
                Enddate = enddate
            };
            db.projects.Add(projects);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int ? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var p = db.projects.FirstOrDefault(a => a.Pr_Id == id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }
        [HttpPost]
        public IActionResult Update(int id,string name, int description, DateTime startdate, DateTime enddate)
        {
            var pr = db.projects.FirstOrDefault(p => p.Pr_Id == id);
            pr.Name = name;
            pr.Description = description;
            pr.Startdate = startdate;
            pr.Enddate = enddate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete( int id )
        {
            if (id == null)
            {
                return BadRequest();
            }
            var p = db.projects.FirstOrDefault(a => a.Pr_Id == id);
            if (p == null)
            {
                return NotFound();
            }
            db.projects.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
