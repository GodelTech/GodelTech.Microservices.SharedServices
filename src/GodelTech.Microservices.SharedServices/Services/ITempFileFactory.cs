namespace GodelTech.Microservices.SharedServices.Services
{
    public interface ITempFileFactory
    {
        ITempFile Create(string tempFolder);
    }
}