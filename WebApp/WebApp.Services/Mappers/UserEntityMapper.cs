using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Data;
using WebApp.Dtos;

namespace WebApp.Services.Mappers
{
    public static class UserEntityMapper
    {
        public static UserDto MapToDto(this User user)
        {
            var userDto = new UserDto
            {
                Id = user.Id,
                LastModified = user.LastModified,
                Name = user.Name
            };
            return userDto;
        }
    }
}
