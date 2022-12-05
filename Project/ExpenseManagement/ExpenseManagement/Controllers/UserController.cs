using ExpenseManagement.DataLayer;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Controllers
{
    public class UserController : Controller
    {
        public readonly DBContextExpMgt _context;

        public UserController(DBContextExpMgt context)
        {
            _context = context;
        }

        public IActionResult Login(string EmailAddress,string Password)
        {
            if (ModelState.IsValid)
            {
                ViewBag.LoginStatus = "";
                var userCheck=_context.Users.FirstOrDefault
                    (x=>x.Email==EmailAddress && x.Password==Password);

                if (User==null)
                {
                    ViewBag.LoginStatus = "Invalid Login";
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            return View();
        }

        public IActionResult Registration(User userDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(userDetails);
                _context.SaveChanges();
                return RedirectToAction("Login");

            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
