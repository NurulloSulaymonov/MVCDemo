using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class DataContext:DbContext
{
    
    //dbcontext options
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {
        
    }
    
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Tutor> Tutors { get; set; }

}