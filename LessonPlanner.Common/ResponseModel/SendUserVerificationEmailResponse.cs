using System;
using System.Collections.Generic;
using System.Text;

namespace LessonPlanner.Common.ResponseModel
{
    public class SendUserVerificationEmailResponse
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }

        public bool isEmailSent { get; set; }
    }
}
