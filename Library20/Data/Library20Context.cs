using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Library10.Models;

namespace Library20.Data
{
    public class Library20Context : DbContext
    {
        public Library20Context (DbContextOptions<Library20Context> options)
            : base(options)
        {
        }

        public DbSet<Library10.Models.Library> Library { get; set; } = default!;
        public DbSet<Library10.Models.Shelf> Shelf { get; set; } = default!;
        public DbSet<Library10.Models.Item> Item { get; set; } = default!;
    }
}
