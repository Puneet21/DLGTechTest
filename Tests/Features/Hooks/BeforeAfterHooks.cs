using DirectLineGroupTests.Driver;
using DirectLineGroupTests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DirectLineGroupTests.Tests.Features.Hooks
{
    [Binding]
    public sealed class BeforeAfterHooks
    {
        [BeforeScenario]
        [Scope(Tag="browser")]
        public void BeforeScenario()
        {


            //TODO: implement logic that has to run before executing each scenario
            Logger.Info("Calling Before Scenario");
            Browser.SetBrowser("Chrome");
        }

        [AfterScenario]
        [Scope(Tag = "browser")]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            Logger.Info("Calling After Scenario");
            Browser.driver.Quit();
           
        }
    }
}
