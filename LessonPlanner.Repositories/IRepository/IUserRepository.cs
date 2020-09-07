using LessonPlanner.Common.ResponseModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LessonPlanner.Repositories.IRepository
{
    public interface IUserRepository
    {
        UserResponseModel GetAllUsers();
        UserResponseModel GetUserByUserID(long userID);
        UserResponseModel GetUserByUserEmail(string email);
        SignUpResponseModel SignUp(DataTable userDataTable, DataTable userEducationDataTable, DataTable userExperienceDataTable, DataTable userGuardianDataTable);
        void SaveUserEmailVerificationCode(long userID, string emailVerificationCode);

    }
}
