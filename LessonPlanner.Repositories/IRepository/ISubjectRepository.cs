using LessonPlanner.Common.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonPlanner.Repositories.IRepository
{
    public interface ISubjectRepository
    {
        SubjectResponseModel GetAllSubjects();
        SubjectResponseModel GetAllSubjectsByGradeID(long gradeID);
    }
}
