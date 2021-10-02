using Document.EF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Interfaces;
using Task.Core.Models;

namespace Test.Ef.Repository
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            ExpenseRepository = new BaseRepository<Expense>(_context);
            Expenses = new ExpenseRepository(_context);

        }
        public IBaseRepository<Expense> ExpenseRepository { get; private set; }

        public IExpenseRepository Expenses { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
