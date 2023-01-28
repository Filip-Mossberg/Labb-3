using System;
using System.Collections.Generic;

namespace Labb_3.Models
{
    public partial class Personal
    {
        public Personal()
        {
            ConnectionTables = new HashSet<ConnectionTable>();
        }

        public int PersonalId { get; set; }
        public string FName { get; set; } = null!;
        public string LName { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual Position? Position { get; set; }
        public virtual ICollection<ConnectionTable> ConnectionTables { get; set; }
    }
}
