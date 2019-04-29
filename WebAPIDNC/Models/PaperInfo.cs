using System;
using System.Collections.Generic;

namespace WebAPIDNC.Models
{
    public partial class PaperInfo
    {
        public int PaperId { get; set; }
        public int? Year { get; set; }
        public string Shift { get; set; }
        public string Final { get; set; }
        public int? StatusId { get; set; }

        public Status Status { get; set; }
    }
}
