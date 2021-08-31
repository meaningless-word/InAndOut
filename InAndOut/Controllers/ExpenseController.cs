using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace InAndOut.Controllers
{
	public class ExpenseController : Controller
	{
		private readonly ApplicationDbContext _db;

		public ExpenseController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			IEnumerable<Expense> objList = _db.Expenses;
			return View(objList);
		}

		public IActionResult Create()
		{
			return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Expense expense)
		{
			if (ModelState.IsValid)
			{
				_db.Expenses.Add(expense);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(expense);
		}


		[HttpGet]
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var expense = _db.Expenses.Find(id);
			if (expense == null)
			{
				return NotFound();
			}
			return View(expense);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePost(int? id)
		{
			var expense = _db.Expenses.Find(id);
			if (expense == null)
			{
				return NotFound();
			}

			_db.Expenses.Remove(expense);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}


		[HttpGet]
		public IActionResult Update(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var expense = _db.Expenses.Find(id);
			if (expense == null)
			{
				return NotFound();
			}
			return View(expense);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(Expense expense)
		{
			if (expense == null)
			{
				return NotFound();
			}

			_db.Expenses.Update(expense);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}