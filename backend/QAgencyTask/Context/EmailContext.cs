using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using QAgencyTask.Models;
using Microsoft.EntityFrameworkCore;

namespace QAgencyTask.Context
{
    public class EmailContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public EmailContext(DbContextOptions<EmailContext> options) : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<Email> Emails { get; set; }

        protected  void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Email>().ToTable("Email");
        }
    }
}
