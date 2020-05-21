using BerlinClock.Classes.Utils;
using NUnit.Framework;
using System;
using System.Collections;

namespace BerlinClockNUnitTest.Utils
{
	[TestFixture]
	public class StringHelperTests
	{
		public static IEnumerable GetFilledStringByCharactersCases
		{
			// Arrange
			get
			{
				yield return new TestCaseData(10, 10, 'x', 'y').Returns("xxxxxxxxxx");
				yield return new TestCaseData(10, 5, 'x', 'y').Returns("xxxxxyyyyy");
				yield return new TestCaseData(1, 0, 'x', 'y').Returns("y");
			}
		}
		[TestCaseSource("GetFilledStringByCharactersCases")]
		public string GetFilledStringByCharacters_CorrectCases(
			int limitChars, int countToFill, char fillingSymbol, char emptySymbol)
		{
			// Act
			string result = StringHelper.GetFilledStringByCharacters(limitChars, countToFill, fillingSymbol, emptySymbol);

			// Assert
			return result;
		}

		[Test]
		public void GetFilledStringByCharacters_IncorrectCase_LimitCharsSmallerThanCountOfFill()
		{
			TestDelegate testDelegate = () =>
			{
				// Arrange
				int limitChars = 0;
				int countToFill = 1;
				char fillingSymbol = 'x';
				char emptySymbol = 'y';

				// Act
				StringHelper.GetFilledStringByCharacters(limitChars, countToFill, fillingSymbol, emptySymbol);
			};

			// Assert
			Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
		}

		public static IEnumerable GetFilledStringByCharactersWithSeparatorsCases
		{
			// Arrange
			get
			{
				yield return new TestCaseData(10, 10, 'x', 2, 's', 'y').Returns("xsxsxsxsxs");
				yield return new TestCaseData(10, 5, 'x', 3, 's', 'y').Returns("xxsxxyyyyy");
				yield return new TestCaseData(15, 12, 'x', 4, 's', 'y').Returns("xxxsxxxsxxxsyyy");
				yield return new TestCaseData(1, 0, 'x', 1, 's', 'y').Returns("y");
			}
		}
		[TestCaseSource("GetFilledStringByCharactersWithSeparatorsCases")]
		public string GetFilledStringByCharactersWithSeparators_CorrectCases(
			int limitChars, int countToFill, char fillingSymbol,
			int numberOfSymbolsBeforeSeparator, char separatorSymbol, char emptySymbol)
		{
			// Act
			string result = StringHelper.GetFilledStringByCharactersWithSeparators(
				limitChars, countToFill, fillingSymbol,
				numberOfSymbolsBeforeSeparator, separatorSymbol, emptySymbol);

			// Assert
			return result;
		}

		[Test]
		public void GetFilledStringByCharactersWithSeparators_IncorrectCase_LimitCharsSmallerThanCountOfFill()
		{
			TestDelegate testDelegate = () =>
			{
				// Arrange
				int limitChars = 0;
				int countToFill = 1;
				char fillingSymbol = 'x';
				int numberOfSymbolsBeforeSeparator = 2;
				char separatorSymbol = 's';
				char emptySymbol = 'y';

				// Act
				StringHelper.GetFilledStringByCharactersWithSeparators(
					limitChars, countToFill, fillingSymbol,
					numberOfSymbolsBeforeSeparator, separatorSymbol, emptySymbol);
			};

			// Assert
			Assert.Throws<ArgumentOutOfRangeException>(testDelegate);
		}
	}
}
