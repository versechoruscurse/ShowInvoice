using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

using Common;

namespace ShowInvoice
{
    class Program
    {
        private const string _WEB_SERVICE_URI = "https://localhost:44358/invoice";
        static void Main(string[] args)
        {
            var invoices = GetData();
            if (invoices == null) return;

            foreach (var invoice in invoices)
            {
                Console.WriteLine(
                    String.Join("\r\n",
                        invoice.name,
                        invoice.addressLine1,
                        invoice.addressLine2,
                        invoice.addressLine3,
                        invoice.county,
                        invoice.postcode,
                        invoice.country
                   )
                );
                Console.WriteLine(); // Separate line for visibility
                Console.WriteLine("{0,36}", String.Format("Date: {0:d}", invoice.invoiceDate));
                Console.WriteLine("Invoice Data for {0}", invoice.name);
                Console.WriteLine("Prepared by operator: {0}\r\n", invoice.user);

                Console.WriteLine(String.Format("{0,-26}{1,10}", "Description", "Amount"));
                Console.WriteLine(String.Format("{0,-26}{1,10}", "===========", "======"));
                foreach (var invoiceLine in invoice.invoiceLines)
                {
                    Console.WriteLine("{0,-26}{1,10}", invoiceLine.description, invoiceLine.amount);
                }
                Console.WriteLine(String.Format("\r\n{0,24}{1,12:C}", "Total:", invoice.InvoiceTotal));
                Console.WriteLine();
            }
        }

        private static Invoice[] GetData()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    string result = wc.DownloadString(_WEB_SERVICE_URI);
                    return JsonSerializer.Deserialize<Invoice[]>(result);
                }
            }
            catch (WebException we)
            {
                Console.WriteLine(we.Message); // Would normally log this
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
