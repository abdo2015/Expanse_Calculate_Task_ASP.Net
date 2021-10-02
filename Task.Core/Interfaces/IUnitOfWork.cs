using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Models;

namespace Task.Core.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {

        IBaseRepository<Expense> ExpenseRepository { get; }
        IExpenseRepository Expenses { get; }

        int Complete();
    }
}
