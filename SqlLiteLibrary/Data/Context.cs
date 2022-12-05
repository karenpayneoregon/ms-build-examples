using Microsoft.EntityFrameworkCore;
using SqlLiteLibrary.Models;

namespace SqlLiteLibrary.Data;

public class Context : DbContext
{
    public DbSet<FileContainer> FileContainers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=files.db");
}