using System;
using System.Collections.Generic;

namespace Labb_3.Models
{
    public partial class ConnectionTable
    {
        public int ConnectId { get; set; }
        public int PersonalId { get; set; }
        public int StudentId { get; set; }
        public int GradeId { get; set; }
        public int SubjectId { get; set; }

        public virtual Grade Grade { get; set; } = null!;
        public virtual Personal Personal { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
