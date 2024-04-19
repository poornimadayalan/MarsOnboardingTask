using OpenQA.Selenium;
using ProjectMars.Utilities;
using ProjectMars.Utilities.Hooks;

namespace ProjectMars.Pages
{
    /// <summary>
    /// Class for sign in related actions.
    /// </summary>
    public class SignInPage : Hooks
    {
        private IWebElement signInButton => Driver.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[1]/div/a"));
        private IWebElement emailAddressTextBox => Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
        private IWebElement passwordTextBox => Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
        private IWebElement loginButton => Driver.driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
        
        /// <summary>
        /// Method to sign in to the application using the required credentials.
        /// </summary>
        /// <param name="driver"></param>
        public void SignInToApplication(IWebDriver driver)
        {
            Driver.NavigateToApplicationUrl(driver);
            signInButton.Click();
            emailAddressTextBox.SendKeys("stellabarrow18@gmail.com");
            passwordTextBox.SendKeys("123456");
            loginButton.Click();
        }
    }
}
