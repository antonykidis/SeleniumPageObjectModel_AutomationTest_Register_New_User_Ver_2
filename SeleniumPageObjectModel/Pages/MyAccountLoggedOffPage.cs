using OpenQA.Selenium;
using SeleniumPageObjectModel.Base;

namespace SeleniumPageObjectModel.Pages
{
    public class MyAccountLoggedOffPage :BaseClass
    {
        private IWebDriver _Driver;
        private IWebElement EmailTextBox => _Driver.FindElement((By.Id("email")));
        private IWebElement PassWordTextBox => _Driver.FindElement((By.Id("passwd")));
        private IWebElement SubmitButton => _Driver.FindElement(By.Id("SubmitLogin"));

        public MyAccountLoggedOffPage(IWebDriver driver)
        {
            this._Driver = driver;
        }

        internal MyAccountPage Login_WithExistingUser(string email, string password)
        {
            EmailTextBox.SendKeys(email);
            PassWordTextBox.SendKeys(password);
            SubmitButton.Click();
            return new MyAccountPage(_Driver);
        }
    }
}