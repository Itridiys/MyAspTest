using MyAspTest.Models;
using System.Collections.Generic;

namespace MyAspTest.ViewModel
{
    public class PositionViewModel
    {
        public string PositionId { get; set; }

        public string PositionName { get; set; }

        public decimal Salary { get; set; }

        public int MaxNumber { get; set; }

        public List<User> Users { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public string DepartmentName { get; set; }

        public List<Position> Positions { get; set; }

        
    }
}
