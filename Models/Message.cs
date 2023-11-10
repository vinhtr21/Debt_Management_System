using System;
using System.Collections.Generic;

namespace Debt_Management.Models;

public partial class Message
{
    public int MsgId { get; set; }

    public string? Sender { get; set; }

    public string? Receiver { get; set; }

    public string? Content { get; set; }

    public DateTime? SendDate { get; set; }
}
