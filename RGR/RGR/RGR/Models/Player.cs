using System;
using System.Collections.Generic;

#nullable disable

namespace RGR
{
    public partial class Player
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? Age { get; set; }
        public string Position { get; set; }
        public long? IdCountry { get; set; }
        public long? IdTeam { get; set; }

        public virtual Country IdCountryNavigation { get; set; }
        public virtual Team IdTeamNavigation { get; set; }
    }
}
