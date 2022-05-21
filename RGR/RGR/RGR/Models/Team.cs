using System;
using System.Collections.Generic;

#nullable disable

namespace RGR
{
    public partial class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? G { get; set; }
        public long? Mp { get; set; }
        public double? Fg { get; set; }
        public double? Fga { get; set; }
        public double? FgPercent { get; set; }
        public double? _3p { get; set; }
        public double? _3pa { get; set; }
        public double? _3pPercent { get; set; }
        public double? _2p { get; set; }
        public double? _2pa { get; set; }
        public double? _2pPercent { get; set; }
        public double? Ft { get; set; }
        public double? Fta { get; set; }
        public double? FtPercent { get; set; }
        public double? Orb { get; set; }
        public double? Drb { get; set; }
        public double? Trb { get; set; }
        public double? Ast { get; set; }
        public double? Stl { get; set; }
        public double? Blk { get; set; }
        public double? Tov { get; set; }
        public double? Pf { get; set; }
        public double? Pts { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
