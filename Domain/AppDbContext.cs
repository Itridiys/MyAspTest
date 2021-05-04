using System;
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

            modelBuilder.Entity<UserInfo>().HasData(new UserInfo[]
            {
                new UserInfo {Id = 1, HireTime = DateTime.Now, CurrentTime = DateTime.Now, FireTime = DateTime.MinValue, IsWorking = true},
                new UserInfo {Id = 2, HireTime = DateTime.Now, CurrentTime = DateTime.Now, FireTime = DateTime.MinValue, IsWorking = true},
                new UserInfo {Id = 3, HireTime = DateTime.Now, CurrentTime = DateTime.Now, FireTime = DateTime.MinValue, IsWorking = true},
            });

            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User {ID = 1, Name = "Никита", Surname = "Антонов", Phone = "891912321", PositionId = 1, StatusId = 1, UserInfoId = 1},
                new User {ID = 2, Name = "Мария", Surname = "Иванова", Phone = "892291312", PositionId = 2, StatusId = 1, UserInfoId = 2},
                new User {ID = 3, Name = "Виолета", Surname = "Смирнова", Phone = "899938958", PositionId = 2, StatusId = 2, UserInfoId = 3},
            });

            

        }


    }
    


}
