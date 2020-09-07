using System;
using System.Collections.Generic;
using System.Text;

namespace LessonPlanner.Assemblers
{
    public class QuizMakerDto
    {
        public long QuizMakerID { get; set; }
        public long GradeID { get; set; }
        public string GradeName { get; set; }
        public long SubjectID { get; set; }
        public string SubjectName { get; set; }
        public long MainTopicID { get; set; }
        public long SubTopicID { get; set; }
        public string MainTopicNumber { get; set; }
        public string SubTopicNumber { get; set; }
        public string TopicNumber { get; set; }
        public string QuizNumber { get; set; }
        public string TimeLimit { get; set; }
        public string TotalQuestions { get; set; }
        public string TotalScore { get; set; }
        public string Instructions { get; set; }
        public bool IsMultiple { get; set; }
        public bool IsTF { get; set; }
        public bool IsFillBlank { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        //public List<MultipleQuestionModel> multipleQuestionModels { get; set; }
    }
}
