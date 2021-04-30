using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using MyAspTest.Models;



namespace MyAspTest.Domain
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<UserInfo> UserInfos { get; set; }

        public DbSet<Status> Statuses { get; set; }
        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb; Database=SuperCompany; Persist Security Info=false; MultipleActiveResultSets=True; Trusted_Connection=False;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(new Status[]
            {
                new Status {Id = 1, Name = "Работает"},
                new Status {Id = 2, Name = "В отпуске"},
                new Status {Id = 3, Name = "На больничном"},
                new Status {Id = 4, Name = "Уволен"},
            });

            modelBuilder.Entity<Department>().HasData(new Department[]
            {
                 new Department {Id = 1, Name = "ИТ Отдел" },
                 new Department {Id = 2, Name = "Бухгалтерия" }
            });

            modelBuilder.Entity<Position>().HasData(new Position[]
            {
                 new Position {Id = 1, Name = "Программист", Salary = 70000, MaxNumber = 3, DepartmentId = 1 },
                 new Position {Id = 2, Name = "Специалист 1С", Salary = 30000, MaxNumber = 10, DepartmentId = 2 }
            });


        }


    }

    //public class DbInitializer : SqlServerCreateDatabaseOperation
    //{
    //    protected void Seed(AppDbContext dbContext)
    //    {
    //        Status worStatus = new Status { Name = "Работает" };
    //        Status hollydayStatus = new Status { Name = "В отпуске" };
    //        Status sickStatus = new Status { Name = "На больничном" };
    //        Status fireStatus = new Status { Name = "Уволен" };

    //        dbContext.Statuses.AddRange(worStatus, hollydayStatus, sickStatus, fireStatus);
    //        dbContext.SaveChanges();

    //        Position itPosition = new Position { Name = "Программист", Salary = 70000, MaxNumber = 3, DepartmentId = 1 };
    //        Position counterPosition = new Position { Name = "Специалист 1С", Salary = 30000, MaxNumber = 10, DepartmentId = 2 };

    //        dbContext.Positions.AddRange(itPosition, counterPosition);
    //        dbContext.SaveChanges();

    //        Department itDepartment = new Department { Name = "ИТ Отдел" };
    //        Department counterDepartment = new Department { Name = "Бухгалтерия" };

    //        dbContext.Departments.AddRange(itDepartment, counterDepartment);
    //        dbContext.SaveChanges();
    //    }


    //}


}
