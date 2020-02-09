using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WebApp.Data;
using WebApp.Dtos;

namespace WebApp.Services.Mappers
{
    public static class UserDtoMapper
    {
        public static User MapToEntity(this UserDto user)
        {
            var userEntity = new User
            {
                Id = user.Id,
                LastModified = user.LastModified,
                Name = user.Name
            };
            return userEntity;
        }
    }
}
