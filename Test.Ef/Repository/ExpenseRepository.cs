using Document.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Interfaces;
using Task.Core.Models;
using Task.Core.ViewModel;

namespace Test.Ef.Repository
{
   public class ExpenseRepository : BaseRepository<Expense> ,IExpenseRepository
    {
        private readonly AppDbContext _context;
        public ExpenseRepository(AppDbContext context) : base(context) { }

        public ExpenseDto GetAll(string search)
        {
            ExpenseDto expense = new ExpenseDto(); 
            if (String.IsNullOrEmpty(search))
            {
                expense.Expenses = GetAll().Where(x => x.ItemName.IndexOf(search) != -1).ToList();
                expense.Total = expense.Expenses.Select(y=>y.Fees).Sum();
                
            }
            else
            {
                expense.Expenses = GetAll().ToList();
                expense.Total = GetAll().Select(y => y.Fees).Sum();
            
            }

            return expense;
        }
    }
}
