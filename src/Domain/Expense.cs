namespace bounty.Domain
{
    public class Expense
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public Account Account { get; set; }
        public string Payee { get; set; }
        public Schedule Schedule { get; set; }
    }
}
