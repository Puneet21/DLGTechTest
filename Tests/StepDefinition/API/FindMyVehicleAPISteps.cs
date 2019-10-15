using DirectLineGroupTests.Support.API;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DirectLineGroupTests.Tests.StepDefinition.API
{
    [Binding]
    public sealed class FindMyVehicleAPISteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;
        
        FindMyVehicleAPI fmvApi;
        public FindMyVehicleAPISteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }

        [Given(@"I have FindMyVehicleAPI end point")]
        public void GivenIHaveFindMyVehicleAPIEndPoint()
        {
            //Creating Page Instance to call its methods
            fmvApi = new FindMyVehicleAPI();
            fmvApi.SetEndPoint();
        }

        [Given(@"I have a registration number for APIs - '(.*)'")]
        [Given(@"I have a registration number for API - '(.*)'")]
        public void GivenIHaveARegistrationNumberForAPI_(string RegistrationNumber)
        {
            //Adding context to be used in different steps
            context.Add("registrationNumber", RegistrationNumber);
           
        }


        [When(@"I call the FindMyVehicleAPI")]
        public void WhenICallTheFindMyVehicleAPI()
        {
            //Calling API and saving result in Context
            var codes = fmvApi.IsVehicleExists(context["registrationNumber"].ToString());
            context.Add("ActualStatusCode", codes["StatusCode"]);
            context.Add("ActualResponseCode", codes["ResponseCode"]);
        }

        [Then(@"I should see http response code - '(.*)'")]
        public void ThenIShouldSeeHttpResponseCode_(string ExpectedResponseCode)
        {
            //Vadidating Response Code
            String ActualResponseCode = context["ActualResponseCode"].ToString();
            Assert.IsTrue(ActualResponseCode.Equals(ExpectedResponseCode), "Response code is Incorrect : Actual -" + ActualResponseCode + ",Expected - " + ExpectedResponseCode);
        }


        [Then(@"I should see http status code - '(.*)'")]
        public void ThenIShouldSeeHttpStatusCode_(string ExpectedStatusCode)
        {
            //Validating Status Code
           String ActualStatusCode = context["ActualStatusCode"].ToString();
            Assert.IsTrue(ActualStatusCode.Equals(ExpectedStatusCode), "Status code is Incorrect : Actual -"+ ActualStatusCode + ",Expected - "+ExpectedStatusCode);
        }

    }
}
