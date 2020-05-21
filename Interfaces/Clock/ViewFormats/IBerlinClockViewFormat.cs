namespace BerlinClock.Interfaces.Clock.ViewFormats
{
	/// <summary>
	/// Contract to decorate outgoing <see cref="BerlinClockModel"/>
	/// </summary>
	public interface IBerlinClockViewFormat
	{
		/// <summary>
		/// Creates view of <see cref="BerlinClockModel"/>
		/// </summary>
		/// <param name="berlinClockModel">Berlin clock model</param>
		/// <returns>View as string result</returns>
		string MakeView(BerlinClockModel berlinClockModel);
	}
}