using System;
using System.Collections.Generic;

namespace WebAPIDNC.Models
{
    public partial class Question
    {
        public Question()
        {
            Option = new HashSet<Option>();
        }

        public int QuesId { get; set; }
        public string QuestionStatement { get; set; }
        public int DifficultyId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }

        public DifficultyLevel Difficulty { get; set; }
        public Subject Subject { get; set; }
        public ICollection<Option> Option { get; set; }
    }
}
