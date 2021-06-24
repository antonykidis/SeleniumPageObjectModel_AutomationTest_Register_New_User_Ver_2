using OpenQA.Selenium;
using SeleniumPageObjectModel.Base;

namespace SeleniumPageObjectModel.Pages
{
    public class MyAccountPage : BaseClass
    {
        private IWebDriver _Driver;
        private IWebElement LogOffButton => _Driver.FindElement(By.CssSelector(".header_user_info>.logout"));
        public IWebElement Username => _Driver.FindElement(By.ClassName("account"));
        private IWebElement PassWord => _Driver.FindElement(By.CssSelector(".header_user_info>.logout"));

        public MyAccountPage(IWebDriver driver)
        {
            this._Driver = driver;
        }

        public MyAccountLoggedOffPage LogOff_ToAccLoggedOff()
        {

            LogOffButton.Click();

            return new MyAccountLoggedOffPage(_Driver);
        }

    }
}