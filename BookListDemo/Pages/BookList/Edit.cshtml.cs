using System.Threading.Tasks;
using BookListDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListDemo.Pages.BookList
{
    public class Edit : PageModel
    {
        private readonly BookListDemoDbContext _context;

        public void OnGet(int id)
        {
            Book = _context.Books.Find(id);
        }

        public Edit(BookListDemoDbContext context)
        {
            _context = context;
        }
        [BindProperty] public Book Book { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDB = await _context.Books.FindAsync(Book.Id);
                BookFromDB.Name = Book.Name;
                BookFromDB.ISBN = Book.ISBN;
                BookFromDB.Author = Book.Author;
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");

            }

            return RedirectToPage();
        }
    }
}

