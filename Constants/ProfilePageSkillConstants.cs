using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMars.Utilities;
using ProjectMars.Utilities.Hooks;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ProjectMars.Constants
{
    // <summary>
    /// Holds constants for Profile page skill functionality.
    /// </summary>
    public class ProfilePageSkillConstants : Hooks
    {
        //Constants for Scenario 1. Verify user is able to add known skills with experience level
        public static IWebElement skillFeatureButton => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
        public static IWebElement addNewSkillButton => Driver.driver.FindElement(By.XPath("//div[@class='ui teal button']"));
        public static IWebElement addSkillTextBox => Driver.driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        public static IWebElement selectBeginnerProficiency => Driver.driver.FindElement(By.XPath("//option[@value='Beginner']"));
        public static IWebElement selectIntermediateProficiency => Driver.driver.FindElement(By.XPath("//option[@value='Intermediate']"));
        public static IWebElement selectExpertProficiency => Driver.driver.FindElement(By.XPath("//option[@value='Expert']"));
        public static IWebElement addSkillButton => Driver.driver.FindElement(By.XPath("//input[@value='Add']"));
        public static IWebElement lastAddedSkillAndLevel => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]"));

        //Constants for Scenario 2. Verify user is able to edit an existing known skill with experience level
        public static IWebElement editSkillButton => Driver.driver.FindElement(By.XPath("//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[last()]/tr[1]/td[3]/span[1]"));
        public static IWebElement selectBeginnerExperienceForEdit => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[2]"));
        public static IWebElement selectIntermediateExperienceForEdit => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[3]"));
        public static IWebElement selectExpertExperienceForEdit => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/div[2]/select/option[4]"));
        public static IWebElement updateSkillButton => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/span/input[1]"));
        public static IWebElement updatedSkillAndLevel => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]"));

        //Constants for Scenario 3. Verify user is able to edit a experience level from the known language
        public static IWebElement editSkillTextBox => Driver.driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td/div/div[1]/input"));

        //Constants for Scenario 4. Verify user is able to delete an existing known skill
        public static IWebElement deleteLastKnownSkill => Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[last()]/tr/td[3]/span[2]"));
        public static IWebElement verifyTheSkillIsDeleted => Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //Constants for Scenario 5. Verify user attempting to add a language already present in the known languages list
        public static IWebElement verifySkillNotDuplicated => Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //Constants for Scenario 6. Verify user tries to add a skill with the same name but different cases
        public static IWebElement verifyTheSystemRejectsShowcasingTheSameSkill => Driver.driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));

        //Constants for Scenario 7. Verify that the system rejects saving an empty skill field with the chosen experience level in the skill profile section
        public static IWebElement emptyStringDisplayAnErrorMessageInTheSkill => Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]"));
    }
}
