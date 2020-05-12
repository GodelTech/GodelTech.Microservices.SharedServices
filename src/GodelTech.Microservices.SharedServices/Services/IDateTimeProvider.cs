using System;

namespace GodelTech.Microservices.SharedServices.Services
{
    public interface IDateTimeProvider
    {
        DateTime GetUtcNow();
    }
}