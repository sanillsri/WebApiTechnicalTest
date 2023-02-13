using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class Brewery
    {
        public Brewery()
        {
            Mapping_Brewery_Beers = new HashSet<Mapping_Brewery_Beer>();
        }

        public int BreweryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Mapping_Brewery_Beer> Mapping_Brewery_Beers { get; set; }
    }
}
