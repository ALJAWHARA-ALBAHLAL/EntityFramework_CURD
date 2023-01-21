using Microsoft.EntityFrameworkCore;
using System.Transactions;
using Try3.Models;


//ctor  
//prop
namespace Try3.Data
{//This context class typically includes DbSet<TEntity> properties for each entity in the model
    public class ApplicationDbContext : DbContext
    {
        //DbContextOptions manage connection
        // It is the connection between our entity classes and the database.
        // The DBContext is responsible for the database interactions like querying the database and loading the data into memory as entity.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)   
        {
             
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
        base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Student>().ToTable("Student","College");
            //modelBuilder.Entity<Department>().ToTable("Department","College");
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Student> Student { get; set; }




    }
}
