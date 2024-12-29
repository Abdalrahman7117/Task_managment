using Microsoft.AspNetCore.Mvc;
using Task_Managment.Models;

namespace Task_Managment.Controllers
{
    public class Task_ManageController : Controller
    {
        DBcontext db = new DBcontext();
        public IActionResult list_task()
        {
            List<Ta_sk> list = db.ta_Sks.ToList();
            return View(list);
        }
        public IActionResult list_tasks()
        {
            List<Ta_sk> list = db.ta_Sks.ToList();
            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string title, string description, string status, string Priority, DateTime deadline)
        {
            Ta_sk ta_Sk = new Ta_sk()
            {
                Title = title,
                Description = description,
                Status = status,
                Priority = Priority,
                Deadline = deadline
            };
            db.ta_Sks.Add(ta_Sk);
            db.SaveChanges();
            return RedirectToAction("list_task");
        }
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var p = db.ta_Sks.FirstOrDefault(a => a.Id == id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }
        [HttpPost]
        public IActionResult Update(int id,string title, string description, string status, string Priority, DateTime deadline)
        {
            var pr = db.ta_Sks.FirstOrDefault(p => p.Id == id);
            pr.Title = title;
            pr.Description = description;
            pr.Status = status;
            pr.Priority = Priority;
            pr.Deadline = deadline;
            db.SaveChanges();
            return RedirectToAction("list_task");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var p = db.ta_Sks.FirstOrDefault(a => a.Id == id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }
        [HttpPost]
        public IActionResult Edit(int id,string status)
        {
            var pr = db.ta_Sks.FirstOrDefault(p => p.Id == id);
            
            pr.Status = status;
           
            db.SaveChanges();
            return RedirectToAction("list_tasks");
        }
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var p = db.ta_Sks.FirstOrDefault(a => a.Id == id);
            if (p == null)
            {
                return NotFound();
            }
            db.ta_Sks.Remove(p);
            db.SaveChanges();
            return RedirectToAction("list_task");
        }
    }
}
