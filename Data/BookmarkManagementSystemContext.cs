using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookmarkManagementSystem.Model;

namespace BookmarkManagementSystem.Data
{
    public class BookmarkManagementSystemContext : DbContext
    {
        public BookmarkManagementSystemContext (DbContextOptions<BookmarkManagementSystemContext> options)
            : base(options)
        {
        }

        public DbSet<BookmarkManagementSystem.Model.Bookmark> Bookmark { get; set; } = default!;
    }
}
