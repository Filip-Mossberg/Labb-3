using System;
using System.Collections.Generic;

namespace Labb_3.Models
{
    public partial class Grade
    {
        public Grade()
        {
            ConnectionTables = new HashSet<ConnectionTable>();
        }

        public int GradeId { get; set; }
        public string? Grade1 { get; set; }
        public DateTime Date { get; set; }

        public virtual ICollection<ConnectionTable> ConnectionTables { get; set; }
    }
}
