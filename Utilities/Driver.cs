using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace ProjectMars.Utilities;

/// <summary>
/// Class responsible for providing some common functionalities for the application.
/// </summary>
public class Driver
{
    public static IWebDriver driver = new ChromeDriver();

    /// <summary>
    /// Intializes the webdriver.
    /// </summary>
    public void Initialize()
    {
        Wait(driver, 5);
        driver.Manage().Window.Maximize();
    }

    /// <summary>
    /// Enforces a wait in the application flow.
    /// </summary>
    /// <param name="driver"></param>
    /// <param name="timeInSeconds"></param>
    public void Wait(IWebDriver driver, int timeInSeconds)
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeInSeconds);
    }

    /// <summary>
    /// Navigates to the application URL.
    /// </summary>
    /// <param name="driver"></param>
    public static void NavigateToApplicationUrl(IWebDriver driver)
    {
        driver.Navigate().GoToUrl(Helpers.Url);
    }

    /// <summary>
    /// Closes the web driver.
    /// </summary>
    /// <param name="driver"></param>
    public static void Close(IWebDriver driver) 
    {
        driver.Quit();
    }
}
