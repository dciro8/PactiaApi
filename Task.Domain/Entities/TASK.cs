using System;
using System.Collections.Generic;

namespace Task.Domain.Entities;

public partial class TASK
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string Developer { get; set; } = null!;

    public DateTime? Date_Created { get; set; }

    public DateTime? Date_Updated { get; set; }
}
