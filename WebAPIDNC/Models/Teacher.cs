using System;
using System.Collections.Generic;

namespace WebAPIDNC.Models
{
    public partial class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
    }
}
