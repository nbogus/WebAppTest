using System;

namespace WebApp.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset LastModified { get; set; }
    }
}
