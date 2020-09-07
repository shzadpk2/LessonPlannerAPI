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
    public class GradeRepository : IGradeRepository
    {
        public GradeResponseModel GetAllGrades()
        {
            GradeResponseModel gradeResponseModel = new GradeResponseModel();
            gradeResponseModel.Data = new List<GradeDto>();
            DataTable dataTable = new DataTable();
            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {

                SqlCommand command = new SqlCommand(@"dbo.uspGetAllGrades", conn);
                command.CommandType = CommandType.StoredProcedure;


                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                gradeResponseModel.Message = "Success";
                gradeResponseModel.StatusCode = 200;

                foreach (DataRow row in dataTable.Rows)
                {
                    GradeDto gradeDto = new GradeDto();
                    gradeDto.GradeID = row["GradeID"] != DBNull.Value ? Convert.ToInt32(row["GradeID"].ToString()) : 0;
                    gradeDto.GradeName = row["GradeName"] != DBNull.Value ? Convert.ToString(row["GradeName"]) : string.Empty;

                    gradeResponseModel.Data.Add(gradeDto);
                }
            }
            catch (Exception ex)
            {
                gradeResponseModel.StatusCode = 500;
                gradeResponseModel.Message = ex.Message;
                gradeResponseModel.Data = null;
            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
                conn.Close();
            }

            return gradeResponseModel;
        }
    }
}
