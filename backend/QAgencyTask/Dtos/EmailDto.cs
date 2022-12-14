namespace QAgencyTask.Dtos
{
    public interface EmailDto
    {
        public Guid ID { get; set; }
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
        public string EmailCC { get; set; }
        public string EmailSubject { get; set; }
        public string Importance { get; set; }
        public string EmailContent { get; set; }
    }
}
