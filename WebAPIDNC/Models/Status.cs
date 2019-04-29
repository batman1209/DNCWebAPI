using System;
using System.Collections.Generic;

namespace WebAPIDNC.Models
{
    public partial class Status
    {
        public Status()
        {
            PaperInfo = new HashSet<PaperInfo>();
        }

        public int StatusId { get; set; }
        public string CurrentStatus { get; set; }

        public ICollection<PaperInfo> PaperInfo { get; set; }
    }
}
