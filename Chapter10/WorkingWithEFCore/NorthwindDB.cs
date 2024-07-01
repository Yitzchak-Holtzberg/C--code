using System.ComponentModel;
using Microsoft.Data.SqlClient; // To use SqlConnectionStringBuilder.
using Microsoft.EntityFrameworkCore; // To use DbContext and so on.

namespace Northwind.EntityModels;

// This manages the connection to the database.
public class NorthwindDb : DbContext
{
  public DbSet<Category>? Categories { get; set; }



  public DbSet<Product>? Products { get; set; }


  protected override void OnConfiguring(
      DbContextOptionsBuilder optionsBuilder)
  {
    SqlConnectionStringBuilder builder = new();

    builder.DataSource = @".\PRACTICESERVER";
    // "ServerName\InstanceName" e.g. @".\sqlexpress"
    builder.InitialCatalog = "Northwind";
    builder.Encrypt = true;
    builder.TrustServerCertificate = true;
    builder.MultipleActiveResultSets = true;
    builder.ConnectTimeout = 3; // Because we want to fail fast. Default is 15 seconds.

    // If using Windows Integrated authentication.
    builder.IntegratedSecurity = true;

    // If using SQL Server authentication.
    // builder.UserId = Environment.GetEnvironmentVariable("MY_SQL_USR");
    // builder.Password = Environment.GetEnvironmentVariable("MY_SQL_PWD");

    string? connectionString = builder.ConnectionString;
    WriteLine($"Connection: {connectionString}");
    optionsBuilder.UseSqlServer(connectionString);
  }


  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Category>()
    .Property(category => category.CategoryName)
    .IsRequired()
    .HasMaxLength(15);


    modelBuilder.Entity<Product>()
    .HasQueryFilter(p => !p.Discontinued );
  }
}