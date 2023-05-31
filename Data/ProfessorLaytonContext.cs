using Microsoft.EntityFrameworkCore;
using ProfessorLayton.Models;

namespace ProfessorLayton.Data;

public class ProfessorLaytonContext : DbContext
{
    public DbSet<Character> Characters { get; set; } = null!;
    public DbSet<Enigma> Enigmas { get; set; } = null!;
    public DbSet<Solution> Solutions { get; set; } = null!;
    public DbSet<Hint> Hints { get; set; } = null!;

    public DbSet<Game> Games { get; set; } = null!;
    public DbSet<Music> Musics { get; set; } = null!;

    public string DbPath { get; private set; }

    public ProfessorLaytonContext()
    {
        // Path to SQLite database file
        DbPath = "ProfessorLayton.db";
    }

    // The following configures EF to create a SQLite database file locally
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Use SQLite as database
        options.UseSqlite($"Data Source={DbPath}");
        // Optional: log SQL queries to console
        options.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
    }
}