using System;
using System.Collections.Generic;
using System.Text;

namespace LessonPlanner.Assemblers
{
    public class SubjectDto
    {
        public long SubjectID { get; set; }
        public long GradeID { get; set; }
        public string SubjectName { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
    }
}
