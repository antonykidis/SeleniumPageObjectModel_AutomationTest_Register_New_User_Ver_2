using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumPageObjectModel.Base;
using System.Threading;

namespace SeleniumPageObjectModel.Pages
{
    public class CreateAccountPage : BaseClass
    {
        public struct MonthStruct
        {
            public string January;
            public string February;
            public string March;
            public string April;
            public string May;
            public string June;
            public string July;
            public string August;
            public string September;
            public string October;
            public string November;
            public string December;
        }

        //properties
        private IWebDriver _Driver;

        #region DOM Elements
        //Getting the Gender MR radio_btn (wait 4 seconds before finding the first radio button. This will also give some time to other elements to load onto the DOM)
        private IWebElement MR_GenderRadioBtn => _Driver.FindElement(By.Id("id_gender1"));
        //Getting the Gender MRs radio_btn
        private IWebElement MRs_GenderRadioBtn => this._Driver.FindElement(By.CssSelector(".radio-inline>.top>#uniform-id_gender2>span>#id_gender2"));
        //Getting  First Name TextBox
        private IWebElement Firstname_TextBox => this._Driver.FindElement(By.Id("customer_firstname"));
        //Getting  Last Name TextBox
        private IWebElement LastName_TextBox => this._Driver.FindElement(By.Id("customer_lastname"));
        //Getting  Email  TextBox
        private IWebElement Email_TextBox => this._Driver.FindElement(By.Id("email"));
        //Getting  Password  TextBox
        private IWebElement Password_TextBox => this._Driver.FindElement(By.Id("passwd"));
        //Getting  DateOfBirth_Days  TextBox
        private IWebElement DateOfBirth_Days_DD => this._Driver.FindElement(By.Id("days"));
        //Getting  DateOfBirth_Months  TextBox
        private IWebElement DateOfBirth_Months_DD => this._Driver.FindElement(By.Id("months"));
        //Getting  DateOfBirth_Years  TextBox
        private IWebElement DateOfBirth_Years_DD => this._Driver.FindElement(By.Id("years"));
        //Getting  News Letter CheckBox 
        private IWebElement NewsLetter_CheckBox => this._Driver.FindElement(By.Id("newsletter"));
        //Getting  Special Offers  CheckBox 
        private IWebElement SpecialOffers_CheckBox => this._Driver.FindElement(By.Id("optin"));

        //YOUR ADDRESS section....................
        //Getting FirstName From Address section
        private IWebElement Address_FirstName_TextBox => this._Driver.FindElement(By.CssSelector("#account-creation_form>div:nth-child(2)>.form-group>#firstname"));
        //Getting LastName From Address section
        private IWebElement Address_LastName_TextBox => this._Driver.FindElement(By.CssSelector("#account-creation_form>div:nth-child(2)>.form-group>#lastname"));
        //Getting Company TextBox From Address section
        private IWebElement Address_Company_TextBox => this._Driver.FindElement(By.CssSelector("#account-creation_form>div:nth-child(2)>.form-group>#company"));
        //Getting Address TextBox From Address section
        private IWebElement Address_Address_TextBox => this._Driver.FindElement(By.CssSelector("#account-creation_form>div:nth-child(2)>p:nth-child(5)>#address1"));
        //Getting Address(Line2) TextBox From Address section
        private IWebElement Address_AddressLineTwo_TextBox => this._Driver.FindElement(By.CssSelector("#account-creation_form>div:nth-child(2)>.is_customer_param>#address2"));
        //Getting Address TextBox From Address section
        private IWebElement Address_City_TextBox => this._Driver.FindElement(By.CssSelector("#account-creation_form>div:nth-child(2)>p:nth-child(7)>#city"));
        //Getting State DropDownBox From Address section
        private IWebElement Address_State_DropDownBox => this._Driver.FindElement(By.CssSelector("#account-creation_form>div:nth-child(2)>.id_state>#uniform-id_state>#id_state"));
        //Getting Zip-Postal-Code TextBox From Address section
        private IWebElement Address_ZipPostalCode_textBox => this._Driver.FindElement(By.CssSelector("#account-creation_form>div:nth-child(2)>.postcode>#postcode"));
        //Getting Country DropDownBox From Address section
        private IWebElement Address_Country_DropDownBox => this._Driver.FindElement(By.CssSelector("#account-creation_form>div:nth-child(2)>p:nth-child(10)>div>#id_country"));
        //Getting AdditionalInfo TextBox From Address section
        private IWebElement Address_AdditionalInfo_TextBox => this._Driver.FindElement(By.CssSelector("#account-creation_form>div:nth-child(2)>p:nth-child(11)>#other"));
        //Getting HomePhone TextBox From Address section
        private IWebElement Address_HomePhone_TextBox => this._Driver.FindElement(By.CssSelector("#account-creation_form>div:nth-child(2)>p:nth-child(13)>#phone"));
        //Getting MobilePhone TextBox From Address section
        private IWebElement Address_MobilePhone_TextBox => this._Driver.FindElement(By.CssSelector("#account-creation_form>div:nth-child(2)>p:nth-child(14)>#phone_mobile"));
        //Getting AddressAlias TextBox From Address section
        private IWebElement Address_AddressAlias_TextBox => this._Driver.FindElement(By.CssSelector("#account-creation_form>div:nth-child(2)>p:nth-child(15)>#alias"));
        //Getting Submit Button From Address section
        private IWebElement Address_Submit_Button => this._Driver.FindElement(By.CssSelector(".submit>#submitAccount"));
        #endregion

