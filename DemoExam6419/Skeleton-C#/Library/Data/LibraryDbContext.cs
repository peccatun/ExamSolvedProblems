using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Data
{
    public class LibraryDbContext:DbContext
    {
        public DbSet<Book> Books { get; set;}

        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=LibraryDb2;Integrated Security=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
