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
    public class LessonPlannerRepository : ILessonPlannerRepository
    {
        public string GetTestString()
        {
            return "string from repository";
        }

        public LessonPlannerResponseModel GetAllLessonPlanners()
        {
            LessonPlannerResponseModel lessonPlannerResponseModel = new LessonPlannerResponseModel();
            lessonPlannerResponseModel.Data = new List<LessonPlannerDto>();
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {

                SqlCommand command = new SqlCommand(@"dbo.uspGetAllLessonPlanners", conn);
                command.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                lessonPlannerResponseModel.Message = "Success";
                lessonPlannerResponseModel.StatusCode = 200;

                foreach (DataRow row in dataTable.Rows)
                {
                    LessonPlannerDto LessonPlannerDto = new LessonPlannerDto();
                    LessonPlannerDto.LessonPlannerID = row["LessonPlannerID"] != DBNull.Value ? Convert.ToInt64(row["LessonPlannerID"].ToString()) : 0;
                    LessonPlannerDto.GradeID = row["GradeID"] != DBNull.Value ? Convert.ToInt64(row["GradeID"].ToString()) : 0;
                    LessonPlannerDto.GradeName = row["GradeName"] != DBNull.Value ? Convert.ToString(row["GradeName"]) : string.Empty;
                    LessonPlannerDto.SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt64(row["SubjectID"].ToString()) : 0;
                    LessonPlannerDto.SubjectName = row["SubjectName"] != DBNull.Value ? Convert.ToString(row["SubjectName"]) : string.Empty;
                    LessonPlannerDto.MainTopicID = row["MainTopicID"] != DBNull.Value ? Convert.ToInt64(row["MainTopicID"].ToString()) : 0;
                    LessonPlannerDto.MainTopicNumber = row["MainTopicNumber"] != DBNull.Value ? Convert.ToString(row["MainTopicNumber"]) : string.Empty;
                    LessonPlannerDto.TitleMainTopic = row["MainTopicTitle"] != DBNull.Value ? Convert.ToString(row["MainTopicTitle"]) : string.Empty;

                    LessonPlannerDto.Introduction = row["Introduction"] != DBNull.Value ? Convert.ToString(row["Introduction"]) : string.Empty;
                    LessonPlannerDto.Objectives = row["Objectives"] != DBNull.Value ? Convert.ToString(row["Objectives"]) : string.Empty;
                    LessonPlannerDto.Material = row["Material"] != DBNull.Value ? Convert.ToString(row["Material"]) : string.Empty;

                    lessonPlannerResponseModel.Data.Add(LessonPlannerDto);
                }
            }
            catch (Exception ex)
            {
                lessonPlannerResponseModel.StatusCode = 500;
                lessonPlannerResponseModel.Message = ex.Message;
                lessonPlannerResponseModel.Data = null;
            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
                conn.Close();

            }

            return lessonPlannerResponseModel;
        }

        public LessonPlannerResponseModel GetAllLessonPlannersByGradeIDandSubjectID(long gradeID, long subjectID)
        {
            LessonPlannerResponseModel lessonPlannerResponseModel = new LessonPlannerResponseModel();
            lessonPlannerResponseModel.Data = new List<LessonPlannerDto>();
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {


                SqlCommand command = new SqlCommand(@"dbo.uspGetAllLessonPlannersByGradeIDandSubjectID", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GradeID", gradeID);
                command.Parameters.AddWithValue("@SubjectID", subjectID);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                lessonPlannerResponseModel.Message = "Success";
                lessonPlannerResponseModel.StatusCode = 200;

                foreach (DataRow row in dataTable.Rows)
                {
                    LessonPlannerDto LessonPlannerDto = new LessonPlannerDto();
                    LessonPlannerDto.LessonPlannerID = row["LessonPlannerID"] != DBNull.Value ? Convert.ToInt64(row["LessonPlannerID"].ToString()) : 0;
                    LessonPlannerDto.GradeID = row["GradeID"] != DBNull.Value ? Convert.ToInt64(row["GradeID"].ToString()) : 0;
                    LessonPlannerDto.GradeName = row["GradeName"] != DBNull.Value ? Convert.ToString(row["GradeName"]) : string.Empty;
                    LessonPlannerDto.SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt64(row["SubjectID"].ToString()) : 0;
                    LessonPlannerDto.SubjectName = row["SubjectName"] != DBNull.Value ? Convert.ToString(row["SubjectName"]) : string.Empty;
                    LessonPlannerDto.MainTopicID = row["MainTopicID"] != DBNull.Value ? Convert.ToInt64(row["MainTopicID"].ToString()) : 0;
                    LessonPlannerDto.MainTopicNumber = row["MainTopicNumber"] != DBNull.Value ? Convert.ToString(row["MainTopicNumber"]) : string.Empty;
                    LessonPlannerDto.TitleMainTopic = row["MainTopicTitle"] != DBNull.Value ? Convert.ToString(row["MainTopicTitle"]) : string.Empty;

                    LessonPlannerDto.Introduction = row["Introduction"] != DBNull.Value ? Convert.ToString(row["Introduction"]) : string.Empty;
                    LessonPlannerDto.Objectives = row["Objectives"] != DBNull.Value ? Convert.ToString(row["Objectives"]) : string.Empty;
                    LessonPlannerDto.Material = row["Material"] != DBNull.Value ? Convert.ToString(row["Material"]) : string.Empty;

                    lessonPlannerResponseModel.Data.Add(LessonPlannerDto);
                }
            }
            catch (Exception ex)
            {
                lessonPlannerResponseModel.StatusCode = 500;
                lessonPlannerResponseModel.Message = ex.Message;
                lessonPlannerResponseModel.Data = null;
            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
                conn.Close();
            }

            return lessonPlannerResponseModel;
        }

        public SubTopicResponseModel GetAllSubTopicByMainTopicID(long mainTopicID)
        {
            SubTopicResponseModel subTopicResponseModel = new SubTopicResponseModel();
            subTopicResponseModel.Data = new List<SubTopicDto>();
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {

                SqlCommand command = new SqlCommand(@"dbo.uspGetAllSubTopicByMainTopicID", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@MainTopicID", mainTopicID);

                conn.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                subTopicResponseModel.Message = "Success";
                subTopicResponseModel.StatusCode = 200;

                foreach (DataRow row in dataTable.Rows)
                {
                    SubTopicDto subTopicModel = new SubTopicDto();
                    subTopicModel.SubTopicID = row["SubTopicID"] != DBNull.Value ? Convert.ToInt64(row["SubTopicID"].ToString()) : 0;
                    subTopicModel.SubTopicNumber = row["SubTopicNumber"] != DBNull.Value ? Convert.ToString(row["SubTopicNumber"]) : string.Empty;
                    subTopicModel.MainTopicNumber = row["MainTopicNumber"] != DBNull.Value ? Convert.ToString(row["MainTopicNumber"]) : string.Empty;
                    subTopicModel.SubTopicTitle = row["SubTopicTitle"] != DBNull.Value ? Convert.ToString(row["SubTopicTitle"]) : string.Empty;
                    subTopicModel.Introduction = row["Introduction"] != DBNull.Value ? Convert.ToString(row["Introduction"]) : string.Empty;
                    subTopicModel.Objectives = row["Objectives"] != DBNull.Value ? Convert.ToString(row["Objectives"]) : string.Empty;
                    subTopicModel.Material = row["Material"] != DBNull.Value ? Convert.ToString(row["Material"]) : string.Empty;
                    subTopicModel.MainTopicID = row["MainTopicID"] != DBNull.Value ? Convert.ToInt64(row["MainTopicID"].ToString()) : 0;

                    subTopicResponseModel.Data.Add(subTopicModel);
                }
            }
            catch (Exception ex)
            {
                subTopicResponseModel.StatusCode = 500;
                subTopicResponseModel.Message = ex.Message;
                subTopicResponseModel.Data = null;
            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
                conn.Close();
            }

            return subTopicResponseModel;
        }

        public MoviesResponseModel GetAllMovies()
        {
            MoviesResponseModel moviesResponseModel = new MoviesResponseModel();
            moviesResponseModel.Data = new List<MoviesDto>();
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(@"dbo.uspGetAllMovies", conn);
                command.CommandType = CommandType.StoredProcedure;

                conn.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                moviesResponseModel.Message = "Success";
                moviesResponseModel.StatusCode = 200;
                foreach (DataRow row in dataTable.Rows)
                {
                    MoviesDto movies = new MoviesDto();
                    movies.MovieID = row["MovieID"] != DBNull.Value ? Convert.ToInt64(row["MovieID"].ToString()) : 0;
                    movies.MainTopicID = row["MainTopicID"] != DBNull.Value ? Convert.ToInt64(row["MainTopicID"].ToString()) : 0;
                    movies.MainTopicNumber = row["MainTopicNumber"] != DBNull.Value ? Convert.ToString(row["MainTopicNumber"]) : string.Empty;
                    movies.MovieDescription = row["MovieDescription"] != DBNull.Value ? Convert.ToString(row["MovieDescription"].ToString()) : string.Empty;

                    moviesResponseModel.Data.Add(movies);
                }
            }
            catch (Exception ex)
            {
                moviesResponseModel.StatusCode = 500;
                moviesResponseModel.Message = ex.Message;
                moviesResponseModel.Data = null;
            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
                conn.Close();
            }

            return moviesResponseModel;
        }

        public DocumentariesResponseModel GetAllDocumentaries()
        {
            DocumentariesResponseModel documentariesResponseModel = new DocumentariesResponseModel();
            documentariesResponseModel.Data = new List<DocumentariesDto>();
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(@"dbo.uspGetAllDocumentaries", conn);
                command.CommandType = CommandType.StoredProcedure;

                conn.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                documentariesResponseModel.Message = "Success";
                documentariesResponseModel.StatusCode = 200;
                foreach (DataRow row in dataTable.Rows)
                {
                    DocumentariesDto documentaries = new DocumentariesDto();
                    documentaries.DocumentaryID = row["DocumentaryID"] != DBNull.Value ? Convert.ToInt64(row["DocumentaryID"].ToString()) : 0;
                    documentaries.MainTopicID = row["MainTopicID"] != DBNull.Value ? Convert.ToInt64(row["MainTopicID"].ToString()) : 0;
                    documentaries.MainTopicNumber = row["MainTopicNumber"] != DBNull.Value ? Convert.ToString(row["MainTopicNumber"]) : string.Empty;
                    documentaries.DocumentaryDescription = row["DocumentaryDescription"] != DBNull.Value ? Convert.ToString(row["DocumentaryDescription"].ToString()) : string.Empty;

                    documentariesResponseModel.Data.Add(documentaries);
                }
            }
            catch (Exception ex)
            {
                documentariesResponseModel.StatusCode = 500;
                documentariesResponseModel.Message = ex.Message;
                documentariesResponseModel.Data = null;
            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
                conn.Close();
            }

            return documentariesResponseModel;
        }

        public GamesResponseModel GetAllGames()
        {
            GamesResponseModel gamesResponseModel = new GamesResponseModel();
            gamesResponseModel.Data = new List<GamesDto>();
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(@"dbo.uspGetAllGames", conn);
                command.CommandType = CommandType.StoredProcedure;

                conn.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                gamesResponseModel.Message = "Success";
                gamesResponseModel.StatusCode = 200;
                foreach (DataRow row in dataTable.Rows)
                {
                    GamesDto gamesModel = new GamesDto();
                    gamesModel.GameID = row["GameID"] != DBNull.Value ? Convert.ToInt64(row["GameID"].ToString()) : 0;
                    gamesModel.MainTopicID = row["MainTopicID"] != DBNull.Value ? Convert.ToInt64(row["MainTopicID"].ToString()) : 0;
                    gamesModel.MainTopicNumber = row["MainTopicNumber"] != DBNull.Value ? Convert.ToString(row["MainTopicNumber"]) : string.Empty;
                    gamesModel.GameDescription = row["GameDescription"] != DBNull.Value ? Convert.ToString(row["GameDescription"].ToString()) : string.Empty;

                    gamesResponseModel.Data.Add(gamesModel);
                }
            }
            catch (Exception ex)
            {
                gamesResponseModel.StatusCode = 500;
                gamesResponseModel.Message = ex.Message;
                gamesResponseModel.Data = null;
            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
                conn.Close();
            }

            return gamesResponseModel;
        }

        public BooksResponseModel GetAllBooks()
        {
            BooksResponseModel booksResponseModel = new BooksResponseModel();
            booksResponseModel.Data = new List<BooksDto>();
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(@"dbo.uspGetAllBooks", conn);
                command.CommandType = CommandType.StoredProcedure;

                conn.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                booksResponseModel.Message = "Success";
                booksResponseModel.StatusCode = 200;
                foreach (DataRow row in dataTable.Rows)
                {
                    BooksDto booksModel = new BooksDto();
                    booksModel.BookID = row["BookID"] != DBNull.Value ? Convert.ToInt64(row["BookID"].ToString()) : 0;
                    booksModel.MainTopicID = row["MainTopicID"] != DBNull.Value ? Convert.ToInt64(row["MainTopicID"].ToString()) : 0;
                    booksModel.MainTopicNumber = row["MainTopicNumber"] != DBNull.Value ? Convert.ToString(row["MainTopicNumber"]) : string.Empty;
                    booksModel.BookDescription = row["BookDescription"] != DBNull.Value ? Convert.ToString(row["BookDescription"].ToString()) : string.Empty;

                    booksResponseModel.Data.Add(booksModel);
                }
            }
            catch (Exception ex)
            {
                booksResponseModel.StatusCode = 500;
                booksResponseModel.Message = ex.Message;
                booksResponseModel.Data = null;
            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
                conn.Close();
            }

            return booksResponseModel;
        }

    }
}
