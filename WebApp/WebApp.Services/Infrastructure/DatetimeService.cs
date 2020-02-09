using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Services.Infrastructure
{
    public class DatetimeService: IDatetimeService
    {
        public DateTimeOffset GetDatetimeNow() => DateTimeOffset.Now;
    }

    public interface IDatetimeService
    {
        DateTimeOffset GetDatetimeNow();
    }
}
