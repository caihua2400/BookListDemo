using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListDemo.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly BookListDemoDbContext _context;

        public CreateModel(BookListDemoDbContext context)
        {
            this._context = context;
        }
        [BindProperty]
        public Book book { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) {
                return Page();
            }
           
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }

    }
}
