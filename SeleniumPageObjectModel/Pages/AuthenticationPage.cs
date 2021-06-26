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
        private string _ErrorMessage ="";
        public AuthenticationPage(IWebDriver driver)
        {
            this._Driver = driver;
            this._ErrorMessage = this.ErroMessage.Text;
        }

        public CreateAccountPage Login_ToCreateAnAccountPage(string email)
        {
            EmailTextBox.Clear();
            EmailTextBox.SendKeys(email);
            SubmitButton.Click();
            // Pause(_Driver, 4000);
            Thread.Sleep(2000);
            if (_Driver.Url == "http://automationpractice.com/index.php?controller=authentication&back=my-account" && ErroMessage.Text.Length > 0)
            {
                //Error  was shown
                return null;
            }
            else
            {
                //No error was shown
                return new CreateAccountPage(_Driver); //Passing driver to the next page
            }
        }
        public CreateAccountPage Login_ToCreateAnAccountPage2(string email)
        {
            EmailTextBox.Clear();
            EmailTextBox.SendKeys(email);
            SubmitButton.Click();
            // Pause(_Driver, 4000);
            Thread.Sleep(2000);
            if (this._Driver.Url.Equals("http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation"))
            {
                //Email was generated successfully
                return new CreateAccountPage(_Driver); //Passing driver to the next page
            }
            return null; //Email was generated badly!!!!
        }

    }

}