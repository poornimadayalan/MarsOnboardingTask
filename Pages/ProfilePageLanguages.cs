using NLog;
using OpenQA.Selenium;
using ProjectMars.Constants;
using ProjectMars.Utilities.Hooks;

namespace ProjectMars.Pages
{
    /// <summary>
    /// Class for profile page language related actions.
    /// </summary>
    public class ProfilePageLanguages : Hooks
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Adds a language to the known laguages list.
        /// </summary>
        /// <param name="driver"></param>
        public void AddLanguageWithProficiencyLevel(IWebDriver driver, string language, string proficiencyLevel)
        {
            try
            {
                ProfilePageLanguageConstants.AddNewButton.Click();
                ProfilePageLanguageConstants.AddLanguageTextBox.SendKeys(language);
                SelectProficiencyLevelForAdd(proficiencyLevel);
                ProfilePageLanguageConstants.AddLanguageButton.Click();
            }
            catch (Exception exception)
            {
                logger.Error(exception, "An exception occurred while adding a new language and proficiency level.");
            }
        }
        /// <summary>
        /// Verifies the added language with proficiency level.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="language"></param>
        /// <param name="proficiencyLevel"></param>
        public Boolean VerifyTheAddedLanguage(IWebDriver driver, string language, string proficiencyLevel)
        {
            Boolean VerifyTheAddedLanguage = false;
            Thread.Sleep(2000);
            string expectedLanguageAndProficiency = ProfilePageLanguageConstants.LastAddedLanguageAndLevel.Text;
            if (expectedLanguageAndProficiency.Contains(language) && expectedLanguageAndProficiency.Contains(proficiencyLevel))
            {
                VerifyTheAddedLanguage = true;
            }

            return VerifyTheAddedLanguage;
        }

        /// <summary>
        /// Edits the language and/or proficiency level from the known languages list.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="language"></param>
        /// <param name="proficiencyLevel"></param>
        public void EditLanguageProficiencyLevel(IWebDriver driver, string language, string proficiencyLevel)
        {
            Thread.Sleep(2000);
            ProfilePageLanguageConstants.ClickOnTheEditButton.Click();
            if (!language.Equals("existing", StringComparison.OrdinalIgnoreCase))
            {
                ProfilePageLanguageConstants.EditLanguageTextBox.Clear();
                ProfilePageLanguageConstants.EditLanguageTextBox.SendKeys(language);
            }
            Thread.Sleep(2000);
            SelectProficiencyLevelForEdit(proficiencyLevel);
            ProfilePageLanguageConstants.UpdateButton.Click();
        }

        /// <summary>
        /// Verifies the updated language with proficiency level.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="language"></param>
        /// <param name="proficiencyLevel"></param>
        public Boolean VerifyUpdatedLanguageProficiencyLevel(IWebDriver driver, string language, string proficiencyLevel)
        {
            Boolean VerifyUpdatedLanguageProficiencyLevel = false;
            Thread.Sleep(2000);
            string updatedLanguageAndProficiency = ProfilePageLanguageConstants.UpdatedLanguageAndLevel.Text;
            if (language.Equals("existing", StringComparison.OrdinalIgnoreCase))
            {
                if (updatedLanguageAndProficiency.Contains(proficiencyLevel))
                {
                    VerifyUpdatedLanguageProficiencyLevel = true; 
                }
                else
                {
                    VerifyUpdatedLanguageProficiencyLevel = false;
                }
            }
            else
            {
                if (updatedLanguageAndProficiency.Contains(language) && updatedLanguageAndProficiency.Contains(proficiencyLevel))
                {
                    VerifyUpdatedLanguageProficiencyLevel = true;
                }
                else
                {
                    VerifyUpdatedLanguageProficiencyLevel = false;
                }
            }

            return VerifyUpdatedLanguageProficiencyLevel;
        }

        /// <summary>
        /// Deletes the language from the known languages list.
        /// </summary>
        /// <param name="driver"></param>
        public void DeleteLanguage(IWebDriver driver, string language)
        {
            ProfilePageLanguageConstants.DeleteLastKnownLanguage.Click();
        }

        /// <summary>
        /// Verifies the language is deleted. 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="language"></param>
        public Boolean VerifyTheLanguageIsDeleted(IWebDriver driver, string language)
        {
            Boolean VerifyTheLanguageIsDeleted = false;
            Wait(driver, 2);
            if (ProfilePageLanguageConstants.VerifyTheLanguageIsDeleted.Text.Contains("has been deleted from your languages", StringComparison.OrdinalIgnoreCase))
            {
                VerifyTheLanguageIsDeleted = true;
            }

            return VerifyTheLanguageIsDeleted;
        }

