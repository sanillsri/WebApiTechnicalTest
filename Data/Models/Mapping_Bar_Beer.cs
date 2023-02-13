using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Mapping_Bar_Beer
    {
        public int Id { get; set; }
        public int BarId { get; set; }
        public int BeerId { get; set; }

        public virtual Bar Bar { get; set; }
        public virtual Beer Beer { get; set; }
    }
}
