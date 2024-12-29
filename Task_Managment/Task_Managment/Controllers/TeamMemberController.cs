using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Task_Managment.Models;

namespace Task_Managment.Controllers
{
    public class TeamMemberController : Controller
    {
        DBcontext db = new DBcontext();
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(TeamMembers team)
        {
            var acc1 = db.teamMembers.FirstOrDefault(u => u.Name == team.Name && u.Email == team.Email && u.Role == "Manage");
            var acc2 = db.teamMembers.FirstOrDefault(u => u.Name == team.Name && u.Email == team.Email && u.Role == "Emp");
            var acc3 = db.teamMembers.FirstOrDefault(u => u.Name == team.Name && u.Email == team.Email && u.Role == "user");
            if (acc1 != null)
            {
                Claim c1 = new Claim("Name", acc1.Name);
                Claim c2 = new Claim("Email", acc1.Email);
                ClaimsIdentity c3 = new ClaimsIdentity("Cookies");
                c3.AddClaim(c1);
                c3.AddClaim(c2);
                ClaimsPrincipal c4 = new ClaimsPrincipal();
                c4.AddIdentity(c3);
                await HttpContext.SignInAsync(c4);
                db.SaveChanges();
                return RedirectToAction("list_task", "Task_Manage"); 
            }
            if (acc2 != null)
            {
                Claim c1 = new Claim("Name", acc2.Name);
                Claim c2 = new Claim("Email", acc2.Email);
                ClaimsIdentity c3 = new ClaimsIdentity("Cookies");
                c3.AddClaim(c1);
                c3.AddClaim(c2);
                ClaimsPrincipal c4 = new ClaimsPrincipal();
                c4.AddIdentity(c3);
                await HttpContext.SignInAsync(c4);
                db.SaveChanges();
                return RedirectToAction("list_tasks","Task_Manage");
            }
            if (acc3 != null)
            {
                Claim c1 = new Claim("Name", acc3.Name);
                Claim c2 = new Claim("Email", acc3.Email);
                ClaimsIdentity c3 = new ClaimsIdentity("Cookies");
                c3.AddClaim(c1);
                c3.AddClaim(c2);
                ClaimsPrincipal c4 = new ClaimsPrincipal();
                c4.AddIdentity(c3);
                await HttpContext.SignInAsync(c4);
                db.SaveChanges();
                return RedirectToAction("Index", "Project");
            }
            else
            {
                ModelState.AddModelError("", "Invaild Name or Email");
            }
            return View();
        }
    }
}
