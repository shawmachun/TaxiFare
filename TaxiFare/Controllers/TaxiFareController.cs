using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TaxiFare.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TaxiFareController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

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
				int entryFee = 3;
				double nightSurcharge = 0;
				int peakSurcharge = 0;
				double stateSurcharge = 0.5;
				double travelCost = (distanceL6 / 5.0) * 0.35;
				double timeCost = timeG6OrIdle * 0.35;

				DateTime day = Convert.ToDateTime(date);
				DateTime start = DateTime.Parse(startTime);
				String dayOfWeek = day.DayOfWeek.ToString();

				TimeSpan nightStart = new TimeSpan(20, 0, 0);
				TimeSpan nightEnd = new TimeSpan(06, 0, 0);
				TimeSpan peakStart = new TimeSpan(16, 0, 0);
				TimeSpan peakEnd = new TimeSpan(20, 0, 0);

				TimeSpan now = start.TimeOfDay;

				bool isNight = now >= nightStart || now <= nightEnd;
				bool isPeak = (dayOfWeek != "Saturday" && dayOfWeek != "Sunday") && (now >= peakStart && now <= peakEnd);

				if (isNight) { nightSurcharge = 0.5; }
				if (isPeak) { peakSurcharge = 1; }

				double totalCost = entryFee + nightSurcharge + peakSurcharge + stateSurcharge + travelCost + timeCost;

				return totalCost;
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
