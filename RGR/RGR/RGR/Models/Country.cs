using System;
using System.Collections.Generic;

#nullable disable

namespace RGR
{
    public partial class Country
    {
        public Country()
        {
            Players = new HashSet<Player>();
        }

        public long Id { get; set; }
        public string NameCountry { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
