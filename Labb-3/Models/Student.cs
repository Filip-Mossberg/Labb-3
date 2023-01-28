using System;
using System.Collections.Generic;

namespace Labb_3.Models
{
    public partial class Student
    {
        public Student()
        {
            ConnectionTables = new HashSet<ConnectionTable>();
        }

        public int StudentId { get; set; }
        public string Ssn { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int ClassId { get; set; }

        public virtual ICollection<ConnectionTable> ConnectionTables { get; set; }
    }
}
