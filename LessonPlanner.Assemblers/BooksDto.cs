using System;
using System.Collections.Generic;
using System.Text;

namespace LessonPlanner.Assemblers
{
    public class BooksDto
    {
		public long BookID { get; set; }
		public string BookDescription { get; set; }
		public long MainTopicID { get; set; }

		public string MainTopicNumber { get; set; }
		public DateTime CreatedOn { get; set; }
		public int CreatedBy { get; set; }
		public DateTime ModifiedOn { get; set; }
		public int ModifiedBy { get; set; }
	}
}
