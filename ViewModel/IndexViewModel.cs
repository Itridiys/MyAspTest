using MyAspTest.Models;
using System.Collections.Generic;

namespace MyAspTest.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public PaginIndexViewModel PaginIndexViewModel { get; set; }
        //AdvancedPagination
        public Pagination Pagination { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
        
    }
}
