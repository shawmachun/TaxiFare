using System;

namespace TaxiFare
{
	public class TaxiFareCalculator
	{
		public string date;

		public int timeG6OrIdle;

		public int distanceL6;

		public string startTime;

		public TaxiFareCalculator(string inputDate, string inputStartTime, int inputTimeG6OrIdle, int intinputDistanceL6)
		{
			date = inputDate;
			startTime = inputStartTime;
			timeG6OrIdle = inputTimeG6OrIdle;
			distanceL6 = intinputDistanceL6;
		}
		public double totalCost { 
			get { 
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
			set { } }
	}
}
