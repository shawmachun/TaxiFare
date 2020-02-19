using System;

namespace TaxiFare
{
	public class TaxiFareCalculator
	{
		public string date;

		public int timeGreaterThanSixOrIdle;

		public int distanceLessThanSix;

		public string startTime;

		public TaxiFareCalculator(string inputDate, string inputStartTime, int inputTimeGreaterThanSixOrIdle, int intinputDistanceLessThanSix)
		{
			date = inputDate;
			startTime = inputStartTime;
			timeGreaterThanSixOrIdle = inputTimeGreaterThanSixOrIdle;
			distanceLessThanSix = intinputDistanceLessThanSix;
		}
		public double totalCost { 
			get { 
				int entryFee = 3;
				double nightSurcharge = 0;
				int peakSurcharge = 0;
				double stateSurcharge = 0.5;
				double travelCost = distanceLessThanSix * 0.35;
				double timeCost = timeGreaterThanSixOrIdle * 0.35;

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
