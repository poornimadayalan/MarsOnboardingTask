using NUnit.Framework;
using ProjectMars.Pages;
using ProjectMars.Utilities.Hooks;
using TechTalk.SpecFlow;

namespace ProjectMars.StepDefinitions
{
    /// <summary>
    /// Step definition for language functionality in my profile.
    /// </summary>
    [Binding]
    public class MyProfileLanguagesStep : Hooks
    {
        SignInPage signInPageObj = new SignInPage();
        ProfilePageLanguages profilePageObj = new ProfilePageLanguages();

        [Given(@"User logs into Mars application")]
        public void GivenUserLogsIntoMarsApplication()
        {
            signInPageObj.SignInToApplication(driver);
        }

        [When(@"User adds '([^']*)' language with '([^']*)' proficiency level into the known languages list")]
        public void WhenUserAddsLanguageWithProficiencyLevelIntoTheKnownLanguagesList(string language, string proficiencyLevel)
        {
            profilePageObj.AddLanguageWithProficiencyLevel(driver, language, proficiencyLevel);
        }

        [Then(@"The '([^']*)' language with '([^']*)' proficiency level should appear in the known languages list")]
        public void ThenTheLanguageWithProficiencyLevelShouldAppearInTheKnownLanguagesList(string language, string proficiencyLevel)
        {
            if (profilePageObj.VerifyTheAddedLanguage(driver, language, proficiencyLevel))
            {
                Assert.Pass(language + " language " + " with proficiency level " + proficiencyLevel + " has been added successfully");
            }
            else
            {
                Assert.Fail(language + " language " + " with proficiency level " + proficiencyLevel + " has not been added successfully");
            }
        }

        [When(@"User edits the '([^']*)' language with '([^']*)' proficiency level from the known languages list")]
        public void WhenUserEditsTheLanguageWithProficiencyLevelFromTheKnownLanguagesList(string language, string proficiencyLevel)
        {
            profilePageObj.EditLanguageProficiencyLevel(driver, language, proficiencyLevel);
        }

        [Then(@"The proficiency level for '([^']*)' language should be updated to '([^']*)'")]
        public void ThenTheProficiencyLevelForLanguageShouldBeUpdatedTo(string language, string proficiencyLevel)
        {
            if (profilePageObj.VerifyUpdatedLanguageProficiencyLevel(driver, language, proficiencyLevel))
            {
                Assert.Pass("Language with proficiency level has been updated successfully");
            }
            else
            {
                Assert.Fail("Language with proficiency level has not been updated successfully");
            }
        }

        [When(@"The User deletes the language '([^']*)'")]
        public void WhenTheUserDeletesTheLanguage(string language)
        {
            profilePageObj.DeleteLanguage(driver, language);
        }

        [Then(@"The language '([^']*)' should not be visible on the profile page")]
        public void ThenTheLanguageShouldNotBeVisibleOnTheProfilePage(string language)
        {
            if (profilePageObj.VerifyTheLanguageIsDeleted(driver, language))
            {
                Assert.Pass(language + " language " + " has been deleted successfully");
            }
            else
            {
                Assert.Fail(language + " language " + " has not been deleted successfully");
            }
        }

        [When(@"The user adds language '([^']*)' with '([^']*)' proficiency level that is already displayed in their known languages list")]
        public void WhenTheUserAddsLanguageWithProficiencyLevelThatIsAlreadyDisplayedInTheirKnownLanguagesList(string language, string proficiencyLevel)
        {
            profilePageObj.DuplicatedLanguage(driver, language, proficiencyLevel);
        }

        [Then(@"The language '([^']*)' should not be duplicated in the known languages list")]
        public void ThenTheLanguageShouldNotBeDuplicatedInTheKnownLanguagesList(string language)
        {
            if (profilePageObj.VerifyLanguageNotDuplicated(driver, language))
            {
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
            if(profilePageObj.EmptyStringDisplayAnErrorMessage(driver, language))
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
          profilePageObj.LanguageWithSameNameButdifferentCases(driver, language, proficiencyLevel);
        }

        [Then(@"The system should accept the same language '([^']*)' with '([^']*)' proficiency level with different case")]
        public void ThenTheSystemShouldAcceptTheSameLanguageWithProficiencyLevelWithDifferentCase(string language, string proficiencyLevel)
        {
            profilePageObj.VerifyTheAddedLanguage(driver, language, proficiencyLevel);
        }

    }
}