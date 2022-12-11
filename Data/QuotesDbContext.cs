using Microsoft.EntityFrameworkCore;
using System;
using QuotesAPI.Models;

namespace QuotesAPI.Data
{
    public class QuotesDbContext : DbContext
    {
        public QuotesDbContext(DbContextOptions<QuotesDbContext> options) : base(options)
        {
        }
        public DbSet<Quote> Quotes { get; set; }    
    }
}
