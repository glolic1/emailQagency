using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QAgencyTask.Models;
using QAgencyTask.Services.Interfaces;

namespace QAgencyTask.Services
{
    public class EmailService : IEmailService
    {
        private readonly QagencyTaskContext _qagencyTaskContext;

        public EmailService(QagencyTaskContext qagencyTaskContext, IMapper mapper)
        {
            _qagencyTaskContext = qagencyTaskContext;
        }
        public async Task<bool> AddEmailAsync(Email email)
        {
            await _qagencyTaskContext.Emails.AddAsync(email);
            return await SaveAsync();
        }
        public async Task<List<Email>> GetAllEmailsAsync()
        {
            var allEmails = await _qagencyTaskContext.Emails.
                Select(x => new Email()
                {
                    Id = x.Id,
                    EmailCc= x.EmailCc,
                    EmailContent= x.EmailContent,
                    EmailSubject= x.EmailSubject,
                    EmailFrom= x.EmailFrom,
                    EmailTo= x.EmailTo,
                    Importance = x.Importance,
                    ImportanceId = x.Importance.Id
                })
                .ToListAsync();

            return allEmails;
        }

        public async Task<List<Importance>> GetAllImportanceLevelsAsync()
        {
            var allImportanceLevels = await _qagencyTaskContext.Importances.ToListAsync();
            return allImportanceLevels;
        }

        public async Task<bool> SaveAsync()
        {
            return await _qagencyTaskContext.SaveChangesAsync() > 0;
        }
    }
}
