using NLog;
using OpenQA.Selenium;
using ProjectMars.Constants;
using ProjectMars.Utilities.Hooks;

namespace ProjectMars.Pages
{
    /// <summary>
    /// Class for profile page related actions.
    /// </summary>
    public class ProfilePageSkills : Hooks
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Selects the skill feature from the my profile page
        /// </summary>
        /// <param name="driver"></param>
        public void ClickOnTheSkillFeature(IWebDriver driver)
        {
            ProfilePageSkillConstants.skillFeatureButton.Click();
        }

        /// <summary>
        /// Adds a skills to the known skills list.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="skill"></param>
        /// <param name="experienceLevel"></param>
        public void AddSkillsWithExperienceLevel(IWebDriver driver, string skill, string experienceLevel)
        {
            try
            {
                ProfilePageSkillConstants.addNewSkillButton.Click();
                ProfilePageSkillConstants.addSkillTextBox.SendKeys(skill);
                selectExperienceLevelForAdd(experienceLevel);
                ProfilePageSkillConstants.addSkillButton.Click();
            }
            catch (Exception exception)
            {
                logger.Error(exception, "An exception occurred while adding a new skill and experience level.");
            }
        }

        /// <summary>
        /// Verifies the added skill with experiance level.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="skill"></param>
        /// <param name="experienceLevel"></param>
        public Boolean VerifyTheAddedSkill(IWebDriver driver, string skill, string experienceLevel)
        {
            Boolean VerifyTheAddedSkill = false;
            Thread.Sleep(5000);
            string expectedSkillAndExperience = ProfilePageSkillConstants.lastAddedSkillAndLevel.Text;
            if (expectedSkillAndExperience.Contains(skill) && expectedSkillAndExperience.Contains(experienceLevel))
            {
                VerifyTheAddedSkill = true; 
            }

            return VerifyTheAddedSkill;
        }

        /// <summary>
        /// Edits the skill and/or experiance level from the known skills list.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="skill"></param>
        /// <param name="experienceLevel"></param>
        public void EditSkillExperienceLevel(IWebDriver driver, string skill, string experienceLevel)
        {
            Thread.Sleep(2000);
            ProfilePageSkillConstants.editSkillButton.Click();
            if (!skill.Equals("existing", StringComparison.OrdinalIgnoreCase))
            {
                ProfilePageSkillConstants.editSkillTextBox.Clear();
                ProfilePageSkillConstants.editSkillTextBox.SendKeys(skill);
            }
            Thread.Sleep(2000);
            selectExperienceLevelForEdit(experienceLevel);
            ProfilePageSkillConstants.updateSkillButton.Click();
        }

        /// <summary>
        /// Verifies the updated skill with experience level.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="skill"></param>
        /// <param name="experienceLevel"></param>
        public Boolean VerifytheUpdatedSkillExperienceLevel(IWebDriver driver, string skill, string experienceLevel)
        {
            Boolean VerifytheUpdatedSkillExperienceLevel = false;
            Thread.Sleep(2000);
            string updatedSkillAndExperience = ProfilePageSkillConstants.updatedSkillAndLevel.Text;
            if (skill.Equals("existing", StringComparison.OrdinalIgnoreCase))
            {
                if (updatedSkillAndExperience.Contains(experienceLevel))
                {
                    VerifytheUpdatedSkillExperienceLevel = true;
                }
                else
                {
                    VerifytheUpdatedSkillExperienceLevel = false;
                }
            }
            else
            {
                if (updatedSkillAndExperience.Contains(skill) && updatedSkillAndExperience.Contains(experienceLevel))
                {
                    VerifytheUpdatedSkillExperienceLevel = true;
                }
                else
                {
                    VerifytheUpdatedSkillExperienceLevel = false;
                }
            }

            return VerifytheUpdatedSkillExperienceLevel;
        }

