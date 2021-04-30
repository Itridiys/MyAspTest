using MyAspTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
