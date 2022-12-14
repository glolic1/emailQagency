using QAgencyTask.Models;

namespace QAgencyTask.Services.Interfaces
{
    public interface IEmailService
    {
        public Task<bool> AddEmailAsync(Email email);
        public Task<List<Email>> GetAllEmailsAsync();
        public Task<List<Importance>> GetAllImportanceLevelsAsync();
    }
}