        /// <summary>
        /// Adds a duplicated language to the known languages list.
        /// </summary>
        /// <param name="proficiencyLevel"></param>
        public void DuplicatedLanguage(IWebDriver driver, string language, string proficiencyLevel)
        {
                Thread.Sleep(2000);
                ProfilePageLanguageConstants.AddNewButton.Click();
                Thread.Sleep(2000);
                ProfilePageLanguageConstants.AddLanguageTextBox.SendKeys(language);
                Thread.Sleep(2000);
                SelectProficiencyLevelForAdd(proficiencyLevel);
                ProfilePageLanguageConstants.AddLanguageButton.Click();      
        }

        /// <summary>
        /// Verifies if the language has been duplicated.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="language"></param>
        public Boolean VerifyLanguageNotDuplicated(IWebDriver driver, string language)
        {
            Boolean VerifyLanguageNotDuplicated = false;
            Thread.Sleep(2000);
            if (ProfilePageLanguageConstants.VerifyLanguageNotDuplicated.Text.Contains("is already exist in your language list.", StringComparison.OrdinalIgnoreCase))
            {
                VerifyLanguageNotDuplicated = true;
            }

            return VerifyLanguageNotDuplicated;
        }

        /// <summary>
        /// Verifies if a language is passed as an empty string displays an error message. 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="language"></param>
        public Boolean EmptyStringDisplayAnErrorMessage(IWebDriver driver, string language)
        {
            Boolean EmptyStringDisplayAnErrorMessage = false;
            Thread.Sleep(3000);
            if (ProfilePageLanguageConstants.EmptyStringDisplayAnErrorMessage.Text.Contains("Please enter language and level", StringComparison.OrdinalIgnoreCase))
            {
                EmptyStringDisplayAnErrorMessage = true;
            }
 
            return EmptyStringDisplayAnErrorMessage;
        }

        /// <summary>
        /// Verifies the language with the same name but different cases.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="language"></param>
        /// <param name="proficiencyLevel"></param>
        public void LanguageWithSameNameButdifferentCases(IWebDriver driver, string language, string proficiencyLevel)
        {
            Thread.Sleep(2000);
            ProfilePageLanguageConstants.AddNewButton.Click();
            ProfilePageLanguageConstants.AddLanguageTextBox.SendKeys(language);
            SelectProficiencyLevelForAdd(proficiencyLevel);
            ProfilePageLanguageConstants.AddLanguageButton.Click();
        }

        private void SelectProficiencyLevelForAdd(string proficiencyLevel)
        {
            if (proficiencyLevel.Equals("basic", StringComparison.OrdinalIgnoreCase))
            {
                ProfilePageLanguageConstants.SelectBasicProficiency.Click();
            }
            if (proficiencyLevel.Equals("conversational", StringComparison.OrdinalIgnoreCase))
            {
                ProfilePageLanguageConstants.SelectConversationalProficiency.Click();
            }
            if (proficiencyLevel.Equals("fluent", StringComparison.OrdinalIgnoreCase))
            {
                ProfilePageLanguageConstants.SelectFluentProficiency.Click();
            }
            if (proficiencyLevel.Equals("native", StringComparison.OrdinalIgnoreCase))
            {
                ProfilePageLanguageConstants.SelectNativeProficiency.Click();
            }
        }

        private void SelectProficiencyLevelForEdit(string proficiencyLevel)
        {
            if (proficiencyLevel.Equals("basic", StringComparison.OrdinalIgnoreCase))
            {
                ProfilePageLanguageConstants.SelectBasicProficiencyForEdit.Click();
            }
            if (proficiencyLevel.Equals("conversational", StringComparison.OrdinalIgnoreCase))
            {
                ProfilePageLanguageConstants.SelectConversationalProficiencyForEdit.Click();
            }
            if (proficiencyLevel.Equals("fluent", StringComparison.OrdinalIgnoreCase))
            {
                ProfilePageLanguageConstants.SelectFluentProficiencyForEdit.Click();
            }
            if (proficiencyLevel.Equals("native", StringComparison.OrdinalIgnoreCase))
            {
                ProfilePageLanguageConstants.SelectNativeProficiencyForEdit.Click();
            }
        }
    }
}