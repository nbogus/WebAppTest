using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset LastModified { get; set; }
    }
}
