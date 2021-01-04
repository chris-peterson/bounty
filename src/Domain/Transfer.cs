using System;

namespace bounty.Domain
{
    public class Transfer
    {
        public DateTime Timestamp { get; set; }
        public Status Status { get; set; }
        public Account From { get; set; }
        public Account To { get; set; }
        public Schedule Schedule { get; set; }
    }
}
