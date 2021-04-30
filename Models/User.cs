using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MyAspTest.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public string Phone { get; set; }
        
        public int PositionId { get; set; }

        public virtual Position Position { get; set; }

        public int StatusId { get; set; }

        public virtual Status Status { get; set; }

        public int UserInfoId { get; set; }

        public virtual UserInfo UserInfo { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public Position UserPosition
        {
            get
            {
                return DataWorker.GetPositionById(PositionId);
            }
        }

        //[System.ComponentModel.DataAnnotations.Schema.NotMapped]
        //public UserInfo UserInformation
        //{
        //    get
        //    {
        //        return DataWorker.GetUserInfoById(UserInfoId);
        //    }
        //}

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public Status UserStatus
        {
            get
            {
                return DataWorker.GetUserStatusById(StatusId);
            }
        }
    }
}
