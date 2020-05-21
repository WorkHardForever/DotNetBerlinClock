using System;

namespace BerlinClock.Classes.Utils
{
	public static class StringHelper
	{
		public static string GetFilledStringByCharacters(
			int limitChars,
			int countToFill,
			char fillingSymbol,
			char emptySymbol)
		{
			if (limitChars < countToFill)
			{
				throw new ArgumentOutOfRangeException(nameof(limitChars), $"{nameof(limitChars)} should be more than {nameof(countToFill)}");
			}

			char[] chars = new char[limitChars];
			for (int i = 0; i < chars.Length; i++)
			{
				chars[i] = i < countToFill
					? fillingSymbol
					: emptySymbol;
			}

			return new string(chars);
		}

		public static string GetFilledStringByCharactersWithSeparators(
			int limitChars,
			int countToFill,
			char fillingSymbol,
			int numberOfSymbolsBeforeSeparator,
			char separatorSymbol,
			char emptySymbol)
		{
			if (limitChars < countToFill)
			{
				throw new ArgumentOutOfRangeException($"{nameof(limitChars)} should be more than {nameof(countToFill)}");
			}

			char[] chars = new char[limitChars];
			for (int i = 0; i < chars.Length; i++)
			{
				if (i < countToFill)
				{
					chars[i] = (i + 1) % numberOfSymbolsBeforeSeparator == 0
						? separatorSymbol
						: fillingSymbol;
				}
				else
				{
					chars[i] = emptySymbol;
				}
			}

			return new string(chars);
		}
	}
}
