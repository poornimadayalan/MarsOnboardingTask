using NUnit.Framework;
using OpenQA.Selenium;
using ProjectMars.Pages;
using ProjectMars.Utilities;

namespace ProjectMars.StepDefinitions
{
    /// <summary>
    /// Step definition for language functionality in my profile.
    /// </summary>
    [Binding]
    public class MyProfileLanguagesStep : Driver
    {
        SignInPage signInPageObj = new SignInPage();
        ProfilePageLanguages profilePageObj = new ProfilePageLanguages();

        [Given(@"User logs into Mars application")]
        public void GivenUserLogsIntoMarsApplication()
        {
            signInPageObj.SignInToApplication();
            CleanupProfilePage();
        }

        [When(@"User adds '([^']*)' language with '([^']*)' proficiency level into the known languages list")]
        public void WhenUserAddsLanguageWithProficiencyLevelIntoTheKnownLanguagesList(string language, string proficiencyLevel)
        {
            profilePageObj.AddLanguageWithProficiencyLevel(language, proficiencyLevel);
        }

        [Then(@"The '([^']*)' language with '([^']*)' proficiency level should appear in the known languages list")]
        public void ThenTheLanguageWithProficiencyLevelShouldAppearInTheKnownLanguagesList(string language, string proficiencyLevel)
        {
            if (profilePageObj.VerifyTheAddedLanguage(language, proficiencyLevel))
            {
                string actualLanguageAndProficiency = ProfilePageLanguages.LastAddedLanguageAndLevel.Text;
                string expectedLanguageAndProficiency = language + " has been added to your languages";
                if (string.Equals(actualLanguageAndProficiency, expectedLanguageAndProficiency, StringComparison.OrdinalIgnoreCase))
                {
                    profilePageObj.DeleteLanguage(language);
                    Assert.Pass(language + " has been added successfully");
                }
            }
            else
            {
                Assert.Fail(language + " has not been added successfully");
            }
        }

        [When(@"User edits the '([^']*)' language with '([^']*)' proficiency level from the known languages list")]
        public void WhenUserEditsTheLanguageWithProficiencyLevelFromTheKnownLanguagesList(string language, string proficiencyLevel)
        {
            profilePageObj.EditLanguageProficiencyLevel(language, proficiencyLevel);
        }

        [Then(@"The proficiency level for '([^']*)' language should be updated to '([^']*)'")]
        public void ThenTheProficiencyLevelForLanguageShouldBeUpdatedTo(string language, string proficiencyLevel)
        {
            if (profilePageObj.VerifyUpdatedLanguageProficiencyLevel(language, proficiencyLevel))
            {
                Thread.Sleep(2000);
                string actualLanguageAndProficiency = ProfilePageLanguages.UpdatedLanguageAndLevel.Text;
                string expectedLanguageAndProficiency = language + " has been updated to your languages";
                if (string.Equals(actualLanguageAndProficiency, expectedLanguageAndProficiency, StringComparison.OrdinalIgnoreCase))
                {
                    profilePageObj.DeleteLanguage(language);
                    Assert.Pass(language + " has been updated to your languages");
                }
            }
            else
            {
                Assert.Fail(language + " has not been updated to your languages");
            }
        }

        [When(@"The User deletes the language '([^']*)'")]
        public void WhenTheUserDeletesTheLanguage(string language)
        {
            profilePageObj.DeleteLanguage(language);
        }

        [Then(@"The language '([^']*)' should not be visible on the profile page")]
        public void ThenTheLanguageShouldNotBeVisibleOnTheProfilePage(string language)
        {
            if (profilePageObj.VerifyTheLanguageIsDeleted(language))
            {
                Assert.Pass(language + " has been deleted successfully");
            }
            else
            {
                Assert.Fail(language + " has not been deleted successfully");
            }
        }

