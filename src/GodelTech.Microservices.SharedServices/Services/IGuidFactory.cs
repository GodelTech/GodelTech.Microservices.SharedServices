using System;

namespace GodelTech.Microservices.SharedServices.Services
{
    public interface IGuidFactory
    {
        Guid New();
        string NewAsString();
    }
}