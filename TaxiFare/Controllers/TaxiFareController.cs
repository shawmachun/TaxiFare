using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TaxiFare.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TaxiFareController : ControllerBase
	{
		private readonly ILogger<TaxiFareController> _logger;

		public TaxiFareController(ILogger<TaxiFareController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public double Get([FromQuery] string date, [FromQuery] string startTime, [FromQuery] int distanceL6, [FromQuery] int timeG6OrIdle)
		{
			try
			{
				TaxiFareCalculator fare = new TaxiFareCalculator(date, startTime, timeG6OrIdle, distanceL6);
				return fare.totalCost;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
