using System;

namespace GodelTech.Microservices.SharedServices.Services
{
    public class GuidFactory : IGuidFactory
    {
        public Guid New()
        {
            return Guid.NewGuid();
        }

        public string NewAsString()
        {
            return New().ToString();
        }
    }
}