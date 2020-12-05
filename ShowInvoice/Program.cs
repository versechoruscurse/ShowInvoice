using System;
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
                        invoice.Name,
                        invoice.AddressLine1,
                        invoice.AddressLine2,
                        invoice.AddressLine3,
                        invoice.County,
                        invoice.Postcode,
                        invoice.Country
                   )
                );
                Console.WriteLine(); // Separate line for visibility
                Console.WriteLine("{0,36}", String.Format("Date: {0:d}", invoice.InvoiceDate));
                Console.WriteLine("Invoice Data for {0}", invoice.Name);
                Console.WriteLine("Prepared by operator: {0}\r\n", invoice.User);

                Console.WriteLine(String.Format("{0,-26}{1,10}", "Description", "Amount"));
                Console.WriteLine(String.Format("{0,-26}{1,10}", "===========", "======"));
                foreach (var invoiceLine in invoice.InvoiceLines)
                {
                    Console.WriteLine("{0,-26}{1,10}", invoiceLine.Description, invoiceLine.Amount);
                }
                Console.WriteLine(String.Format("\r\n{0,24}{1,12:C}", "Total:", invoice.InvoiceTotal));
                Console.WriteLine();
            }
        }

        private static Invoice[] GetData()
        {
            JsonSerializerOptions jso = new JsonSerializerOptions()
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true
            };

            try
            {
                using (WebClient wc = new WebClient())
                {
                    string result = wc.DownloadString(_WEB_SERVICE_URI);
                    return JsonSerializer.Deserialize<Invoice[]>(result, jso);
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
