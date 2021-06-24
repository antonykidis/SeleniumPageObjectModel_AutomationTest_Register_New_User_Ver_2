using OpenQA.Selenium;
using SeleniumPageObjectModel.Base;
using System.Threading;

namespace SeleniumPageObjectModel.Pages
{
    public class AuthenticationPage : BaseClass // BaseClass serves WaitFindelement() method
    {
        //Properties
        private IWebDriver _Driver;
        private IWebElement EmailTextBox => _Driver.FindElement(By.CssSelector(".form-group>.is_required#email_create"));
        private IWebElement SubmitButton => _Driver.FindElement(By.CssSelector(".form_content >.submit>#SubmitCreate"));
        private IWebElement ErroMessage =>  _Driver.FindElement(By.CssSelector("#create_account_error"));

        public AuthenticationPage(IWebDriver driver)
        {
            this._Driver = driver;
        }

        public CreateAccountPage Login_ToCreateAnAccountPage(string email)
        {
            EmailTextBox.Clear();
            EmailTextBox.SendKeys(email);
            SubmitButton.Click();
            // Pause(_Driver, 4000);
            Thread.Sleep(4000);

            if (ErroMessage.Text.Length > 0)
            {
                return null;
            }
            else
            {
                return new CreateAccountPage(_Driver); //Passing driver to the next page
            }
        }
        public CreateAccountPage Login_ToCreateAnAccountPage2(string email)
        {
            EmailTextBox.Clear();
            EmailTextBox.SendKeys(email);
            SubmitButton.Click();
            // Pause(_Driver, 4000);
            Thread.Sleep(4000);
            if (this._Driver.Url.Equals("http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation"))
            {
                return new CreateAccountPage(_Driver); //Passing driver to the next page
            }
            return null;
        }

    }

}