        /// <summary>
        /// Deletes the skill from the known skills list.
        /// </summary>
        /// <param name="driver"></param>
        public void DeleteSkill(IWebDriver driver, string skill)
        {
            ProfilePageSkillConstants.deleteLastKnownSkill.Click();
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Verifies the skill is deleted.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="skill"></param>
        public Boolean verifyTheSkillIsDeleted(IWebDriver driver, string skill)
        {
            Boolean verifyTheSkillIsDeleted = false;
            Thread.Sleep(3000);
            if (ProfilePageSkillConstants.verifyTheSkillIsDeleted.Text.Contains("has been deleted", StringComparison.OrdinalIgnoreCase))
            {
                verifyTheSkillIsDeleted = true;
            }

            return verifyTheSkillIsDeleted;
        }

        /// <summary>
        /// Adds a duplicated skill to the known languages list.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="skill"></param>
        /// <param name="experienceLevel"></param>
        public void DuplicatedSkill(IWebDriver driver, string skill, string experienceLevel)
        {
            Thread.Sleep(2000);
            ProfilePageSkillConstants.addNewSkillButton.Click();
            Thread.Sleep(2000);
            ProfilePageSkillConstants.addSkillTextBox.SendKeys(skill);
            Thread.Sleep(2000);
            selectExperienceLevelForAdd(experienceLevel);
            ProfilePageSkillConstants.addSkillButton.Click();
        }

        /// <summary>
        /// Verifies if the skill has been duplicated.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="skill"></param>
        public Boolean VerifySkillNotDuplicated(IWebDriver driver, string skill)
        {
            Boolean VerifySkillNotDuplicated = false;
            Thread.Sleep(2000);
            if (ProfilePageSkillConstants.verifySkillNotDuplicated.Text.Contains("is already exist in your skill list.", StringComparison.OrdinalIgnoreCase))
            {
                VerifySkillNotDuplicated = true;  
            }
            
            return VerifySkillNotDuplicated;
        }

        /// <summary>
        /// Verifies the skill with the same name but different cases.
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="skill"></param>
        /// <param name="experienceLevel"></param>
        public void skillWithSameNameButdifferentCases(IWebDriver driver, string skill, string experienceLevel)
        {
                Thread.Sleep(2000);
                ProfilePageSkillConstants.addNewSkillButton.Click();
                ProfilePageSkillConstants.addSkillTextBox.SendKeys(skill);
                selectExperienceLevelForAdd(experienceLevel);
                ProfilePageSkillConstants.addSkillButton.Click();
        }
   
        /// <summary>
        ///  Verifies if a skill is passed as an empty string displays an error message. 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="skill"></param>
        public Boolean EmptyStringDisplayAnErrorMessageInTheSkill(IWebDriver driver, string skill)
        {
            Boolean EmptyStringDisplayAnErrorMessageInTheSkill = false;
            Thread.Sleep(3000);
            if (ProfilePageSkillConstants.emptyStringDisplayAnErrorMessageInTheSkill.Text.Contains("Please enter skill and experience" + " level", StringComparison.OrdinalIgnoreCase))
            {
                EmptyStringDisplayAnErrorMessageInTheSkill = true;
            }
            
            return EmptyStringDisplayAnErrorMessageInTheSkill;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="skill"></param>
        /// 
        private void selectExperienceLevelForAdd(string experienceLevel)
        {
            if (experienceLevel.Equals("beginner", StringComparison.OrdinalIgnoreCase))
            {
                ProfilePageSkillConstants.selectBeginnerProficiency.Click();
            }
            if (experienceLevel.Equals("intermediate", StringComparison.OrdinalIgnoreCase))
            {
                ProfilePageSkillConstants.selectIntermediateProficiency.Click();
            }
            if (experienceLevel.Equals("expert", StringComparison.OrdinalIgnoreCase))
            {
                ProfilePageSkillConstants.selectExpertProficiency.Click();
            }
        }

        private void selectExperienceLevelForEdit(string experienceLevel)
        {
            if (experienceLevel.Equals("beginner", StringComparison.OrdinalIgnoreCase))
            {
                ProfilePageSkillConstants.selectBeginnerExperienceForEdit.Click();
            }
            if (experienceLevel.Equals("intermediate", StringComparison.OrdinalIgnoreCase))
            {
                ProfilePageSkillConstants.selectIntermediateExperienceForEdit.Click();
            }
            if (experienceLevel.Equals("expert", StringComparison.OrdinalIgnoreCase))
            {
                ProfilePageSkillConstants.selectExpertExperienceForEdit.Click();
            }
        }
    }
}
