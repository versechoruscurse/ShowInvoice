using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common
{
    public class InvoiceLine
    {
        public string description { get; set; }
        public decimal amount { get; set; }

        public InvoiceLine() { }
        public InvoiceLine(string Description, decimal Amount)
        {
            this.description = Description;
            this.amount = Amount;
        }
    }
}
