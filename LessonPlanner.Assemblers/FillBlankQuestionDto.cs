﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LessonPlanner.Assemblers
{
    public class FillBlankQuestionDto
    {
        public FillBlankQuestionDto()
        {
            QuestionCounter = 0;
        }
        public long QuestionID { get; set; }
        public string QuestionText { get; set; }
        public long QuizMakerID { get; set; }
        public long MainTopicID { get; set; }
        public long SubTopicID { get; set; }

        //True Flase Answer Properties

        //AnswerProperties
        public long AnswerID { get; set; }
        public string AnswerText { get; set; }

        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public int QuestionCounter { get; set; }
    }
}
