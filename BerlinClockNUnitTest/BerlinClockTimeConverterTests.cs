using BerlinClock;
using BerlinClock.Classes.Clock.ViewFormats;
using BerlinClock.Interfaces;
using BerlinClock.Interfaces.Clock.ViewFormats;
using NUnit.Framework;
using System;
using System.Collections;

namespace BerlinClockNUnitTest
{
	[TestFixture]
	public class BerlinClockTimeConverterTests
	{
		private BerlinClockTimeConverter _berlinClockTimeConverter;

		[SetUp]
		public void SetUp()
		{
			this._berlinClockTimeConverter = new BerlinClockTimeConverter();
		}

		[Test]
		public void BerlinClockCharViewFormat_CreatedSuccessfully()
		{
			// Assert
			Assert.IsNotNull(this._berlinClockTimeConverter, "Object should be created");
		}

		[Test]
		public void BerlinClockCharViewFormat_IsITimeConverter()
		{
			// Assert
			Assert.IsTrue(this._berlinClockTimeConverter is ITimeConverter, $"Object should be type of {typeof(ITimeConverter)}");
		}

		public static IEnumerable ConvertTimeStringCases
		{
			// Arrange
			get
			{
				yield return new TestCaseData("00:00:00").Returns("Y\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nOOOO");
				yield return new TestCaseData("24:00:00").Returns("Y\r\nRRRR\r\nRRRR\r\nOOOOOOOOOOO\r\nOOOO");
				yield return new TestCaseData("00:00:01").Returns("O\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nOOOO");
				yield return new TestCaseData("11:25:41").Returns("O\r\nRROO\r\nROOO\r\nYYRYYOOOOOO\r\nOOOO");
				yield return new TestCaseData("17:39:55").Returns("O\r\nRRRO\r\nRROO\r\nYYRYYRYOOOO\r\nYYYY");
				yield return new TestCaseData("23:59:59").Returns("O\r\nRRRR\r\nRRRO\r\nYYRYYRYYRYY\r\nYYYY");
			}
		}
		[TestCaseSource("ConvertTimeStringCases")]
		public string ConvertTimeString_GetCorrectResultCases(string timeSpan)
		{
			// Act
			string result = this._berlinClockTimeConverter.ConvertTime(timeSpan);

			// Assert
			return result;
		}

		[Test]
		public void ConvertTimeString_IncorrectCase_TimeSpanNotCorrect()
		{
			TestDelegate testDelegate = () =>
			{
				// Arrange
				string timeSpan = "99:99:99f";

				// Act
				this._berlinClockTimeConverter.ConvertTime(timeSpan);
			};

			// Assert
			Assert.Throws<ArgumentException>(testDelegate);
		}

		public static IEnumerable ConvertTimeStringAndFormatsCases
		{
			// Arrange
			get
			{
				yield return new TestCaseData("00:00:00", new BerlinClockCharViewFormat()).Returns("Y\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nOOOO");
				yield return new TestCaseData("24:00:00", new BerlinClockCharViewFormat()).Returns("Y\r\nRRRR\r\nRRRR\r\nOOOOOOOOOOO\r\nOOOO");
				yield return new TestCaseData("00:00:01", new BerlinClockCharViewFormat()).Returns("O\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nOOOO");
				yield return new TestCaseData("11:25:41", new BerlinClockCharViewFormat()).Returns("O\r\nRROO\r\nROOO\r\nYYRYYOOOOOO\r\nOOOO");
				yield return new TestCaseData("17:39:55", new BerlinClockCharViewFormat()).Returns("O\r\nRRRO\r\nRROO\r\nYYRYYRYOOOO\r\nYYYY");
				yield return new TestCaseData("23:59:59", new BerlinClockCharViewFormat()).Returns("O\r\nRRRR\r\nRRRO\r\nYYRYYRYYRYY\r\nYYYY");
			}
		}
		[TestCaseSource("ConvertTimeStringAndFormatsCases")]
		public string ConvertTimeStringAndFormats_GetCorrectResultCases(
			string timeSpan, IBerlinClockViewFormat berlinClockViewFormat)
		{
			// Act
			string result = this._berlinClockTimeConverter.ConvertTime(timeSpan, berlinClockViewFormat);

			// Assert
			return result;
		}

		[Test]
		public void ConvertTimeStringAndFormats_IncorrectCase_TimeSpanNotCorrect()
		{
			TestDelegate testDelegate = () =>
			{
				// Arrange
				string timeSpan = "99:99:99f";
				IBerlinClockViewFormat berlinClockViewFormat = new BerlinClockCharViewFormat();

				// Act
				this._berlinClockTimeConverter.ConvertTime(timeSpan, berlinClockViewFormat);
			};

			// Assert
			Assert.Throws<ArgumentException>(testDelegate);
		}

		[Test]
		public void ConvertTimeStringAndFormats_IncorrectCase_BerlinClockViewFormatNotCorrect()
		{
			TestDelegate testDelegate = () =>
			{
				// Arrange
				string timeSpan = "00:12:34";
				IBerlinClockViewFormat berlinClockViewFormat = null;

				// Act
				this._berlinClockTimeConverter.ConvertTime(timeSpan, berlinClockViewFormat);
			};

			// Assert
			Assert.Throws<ArgumentNullException>(testDelegate);
		}

		public static IEnumerable ConvertTimeSpanAndFormatCases
		{
			// Arrange
			get
			{
				yield return new TestCaseData(TimeSpan.Parse("00:00:00"), new BerlinClockCharViewFormat()).Returns("Y\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nOOOO");
				yield return new TestCaseData(TimeSpan.Parse("24:00:00"), new BerlinClockCharViewFormat()).Returns("Y\r\nRRRR\r\nRRRR\r\nOOOOOOOOOOO\r\nOOOO");
				yield return new TestCaseData(TimeSpan.Parse("00:00:01"), new BerlinClockCharViewFormat()).Returns("O\r\nOOOO\r\nOOOO\r\nOOOOOOOOOOO\r\nOOOO");
				yield return new TestCaseData(TimeSpan.Parse("11:25:41"), new BerlinClockCharViewFormat()).Returns("O\r\nRROO\r\nROOO\r\nYYRYYOOOOOO\r\nOOOO");
				yield return new TestCaseData(TimeSpan.Parse("17:39:55"), new BerlinClockCharViewFormat()).Returns("O\r\nRRRO\r\nRROO\r\nYYRYYRYOOOO\r\nYYYY");
				yield return new TestCaseData(TimeSpan.Parse("23:59:59"), new BerlinClockCharViewFormat()).Returns("O\r\nRRRR\r\nRRRO\r\nYYRYYRYYRYY\r\nYYYY");
			}
		}
		[TestCaseSource("ConvertTimeSpanAndFormatCases")]
		public string ConvertTimeSpanAndFormat_GetCorrectResultCases(
			TimeSpan timeSpan, IBerlinClockViewFormat berlinClockViewFormat)
		{
			// Act
			string result = this._berlinClockTimeConverter.ConvertTime(timeSpan, berlinClockViewFormat);

			// Assert
			return result;
		}

		[Test]
		public void ConvertTimeSpanAndFormat_IncorrectCase_BerlinClockViewFormatNotCorrect()
		{
			TestDelegate testDelegate = () =>
			{
				// Arrange
				TimeSpan timeSpan = new TimeSpan();
				IBerlinClockViewFormat berlinClockViewFormat = null;

				// Act
				this._berlinClockTimeConverter.ConvertTime(timeSpan, berlinClockViewFormat);
			};

			// Assert
			Assert.Throws<ArgumentNullException>(testDelegate);
		}
	}
}
