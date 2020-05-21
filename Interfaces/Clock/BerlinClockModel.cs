using System;

namespace BerlinClock.Interfaces.Clock
{
	/// <summary>
	/// Berlin clock container
	/// </summary>
	public class BerlinClockModel
	{
		public const int c_limit5HoursChars = 4;
		public const int c_limitModHoursChars = 4;
		public const int c_limit5MinutesChars = 11;
		public const int c_limitModMinutesChars = 4;

		public bool EvenSeconds { get; set; }
		public int CountOf5Hours { get; set; }
		public int CountOfModHours { get; set; }
		public int CountOf5Minutes { get; set; }
		public int CountOfModMinutes { get; set; }


		public BerlinClockModel(
			bool evenSeconds,
			int countOf5Hours,
			int countOfModHours,
			int countOf5Minutes,
			int countOfModMinutes)
		{
			if (0 > countOf5Hours || countOf5Hours > c_limit5HoursChars)
			{
				throw new ArgumentOutOfRangeException($"Argument {countOf5Hours} out of required range | limit: {c_limit5HoursChars}");
			}
			if (0 > countOfModHours || countOfModHours > c_limitModHoursChars)
			{
				throw new ArgumentOutOfRangeException($"Argument {countOfModHours} out of required range | limit: {c_limitModHoursChars}");
			}
			if (0 > countOf5Minutes || countOf5Minutes > c_limit5MinutesChars)
			{
				throw new ArgumentOutOfRangeException($"Argument {countOf5Minutes} out of required range | limit: {c_limit5MinutesChars}");
			}
			if (0 > countOfModMinutes || countOfModMinutes > c_limitModMinutesChars)
			{
				throw new ArgumentOutOfRangeException($"Argument {countOfModMinutes} out of required range | limit: {c_limitModMinutesChars}");
			}

			this.EvenSeconds = evenSeconds;
			this.CountOf5Hours = countOf5Hours;
			this.CountOfModHours = countOfModHours;
			this.CountOf5Minutes = countOf5Minutes;
			this.CountOfModMinutes = countOfModMinutes;
		}
	}
}
