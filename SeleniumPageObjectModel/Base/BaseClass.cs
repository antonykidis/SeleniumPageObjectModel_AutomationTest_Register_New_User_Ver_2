using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPageObjectModel.Base
{
    public class BaseClass
    {
        public IWebDriver _Driver;

        [TestInitialize] //Runs before each test methods
        public void OpenDriver()
        {
            this._Driver = new ChromeDriver();
            _Driver.Manage().Window.Maximize();
            _Driver.Url = "http://automationpractice.com/index.php";

            if (_Driver.PageSource.Length < 800) //If html source.Length less then 800 chars looks like we have a problem.
            {
                throw new Exception("Cannot Connect to remote server. Try again later");
            }
        }

        [TestCleanup] //Runs immediately after each test is run
        public void CloseDriver()
        {
            _Driver.Close();
            _Driver.Quit(); //Kills Chrome's Driver.exe in Task Manager
        }

    }

}
