using System;
using System.Diagnostics;
using NUnit.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UserInterfaceTesting
{
    [TestFixture]
    public class SeleniumTesting
    {
        static IWebDriver driverChrome;
        static IAlert alert;
        readonly string _searchstring = "Selenium" + Keys.Enter;

        [SetUp]
        public static void Setup()
        {
            driverChrome = new ChromeDriver();
            driverChrome.Manage().Window.Maximize();
        }

        [TearDown]
        public static void Cleanup()
        {
            driverChrome.Close();
            driverChrome.Quit();
        }

        [Test]
        public void SeleniumTestGoogle()
        {
            driverChrome.Navigate().GoToUrl("http://www.google.com");
            driverChrome.FindElement(By.Id("lst-ib")).SendKeys(_searchstring);
//            driverChrome.FindElement(By.Id("_fZ1")).Click();
        }

        [Test]
        public void SeleniumTestYahoo()
        {
            driverChrome.Navigate().GoToUrl("http://www.yahoo.com");
            driverChrome.FindElement(By.Id("uh-search-box")).SendKeys(_searchstring);
//            driverChrome.FindElement(By.Id("uh-search-button")).Click();
        }

        [Test]
        public void SeleniumTestBossTest()
        {
            driverChrome.Navigate().GoToUrl("http://bosstest.careerbuilder.com/axiom/");
            TakeScreenshot("SeleniumTestingScreenshot0.jpg");

            if (AlertIsPresent() &&
                alert.Text.Equals("http://bosstest.careerbuilder.com is requesting your username and password."))
            {
                string credentials = "corpappqausr" + Keys.Tab + "CACruise1";
                alert.SendKeys(credentials);
                //    alert.SetAuthenticationCredentials("corpappqausr", "CACruise1");
                alert.Accept();
            }

            TakeScreenshot("SeleniumTestingScreenshot1.jpg");
            BecomeUser("lbrown");
            driverChrome.FindElement(By.Id("tdMenuBarItemAccount")).Click();
            //            driverChrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driverChrome.FindElement(By.LinkText("Account Search")).Click();
        }

        private static bool AlertIsPresent()
        {
            try
            {
                alert = driverChrome.SwitchTo().Alert();

                return true;
            }   // try 
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private static void BecomeUser(string loginID)
        {
            string currentuser = "Currently seen as user " + driverChrome.FindElement(By.XPath("//*[contains(text(),'" + "Welcome" + "')]")).Text;
            Trace.WriteLine(currentuser); 
            driverChrome.FindElement(By.LinkText(" Become")).Click();
            driverChrome.FindElement(By.Id("CBEmployee_HHRepID")).SendKeys(loginID);
            driverChrome.FindElement(By.Id("btnAction")).Click();
            driverChrome.FindElement(By.LinkText("Become")).Click();
        }

        public void TakeScreenshot(string screenshotname)
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)driverChrome).GetScreenshot();
                ss.SaveAsFile(@"D:\AbeysSnapshots\" + screenshotname, ScreenshotImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }
    }
}