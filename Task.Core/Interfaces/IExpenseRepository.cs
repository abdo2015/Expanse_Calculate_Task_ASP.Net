using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Models;
using Task.Core.ViewModel;

namespace Task.Core.Interfaces
{
    public interface IExpenseRepository : IBaseRepository<Expense>
    {
        ExpenseDto GetAll(string search);

    }
}
