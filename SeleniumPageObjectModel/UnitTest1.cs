using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumPageObjectModel.Base;
using SeleniumPageObjectModel.Pages;
using System;
using System.Configuration;

namespace SeleniumPageObjectModel
{
    [TestClass]
    public class UnitTest1 : BaseClass
    {


        string _FirstName = "Chupa";
        string _Lastname = "Kabra";
        //  string _Email = "chupa10@gmail.com"; 
        string _email_fromConfig = ConfigurationManager.AppSettings["Email"]; // This is the only property you have to change to register new user(If Exists, simply put here new email, and run the test!)
        string _Password = "chupa@123";
        string _Day = "13";
        string _Month = "February";
        string _Year = "1980";
        string _Company = "Chupa&Sons";
        string _Address = "ChupaStreet. POB 123";
        string _City = "Los Angeles";
        string _State = "California";
        string _AddInfo = "I like Snikers";
        string _MobilePhone = "0549967045";
        Random rnd = new Random();


        [TestMethod]
        public void TestMethod1()
        {
            AuthenticationPage AuthPage = new HomePage(base._Driver).SignIn_ToAuthPage();
            //Check if user already exists in the database
            if (null == AuthPage.Login_ToCreateAnAccountPage(_email_fromConfig))
            {
                //If true, user Exists in database!
                // Error message is shown to the user.
                //2.Manipulate Email
                _email_fromConfig = rnd.Next(1, 10000).ToString() + _email_fromConfig;
                //3.Start again with new Email :-)
                CreateAccountPage CreateAccPage = AuthPage.Login_ToCreateAnAccountPage2(_email_fromConfig);
                if (CreateAccPage == null) { throw new Exception("This generated Email was failed. Please generate new unique Email address, and try again"); }
                MyAccountPage MyAccPage = CreateAccPage.RegisterNewUser_And_GoToMyAccountPage(_FirstName, _Lastname, _email_fromConfig, _Password, _Day, _Month, _Year, _Company, _Address, _City, _State, _AddInfo, _MobilePhone); //provide your Unregisterd user
                MyAccountLoggedOffPage MyAccloggedOff = MyAccPage.LogOff_ToAccLoggedOff();
                MyAccPage = MyAccloggedOff.Login_WithExistingUser(_email_fromConfig, _Password); //verification

                //Assert here
                Assert.IsTrue(MyAccPage.Username.Text.Equals(_FirstName + " " + _Lastname));
                Assert.AreEqual("http://automationpractice.com/index.php?controller=my-account", _Driver.Url.ToString());

            }
            else
            {
                //if user reaches the account-creation.htm change the flow of the logic
                if (_Driver.Url == "http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation")
                {
                    CreateAccountPage CreateAccPage = new CreateAccountPage(_Driver);
                    MyAccountPage MyAccPage = CreateAccPage.RegisterNewUser_And_GoToMyAccountPage(_FirstName, _Lastname, _email_fromConfig, _Password, _Day, _Month, _Year, _Company, _Address, _City, _State, _AddInfo, _MobilePhone); //provide your Unregisterd user
                    MyAccountLoggedOffPage MyAccloggedOff = MyAccPage.LogOff_ToAccLoggedOff();
                    MyAccPage = MyAccloggedOff.Login_WithExistingUser(_email_fromConfig, _Password); //verification
                    //Assert here                                                                               
                    Assert.IsTrue(MyAccPage.Username.Text.Equals(_FirstName + " " + _Lastname));
                    Assert.AreEqual("http://automationpractice.com/index.php?controller=my-account", _Driver.Url.ToString());
                }
                else
                {
                    throw new Exception("account-creation.html does not exists");
                }
       
            }

        }
    }
}
