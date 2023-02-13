using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Beer
    {
        public Beer()
        {
            Mapping_Bar_Beers = new HashSet<Mapping_Bar_Beer>();
            Mapping_Brewery_Beers = new HashSet<Mapping_Brewery_Beer>();
        }

        public int BeerId { get; set; }
        public string Name { get; set; }
        public double PercentageAlcholByVolume { get; set; }

        public virtual ICollection<Mapping_Bar_Beer> Mapping_Bar_Beers { get; set; }
        public virtual ICollection<Mapping_Brewery_Beer> Mapping_Brewery_Beers { get; set; }
    }
}
