using System;
using System.Collections;
using System.Linq;

using Common;

namespace InvoiceService
{
    public class Invoices : IEnumerable
    {
        private static readonly object _lockDA = new Object();
        private Invoice[] invoices = null;

        public Invoice[] Get()
        {
            lock (_lockDA)
            {
                if (invoices == null)
                {
                    invoices = new Invoice[]
                    {
                        new Invoice(
                            DateTime.Parse("2020-12-01"),
                            1048576,
                            "Tom Mann",
                            "Edward Woodward",
                            "35 Equaliser Drive",
                            "Barnard Castle",
                            "",
                            "Durham",
                            "DL12 2SE",
                            "United Kingdom",
                            new InvoiceLine[] {
                                new InvoiceLine("File Transfer", 10.00m),
                                new InvoiceLine("File Storage", 54.99m)
                            }
                            ),
                        new Invoice(
                            DateTime.Parse("2020-11-28"),
                            1048555,
                            "Tom Mann",
                            "Samuel L Jackson",
                            "48 Pulp Drive",
                            "Snake Valley",
                            "Beverly Hills",
                            "CA",
                            "90210",
                            "USA",
                            new InvoiceLine[] {
                                new InvoiceLine("Encrypted Content", 1490.00m),
                                new InvoiceLine("Decryption Key", 9.99m)
                            }
                            )
                    };
                }
            }
            return invoices;
        }

        public IEnumerator GetEnumerator()
        {
            yield return invoices.ToList<Invoice>();
        }
    }
}