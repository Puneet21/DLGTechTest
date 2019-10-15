using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using DirectLineGroupTests.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using DirectLineGroupTests.Tests.Features.Hooks;
using DirectLineGroupTests.Driver;

namespace DirectLineGroupTests.Tests.StepDefinition.UI
{
    [Binding]
    public sealed class FindMyVehicleSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private ScenarioContext context;
        FindMyVehicle fmv;
        public FindMyVehicleSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"I am on VFS - FindMyVehicle page")]
        public void GivenIAmOnVFS_FindMyVehiclePage()
        {
            //Calling URL
            Browser.NavigateToURL(Settings.ProjectSettings.Default.UIUrl);
        }

        [Given(@"I have a registration number - '(.*)'")]
        public void GivenIHaveARegistrationNumber_(string RegistrationNumber)
        {
            //Add Scenario Context
            context.Add("registrationNumber", RegistrationNumber);
        }

        [When(@"I enter registration number in text field")]
        public void WhenIEnterRegistrationNumberInTextField()
        {
            //Creating Instance to Call methods of Page
            fmv = new FindMyVehicle();
            fmv.AddRegistrationToTextBox(context["registrationNumber"].ToString());
        }

        [When(@"I click on '(.*)' button")]
        public void WhenIClickOnButton(string buttonName)
        {
            //Clicking on 
            fmv.ClickOnFIndVehicleButton();
         
        }

        [Then(@"I should see the result as '(.*)'")]
        public void ThenIShouldSeeTheResultAs(string expectedResult)
        {
            //Adding Error text and Result text to string to validate
            String actualResults = String.Empty;
            actualResults += fmv.getErrorText();
            actualResults += fmv.getResultText();
            Assert.IsTrue(actualResults.Equals(expectedResult), "Error/Result message is not working correctly");
        }
    }
}
