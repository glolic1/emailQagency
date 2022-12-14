using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QAgencyTask.Models;
using QAgencyTask.Services.Interfaces;

namespace QAgencyTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpGet("email")]
        public async Task<ActionResult<List<Email>>> GetAllEmails()
        {
            return Ok(await _emailService.GetAllEmailsAsync());
        }

        [HttpGet("importance")]
        public async Task<ActionResult<List<Importance>>> GetImportanceLevels()
        {
            return Ok(await _emailService.GetAllImportanceLevelsAsync());
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddEmailAsync(Email email)
        {
            return Ok(await _emailService.AddEmailAsync(email));
        }
    }
}
