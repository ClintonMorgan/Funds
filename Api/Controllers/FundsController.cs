namespace Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.IO;
    using Api.DataFiles;
    using Serilog;

    public class FundsController : Controller
    {
        List<string> convertedFundsFile = new List<string>();

        [Route("get-funds")]
        public IActionResult GetFunds()
        {

            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

            Log.Logger.Information("Request Get Funds");

            return this.Ok(funds.Select(x => new { x.Active, CurrentUnitPrice = Math.Round(x.CurrentUnitPrice, 2), x.FundManager, Code = x.MarketCode, x.Name }));
        }

        [Route("get-fund/{id}")]
        public IActionResult GetFund(string id)
        {
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

            Log.Logger.Information("Request Get Fund - with ID = " + id);

            if (id != null)
            {
                return this.Ok(funds.Select(x => new { x.Active, CurrentUnitPrice = Math.Round(x.CurrentUnitPrice, 2), x.FundManager, Code = x.MarketCode, x.Name }).FirstOrDefault(x => x.Code == id));
            }

            return this.Ok(funds);
        }


        [Route("get-managerfunds/{manager}")]
        public IActionResult GetManagerFunds(string manager)
        {
            var file = System.IO.File.ReadAllTextAsync("./DataFiles/funds.json").Result;

            var funds = JsonConvert.DeserializeObject<List<FundDetails>>(file);

            Log.Logger.Information("Request Get Fund - with Fund Manager = " + manager);

            return this.Ok(funds.Select(x => new { x.Active, CurrentUnitPrice = Math.Round(x.CurrentUnitPrice, 2), x.FundManager, Code = x.MarketCode, x.Name }).Where(x => x.FundManager == manager));
        }
    }
}