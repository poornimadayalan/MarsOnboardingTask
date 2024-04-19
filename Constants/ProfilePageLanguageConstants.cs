using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMars.Utilities;
using ProjectMars.Utilities.Hooks;
using OpenQA.Selenium;

namespace ProjectMars.Constants
{
    /// <summary>
    /// Holds constants for Profile page language functionality.
    /// </summary>
    public class ProfilePageLanguageConstants : Hooks
    {
        //Constants for Scenario 1. Verify user is able to add known languages with proficiency level
        public static IWebElement AddNewButton => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div"));
        public static IWebElement AddLanguageTextBox => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input"));
        public static IWebElement SelectBasicProficiency => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[2]"));
        public static IWebElement SelectConversationalProficiency => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[3]"));
        public static IWebElement SelectFluentProficiency => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[4]"));
        public static IWebElement SelectNativeProficiency => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[5]"));
        public static IWebElement AddLanguageButton => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[3]/input[1]"));
        public static IWebElement LastAddedLanguageAndLevel => Driver.driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[last()]/tr[1]"));

        //Constants for Scenario 2. Verify user is able to edit an existing known language with proficiency level
        public static IWebElement ClickOnTheEditButton => Driver.driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[last()]/tr[1]/td[3]/span[1]/i[1]"));
        public static IWebElement SelectBasicProficiencyForEdit => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[2]/select/option[2]"));
        public static IWebElement SelectConversationalProficiencyForEdit => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[2]/select/option[3]"));
        public static IWebElement SelectFluentProficiencyForEdit => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[2]/select/option[4]"));
        public static IWebElement SelectNativeProficiencyForEdit => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[2]/select/option[5]"));
        public static IWebElement UpdateButton => Driver.driver.FindElement(By.XPath("//input[@value='Update']"));
        public static IWebElement UpdatedLanguageAndLevel => Driver.driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[last()]/tr[1]"));

        //Constants for Scenario 3. Verify user is able to edit a proficiency level from the known language  
        public static IWebElement EditLanguageTextBox => Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));

        //Constants for Scenario 4. Verify user is able to delete an existing known language
        public static IWebElement DeleteLastKnownLanguage => Driver.driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[last()]/tr[1]/td[3]/span[2]/i[1]"));
        public static IWebElement VerifyTheLanguageIsDeleted => Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //Constants for Scenario 5. Verify user attempting to add a language already present in the known languages list
        public static IWebElement VerifyLanguageNotDuplicated => Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //Constants for Scenario 6. Verify that the system rejects saving an empty language field with the chosen proficiency level in the language profile section
        public static IWebElement EmptyStringDisplayAnErrorMessage => Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]"));

        //Constants for Scenario 7. Verify user tries to add a language with the same name but different cases
        public static IWebElement VerifyTheSystemRejectsShowcasingTheSameLanguage => Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
    }
}
