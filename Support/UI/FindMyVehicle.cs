using DirectLineGroupTests.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectLineGroupTests.Support.UI
{
    public class FindMyVehicle
    {

        //DOM
        #region Repository
        private IWebElement RegNumber => Browser.driver.FindElement(By.Id("vehicleReg"));
        private IWebElement FindVehicle => Browser.driver.FindElement(By.Name("btnfind"));
        private IWebElement ErrorText => Browser.driver.FindElement(By.ClassName("error-required"));
        private IWebElement ResulText => Browser.driver.FindElement(By.ClassName("result"));
        #endregion

        public void AddRegistrationToTextBox(String registrationNumber)
        {
            RegNumber.SendKeys(registrationNumber);
        }

        public void ClickOnFIndVehicleButton()
        {
            FindVehicle.Click();
        }

        public string getErrorText()
        {
            try
            {
                return ErrorText.Text.Trim();
            }
            catch (Exception e)
            {
                return String.Empty;
            }
        }

        public string getResultText()
        {
            try
            {
                return ResulText.Text.Trim();
            }
            catch (Exception e)
            {
                return String.Empty;
            }
        }



    }
}
