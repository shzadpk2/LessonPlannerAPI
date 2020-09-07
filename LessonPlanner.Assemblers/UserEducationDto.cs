using System;
using System.Collections.Generic;
using System.Text;

namespace LessonPlanner.Assemblers
{
    public class UserEducationDto
    {
        public long? UserEducationID { get; set; }
        public string UserEducation { get; set; }
        public long UserID { get; set; }

        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public long ModifiedBy { get; set; }
    }
}
