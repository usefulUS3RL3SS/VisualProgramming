using System;
using System.Collections.Generic;

#nullable disable

namespace RGR
{
    public partial class Result
    {
        public long? IdLeague { get; set; }
        public long? IdTeam { get; set; }
        public long? Place { get; set; }

        public virtual League IdLeagueNavigation { get; set; }
        public virtual Team IdTeamNavigation { get; set; }
    }
}
