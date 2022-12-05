using ExpenseManagement.DataLayer;
using ExpenseManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpenseManagement.Controllers
{ 
    public class ExpenseController : Controller
    {
        public readonly DBContextExpMgt _context;

        public ExpenseController(DBContextExpMgt context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseEntity> expensesList = _context.Expenses.ToList();
            foreach (var item in expensesList)
            {
                item.ExpenseCategory=_context.ExpenseCategory.FirstOrDefault
                    (x=>x.ExpenseCategoryId==item.ExpenseCategoryId);
            }

            return View(expensesList);
        }

        public IActionResult Create(ExpenseEntity expenseDetails)
        {
            IEnumerable<SelectListItem> getExpenseCategoryList =
                _context.ExpenseCategory.Select(x => new SelectListItem
                {
                    Text = x.ExpenseCategoryName,
                    Value = x.ExpenseCategoryId.ToString()
                });
            ViewBag.PopulateExpCategory = getExpenseCategoryList;

            if (ModelState.IsValid)
            {
                _context.Expenses.Add(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult GetExpenseDetailsForUpdate(int? id)
        {
            IEnumerable<SelectListItem> getExpenseCategoryList =
                _context.ExpenseCategory.Select(x => new SelectListItem
                {
                    Text = x.ExpenseCategoryName,
                    Value = x.ExpenseCategoryId.ToString()
                });
            ViewBag.PopulateExpCategory = getExpenseCategoryList;

            var _ExpenseDetails = _context.Expenses.Find(id);
            if (_ExpenseDetails == null) 
            {
                return NotFound();
            }
            
            return View(_ExpenseDetails);
        }

        [HttpPost]
        public IActionResult Update(ExpenseEntity expenseDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Update(expenseDetails);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult GetExpenseDetailsForDelete(int? id)
        {
            IEnumerable<SelectListItem> getExpenseCategoryList =
                _context.ExpenseCategory.Select(x => new SelectListItem
                {
                    Text = x.ExpenseCategoryName,
                    Value = x.ExpenseCategoryId.ToString()
                });
            ViewBag.PopulateExpCategory = getExpenseCategoryList;

            var _ExpenseDetails = _context.Expenses.Find(id);
            if (_ExpenseDetails == null)
            {
                return NotFound();
            }

            return View(_ExpenseDetails);
        }
        [HttpPost]
        public IActionResult Delete(int? ExpenseId)
        {
            var _ExpenseDetails = _context.Expenses.Find(ExpenseId);
            if (_ExpenseDetails == null)
            {
                return NotFound();
            }
            _context.Expenses.Remove(_ExpenseDetails);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
