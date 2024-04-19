using TechTalk.SpecFlow;

namespace ProjectMars.Utilities.Hooks
{
    /// <summary>
    /// Class containing setup and clean-up actions.
    /// </summary>
    [Binding]
    public class Hooks : Driver
    {
        /// <summary>
        /// Sets up the test execution.
        /// </summary>
        [BeforeScenario]
        public void Setup()
        {
            Initialize();
        }

        /// <summary>
        /// Concludes the test execution.
        /// </summary>
        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
    