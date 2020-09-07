using LessonPlanner.Assemblers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonPlanner.Common.ResponseModel
{
    public class QuizMakerTopicNumberDetailResponseModel
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public List<QuizMakerTopicNumberDetailDto> Data { get; set; }
    }
}
