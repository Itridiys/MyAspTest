using System;
using MyAspTest.Models;

namespace MyAspTest.ViewModel
{
    public class UserViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Phone { get; set; }

        public int PositionId { get; set; }

        public DateTime HireTime { get; set; }

        public DateTime CurrentTime { get; set; }

        public DateTime FireTime { get; set; }

        public int UserInfoId { get; set; }

        public virtual UserInfo UserInfo { get; set; }

        public int StatusId { get; set; }

        public  virtual  Status Status { get; set; }

        public  virtual Position Position { get; set; }
    }
}