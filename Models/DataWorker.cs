using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyAspTest.Domain;

namespace MyAspTest.Models
{
    public static class DataWorker 
    {
        public static List<Position> GetdPositionsBydepartmentId(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                List<Position> positions = (from position in GetAllPositions() where position.DepartmentId == id select position).ToList();
                return positions;
            }
        }
        
        public static List<Position> GetAllPositions()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.Positions.ToList();
                return result;
            }
        }
        

        public static Department GetdDepartmentById(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                Department pos = db.Departments.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }

        public static List<User> GetdUsersByPositionId(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                List<User> users = (from user in GetAllUsers() where user.PositionId == id select user).ToList();
                return users;
            }
        }

        public static List<User> GetAllUsers()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.Users.OrderBy(u =>u.ID).ToList();
                return result;
            }
        }

        public static IQueryable<User> GetAllUsers(UserParameters userParameters)
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.Users.OrderBy(u => u.ID).Skip((userParameters.PageNumber - 1) * userParameters.PageSize).Take(userParameters.PageSize);
                return result;
            }
        }

        public static Position GetPositionById(int id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                Position pos = db.Positions.FirstOrDefault(p => p.Id == id);
                return pos;
            }
        }

        public static UserInfo GetUserInfoById(int userId)
        {
            using (AppDbContext db = new AppDbContext())
            {
                UserInfo infos = db.UserInfos.FirstOrDefault(p => p.Id == userId);
                return infos;
            }
        }

        internal static Status GetUserStatusById(int statusId)
        {
            using (AppDbContext db = new AppDbContext())
            {
                Status status = db.Statuses.FirstOrDefault(p => p.Id == statusId);
                return status;
            }
        }
        
        public static List<UserInfo> GetAllInfos()
        {
            using (AppDbContext db = new AppDbContext())
            {
                var result = db.UserInfos.ToList();
                return result;
            }
        }

        internal static User GetUserById(int Id)
        {
            using (AppDbContext db = new AppDbContext())
            {
                User user = db.Users.FirstOrDefault(p => p.ID == Id);
                return user;
            }
        }


    }
}
