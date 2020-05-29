using System;
using TechTalk.SpecFlow;

namespace SystemTest
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"The oven is reset")]
        public void GivenTheOvenIsReset()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press the time button (.*) time\(s\)")]
        public void WhenIPressTheTimeButtonTimeS(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the display should show (.*) sec")]
        public void ThenTheDisplayShouldShowSec(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
