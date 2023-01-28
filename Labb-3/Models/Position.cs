using System;
using System.Collections.Generic;

namespace Labb_3.Models
{
    public partial class Position
    {
        public int PositionId { get; set; }
        public string Position1 { get; set; } = null!;

        public virtual Personal PositionNavigation { get; set; } = null!;
    }
}
