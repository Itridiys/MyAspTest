using MyAspTest.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyAspTest.ViewModel
{
    public class UserFilterViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public SelectList PositionSelectList { get; set; }
        public SelectList StatusList { get; set; }
        public SelectList InfoList { get; set; }
    }
}
