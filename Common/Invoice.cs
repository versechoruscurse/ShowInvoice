using System;

namespace Common
{
    public class Invoice
    {
        private string _postcode;

        public DateTime InvoiceDate { get; set; }
        public ulong InvoiceNumber { get; set; }
        public string User { get; set; }

        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string County { get; set; }
        public string Postcode
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
        public string Country { get; set; }
        public InvoiceLine[] InvoiceLines { get; set; }

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
            this.InvoiceDate = InvoiceDate;
            this.InvoiceNumber = InvoiceNumber;
            this.User = User;
            this.Name = Name;
            this.AddressLine1 = AddressLine1;
            this.AddressLine2 = AddressLine2;
            this.AddressLine3 = AddressLine3;
            this.County = County;
            this.Postcode = Postcode;
            this.Country = Country;
            this.InvoiceLines = InvoiceLines;
        }

        public decimal InvoiceTotal
        {
            get
            {
                decimal sum = 0;
                foreach (var invoiceLine in InvoiceLines)
                {
                    sum += invoiceLine.Amount;
                }
                return sum;
            }
        }
    }
}
