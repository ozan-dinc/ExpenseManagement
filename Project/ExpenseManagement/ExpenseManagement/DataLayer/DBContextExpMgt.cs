using ExpenseManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.DataLayer
{
    public class DBContextExpMgt : DbContext
    {
        public DBContextExpMgt(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ExpenseEntity> Expenses { get; set; }
        public DbSet<ExpenseCategoryEntity> ExpenseCategory { get; set; }
        public DbSet<User> Users { get; set; }



    }
}
