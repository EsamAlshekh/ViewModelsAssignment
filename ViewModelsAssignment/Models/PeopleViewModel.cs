using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewModelsAssignment.Models
{
    public class PeopleViewModel
    {
        public string searchString { get; set; }
        public int? page { get; set; }
        public string sortBy { get; set; }
        public List<People> People { get; set; }

        public PagedList.IPagedList<People> pagedList { get; set; }
    }
}