using Microsoft.EntityFrameworkCore;
using Assignment_AI.Models;

namespace Assignment_AI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial transactions
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction
                {
                    Id = 1,
                    Date = DateTime.SpecifyKind(new DateTime(2024, 2, 17), DateTimeKind.Utc),
                    Description = "Initial Office Credit",
                    Amount = 5000m,
                    Type = TransactionType.Credit
                },
                new Transaction
                {
                    Id = 2,
                    Date = DateTime.SpecifyKind(new DateTime(2024, 2, 18), DateTimeKind.Utc),
                    Description = "Snacks Party",
                    Amount = 500m,
                    Type = TransactionType.Debit
                },
                new Transaction
                {
                    Id = 3,
                    Date = DateTime.SpecifyKind(new DateTime(2024, 2, 18), DateTimeKind.Utc),
                    Description = "Printing Sheets",
                    Amount = 285m,
                    Type = TransactionType.Debit
                },
                new Transaction
                {
                    Id = 4,
                    Date = DateTime.SpecifyKind(new DateTime(2024, 2, 20), DateTimeKind.Utc),
                    Description = "Misc. Expense",
                    Amount = 3000m,
                    Type = TransactionType.Debit
                }
            );
        }
    }
}
