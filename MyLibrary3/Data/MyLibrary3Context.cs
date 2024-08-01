using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyLibrary3.Models;

namespace MyLibrary3.Data
{
    public class MyLibrary3Context : DbContext
    {
        public MyLibrary3Context (DbContextOptions<MyLibrary3Context> options)
            : base(options)
        {
        }

        public DbSet<MyLibrary3.Models.Library> Library { get; set; } = default!;
        public DbSet<MyLibrary3.Models.Shelf> Shelf { get; set; } = default!;
        public DbSet<MyLibrary3.Models.Book> Book { get; set; } = default!;
        public DbSet<MyLibrary3.Models.BookSet> BookSet { get; set; } = default!;
    }
}
