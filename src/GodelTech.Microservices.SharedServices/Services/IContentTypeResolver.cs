namespace GodelTech.Microservices.SharedServices.Services
{
    public interface IContentTypeResolver
    {
        string GetByFilePath(string filePath);
    }
}
