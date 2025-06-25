using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment_AI.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Transaction Date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Amount")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be positive.")]
        public decimal Amount { get; set; }

        [Display(Name = "Running Balance")]
        public decimal Balance { get; set; }

        [Required]
        [Display(Name = "Transaction Type")]
        public TransactionType Type { get; set; }
    }

    public enum TransactionType
    {
        Credit,
        Debit
    }
}
