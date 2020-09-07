using System;
using System.Collections.Generic;
using System.Text;

namespace LessonPlanner.Common.ResponseModel
{
    public class SignUpResponseModel
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public long UserID { get; set; }
        public string   ClassCode { get; set; }
    }
}
