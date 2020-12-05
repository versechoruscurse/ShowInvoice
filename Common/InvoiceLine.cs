namespace Common
{
    public class InvoiceLine
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public InvoiceLine() { }
        public InvoiceLine(string Description, decimal Amount)
        {
            this.Description = Description;
            this.Amount = Amount;
        }
    }
}
