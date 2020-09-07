using System;
using System.Collections.Generic;
using System.Text;

namespace LessonPlanner.Assemblers
{
    public class MoviesDto
    {
        public long MovieID { get; set; }
        public string MovieDescription { get; set; }
        public long MainTopicID { get; set; }

        public string MainTopicNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn
        {
            get; set;
        }

    }
}
