using System;
using System.Collections.Generic;

namespace DOOBY.Models;

public partial class Customer
{
    public int CustId { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public string PhoneNum { get; set; } = null!;

    public virtual User Cust { get; set; } = null!;

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<Grievance> Grievances { get; set; } = new List<Grievance>();
}
