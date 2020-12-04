using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InvoiceService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<InvoiceController> _logger;

        public InvoiceController(ILogger<InvoiceController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Invoice> Get()
        {
            Invoices invoices = new Invoices();
            return invoices.Get().AsEnumerable();
        }
    }
}
