using System;
using System.Collections.Generic;

namespace QAgencyTask.Models;

public partial class Importance
{
    public Guid Id { get; set; }

    public string? Importance1 { get; set; }

    public virtual ICollection<Email> Emails { get; } = new List<Email>();
}
