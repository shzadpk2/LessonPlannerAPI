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
    public class UserRepository : IUserRepository
    {
        public UserResponseModel GetAllUsers()
        {
            UserResponseModel userResponseModel = new UserResponseModel();
            userResponseModel.Data = new List<UserDto>();
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

                SqlCommand command = new SqlCommand(@"dbo.uspGetAllUsers", conn);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                userResponseModel.Message = "Success";
                userResponseModel.StatusCode = 200;

                foreach (DataRow row in dataTable.Rows)
                {
                    UserDto userDto = new UserDto();
                    userDto.UserID = row["UserID"] != DBNull.Value ? Convert.ToInt64(row["UserID"].ToString()) : 0;
                    userDto.FirstName = row["FirstName"] != DBNull.Value ? Convert.ToString(row["FirstName"]) : string.Empty;
                    userDto.LastName = row["LastName"] != DBNull.Value ? Convert.ToString(row["LastName"]) : string.Empty;
                    userDto.Gender = row["Gender"] != DBNull.Value ? Convert.ToString(row["Gender"].ToString()) : string.Empty;
                    userDto.DOB = row["DOB"] != DBNull.Value ? Convert.ToDateTime(row["DOB"].ToString()) : DateTime.MinValue;
                    userDto.Phone = row["Phone"] != DBNull.Value ? Convert.ToString(row["Phone"]) : string.Empty;
                    userDto.Email = row["Email"] != DBNull.Value ? Convert.ToString(row["Email"]) : string.Empty;
                    userDto.Country = row["Country"] != DBNull.Value ? Convert.ToString(row["Country"]) : string.Empty;
                    userDto.City = row["City"] != DBNull.Value ? Convert.ToString(row["City"]) : string.Empty;
                    userDto.Address = row["Address"] != DBNull.Value ? Convert.ToString(row["Address"]) : string.Empty;
                    userDto.IsPhoneVerified = row["IsPhoneVerified"] != DBNull.Value ? Convert.ToBoolean(row["IsPhoneVerified"].ToString()) : false;
                    userDto.IsEmailVerified = row["IsEmailVerified"] != DBNull.Value ? Convert.ToBoolean(row["IsEmailVerified"].ToString()) : false;
                    userDto.CreatedBy = row["CreatedBy"] != DBNull.Value ? Convert.ToInt64(row["CreatedBy"].ToString()) : 0;
                    userDto.CreatedOn = row["CreatedOn"] != DBNull.Value ? Convert.ToDateTime(row["CreatedOn"].ToString()) : DateTime.MinValue;
                    userDto.ModifiedBy = row["ModifiedBy"] != DBNull.Value ? Convert.ToInt32(row["ModifiedBy"].ToString()) : 0;
                    userDto.ModifiedOn = row["ModifiedOn"] != DBNull.Value ? Convert.ToDateTime(row["ModifiedOn"].ToString()) : DateTime.MinValue;
                    userResponseModel.Data.Add(userDto);
                }
            }
            catch (Exception ex)
            {
                userResponseModel.Message = ex.Message;
                userResponseModel.StatusCode = 500;
                userResponseModel.Data = null;

            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
            }

            return userResponseModel;
        }
        public UserResponseModel GetUserByUserID(long userID)
        {
            UserResponseModel userResponseModel = new UserResponseModel();
            userResponseModel.Data = new List<UserDto>();
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

                SqlCommand command = new SqlCommand(@"dbo.GetUserByUserID", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", userID);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                userResponseModel.Message = "Success";
                userResponseModel.StatusCode = 200;

                foreach (DataRow row in dataTable.Rows)
                {
                    UserDto userDto = new UserDto();
                    userDto.UserID = row["UserID"] != DBNull.Value ? Convert.ToInt64(row["UserID"].ToString()) : 0;
                    userDto.FirstName = row["FirstName"] != DBNull.Value ? Convert.ToString(row["FirstName"]) : string.Empty;
                    userDto.LastName = row["LastName"] != DBNull.Value ? Convert.ToString(row["LastName"]) : string.Empty;
                    userDto.Gender = row["Gender"] != DBNull.Value ? Convert.ToString(row["Gender"].ToString()) : string.Empty;
                    userDto.DOB = row["DOB"] != DBNull.Value ? Convert.ToDateTime(row["DOB"].ToString()) : DateTime.MinValue;
                    userDto.Phone = row["Phone"] != DBNull.Value ? Convert.ToString(row["Phone"]) : string.Empty;
                    userDto.Email = row["Email"] != DBNull.Value ? Convert.ToString(row["Email"]) : string.Empty;
                    userDto.Country = row["Country"] != DBNull.Value ? Convert.ToString(row["Country"]) : string.Empty;
                    userDto.City = row["City"] != DBNull.Value ? Convert.ToString(row["City"]) : string.Empty;
                    userDto.Address = row["Address"] != DBNull.Value ? Convert.ToString(row["Address"]) : string.Empty;
                    userDto.IsPhoneVerified = row["IsPhoneVerified"] != DBNull.Value ? Convert.ToBoolean(row["IsPhoneVerified"].ToString()) : false;
                    userDto.IsEmailVerified = row["IsEmailVerified"] != DBNull.Value ? Convert.ToBoolean(row["IsEmailVerified"].ToString()) : false;
                    userDto.CreatedBy = row["CreatedBy"] != DBNull.Value ? Convert.ToInt64(row["CreatedBy"].ToString()) : 0;
                    userDto.CreatedOn = row["CreatedOn"] != DBNull.Value ? Convert.ToDateTime(row["CreatedOn"].ToString()) : DateTime.MinValue;
                    userDto.ModifiedBy = row["ModifiedBy"] != DBNull.Value ? Convert.ToInt32(row["ModifiedBy"].ToString()) : 0;
                    userDto.ModifiedOn = row["ModifiedOn"] != DBNull.Value ? Convert.ToDateTime(row["ModifiedOn"].ToString()) : DateTime.MinValue;
                    userResponseModel.Data.Add(userDto);
                }
            }
            catch (Exception ex)
            {
                userResponseModel.Message = ex.Message;
                userResponseModel.StatusCode = 500;
                userResponseModel.Data = null;

            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
            }

            return userResponseModel;
        }

        public UserResponseModel GetUserByUserEmail(string email)
        {
            UserResponseModel userResponseModel = new UserResponseModel();
            userResponseModel.Data = new List<UserDto>();
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

                SqlCommand command = new SqlCommand(@"dbo.GetUserByUserEmail", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserEmail", email);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);

                userResponseModel.Message = "Success";
                userResponseModel.StatusCode = 200;

                foreach (DataRow row in dataTable.Rows)
                {
                    UserDto userDto = new UserDto();
                    userDto.UserID = row["UserID"] != DBNull.Value ? Convert.ToInt64(row["UserID"].ToString()) : 0;
                    userDto.FirstName = row["FirstName"] != DBNull.Value ? Convert.ToString(row["FirstName"]) : string.Empty;
                    userDto.LastName = row["LastName"] != DBNull.Value ? Convert.ToString(row["LastName"]) : string.Empty;
                    userDto.Gender = row["Gender"] != DBNull.Value ? Convert.ToString(row["Gender"].ToString()) : string.Empty;
                    userDto.DOB = row["DOB"] != DBNull.Value ? Convert.ToDateTime(row["DOB"].ToString()) : DateTime.MinValue;
                    userDto.Phone = row["Phone"] != DBNull.Value ? Convert.ToString(row["Phone"]) : string.Empty;
                    userDto.Email = row["Email"] != DBNull.Value ? Convert.ToString(row["Email"]) : string.Empty;
                    userDto.Country = row["Country"] != DBNull.Value ? Convert.ToString(row["Country"]) : string.Empty;
                    userDto.City = row["City"] != DBNull.Value ? Convert.ToString(row["City"]) : string.Empty;
                    userDto.Address = row["Address"] != DBNull.Value ? Convert.ToString(row["Address"]) : string.Empty;
                    userDto.IsPhoneVerified = row["IsPhoneVerified"] != DBNull.Value ? Convert.ToBoolean(row["IsPhoneVerified"].ToString()) : false;
                    userDto.IsEmailVerified = row["IsEmailVerified"] != DBNull.Value ? Convert.ToBoolean(row["IsEmailVerified"].ToString()) : false;
                    userDto.CreatedBy = row["CreatedBy"] != DBNull.Value ? Convert.ToInt64(row["CreatedBy"].ToString()) : 0;
                    userDto.CreatedOn = row["CreatedOn"] != DBNull.Value ? Convert.ToDateTime(row["CreatedOn"].ToString()) : DateTime.MinValue;
                    userDto.ModifiedBy = row["ModifiedBy"] != DBNull.Value ? Convert.ToInt32(row["ModifiedBy"].ToString()) : 0;
                    userDto.ModifiedOn = row["ModifiedOn"] != DBNull.Value ? Convert.ToDateTime(row["ModifiedOn"].ToString()) : DateTime.MinValue;
                    userResponseModel.Data.Add(userDto);
                }
            }
            catch (Exception ex)
            {
                userResponseModel.Message = ex.Message;
                userResponseModel.StatusCode = 500;
                userResponseModel.Data = null;

            }
            finally
            {

                dataTable.Clear();
                dataTable = null;
            }

            return userResponseModel;
        }

        public SignUpResponseModel SignUp(DataTable userDataTable, DataTable userEducationDataTable, DataTable userExperienceDataTable, DataTable userGuardianDataTable)
        {
            SignUpResponseModel signUpResponseModel = new SignUpResponseModel();
            DataTable dataTable = new DataTable();

            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(@"dbo.uspSignUpSaveUser", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserSigupUDT", userDataTable);
                command.Parameters.AddWithValue("@UserExperienceUDT", userExperienceDataTable);
                command.Parameters.AddWithValue("@UserEducationUDT", userEducationDataTable);
                command.Parameters.AddWithValue("@UserGuardianUDT", userGuardianDataTable);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    signUpResponseModel.UserID = row["UserID"] != DBNull.Value ? Convert.ToInt64(row["UserID"].ToString()) : 0;
                    signUpResponseModel.ClassCode = row["ClassCode"] != DBNull.Value ? Convert.ToString(row["ClassCode"]) : string.Empty;
                    
                }

                signUpResponseModel.Message = "Created";
                signUpResponseModel.StatusCode = 201;
            }
            catch (Exception ex)
            {
                signUpResponseModel.UserID = 0;
                signUpResponseModel.ClassCode = "0";
                signUpResponseModel.Message = "Internal Server Error";
                signUpResponseModel.StatusCode = 500;
            }
            finally
            {
                conn.Close();
            }
            return signUpResponseModel;

        }

        public void SaveUserEmailVerificationCode(long userID, string emailVerificationCode)
        {

            SqlConnection conn = new SqlConnection(DbHelper.DbConnectionString);

            try
            {
                SqlCommand command = new SqlCommand(@"dbo.uspSaveUserEmailVerificationCode", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@EmailVerificationCode", emailVerificationCode);

                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                conn.Close();
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
