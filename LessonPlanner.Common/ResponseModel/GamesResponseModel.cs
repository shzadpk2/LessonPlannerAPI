using LessonPlanner.Assemblers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonPlanner.Common.ResponseModel
{
    public class GamesResponseModel
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public List<GamesDto> Data { get; set; }
    }
}
