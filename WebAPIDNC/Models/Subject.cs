using System;
using System.Collections.Generic;

namespace WebAPIDNC.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Question = new HashSet<Question>();
        }

        public int SubjectId { get; set; }
        public string Name { get; set; }

        public ICollection<Question> Question { get; set; }
    }
}
