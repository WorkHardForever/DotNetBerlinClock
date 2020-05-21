using BerlinClock.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace BerlinClock
{
	[Binding]
	public class TheBerlinClockSteps
	{
		private ITimeConverter berlinClock = new BerlinClockTimeConverter();
		private string theTime;


		[When(@"the time is ""(.*)""")]
		public void WhenTheTimeIs(string time)
		{
			this.theTime = time;
		}

		[Then(@"the clock should look like")]
		public void ThenTheClockShouldLookLike(string theExpectedBerlinClockOutput)
		{
			Assert.AreEqual(this.berlinClock.ConvertTime(this.theTime), theExpectedBerlinClockOutput);
		}

	}
}
