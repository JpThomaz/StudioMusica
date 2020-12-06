using Microsoft.AspNetCore.Http;

namespace StudioMusica.Services
{
    public interface IFileService
    {
        string Upload(IFormFile file);
    }
}