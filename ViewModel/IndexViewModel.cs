using MyAspTest.Models;
using System.Collections.Generic;

namespace MyAspTest.ViewModel
{
    public class IndexViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
