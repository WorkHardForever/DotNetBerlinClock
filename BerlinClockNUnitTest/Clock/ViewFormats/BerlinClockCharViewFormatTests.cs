using BerlinClock.Classes.Clock.ViewFormats;
using BerlinClock.Interfaces.Clock;
using NUnit.Framework;
using System.Collections;

namespace BerlinClockNUnitTest.Clock.ViewFormats
{
	[TestFixture]
	public class BerlinClockCharViewFormatTests
	{
		private BerlinClockCharViewFormat _berlinClockCharViewFormat;

		[SetUp]
		public void SetUp()
		{
			this._berlinClockCharViewFormat = new BerlinClockCharViewFormat();
		}

		[Test]
		public void BerlinClockCharViewFormat_CreatedSuccessfully()
		{
			// Assert
			Assert.IsNotNull(this._berlinClockCharViewFormat, "Object should be created");
		}

		public static IEnumerable MakeViewCases
		{
			// Arrange
			get
			{
				yield return new TestCaseData(new BerlinClockModel(true, 0, 0, 0, 0)).Returns("Y\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nOOOO");
				yield return new TestCaseData(new BerlinClockModel(false, 0, 0, 0, 0)).Returns("O\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nOOOO");
				yield return new TestCaseData(new BerlinClockModel(true, 0, 0, 0, 1)).Returns("Y\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nYOOO");
				yield return new TestCaseData(new BerlinClockModel(true, 1, 2, 3, 4)).Returns("Y\r\nROOO\r\nRROO\r\nYYROOOOOOOO\r\nYYYY");
				yield return new TestCaseData(new BerlinClockModel(false, 1, 2, 3, 4)).Returns("O\r\nROOO\r\nRROO\r\nYYROOOOOOOO\r\nYYYY");
				yield return new TestCaseData(new BerlinClockModel(true, 4, 4, 11, 4)).Returns("Y\r\nRRRR\r\nRRRR\r\nYYRYYRYYRYY\r\nYYYY");
				yield return new TestCaseData(new BerlinClockModel(false, 4, 4, 11, 4)).Returns("O\r\nRRRR\r\nRRRR\r\nYYRYYRYYRYY\r\nYYYY");
			}
		}
		[TestCaseSource("MakeViewCases")]
		public string MakeView_GetCorrectViewCases(BerlinClockModel model)
		{
			// Act
			string result = this._berlinClockCharViewFormat.MakeView(model);

			// Assert
			return result;
		}
	}
}
