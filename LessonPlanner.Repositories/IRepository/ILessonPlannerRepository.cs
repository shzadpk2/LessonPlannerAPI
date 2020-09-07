using LessonPlanner.Assemblers;
using LessonPlanner.Common.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonPlanner.Repositories.IRepository
{
    public interface ILessonPlannerRepository
    {
        string GetTestString();

        LessonPlannerResponseModel GetAllLessonPlanners();
        LessonPlannerResponseModel GetAllLessonPlannersByGradeIDandSubjectID(long gradeID, long subjectID);
        SubTopicResponseModel GetAllSubTopicByMainTopicID(long mainTopicID);

        MoviesResponseModel GetAllMovies();
        DocumentariesResponseModel GetAllDocumentaries();
        GamesResponseModel GetAllGames();

        BooksResponseModel GetAllBooks();
    }
}
