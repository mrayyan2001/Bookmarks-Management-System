using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookmarkManagementSystem.Data;
using BookmarkManagementSystem.Model;

namespace BookmarkManagementSystem.Pages.Bookmarks
{
    public class IndexModel : PageModel
    {
        private readonly BookmarkManagementSystem.Data.BookmarkManagementSystemContext _context;

        public IndexModel(BookmarkManagementSystem.Data.BookmarkManagementSystemContext context)
        {
            _context = context;
        }

        public IList<Bookmark> Bookmark { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Bookmark = await _context.Bookmark.ToListAsync();
        }
    }
}
