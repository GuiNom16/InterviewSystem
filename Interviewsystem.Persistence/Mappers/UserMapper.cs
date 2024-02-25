using Interviewsystem.Domain.Models;
using Interviewsystem.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Interviewsystem.Persistence.Mappers
{
    internal static class UserMapper
    {
        public static UserEntity ToUserEntity(this UserModel userModel)
        {
            return new UserEntity
            {
                UserId = userModel.UserId,
                Fullname = userModel.Fullname,
                Password = userModel.Password,
                Login = userModel.Login,
                Profile = userModel.Profile,
            };
        }

        public static UserModel ToUserModel(this UserEntity userEntity)
        {
            return new UserModel
            {
                UserId = userEntity.UserId,
                Fullname = userEntity.Fullname,
                Password = userEntity.Password,
                Login = userEntity.Login,
                Profile = userEntity.Profile,
            };
        }
    }
}
