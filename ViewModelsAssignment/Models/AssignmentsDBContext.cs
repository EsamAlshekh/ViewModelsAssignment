using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ViewModelsAssignment.Models
{
    public class AssignmentsDBContext:DbContext
    {
        public AssignmentsDBContext() : base("AssignmentsDBContext")
        { }

        public DbSet<People> People { get; set; }

    }
}