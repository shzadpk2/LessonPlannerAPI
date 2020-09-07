using LessonPlanner.Common.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonPlanner.Repositories.IRepository
{
    public interface IQuizMakerRepository
    {
        QuizMakerResponseModel GetAllQuizMakers();
        QuizMakerTopicNumberDetailResponseModel GetQuizMakerTopicNumberDetail(long gradeID, long subjectID);

        QuizMakerResponseModel GetAllQuizMakersByMainTopicID(long mainTopicID);

        QuizMakerResponseModel GetAllQuizMakersBySubTopicID(long subTopicID);

        long GetMaxQuixNumber(long gradeID, long subjectID, string topicNumber);

        MultipleQuestionResponseModel GetAllMultipleQuestionsByQuizMakerID(long quizMakerID);

        TrueFalseQuestionResponseModel GetAllTrueFalseQuestionsByQuizMakerID(long quizMakerID);

        FillBlankQuestionResponseModel GetAllFillBlankQuestionsByQuizMakerID(long quizMakerID);

    }
}
