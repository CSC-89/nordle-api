using Microsoft.EntityFrameworkCore;
using Wordle.Api.Models;

public class WordContext : DbContext
{
    public WordContext (DbContextOptions<WordContext> options)
        : base(options)
    {
    }

    public DbSet<WordItem> Word { get; set; } = default!;
    
}