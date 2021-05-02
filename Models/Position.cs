using System.Collections.Generic;

namespace MyAspTest.Models
{
    public class Position
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public decimal Salary { get; set; }
        
        public int MaxNumber { get; set; }

        public List<User> Users { get; set; }
        
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public Department PositionDepartment
        {
            get
            {
                return DataWorker.GetdDepartmentById(DepartmentId);
            }
        }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public List<User> PositionUsers
        {
            get
            {
                return DataWorker.GetdUsersByPositionId(Id);
            }
        }
    }
}
