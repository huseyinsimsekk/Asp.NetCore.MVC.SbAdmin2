using System;
using System.Collections.Generic;
using System.Text;

namespace SbAdmin2.Core.Models
{
    public class Alert : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? ExpireTime { get; set; }
    }
}
