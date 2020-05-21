using BerlinClock.Classes.Clock.ViewFormats;
using BerlinClock.Interfaces;
using BerlinClock.Interfaces.Clock;
using BerlinClock.Interfaces.Clock.ViewFormats;
using System;
using System.Globalization;

namespace BerlinClock
{
	/// <summary>
	/// Time converter to Berlin Clock. See remarks to details
	/// </summary>
	/// <remarks>
	/// About the clock you can find info in link below:
	/// http://www.aquaphoenix.com/misc/settheoryclock/
	/// 
	/// Example of their work:
	/// https://jayasurian123.github.io/berlin-uhr/
	/// </remarks>
	public class BerlinClockTimeConverter : ITimeConverter
	{
		/// <summary>
		/// Convert input time to Berlin Clock
		/// </summary>
		/// <param name="timeSpan">Time span</param>
		/// <returns>Converted time to <see cref="BerlinClockCharViewFormat"/> format</returns>
		public string ConvertTime(string timeSpan)
		{
			IBerlinClockViewFormat berlinClockViewFormat = new BerlinClockCharViewFormat();

			return this.ConvertTime(timeSpan, berlinClockViewFormat);
		}

		/// <summary>
		/// Convert input time to Berlin Clock
		/// </summary>
		/// <param name="timeSpan">Time span</param>
		/// <param name="berlinClockViewFormat">View of Berlin clock</param>
		/// <param name="timeFormatProvider">Culture of time span convertation</param>
		/// <returns>Formatted Berlin Clock as string result</returns>
		public string ConvertTime(
			string timeSpan,
			IBerlinClockViewFormat berlinClockViewFormat,
			IFormatProvider timeFormatProvider = null)
		{
			if (string.IsNullOrEmpty(timeSpan))
			{
				throw new ArgumentException($"Argument {timeSpan} can't be null or empty");
			}
			if (berlinClockViewFormat == null)
			{
				throw new ArgumentNullException($"Argument {berlinClockViewFormat} can't be null");
			}

			IFormatProvider usedFormatProvider = timeFormatProvider ?? CultureInfo.InvariantCulture;
			TimeSpan convertedTimeSpan;
			bool parsed = TimeSpan.TryParse(timeSpan, usedFormatProvider, out convertedTimeSpan);

			if (!parsed)
			{
				throw new ArgumentException($"Argument {timeSpan} should be a time span and convertable to {typeof(TimeSpan)}");
			}

			return this.GenerateTimeToViewFormat(convertedTimeSpan, berlinClockViewFormat);
		}

		/// <summary>
		/// Convert input time to Berlin Clock
		/// </summary>
		/// <param name="timeSpan">Time span</param>
		/// <param name="berlinClockViewFormat">View of Berlin clock</param>
		/// <returns>Formatted Berlin Clock as string result</returns>
		public string ConvertTime(
			TimeSpan timeSpan,
			IBerlinClockViewFormat berlinClockViewFormat)
		{
			if (berlinClockViewFormat == null)
			{
				throw new ArgumentNullException($"Argument {berlinClockViewFormat} can't be null");
			}

			return this.GenerateTimeToViewFormat(timeSpan, berlinClockViewFormat);
		}


		private string GenerateTimeToViewFormat(
			TimeSpan timeSpan,
			IBerlinClockViewFormat berlinClockViewFormat)
		{
			int hour = this.CalculateHour(timeSpan);
			int minutes = timeSpan.Minutes;
			int seconds = timeSpan.Seconds;

			BerlinClockModel berlinClockModel = new BerlinClockModel(
				evenSeconds: seconds % 2 == 0,
				countOf5Hours: hour / 5,
				countOfModHours: hour % 5,
				countOf5Minutes: minutes / 5,
				countOfModMinutes: minutes % 5
			);

			return berlinClockViewFormat.MakeView(berlinClockModel);
		}

		private int CalculateHour(TimeSpan timeSpan)
		{
			// Check case when clock should show another time in midnight 24:00:00 than 00:00:00
			// Original TimeSpan.Parse didn't abillity to convert correctly
			// https://docs.microsoft.com/en-us/dotnet/api/system.timespan.parse?view=netcore-3.1#System_TimeSpan_Parse_System_String_
			if (timeSpan.Days == 24
				&& timeSpan.Hours == 0
				&& timeSpan.Minutes == 0
				&& timeSpan.Seconds == 0)
			{
				return 24;
			}

			return timeSpan.Hours;
		}
	}
}
