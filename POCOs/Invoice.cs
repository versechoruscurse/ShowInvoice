using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common
{
    public class Invoice
    {
        private string _postcode;

        public DateTime invoiceDate { get; set; }
        public ulong invoiceNumber { get; set; }
        public string user { get; set; }

        public string name { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string addressLine3 { get; set; }
        public string county { get; set; }
        public string postcode
        {
            get
            {
                return _postcode;
            }
            set
            {
                _postcode = value.ToUpper();
            }
        }
        public string country { get; set; }
        public InvoiceLine[] invoiceLines { get; set; }

        public Invoice() { }

        public Invoice(
            DateTime InvoiceDate,
            ulong InvoiceNumber,
            string User,
            string Name,
            string AddressLine1,
            string AddressLine2,
            string AddressLine3,
            string County,
            string Postcode,
            string Country,
            InvoiceLine[] InvoiceLines
            )
        {
            this.invoiceDate = InvoiceDate;
            this.invoiceNumber = InvoiceNumber;
            this.user = User;
            this.name = Name;
            this.addressLine1 = AddressLine1;
            this.addressLine2 = AddressLine2;
            this.addressLine3 = AddressLine3;
            this.county = County;
            this.postcode = Postcode;
            this.country = Country;
            this.invoiceLines = InvoiceLines;
        }

        public Decimal InvoiceTotal
        {
            get
            {
                decimal sum = 0;
                foreach (var invoiceLine in invoiceLines)
                {
                    sum += invoiceLine.amount;
                }
                return sum;
            }
        }
    }
}
