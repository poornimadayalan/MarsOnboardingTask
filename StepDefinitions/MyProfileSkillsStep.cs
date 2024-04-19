using NUnit.Framework;
using ProjectMars.Pages;
using ProjectMars.Utilities.Hooks;
using TechTalk.SpecFlow;

namespace ProjectMars.StepDefinitions
{
    // <summary>
    /// Step definition for skill functionality in my profile.
    /// </summary>
    public class MyProfileSkillsStep : Hooks
    {
        ProfilePageSkills profilePageSkillObj = new ProfilePageSkills();

        [When(@"User clicks on the skill feature")]
        public void WhenTheUserClicksOnTheSkillFeature()
        {
            profilePageSkillObj.ClickOnTheSkillFeature(driver);
        }

        [When(@"The user adds '([^']*)' skill with '([^']*)' experience level into the known skills list")]
        public void WhenUserAddsSkillWithexperienceLevelIntoTheKnownSkillsList(string skill, string experienceLevel)
        {
            profilePageSkillObj.AddSkillsWithExperienceLevel(driver, skill, experienceLevel);
        }

        [Then(@"The '([^']*)' skill with '([^']*)' experience level should appear in the known skills list")]
        public void ThenTheSkillWithexperienceLevelShouldAppearInTheKnownSkillsList(string skill, string experienceLevel)
        {
            if(profilePageSkillObj.VerifyTheAddedSkill(driver, skill, experienceLevel))
            {
                Assert.Pass(skill + " skill " + " with experience level " + experienceLevel + " has been added successfully.");
            }
            else
            {
                Assert.Fail(skill + " skill " + " with experience level " + experienceLevel + " has not been added successfully.");
            }
        }

        [When(@"The user edits the '([^']*)' skill with '([^']*)' experience level from the known skills list")]
        public void WhenTheUserEditsTheSkillWithexperienceLevelFromTheKnownSkillsList(string skill, string experienceLevel)
        {
            profilePageSkillObj.EditSkillExperienceLevel(driver, skill, experienceLevel);
        }

        [Then(@"The experience level for '([^']*)' skill should be updated to '([^']*)'")]
        public void ThenTheexperienceLevelForSkillShouldBeUpdatedTo(string skill, string experienceLevel)
        {
            if (profilePageSkillObj.VerifytheUpdatedSkillExperienceLevel(driver, skill, experienceLevel))
            {
                Assert.Pass("Experience level and skill has been updated successfully.");
            }
            else
            {
                Assert.Fail("Experience level and skill has not been updated successfully.");
            }
        }

        [When(@"The User deletes the skill '([^']*)'")]
        public void WhenTheUserDeletesTheSkill(string skill)
        {
            profilePageSkillObj.DeleteSkill(driver, skill);
        }

        [Then(@"The skill '([^']*)' should not be visible on the profile page")]
        public void ThenTheSkillShouldNotBeVisibleOnTheProfilePage(string skill)
        {
            if(profilePageSkillObj.verifyTheSkillIsDeleted(driver, skill))
            {
                Assert.Pass(skill + " skill " + " has been deleted successfully.");
            }
            else
            {
                Assert.Fail(skill + " skill " + " has not been deleted successfully.");
            }
        }

        [When(@"The user adds skill '([^']*)' with '([^']*)' experience level that is already displayed in their known skills list")]
        public void WhenTheUserAddsSkillWithExperienceLevelThatIsAlreadyDisplayedInTheirKnownSkillsList(string skill, string experienceLevel)
        {
            profilePageSkillObj.DuplicatedSkill(driver, skill, experienceLevel);
        }

        [Then(@"The skill '([^']*)' should not be duplicated in the known skills list")]
        public void ThenTheSkillShouldNotBeDuplicatedInTheKnownSkillsList(string skill)
        {
            if(profilePageSkillObj.VerifySkillNotDuplicated(driver, skill))
            {
                Assert.Pass(skill + " skill " + " is already exist in your skill list.");
            }
            else
            {
                Assert.Fail(skill + " skill " + " has been added to your list");
            }
        }

        [When(@"The user adds '([^']*)' skill with '([^']*)' experience level with the same name but different cases")]
        public void WhenTheUserAddsSkillWithExperienceLevelWithTheSameNameButDifferentCases(string skill, string experienceLevel)
        {
            profilePageSkillObj.skillWithSameNameButdifferentCases(driver, skill, experienceLevel);
        }

        [Then(@"The system should accept the same skill '([^']*)' with '([^']*)' experience level with different case")]
        public void ThenTheSystemShouldAcceptTheSameSkillWithExperienceLevelWithDifferentCase(string skill, string experienceLevel)
        {
            profilePageSkillObj.AddSkillsWithExperienceLevel(driver, skill, experienceLevel);   
        }


        [Then(@"The system should reject showcasing an empty '([^']*)' field and display an error message")]
        public void ThenTheSystemShouldRejectShowcasingAnEmptyFieldAndDisplayAnErrorMessage(string skill)
        {
            if(profilePageSkillObj.EmptyStringDisplayAnErrorMessageInTheSkill(driver, skill))
            {
                Assert.Pass("Skill cannot be created with an empty value.");
            }
            else
            {
                Assert.Fail("Skill has been created with an empty value.");
            }
        }
    }
}
