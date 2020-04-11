using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroRabbit.Banking.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public BankingController(IAccountService accountService) {

            _accountService = accountService;
        }

        //private readonly ILogger<BankingController> _logger;

        //public BankingController(ILogger<BankingController> logger)
        //{
        //    _logger = logger;
        //}

            //Get Api /Banking
        [HttpGet]
        public ActionResult<Account> Get()
        {
            return Ok(_accountService.GetAccounts());
        }

        [HttpPost]
        public IActionResult Post([FromBody] AccountTransfer accoutTrasnfer) {

            _accountService.Transfer(accoutTrasnfer);
            return Ok(accoutTrasnfer);
        }
    }
}
