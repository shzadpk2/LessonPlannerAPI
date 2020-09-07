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
    public class SubjectRespository : ISubjectRepository
    {
        public SubjectResponseModel GetAllSubjects()
        {
            SubjectResponseModel subjectResponseModel = new SubjectResponseModel();
            subjectResponseModel.Data = new List<SubjectDto>();
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(@"dbo.uspGetAllSubjects", conn);
                command.CommandType = CommandType.StoredProcedure;

                conn.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    SubjectDto subjectDto = new SubjectDto();
                    subjectDto.SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt32(row["SubjectID"].ToString()) : 0;
                    subjectDto.SubjectName = row["SubjectName"] != DBNull.Value ? Convert.ToString(row["SubjectName"]) : string.Empty;
                    subjectDto.GradeID = row["GradeID"] != DBNull.Value ? Convert.ToInt32(row["GradeID"].ToString()) : 0;
                    subjectDto.CreatedBy = row["CreatedBy"] != DBNull.Value ? Convert.ToInt32(row["CreatedBy"].ToString()) : 0;
                    subjectDto.CreatedOn = row["CreatedOn"] != DBNull.Value ? Convert.ToDateTime(row["CreatedOn"].ToString()) : DateTime.MinValue;
                    subjectDto.ModifiedBy = row["ModifiedBy"] != DBNull.Value ? Convert.ToInt32(row["ModifiedBy"].ToString()) : 0;
                    subjectDto.ModifiedOn = row["ModifiedOn"] != DBNull.Value ? Convert.ToDateTime(row["ModifiedOn"].ToString()) : DateTime.MinValue;
                    subjectResponseModel.Data.Add(subjectDto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
                conn.Close();
            }

            return subjectResponseModel;
        }

        public SubjectResponseModel GetAllSubjectsByGradeID(long gradeID)
        {
            SubjectResponseModel subjectResponseModel = new SubjectResponseModel();
            subjectResponseModel.Data = new List<SubjectDto>();
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {

                SqlCommand command = new SqlCommand(@"dbo.uspGetAllSubjectsByGradeID", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GradeID", gradeID);

                conn.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    SubjectDto subjectDto = new SubjectDto();
                    subjectDto.SubjectID = row["SubjectID"] != DBNull.Value ? Convert.ToInt32(row["SubjectID"].ToString()) : 0;
                    subjectDto.SubjectName = row["SubjectName"] != DBNull.Value ? Convert.ToString(row["SubjectName"]) : string.Empty;
                    subjectDto.GradeID = row["GradeID"] != DBNull.Value ? Convert.ToInt32(row["GradeID"].ToString()) : 0;
                    subjectDto.CreatedBy = row["CreatedBy"] != DBNull.Value ? Convert.ToInt32(row["CreatedBy"].ToString()) : 0;
                    subjectDto.CreatedOn = row["CreatedOn"] != DBNull.Value ? Convert.ToDateTime(row["CreatedOn"].ToString()) : DateTime.MinValue;
                    subjectDto.ModifiedBy = row["ModifiedBy"] != DBNull.Value ? Convert.ToInt32(row["ModifiedBy"].ToString()) : 0;
                    subjectDto.ModifiedOn = row["ModifiedOn"] != DBNull.Value ? Convert.ToDateTime(row["ModifiedOn"].ToString()) : DateTime.MinValue;
                    subjectResponseModel.Data.Add(subjectDto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
                conn.Close();
            }

            return subjectResponseModel;
        }

    }
}
