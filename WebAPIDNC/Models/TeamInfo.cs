using System;
using System.Collections.Generic;

namespace WebAPIDNC.Models
{
    public partial class TeamInfo
    {
        public int TeamId { get; set; }
        public int? Year { get; set; }
        public string Class { get; set; }
    }
}
