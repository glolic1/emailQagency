using System;
using System.Collections.Generic;

namespace QAgencyTask.Models;

public partial class Email
{
    public Guid Id { get; set; }

    public string? EmailFrom { get; set; }

    public string? EmailTo { get; set; }

    public string? EmailCc { get; set; }

    public string? EmailSubject { get; set; }

    public Guid? ImportanceId { get; set; }

    public string? EmailContent { get; set; }

    public virtual Importance? Importance { get; set; }
}
