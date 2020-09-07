using LessonPlanner.Assemblers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonPlanner.Common.ResponseModel
{
    public class MoviesResponseModel
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public List<MoviesDto> Data { get; set; }
    }
}
