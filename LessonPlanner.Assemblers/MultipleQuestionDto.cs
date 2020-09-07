using System;
using System.Collections.Generic;
using System.Text;

namespace LessonPlanner.Assemblers
{
    public class MultipleQuestionDto
    {
		public MultipleQuestionDto()
		{
			QuestionCounter = 0;
		}
		public long QuestionID { get; set; }
		public string QuestionText { get; set; }
		public long QuizMakerID { get; set; }
		public long MainTopicID { get; set; }
		public long SubTopicID { get; set; }
		public int NoOfOption { get; set; }
		public string OptionOneText { get; set; }
		public string OptionTwoText { get; set; }
		public string OptionThreeText { get; set; }
		public string OptionFourText { get; set; }

		public int QuestionCounter { get; set; }

		//AnswerProperties
		public long AnswerID { get; set; }
		public int AnswerOptionNo { get; set; }
		public string AnswerOptionText { get; set; }

		public DateTime CreatedOn { get; set; }
		public int CreatedBy { get; set; }
		public DateTime ModifiedOn { get; set; }
		public int ModifiedBy { get; set; }

	}
}
