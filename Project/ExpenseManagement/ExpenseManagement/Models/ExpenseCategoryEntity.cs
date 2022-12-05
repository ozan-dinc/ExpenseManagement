using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Models
{
    public class ExpenseCategoryEntity
    {
        [Key]
        public int ExpenseCategoryId { get; set; }

        public string ExpenseCategoryName { get; set; }

    }
}
