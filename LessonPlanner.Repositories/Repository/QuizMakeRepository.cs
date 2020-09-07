using LessonPlanner.Assemblers;
using LessonPlanner.Common;
using LessonPlanner.Common.ResponseModel;
using LessonPlanner.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace LessonPlanner.Repositories.Repository
{
    public class QuizMakeRepository : IQuizMakerRepository
    {
        public QuizMakerResponseModel GetAllQuizMakers()
        {
            QuizMakerResponseModel quizMakerResponseModel = new QuizMakerResponseModel();
            quizMakerResponseModel.Data = new List<QuizMakerDto>();
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {

                SqlCommand command = new SqlCommand(@"dbo.uspGetAllQuizMakers", conn);
                command.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                quizMakerResponseModel.Message = "Success";
                quizMakerResponseModel.StatusCode = 200;

                foreach (DataRow row in dataTable.Rows)
                {
                    QuizMakerDto quizMakerModel = new QuizMakerDto();
                    quizMakerModel.QuizMakerID = row["QuizMakerID"] != DBNull.Value ? Convert.ToInt64(row["QuizMakerID"].ToString()) : 0;
                    quizMakerModel.GradeID = row["GradeID"] != DBNull.Value ? Convert.ToInt64(row["GradeID"].ToString()) : 0;
                    quizMakerModel.GradeName = row["GradeName"] != DBNull.Value ? Convert.ToString(row["GradeName"]) : string.Empty;
                    quizMakerModel.SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt64(row["SubjectID"].ToString()) : 0;
                    quizMakerModel.SubjectName = row["SubjectName"] != DBNull.Value ? Convert.ToString(row["SubjectName"]) : string.Empty;
                    quizMakerModel.MainTopicID = row["MainTopicID"] != DBNull.Value ? Convert.ToInt64(row["MainTopicID"].ToString()) : 0;
                    quizMakerModel.MainTopicNumber = row["MainTopicNumber"] != DBNull.Value ? Convert.ToString(row["MainTopicNumber"]) : string.Empty;
                    quizMakerModel.SubTopicID = row["SubTopicID"] != DBNull.Value ? Convert.ToInt64(row["SubTopicID"].ToString()) : 0;
                    quizMakerModel.SubTopicNumber = row["SubTopicNumber"] != DBNull.Value ? Convert.ToString(row["SubTopicNumber"]) : string.Empty;
                    quizMakerModel.TimeLimit = row["TimeLimit"] != DBNull.Value ? Convert.ToString(row["TimeLimit"]) : string.Empty;
                    quizMakerModel.TotalQuestions = row["TotalQuestions"] != DBNull.Value ? Convert.ToString(row["TotalQuestions"]) : string.Empty;
                    quizMakerModel.TotalScore = row["TotalScore"] != DBNull.Value ? Convert.ToString(row["TotalScore"]) : string.Empty;
                    quizMakerModel.Instructions = row["Instructions"] != DBNull.Value ? Convert.ToString(row["Instructions"]) : string.Empty;

                    quizMakerResponseModel.Data.Add(quizMakerModel);
                }
            }
            catch (Exception ex)
            {
                quizMakerResponseModel.StatusCode = 500;
                quizMakerResponseModel.Message = ex.Message;
                quizMakerResponseModel.Data = null;
            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
                conn.Close();

            }

            return quizMakerResponseModel;
        }

        public QuizMakerResponseModel GetAllQuizMakersByMainTopicID(long mainTopicID)
        {
            QuizMakerResponseModel quizMakerResponseModel = new QuizMakerResponseModel();
            quizMakerResponseModel.Data = new List<QuizMakerDto>();
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(@"dbo.uspGetAllQuizzesByMainTopicID", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MainTopicID", mainTopicID);


                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                quizMakerResponseModel.Message = "Success";
                quizMakerResponseModel.StatusCode = 200;

                foreach (DataRow row in dataTable.Rows)
                {
                    QuizMakerDto quizMakerModel = new QuizMakerDto();
                    quizMakerModel.QuizMakerID = row["QuizMakerID"] != DBNull.Value ? Convert.ToInt64(row["QuizMakerID"].ToString()) : 0;
                    quizMakerModel.GradeID = row["GradeID"] != DBNull.Value ? Convert.ToInt64(row["GradeID"].ToString()) : 0;
                    quizMakerModel.GradeName = row["GradeName"] != DBNull.Value ? Convert.ToString(row["GradeName"]) : string.Empty;
                    quizMakerModel.SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt64(row["SubjectID"].ToString()) : 0;
                    quizMakerModel.SubjectName = row["SubjectName"] != DBNull.Value ? Convert.ToString(row["SubjectName"]) : string.Empty;
                    quizMakerModel.MainTopicID = row["MainTopicID"] != DBNull.Value ? Convert.ToInt64(row["MainTopicID"].ToString()) : 0;
                    quizMakerModel.MainTopicNumber = row["MainTopicNumber"] != DBNull.Value ? Convert.ToString(row["MainTopicNumber"]) : string.Empty;
                    quizMakerModel.QuizNumber = row["QuizNumber"] != DBNull.Value ? Convert.ToString(row["QuizNumber"]) : string.Empty;
                    //quizMakerModel.SubTopicID = row["SubTopicID"] != DBNull.Value ? Convert.ToInt64(row["SubTopicID"].ToString()) : 0;
                    //quizMakerModel.SubTopicNumber = row["SubTopicNumber"] != DBNull.Value ? Convert.ToString(row["SubTopicNumber"]) : string.Empty;
                    quizMakerModel.TimeLimit = row["TimeLimit"] != DBNull.Value ? Convert.ToString(row["TimeLimit"]) : string.Empty;
                    quizMakerModel.TotalQuestions = row["TotalQuestions"] != DBNull.Value ? Convert.ToString(row["TotalQuestions"]) : string.Empty;
                    quizMakerModel.TotalScore = row["TotalScore"] != DBNull.Value ? Convert.ToString(row["TotalScore"]) : string.Empty;
                    quizMakerModel.Instructions = row["Instructions"] != DBNull.Value ? Convert.ToString(row["Instructions"]) : string.Empty;


                    quizMakerResponseModel.Data.Add(quizMakerModel);
                }
            }
            catch (Exception ex)
            {
                quizMakerResponseModel.StatusCode = 500;
                quizMakerResponseModel.Message = ex.Message;
                quizMakerResponseModel.Data = null;
            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
                conn.Close();

            }

            return quizMakerResponseModel;
        }

        public QuizMakerResponseModel GetAllQuizMakersBySubTopicID(long subTopicID)
        {
            QuizMakerResponseModel quizMakerResponseModel = new QuizMakerResponseModel();
            quizMakerResponseModel.Data = new List<QuizMakerDto>();
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(@"dbo.uspGetAllQuizzesBySubTopicID", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@SubTopicID", subTopicID);


                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                quizMakerResponseModel.Message = "Success";
                quizMakerResponseModel.StatusCode = 200;

                foreach (DataRow row in dataTable.Rows)
                {
                    QuizMakerDto quizMakerModel = new QuizMakerDto();
                    quizMakerModel.QuizMakerID = row["QuizMakerID"] != DBNull.Value ? Convert.ToInt64(row["QuizMakerID"].ToString()) : 0;
                    quizMakerModel.GradeID = row["GradeID"] != DBNull.Value ? Convert.ToInt64(row["GradeID"].ToString()) : 0;
                    quizMakerModel.GradeName = row["GradeName"] != DBNull.Value ? Convert.ToString(row["GradeName"]) : string.Empty;
                    quizMakerModel.SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt64(row["SubjectID"].ToString()) : 0;
                    quizMakerModel.SubjectName = row["SubjectName"] != DBNull.Value ? Convert.ToString(row["SubjectName"]) : string.Empty;
                    quizMakerModel.SubTopicID = row["SubTopicID"] != DBNull.Value ? Convert.ToInt64(row["SubTopicID"].ToString()) : 0;
                    quizMakerModel.SubTopicNumber = row["SubTopicNumber"] != DBNull.Value ? Convert.ToString(row["SubTopicNumber"]) : string.Empty;
                    quizMakerModel.QuizNumber = row["QuizNumber"] != DBNull.Value ? Convert.ToString(row["QuizNumber"]) : string.Empty;
                    quizMakerModel.TimeLimit = row["TimeLimit"] != DBNull.Value ? Convert.ToString(row["TimeLimit"]) : string.Empty;
                    quizMakerModel.TotalQuestions = row["TotalQuestions"] != DBNull.Value ? Convert.ToString(row["TotalQuestions"]) : string.Empty;
                    quizMakerModel.TotalScore = row["TotalScore"] != DBNull.Value ? Convert.ToString(row["TotalScore"]) : string.Empty;
                    quizMakerModel.Instructions = row["Instructions"] != DBNull.Value ? Convert.ToString(row["Instructions"]) : string.Empty;
                    quizMakerResponseModel.Data.Add(quizMakerModel);
                }
            }
            catch (Exception ex)
            {
                quizMakerResponseModel.StatusCode = 500;
                quizMakerResponseModel.Message = ex.Message;
                quizMakerResponseModel.Data = null;
            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
                conn.Close();

            }

            return quizMakerResponseModel;
        }

        public QuizMakerTopicNumberDetailResponseModel GetQuizMakerTopicNumberDetail(long gradeID, long subjectID)
        {
            QuizMakerTopicNumberDetailResponseModel quizMakerTopicNumberDetailResponseModel = new QuizMakerTopicNumberDetailResponseModel();
            quizMakerTopicNumberDetailResponseModel.Data = new List<QuizMakerTopicNumberDetailDto>();
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {

                SqlCommand command = new SqlCommand(@"dbo.uspGetAllSubTopicDetails", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@gradeID", gradeID);
                command.Parameters.AddWithValue("@subjectID", subjectID);


                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                quizMakerTopicNumberDetailResponseModel.Message = "Success";
                quizMakerTopicNumberDetailResponseModel.StatusCode = 200;

                foreach (DataRow row in dataTable.Rows)
                {
                    QuizMakerTopicNumberDetailDto quizMakerTopicNumberDetail = new QuizMakerTopicNumberDetailDto();

                    quizMakerTopicNumberDetail.TopicID = row["TopicID"] != DBNull.Value ? Convert.ToString(row["TopicID"].ToString()) : string.Empty;
                    quizMakerTopicNumberDetail.TopicNumber = row["TopicNumber"] != DBNull.Value ? Convert.ToString(row["TopicNumber"].ToString()) : string.Empty;


                    quizMakerTopicNumberDetailResponseModel.Data.Add(quizMakerTopicNumberDetail);
                }
            }
            catch (Exception ex)
            {
                quizMakerTopicNumberDetailResponseModel.StatusCode = 500;
                quizMakerTopicNumberDetailResponseModel.Message = ex.Message;
                quizMakerTopicNumberDetailResponseModel.Data = null;
            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
                conn.Close();

            }

            return quizMakerTopicNumberDetailResponseModel;
        }

        public long GetMaxQuixNumber(long gradeID, long subjectID, string topicNumber)
        {
            long result = 0;
            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(@"dbo.uspGetMaxTopicNumber", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GradeID", gradeID);
                command.Parameters.AddWithValue("@SubjectID", subjectID);
                command.Parameters.AddWithValue("@TopicNumber", topicNumber);

                conn.Open();
                //command.Connection = DatabaseContext.Connection;
                //command.Transaction = DatabaseContext.Transaction;

                result = Convert.ToInt64(command.ExecuteScalar());
                conn.Close();
            }
            catch (Exception ex)
            {
                result = 0;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public MultipleQuestionResponseModel GetAllMultipleQuestionsByQuizMakerID(long quizMakerID)
        {
            MultipleQuestionResponseModel multipleQuestionResponseModel = new MultipleQuestionResponseModel();
            multipleQuestionResponseModel.Data = new List<MultipleQuestionDto>();
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(@"dbo.uspGetAllMultipleQuestionsByQuizMakerID", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@QuizMakerID", quizMakerID);


                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                multipleQuestionResponseModel.Message = "Success";
                multipleQuestionResponseModel.StatusCode = 200;

                foreach (DataRow row in dataTable.Rows)
                {
                    MultipleQuestionDto multipleQuestionModel = new MultipleQuestionDto();
                    multipleQuestionModel.QuestionID = row["QuestionID"] != DBNull.Value ? Convert.ToInt64(row["QuestionID"].ToString()) : 0;
                    multipleQuestionModel.QuizMakerID = row["QuizMakerID"] != DBNull.Value ? Convert.ToInt64(row["QuizMakerID"].ToString()) : 0;
                    multipleQuestionModel.QuestionText = row["QuestionText"] != DBNull.Value ? Convert.ToString(row["QuestionText"]) : string.Empty;
                    multipleQuestionModel.NoOfOption = row["NoOfOptions"] != DBNull.Value ? Convert.ToInt32(row["NoOfOptions"].ToString()) : 0;
                    multipleQuestionModel.OptionOneText = row["OptionOneText"] != DBNull.Value ? Convert.ToString(row["OptionOneText"]) : string.Empty;
                    multipleQuestionModel.OptionTwoText = row["OptionTwoText"] != DBNull.Value ? Convert.ToString(row["OptionTwoText"]) : string.Empty;
                    multipleQuestionModel.OptionThreeText = row["OptionThreeText"] != DBNull.Value ? Convert.ToString(row["OptionThreeText"]) : string.Empty;
                    multipleQuestionModel.OptionFourText = row["OptionFourText"] != DBNull.Value ? Convert.ToString(row["OptionFourText"]) : string.Empty;
                    multipleQuestionModel.AnswerOptionNo = row["AnswerOption"] != DBNull.Value ? Convert.ToInt32(row["AnswerOption"].ToString()) : 0;
                    multipleQuestionResponseModel.Data.Add(multipleQuestionModel);
                }
            }
            catch (Exception ex)
            {
                multipleQuestionResponseModel.StatusCode = 500;
                multipleQuestionResponseModel.Message = ex.Message;
                multipleQuestionResponseModel.Data = null;
            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
                conn.Close();

            }

            return multipleQuestionResponseModel;
        }

        public TrueFalseQuestionResponseModel GetAllTrueFalseQuestionsByQuizMakerID(long quizMakerID)
        {
            TrueFalseQuestionResponseModel trueFalseQuestionResponseModel = new TrueFalseQuestionResponseModel();
            trueFalseQuestionResponseModel.Data = new List<TrueFalseQuestionDto>();
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(@"dbo.uspGetAllTrueFalseQuestionsByQuizMakerID", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@QuizMakerID", quizMakerID);


                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                trueFalseQuestionResponseModel.Message = "Success";
                trueFalseQuestionResponseModel.StatusCode = 200;

                foreach (DataRow row in dataTable.Rows)
                {
                    TrueFalseQuestionDto trueFalseQuestionModel = new TrueFalseQuestionDto();
                    trueFalseQuestionModel.QuestionID = row["QuestionID"] != DBNull.Value ? Convert.ToInt64(row["QuestionID"].ToString()) : 0;
                    trueFalseQuestionModel.QuizMakerID = row["QuizMakerID"] != DBNull.Value ? Convert.ToInt64(row["QuizMakerID"].ToString()) : 0;
                    trueFalseQuestionModel.TrueText = row["TrueText"] != DBNull.Value ? Convert.ToString(row["TrueText"]) : string.Empty;
                    trueFalseQuestionModel.FalseText = row["FalseText"] != DBNull.Value ? Convert.ToString(row["FalseText"]) : string.Empty;

                    trueFalseQuestionResponseModel.Data.Add(trueFalseQuestionModel);
                }
            }
            catch (Exception ex)
            {
                trueFalseQuestionResponseModel.StatusCode = 500;
                trueFalseQuestionResponseModel.Message = ex.Message;
                trueFalseQuestionResponseModel.Data = null;
            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
                conn.Close();

            }

            return trueFalseQuestionResponseModel;
        }

        public FillBlankQuestionResponseModel GetAllFillBlankQuestionsByQuizMakerID(long quizMakerID)
        {
            FillBlankQuestionResponseModel fillBlankQuestionResponseModel = new FillBlankQuestionResponseModel();
            fillBlankQuestionResponseModel.Data = new List<FillBlankQuestionDto>();
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(@"dbo.uspGetAllFillBlankQuestionsByQuizMakerID", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@QuizMakerID", quizMakerID);


                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                fillBlankQuestionResponseModel.Message = "Success";
                fillBlankQuestionResponseModel.StatusCode = 200;

                foreach (DataRow row in dataTable.Rows)
                {
                    FillBlankQuestionDto fillBlankQuestionModel = new FillBlankQuestionDto();
                    fillBlankQuestionModel.QuestionID = row["QuestionID"] != DBNull.Value ? Convert.ToInt64(row["QuestionID"].ToString()) : 0;
                    fillBlankQuestionModel.QuizMakerID = row["QuizMakerID"] != DBNull.Value ? Convert.ToInt64(row["QuizMakerID"].ToString()) : 0;
                    fillBlankQuestionModel.QuestionText = row["QuestionText"] != DBNull.Value ? Convert.ToString(row["QuestionText"]) : string.Empty;
                    fillBlankQuestionModel.AnswerText = row["AnswerText"] != DBNull.Value ? Convert.ToString(row["AnswerText"]) : string.Empty;

                    fillBlankQuestionResponseModel.Data.Add(fillBlankQuestionModel);
                }
            }
            catch (Exception ex)
            {
                fillBlankQuestionResponseModel.StatusCode = 500;
                fillBlankQuestionResponseModel.Message = ex.Message;
                fillBlankQuestionResponseModel.Data = null;
            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
                conn.Close();

            }

            return fillBlankQuestionResponseModel;
        }


    }
}
