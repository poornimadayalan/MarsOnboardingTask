using NUnit.Framework;
using OpenQA.Selenium;
using ProjectMars.Pages;
using ProjectMars.Utilities;

namespace ProjectMars.StepDefinitions
{
    // <summary>
    /// Step definition for skill functionality in my profile.
    /// </summary>
    [Binding]
    public class MyProfileSkillsStep : Driver
    {
        ProfilePageSkills profilePageSkillObj = new ProfilePageSkills();

        [When(@"User clicks on the skill feature")]
        public void WhenUserClicksOnTheSkillFeature()
        {
            profilePageSkillObj.ClickOnTheSkillFeature();
            CleanupProfilePageForSkills();
        }

        [When(@"The user adds '([^']*)' skill with '([^']*)' experience level into the known skills list")]
        public void WhenTheUserAddsSkillWithExperienceLevelIntoTheKnownSkillsList(string skill, string experienceLevel)
        {
            profilePageSkillObj.AddSkillsWithExperienceLevel(skill, experienceLevel);
        }

        [Then(@"The '([^']*)' skill with '([^']*)' experience level should appear in the known skills list")]
        public void ThenTheSkillWithExperienceLevelShouldAppearInTheKnownSkillsList(string skill, string experienceLevel)
        {
            if (profilePageSkillObj.VerifyTheAddedSkill(skill, experienceLevel))
            {
                string actualSkillAndExperience = ProfilePageSkills.LastAddedSkillAndLevel.Text;
                string expectedSkillAndExperience = skill + " has been added to your skills";
                if (string.Equals(actualSkillAndExperience, expectedSkillAndExperience, StringComparison.OrdinalIgnoreCase))
                {
                    profilePageSkillObj.DeleteSkill(skill);
                    Assert.Pass(skill + " has been added to your skills");
                }
            }
            else
            {
                Assert.Fail(skill + " has not been added to your skills");
            }
        }

        [When(@"The user edits the '([^']*)' skill with '([^']*)' experience level from the known skills list")]
        public void WhenTheUserEditsTheSkillWithExperienceLevelFromTheKnownSkillsList(string skill, string experienceLevel)
        {
            profilePageSkillObj.EditSkillExperienceLevel(skill, experienceLevel);
        }

        [Then(@"The experience level for '([^']*)' skill should be updated to '([^']*)'")]
        public void ThenTheExperienceLevelForSkillShouldBeUpdatedTo(string skill, string experienceLevel)
        {
            if (profilePageSkillObj.VerifytheUpdatedSkillExperienceLevel(skill, experienceLevel))
            {
                Thread.Sleep(2000);
                string actualSkillAndExperience = ProfilePageSkills.UpdatedSkillAndLevel.Text;
                string expectedSkillAndExperience = skill + " has been updated to your skills";
                if (string.Equals(actualSkillAndExperience, expectedSkillAndExperience, StringComparison.OrdinalIgnoreCase))
                {
                    profilePageSkillObj.DeleteSkill(skill);
                    Assert.Pass(skill + " has been updated to your skills");
                }
            }
            else
            {
                Assert.Fail(skill + " has not been updated");
            }
        }

        [When(@"The User deletes the skill '([^']*)'")]
        public void WhenTheUserDeletesTheSkill(string skill)
        {
            profilePageSkillObj.DeleteSkill(skill);
        }

        [Then(@"The skill '([^']*)' should not be visible on the profile page")]
        public void ThenTheSkillShouldNotBeVisibleOnTheProfilePage(string skill)
        {
            if (profilePageSkillObj.VerifyTheSkillIsDeleted(skill))
            {
                Assert.Pass(skill + " has been deleted");
            }
            else
            {
                Assert.Fail(skill + " has not been deleted");
            }
        }

