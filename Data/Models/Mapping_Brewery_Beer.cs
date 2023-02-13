using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Mapping_Brewery_Beer
    {
        public int Id { get; set; }
        public int BreweryId { get; set; }
        public int BeerId { get; set; }

        public virtual Beer Beer { get; set; }
        public virtual Brewery Brewery { get; set; }
    }
}
