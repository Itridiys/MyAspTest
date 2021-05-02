using System.Collections.Generic;

namespace MyAspTest.Models
{
    public class Department
    {
        
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<Position> Positions { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public List<Position> DepartmentPositions
        {
            get
            {
                return DataWorker.GetdPositionsBydepartmentId(Id);
            }
        }
    }
}
