using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookmarkManagementSystem.Data;
using BookmarkManagementSystem.Model;

namespace BookmarkManagementSystem.Pages.Bookmarks
{
    public class EditModel : PageModel
    {
        private readonly BookmarkManagementSystem.Data.BookmarkManagementSystemContext _context;

        public EditModel(BookmarkManagementSystem.Data.BookmarkManagementSystemContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bookmark Bookmark { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookmark =  await _context.Bookmark.FirstOrDefaultAsync(m => m.ID == id);
            if (bookmark == null)
            {
                return NotFound();
            }
            Bookmark = bookmark;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bookmark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookmarkExists(Bookmark.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookmarkExists(int id)
        {
            return _context.Bookmark.Any(e => e.ID == id);
        }
    }
}
