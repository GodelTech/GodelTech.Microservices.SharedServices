using System;

namespace GodelTech.Microservices.SharedServices.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetUtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