        //Constructor
        public CreateAccountPage(IWebDriver driver)
        {
            this._Driver = driver;
        }


        internal MyAccountPage RegisterNewUser_And_GoToMyAccountPage(string firstname, string lastname, string email, string password, string birhday_day, string birthday_month, string birthday_year, string company, string address, string city, string state, string additional_info, string mobilePhone)
        {

            int index = 0;
            switch (birthday_month)
            {
                case "January":
                    index = 1;
                    break;
                case "February":
                    index = 2;
                    break;
                case "March":
                    index = 3;
                    break;
                case "April":
                    index = 4;
                    break;
                case "May":
                    index = 5;
                    break;
                case "June":
                    index = 6;
                    break;
                case "July":
                    index = 7;
                    break;
                case "August":
                    index = 8;
                    break;
                case "September":
                    index = 9;
                    break;
                case "October":
                    index = 10;
                    break;
                case "November":
                    index = 11;
                    break;
                case "December":
                    index = 12;
                    break;
            }

             Thread.Sleep(2000);

            MR_GenderRadioBtn.Click();
            Firstname_TextBox.SendKeys(firstname);
            LastName_TextBox.SendKeys(lastname);
            Email_TextBox.Clear();
            Email_TextBox.SendKeys(email);
            Password_TextBox.SendKeys(password);
            SelectElement Day = new SelectElement(DateOfBirth_Days_DD);
            Day.SelectByValue(birhday_day);
            SelectElement Month = new SelectElement(DateOfBirth_Months_DD);
            Month.SelectByIndex(index);                                          //--fixed via switch
            SelectElement Years = new SelectElement(DateOfBirth_Years_DD);
            Years.SelectByValue(birthday_year);
            NewsLetter_CheckBox.Click();
            SpecialOffers_CheckBox.Click();

            //YOUR ADDRESS section....................
            Address_FirstName_TextBox.Clear();
            Address_FirstName_TextBox.SendKeys(firstname);
            Address_LastName_TextBox.Clear();
            Address_LastName_TextBox.SendKeys(lastname);
            Address_Company_TextBox.SendKeys(company);
            Address_Address_TextBox.SendKeys(address);
            Address_AddressLineTwo_TextBox.SendKeys("I Live in Mars");
            Address_City_TextBox.SendKeys(city);
            Address_State_DropDownBox.SendKeys(state);
            Address_ZipPostalCode_textBox.SendKeys("90001");
            SelectElement Country = new SelectElement(Address_Country_DropDownBox);
            Country.SelectByIndex(1);                                               //only US available
            Address_AdditionalInfo_TextBox.SendKeys(additional_info);
            Address_HomePhone_TextBox.SendKeys("213-509-6995");
            Address_MobilePhone_TextBox.SendKeys(mobilePhone);
            Address_AddressAlias_TextBox.Clear();
            Address_AddressAlias_TextBox.SendKeys(firstname + " " + lastname);
            Address_Submit_Button.Click();

            return new MyAccountPage(_Driver);
        }
    }

}