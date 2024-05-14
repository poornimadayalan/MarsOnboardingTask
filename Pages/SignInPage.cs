using OpenQA.Selenium;
using ProjectMars.Utilities;

namespace ProjectMars.Pages
{
    /// <summary>
    /// Class for sign in related actions.
    /// </summary>
    public class SignInPage : Driver
    {
        // Constructor
        public SignInPage()
        {
        }
        private IWebElement signInButton => driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div[1]/div/a"));
        private IWebElement emailAddressTextBox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
        private IWebElement passwordTextBox => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
        private IWebElement loginButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
        
        /// <summary>
        /// Method to sign in to the application using the required credentials.
        /// </summary>
        public void SignInToApplication()
        {
            Driver.NavigateToApplicationUrl(driver);
            signInButton.Click();
            emailAddressTextBox.SendKeys("stellabarrow18@gmail.com");
            passwordTextBox.SendKeys("123456");
            loginButton.Click();
        }

    }
}
