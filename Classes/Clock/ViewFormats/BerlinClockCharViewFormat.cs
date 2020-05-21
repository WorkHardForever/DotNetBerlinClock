using BerlinClock.Classes.Utils;
using BerlinClock.Interfaces.Clock;
using BerlinClock.Interfaces.Clock.ViewFormats;

namespace BerlinClock.Classes.Clock.ViewFormats
{
	public class BerlinClockCharViewFormat : IBerlinClockViewFormat
	{
		private const char c_offSymbol = 'O';
		private const char c_secondSymbol = 'Y';
		private const char c_hourSymbol = 'R';
		private const char c_minuteSymbol = 'Y';
		private const char c_quarterSymbol = 'R';

		private const int c_quaterSeparateNumber = 3;


		/// <summary>
		/// Creates view of <see cref="BerlinClockModel"/> as characters. See remarks for examples
		/// </summary>
		/// <param name="model">Berlin clock model</param>
		/// <returns><see cref="BerlinClockModel"/> as characters</returns>
		/// <remarks>
		/// Some examples:
		/// 1. For "23:59:59"
		/// O
		/// RRRR
		/// RRRO
		/// YYRYYRYYRYY
		/// YYYY
		/// 
		/// 2. For "00:00:00"
		/// Y
		/// OOOO
		/// OOOO
		/// OOOOOOOOOOO
		/// OOOO
		/// </remarks>
		public string MakeView(BerlinClockModel model)
		{
			char secondsSymbol = model.EvenSeconds
				? c_secondSymbol
				: c_offSymbol;
			string secondsRow = secondsSymbol.ToString();

			string filling5HoursRow = StringHelper.GetFilledStringByCharacters(
				BerlinClockModel.c_limit5HoursChars, model.CountOf5Hours, c_hourSymbol, c_offSymbol);

			string fillingModHoursRow = StringHelper.GetFilledStringByCharacters(
				BerlinClockModel.c_limitModHoursChars, model.CountOfModHours, c_hourSymbol, c_offSymbol);

			string filling5MinutesRow = StringHelper.GetFilledStringByCharactersWithSeparators(
				BerlinClockModel.c_limit5MinutesChars, model.CountOf5Minutes, c_minuteSymbol, c_quaterSeparateNumber, c_quarterSymbol, c_offSymbol);

			string fillingModMinutesRow = StringHelper.GetFilledStringByCharacters(
				BerlinClockModel.c_limitModMinutesChars, model.CountOfModMinutes, c_minuteSymbol, c_offSymbol);

			string resultView = $"{secondsRow}\r\n{filling5HoursRow}\r\n{fillingModHoursRow}\r\n{filling5MinutesRow}\r\n{fillingModMinutesRow}";

			return resultView;
		}
	}
}
