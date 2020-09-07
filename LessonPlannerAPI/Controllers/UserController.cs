using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using LessonPlanner.Assemblers;
using LessonPlanner.Common;
using LessonPlanner.Common.ResponseModel;
using LessonPlanner.Repositories.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LessonPlannerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserRepository _userRepository;
        private IConfiguration _configuration;
        public UserController(ILogger<UserController> logger, IConfiguration iConfig, IUserRepository userRepository)
        {
            _logger = logger;
            _configuration = iConfig;
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<ActionResult<UserResponseModel>> GetAllUsers()
        {
            UserResponseModel userResponseModel = new UserResponseModel();

            userResponseModel = _userRepository.GetAllUsers();

            return Ok(userResponseModel);
        }

        [HttpGet]
        [Route("GetUserByUserID")]
        public async Task<ActionResult<UserResponseModel>> GetUserByUserID(long userID)
        {
            UserResponseModel userResponseModel = new UserResponseModel();

            userResponseModel = _userRepository.GetUserByUserID(userID);

            return Ok(userResponseModel);
        }

        [HttpGet]
        [Route("GetUserByUserEmail")]
        public async Task<ActionResult<UserResponseModel>> GetUserByUserEmail(string email)
        {
            UserResponseModel userResponseModel = new UserResponseModel();

            userResponseModel = _userRepository.GetUserByUserEmail(email);

            return Ok(userResponseModel);
        }

        [HttpPost]
        [Route("SignUp")]
        public async Task<ActionResult<long>> SignUp(UserDto userDto)
        {
            SignUpResponseModel signUpResponseModel = new SignUpResponseModel();


            if (userDto != null)
            {
                //User Already Exists
                UserResponseModel userResponseModel = _userRepository.GetUserByUserEmail(userDto.Email);
                if (userResponseModel != null && userResponseModel.Data != null && userResponseModel.Data.Count > 0)
                {
                    signUpResponseModel.StatusCode = 409;
                    signUpResponseModel.Message = "User Already Exists!";
                    signUpResponseModel.UserID = 0;
                    signUpResponseModel.ClassCode = "0";

                }
                else
                {
                    DataTable userDataTable = TranslateUserDtoToDataTable(userDto);
                    DataTable userEducationDataTable = TranslateUserEducationDtoToDataTable(userDto.userEducation);
                    DataTable userExperienceDataTable = TranslateUserExperienceDtoToDataTable(userDto.userExperience);
                    DataTable userGuardianDataTable = TranslateUserGuardianDtoToDataTable(userDto.userGuardian);
                    signUpResponseModel = _userRepository.SignUp(userDataTable, userEducationDataTable, userExperienceDataTable, userGuardianDataTable);
                }

            }
            signUpResponseModel.ClassCode = "0";
            return Ok(signUpResponseModel);
        }

        [HttpPost]
        [Route("SendUserVerificationEmail")]
        public async Task<ActionResult<SendUserVerificationEmailResponse>> SendUserVerificationEmail(long userID, string userEmail)
        {
            SendUserVerificationEmailResponse sendUserVerificationEmailResponse = new SendUserVerificationEmailResponse();

            bool isEmailSent = false;

            if (userID > 0)
            {
                string userEmailToSend = string.Empty;
                string emailVerificationCode = Guid.NewGuid().ToString() + Guid.NewGuid().ToString();
                string currentHostUrl = _configuration.GetValue<string>("ApiUrls:ApiBaseUrl");
                string linkToSendInEmail = currentHostUrl + "/VerifyEmail?code=" + emailVerificationCode; 

                if (!string.IsNullOrEmpty(userEmail))
                {
                    userEmailToSend = userEmail;
                }
                else
                {
                    UserResponseModel userResponseModel = _userRepository.GetUserByUserID(userID);
                    if (userResponseModel != null && userResponseModel.Data != null && userResponseModel.Data.Count > 0)
                    {
                        userEmailToSend = userResponseModel.Data.Select(x => x.Email).FirstOrDefault();

                    }
                }

                string _Subject = "Registertion Email Verification Code";
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Your Email Verification Code is: </br></br><b>" + linkToSendInEmail + " </b>");
                stringBuilder.Append("</br></br>Please click this link or Copy/Paste it in url");

                string _toEmail = userEmailToSend;

                isEmailSent = EmailHelper.SendEmailToUser(_Subject, stringBuilder.ToString(), _toEmail);

                if (isEmailSent)
                {
                    _userRepository.SaveUserEmailVerificationCode(userID, emailVerificationCode);
                    sendUserVerificationEmailResponse.StatusCode = 200;
                    sendUserVerificationEmailResponse.Message = "Success";
                    sendUserVerificationEmailResponse.isEmailSent = true;
                }
                else
                {
                    sendUserVerificationEmailResponse.StatusCode = 500;
                    sendUserVerificationEmailResponse.Message = "Internal Server Error";
                    sendUserVerificationEmailResponse.isEmailSent = false;
                }

            }
            else
            {
                sendUserVerificationEmailResponse.StatusCode = 500;
                sendUserVerificationEmailResponse.Message = "Internal Server Error";
                sendUserVerificationEmailResponse.isEmailSent = false;
            }

            return Ok(sendUserVerificationEmailResponse);
        }

        [HttpPost]
        [Route("SendUserVerificationEmail")]
        public async Task<ActionResult<SendUserVerificationEmailResponse>> SendUserVerificationEmail(long userID, string userEmail)
        {
            SendUserVerificationEmailResponse sendUserVerificationEmailResponse = new SendUserVerificationEmailResponse();

            bool isEmailSent = false;

            if (userID > 0)
            {
                string userEmailToSend = string.Empty;
                string emailVerificationCode = Guid.NewGuid().ToString() + Guid.NewGuid().ToString();
                string currentHostUrl = _configuration.GetValue<string>("ApiUrls:ApiBaseUrl");
                string linkToSendInEmail = currentHostUrl + "/VerifyEmail?Code=" + emailVerificationCode;

                if (!string.IsNullOrEmpty(userEmail))
                {
                    userEmailToSend = userEmail;
                }
                else
                {
                    UserResponseModel userResponseModel = _userRepository.GetUserByUserID(userID);
                    if (userResponseModel != null && userResponseModel.Data != null && userResponseModel.Data.Count > 0)
                    {
                        userEmailToSend = userResponseModel.Data.Select(x => x.Email).FirstOrDefault();

                    }
                }

                string _Subject = "Registertion Email Verification Code";
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Your Email Verification Code is: </br></br><b>" + linkToSendInEmail + " </b>");
                stringBuilder.Append("</br></br>Please click this link or Copy/Paste it in url");

                string _toEmail = userEmailToSend;

                isEmailSent = EmailHelper.SendEmailToUser(_Subject, stringBuilder.ToString(), _toEmail);

                if (isEmailSent)
                {
                    _userRepository.SaveUserEmailVerificationCode(userID, emailVerificationCode);
                    sendUserVerificationEmailResponse.StatusCode = 200;
                    sendUserVerificationEmailResponse.Message = "Success";
                    sendUserVerificationEmailResponse.isEmailSent = true;
                }
                else
                {
                    sendUserVerificationEmailResponse.StatusCode = 500;
                    sendUserVerificationEmailResponse.Message = "Internal Server Error";
                    sendUserVerificationEmailResponse.isEmailSent = false;
                }

            }
            else
            {
                sendUserVerificationEmailResponse.StatusCode = 500;
                sendUserVerificationEmailResponse.Message = "Internal Server Error";
                sendUserVerificationEmailResponse.isEmailSent = false;
            }

            return Ok(sendUserVerificationEmailResponse);
        }


        private DataTable TranslateUserDtoToDataTable(UserDto userDto)
        {
            DataTable dataTable = new DataTable();

            dataTable.Clear();

            dataTable.Columns.Add("UserID", typeof(long));
            dataTable.Columns.Add("UserType", typeof(string));
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Gender", typeof(string));
            dataTable.Columns.Add("DOB", typeof(DateTime));
            dataTable.Columns.Add("Phone", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Country", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("TeacherClassCode", typeof(string));
            dataTable.Columns.Add("CreatedBy", typeof(int));
            dataTable.Columns.Add("CreatedOn", typeof(DateTime));
            dataTable.Columns.Add("ModifiedBy", typeof(int));
            dataTable.Columns.Add("ModifiedOn", typeof(DateTime));


            if (userDto != null)
            {
                DataRow dr = dataTable.NewRow();

                dr["UserID"] = 0;
                dr["UserType"] = userDto.UserType;
                dr["FirstName"] = userDto.FirstName;
                dr["LastName"] = userDto.LastName;
                dr["Gender"] = userDto.Gender;
                if (userDto.DOB != DateTime.MinValue)
                {
                    dr["DOB"] = userDto.DOB;
                }
                dr["Phone"] = userDto.Phone;
                dr["Email"] = userDto.Email;
                dr["Country"] = userDto.Country;
                dr["City"] = userDto.City;
                dr["Address"] = userDto.Address;
                dr["TeacherClassCode"] = string.IsNullOrEmpty(userDto.TeacherClassCode) ? "" : userDto.TeacherClassCode;
                dr["CreatedBy"] = 1;
                dr["CreatedOn"] = DateTime.Now;
                dr["ModifiedBy"] = 1;
                dr["ModifiedOn"] = DateTime.Now;

                dataTable.Rows.Add(dr);
            }

            return dataTable;
        }
        private DataTable TranslateUserEducationDtoToDataTable(List<UserEducationDto> userEducationDtos)
        {
            DataTable dataTable = new DataTable();
            dataTable.Clear();
            //dataTable.Columns.Add("UserEducationID", typeof(long));

            dataTable.Columns.Add("UserEducation", typeof(string));
            dataTable.Columns.Add("UserID", typeof(long));

            dataTable.Columns.Add("CreatedOn", typeof(DateTime));

            dataTable.Columns.Add("CreatedBy", typeof(int));
            dataTable.Columns.Add("ModifiedOn", typeof(DateTime));

            dataTable.Columns.Add("ModifiedBy", typeof(int));

            if (userEducationDtos != null && userEducationDtos.Count > 0)
            {
                foreach (UserEducationDto item in userEducationDtos)
                {
                    DataRow dr = dataTable.NewRow();

                    //dr["UserEducationID"] = 0;
                    dr["UserEducation"] = item.UserEducation;
                    dr["UserID"] = 0;
                    dr["CreatedBy"] = 1;
                    dr["CreatedOn"] = DateTime.Now;
                    dr["ModifiedBy"] = 1;
                    dr["ModifiedOn"] = DateTime.Now;

                    dataTable.Rows.Add(dr);
                }
            }

            return dataTable;
        }
        private DataTable TranslateUserExperienceDtoToDataTable(List<UserExperienceDto> userExperienceDtos)
        {
            DataTable dataTable = new DataTable();
            dataTable.Clear();
            //dataTable.Columns.Add("UserExperienceID", typeof(long));
            dataTable.Columns.Add("UserExperience", typeof(string));
            dataTable.Columns.Add("UserID", typeof(long));
            dataTable.Columns.Add("CreatedOn", typeof(DateTime));

            dataTable.Columns.Add("CreatedBy", typeof(int));
            dataTable.Columns.Add("ModifiedOn", typeof(DateTime));

            dataTable.Columns.Add("ModifiedBy", typeof(int));

            if (userExperienceDtos != null && userExperienceDtos.Count > 0)
            {
                foreach (UserExperienceDto item in userExperienceDtos)
                {
                    DataRow dr = dataTable.NewRow();

                    //dr["UserExperienceID"] = 0;
                    dr["UserExperience"] = item.UserExperience;
                    dr["UserID"] = 0;
                    dr["CreatedBy"] = 1;
                    dr["CreatedOn"] = DateTime.Now;
                    dr["ModifiedBy"] = 1;
                    dr["ModifiedOn"] = DateTime.Now;

                    dataTable.Rows.Add(dr);
                }
            }

            return dataTable;
        }
        private DataTable TranslateUserGuardianDtoToDataTable(List<UserGuardianDto> userGuardianDtos)
        {
            DataTable dataTable = new DataTable();
            dataTable.Clear();
            //dataTable.Columns.Add("UserGuardianID", typeof(long));
            dataTable.Columns.Add("UserID", typeof(string));
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("Relationship", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Gender", typeof(string));
            dataTable.Columns.Add("DOB", typeof(DateTime));
            dataTable.Columns.Add("Phone", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Country", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("CreatedOn", typeof(DateTime));
            dataTable.Columns.Add("CreatedBy", typeof(int));
            dataTable.Columns.Add("ModifiedOn", typeof(DateTime));
            dataTable.Columns.Add("ModifiedBy", typeof(int));

            if (userGuardianDtos != null && userGuardianDtos.Count > 0)
            {
                foreach (UserGuardianDto item in userGuardianDtos)
                {
                    DataRow dr = dataTable.NewRow();

                    dr["UserID"] = 0;
                    dr["FirstName"] = item.FirstName;
                    dr["Relationship"] = item.Relationship;
                    dr["LastName"] = item.LastName;
                    dr["Gender"] = item.Gender;
                    if (item.DOB != DateTime.MinValue)
                    {
                        dr["DOB"] = item.DOB;
                    }
                    dr["Phone"] = item.Phone;
                    dr["Email"] = item.Email;
                    dr["Country"] = item.Country;
                    dr["City"] = item.City;
                    dr["Address"] = item.Address;
                    dr["CreatedBy"] = 1;
                    dr["CreatedOn"] = DateTime.Now;
                    dr["ModifiedBy"] = 1;
                    dr["ModifiedOn"] = DateTime.Now;

                    dataTable.Rows.Add(dr);
                }
            }

            return dataTable;
        }

    }

}
