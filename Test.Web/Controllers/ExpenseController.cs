using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Core.Interfaces;
using Task.Core.Models;
using Test.Ef.Repository;

namespace Test.Web.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly IUnitOfWork _uniteOfWork;
        public ExpenseController(UnitOfWork uniteOfWork)
        {
            _uniteOfWork = uniteOfWork;   
        }
        
       
        // GET: Expense
        public ActionResult Index(string searchString=null)
        { 
            return View(_uniteOfWork.Expenses.GetAll(searchString));
        }
        public ActionResult AddEditExpenses(int itemId)
        {
            Expense model = new Expense();
            if (itemId > 0)
            {
                model = _uniteOfWork.ExpenseRepository.GetById(itemId);
            }
            return PartialView("_expenseForm", model);
        }

        [HttpPost]
        public ActionResult Create(Expense newExpense)
        {
            if (ModelState.IsValid)
            {
                if (newExpense.ItemId > 0)
                {
                    _uniteOfWork.ExpenseRepository.Update(newExpense);
                }
                else
                {
                    _uniteOfWork.ExpenseRepository.Add(newExpense);
                }
                _uniteOfWork.Complete();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _uniteOfWork.ExpenseRepository.Delete(id);
            _uniteOfWork.Complete();
            return RedirectToAction("Index");
        }
        
    }
}