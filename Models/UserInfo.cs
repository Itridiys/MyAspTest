using System;
using System.Collections.Generic;

namespace MyAspTest.Models
{
    public class UserInfo
    {
       
        public int Id { get; set; }

        public DateTime HireTime { get; set; }

        public DateTime CurrentTime { get; set; }

        public DateTime FireTime { get; set; }

        private bool _IsWorking;

        public bool IsWorking
        {
            get => IsWorking = _IsWorking;
            set => _IsWorking = value;

        }
        
        public virtual List<User> Users { get; set; }


        public void GetInfo (bool isWorking = true)
        {
            _IsWorking = isWorking;
        }

        

    }
}