        [When(@"The user adds language '([^']*)' with '([^']*)' proficiency level that is already displayed in their known languages list")]
        public void WhenTheUserAddsLanguageWithProficiencyLevelThatIsAlreadyDisplayedInTheirKnownLanguagesList(string language, string proficiencyLevel)
        {
            profilePageObj.DuplicatedLanguage(language, proficiencyLevel);
        }

        [Then(@"The language '([^']*)' should not be duplicated in the known languages list")]
        public void ThenTheLanguageShouldNotBeDuplicatedInTheKnownLanguagesList(string language)
        {
            if (profilePageObj.VerifyLanguageNotDuplicated(language))
            {
                profilePageObj.DeleteLanguage(language);
                Assert.Pass(language + " language " + " is already exist in your language list.");
            }
            else
            {
                Assert.Fail(language + " language " + " has been added to your list");
            }
        }

        [Then(@"The system should reject showcasing an empty '([^']*)' and display an error message")]
        public void ThenTheSystemShouldRejectShowcasingAnEmptyAndDisplayAnErrorMessage(string language)
        {
            if (profilePageObj.EmptyStringDisplayAnErrorMessage(language))
            {
                Assert.Pass(language + "cannot be created with an empty value.");
            }
            else
            {
                Assert.Fail(language + "has been created with an empty value.");
            }
        }

        [When(@"The user adds '([^']*)' language with '([^']*)' proficiency level with the same name but different cases")]
        public void WhenTheUserAddsLanguageWithProficiencyLevelWithTheSameNameButDifferentCases(string language, string proficiencyLevel)
        {
            profilePageObj.LanguageWithSameNameButdifferentCases(language, proficiencyLevel);
        }

        [Then(@"The system should accept the same language '([^']*)' with '([^']*)' proficiency level with different case")]
        public void ThenTheSystemShouldAcceptTheSameLanguageWithProficiencyLevelWithDifferentCase(string language, string proficiencyLevel)
        {
            profilePageObj.VerifyTheAddedLanguage(language, proficiencyLevel);
            profilePageObj.DeleteLanguage(language);
            profilePageObj.DeleteLanguage(language);
        }

        [When(@"The user adds '([^']*)' language with '([^']*)' proficiency level with language field containing only numbers")]
        public void WhenTheUserAddsLanguageWithProficiencyLevelWithLanguageFieldContainingOnlyNumbers(string language, string proficiencyLevel)
        {
            profilePageObj.LanguageFieldContainsNumber(language, proficiencyLevel);
        }

        [When(@"The user adds '([^']*)' language with '([^']*)' proficiency level with the language field containing special characters")]
        public void WhenTheUserAddsLanguageWithProficiencyLevelWithTheLanguageFieldContainingSpecialCharacters(string language, string proficiencyLevel)
        {
            profilePageObj.LanguageFieldContainsSpecialCharacter(language, proficiencyLevel);
        }

        [When(@"The user adds '([^']*)' language with '([^']*)' but refrains from selecting any proficiency level and leaves it at the default")]
        public void WhenTheUserAddsLanguageWithButRefrainsFromSelectingAnyProficiencyLevelAndLeavesItAtTheDefault(string language, string proficiencyLevel)
        {
            profilePageObj.InvalidProficiencyLevel(language, proficiencyLevel);
        }

        private void CleanupProfilePage()
        {
            // Find all tables containing languages
            var tables = driver.FindElements(By.TagName("table"));

            foreach (var table in tables)
            {
                // Check if the table has a tbody element
                try
                {
                    var tbody = table.FindElement(By.TagName("tbody"));

                    if (tbody != null)
                    {
                        // Find all rows (tr elements) within the tbody
                        var rows = tbody.FindElements(By.TagName("tr"));

                        foreach (var row in rows)
                        {
                            // Find the delete button for each language
                            var deleteButton = driver.FindElement(By.CssSelector(".remove.icon"));

                            // Click the delete button
                            deleteButton.Click();
                            Thread.Sleep(2000);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No languages found to clean up in this table.");
                    }
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("No tbody found in this table.");
                    break;
                }
            }
        }
    }
}