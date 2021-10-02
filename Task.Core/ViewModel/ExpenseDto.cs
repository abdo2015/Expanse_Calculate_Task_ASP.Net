using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Models;

namespace Task.Core.ViewModel
{
    public class ExpenseDto
    {
        public IEnumerable<Expense> Expenses { get; set; }
        public decimal? Total { get; set; }
    }
}
