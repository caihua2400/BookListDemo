using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListDemo.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly BookListDemoDbContext _context;
        public IndexModel(BookListDemoDbContext context)
        {
            this._context = context;
        }
        [BindProperty]
        public IEnumerable<Book> Books { get; set; }
        [TempData]

        public string message { get; set; }
        
        public async Task OnGet()
        {
            Books = await _context.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return Page();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            message = "book delete successfully";
            return RedirectToPage("Index");
        }
    }
}