        [When(@"The user adds skill '([^']*)' with '([^']*)' experience level that is already displayed in their known skills list")]
        public void WhenTheUserAddsSkillWithExperienceLevelThatIsAlreadyDisplayedInTheirKnownSkillsList(string skill, string experienceLevel)
        {
            profilePageSkillObj.DuplicatedSkill(skill, experienceLevel);
        }

        [Then(@"The skill '([^']*)' should not be duplicated in the known skills list")]
        public void ThenTheSkillShouldNotBeDuplicatedInTheKnownSkillsList(string skill)
        {
            if (profilePageSkillObj.VerifySkillNotDuplicated(skill))
            {
                profilePageSkillObj.DeleteSkill(skill);
                Assert.Pass("This skill is already exist in your skill list.");
            }
            else
            {
                Assert.Fail("This skill has been added to your list.");
            }
        }

        [When(@"The user adds '([^']*)' skill with '([^']*)' experience level with the same name but different cases")]
        public void WhenTheUserAddsSkillWithExperienceLevelWithTheSameNameButDifferentCases(string skill, string experienceLevel)
        {
            profilePageSkillObj.SkillWithSameNameButdifferentCases(skill, experienceLevel);
        }

        [Then(@"The system should accept the same skill '([^']*)' with '([^']*)' experience level with different case")]
        public void ThenTheSystemShouldAcceptTheSameSkillWithExperienceLevelWithDifferentCase(string skill, string experienceLevel)
        {
            profilePageSkillObj.AddSkillsWithExperienceLevel(skill, experienceLevel);
            profilePageSkillObj.DeleteSkill(skill);
            profilePageSkillObj.DeleteSkill(skill);
        }

        [Then(@"The system should reject showcasing an empty '([^']*)' field and display an error message")]
        public void ThenTheSystemShouldRejectShowcasingAnEmptyFieldAndDisplayAnErrorMessage(string skill)
        {
            if (profilePageSkillObj.EmptyStringDisplayAnErrorMessageInTheSkill(skill))
            {
                Assert.Pass("Skill cannot be created with an empty value.");
            }
            else
            {
                Assert.Fail("Skill has been created with an empty value.");
            }
        }

        [When(@"The user adds '([^']*)' skill with '([^']*)' experience level  with the skill field containing only numbers")]
        public void WhenTheUserAddsSkillWithExperienceLevelWithTheSkillFieldContainingOnlyNumbers(string skill, string experienceLevel)
        {
            profilePageSkillObj.SkillFieldWithNumbers(skill, experienceLevel);
        }

        [When(@"The user adds '([^']*)' skill with '([^']*)' experience level with the skill field containing special characters")]
        public void WhenTheUserAddsSkillWithExperienceLevelWithTheSkillFieldContainingSpecialCharacters(string skill, string experienceLevel)
        {
            profilePageSkillObj.SkillFieldWithSpecialCharacters(skill, experienceLevel);
        }

        [When(@"The user adds '([^']*)' skill with '([^']*)' but refrains from selecting any experience level and leaves it at the default")]
        public void WhenTheUserAddsSkillWithButRefrainsFromSelectingAnyExperienceLevelAndLeavesItAtTheDefault(string skill, string experienceLevel)
        {
            profilePageSkillObj.InValidExperienceLevel(skill, experienceLevel);
        }

        private void CleanupProfilePageForSkills()
        {
            //Find all tables containing skills
           var tables = driver.FindElements(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table"));

            foreach (var table in tables)
            {
                //Check if the table has a tbody element
                try
                {
                    var tbody = table.FindElement(By.TagName("tbody"));

                    if (tbody != null)
                    {
                        //Find all rows(tr elements) within the tbody
                       var rows = tbody.FindElements(By.TagName("tr"));

                        foreach (var row in rows)
                        {
                            //Find the delete button for each skills
                            var deleteButton = driver.FindElement(By.CssSelector(".remove.icon"));

                            //Click the delete button
                            deleteButton.Click();
                            Thread.Sleep(2000);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No skills found to clean up in this table.");
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
