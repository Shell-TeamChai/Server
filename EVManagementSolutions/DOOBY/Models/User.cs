using System;
using System.Collections.Generic;

namespace DOOBY.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Type { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual Admin? Admin { get; set; }

    public virtual Customer? Customer { get; set; }
}
