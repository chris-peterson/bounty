using System;
using System.Collections.Generic;

namespace bounty.Domain
{
    public class Transaction
    {
        public DateTime Timestamp { get; set; }
        public decimal Amount { get; set; }
        public string Payee { get; set; }
        public string Category { get; set; }
        public List<string> Notes { get; set; } = new();
        public Status Status { get; set; }
    }

    public enum Status
    {
        Cleared,
        Pending
    }
}
