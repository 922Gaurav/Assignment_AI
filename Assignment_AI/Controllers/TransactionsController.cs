using Assignment_AI.Data;
using Assignment_AI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_AI.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var transactions = await _context.Transactions
                .OrderByDescending(t => t.Date)
                .ToListAsync();


            return View(transactions);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transactions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,Description,Amount,Type")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                // Get the previous balance (most recent transaction)
                var lastTransaction = await _context.Transactions
                    .OrderByDescending(t => t.Date)
                    .FirstOrDefaultAsync();

                decimal previousBalance = lastTransaction?.Balance ?? 0;

                // Set the transaction date to UTC
                transaction.Date = DateTime.SpecifyKind(transaction.Date, DateTimeKind.Utc);

                // Calculate credit and debit
                decimal credit = transaction.Type == Assignment_AI.Models.TransactionType.Credit ? transaction.Amount : 0;
                decimal debit = transaction.Type == Assignment_AI.Models.TransactionType.Debit ? transaction.Amount : 0;

                // Calculate new balance based on previous balance
                transaction.Balance = previousBalance + credit - debit;


                _context.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transaction);
        }
    }
}
