using System;
using System.Collections.Generic;
using System.Text;
using BookCrudWithAspdotnetcore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookCrudWithAspdotnetcore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
      
         }
        public DbSet<Book> Book { get; set; }
    }
}
