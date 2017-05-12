using System;
using System.Diagnostics;
using JetBrains.TeamCity.ServiceMessages.Write;
using NUnit.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UserInterfaceTesting
{
    [TestFixture]
    public class SeleniumTesting
    {
        private static IWebDriver driverChrome;
        private static IAlert alert;
        private readonly string _searchstring = "Selenium" + Keys.Enter;

        [SetUp]
        public static void Setup()
        {
            Console.WriteLine("Starting Chrome Driver");

            driverChrome = new ChromeDriver();
            driverChrome.Manage().Window.Maximize();
        }

        [TearDown]
        public static void Cleanup()
        {
            Console.WriteLine("Closing Chrome Driver");

            driverChrome.Close();
            driverChrome.Quit();
        }

        [Test]
        public void SeleniumTestGoogle()
        {
            Console.Out.WriteLine("Navigating to Google");
            driverChrome.Navigate().GoToUrl("http://www.google.com");
            driverChrome.FindElement(By.Id("lst-ib")).SendKeys(_searchstring);
//            driverChrome.FindElement(By.Id("_fZ1")).Click();
        }

        [Test]
        public void SeleniumTestYahoo()
        {
            Console.Out.WriteLine("Navigating to Yahoo");
            driverChrome.Navigate().GoToUrl("http://www.yahoo.com");
            driverChrome.FindElement(By.Id("uh-search-box")).SendKeys(_searchstring);
//            driverChrome.FindElement(By.Id("uh-search-button")).Click();
        }

        [Test]
        public void SeleniumTestBossTest()
        {
            Console.WriteLine("Navigating to URL");

            driverChrome.Navigate().GoToUrl("http://bosstest.careerbuilder.com/axiom/");
//            TakeScreenshot("SeleniumTestingScreenshot0.jpg");
            Console.WriteLine(driverChrome.PageSource);

            if (AlertIsPresent() && alert.Text.Contains("http://bosstest.careerbuilder.com"))
//                alert.Text.Equals("http://bosstest.careerbuilder.com is requesting your username and password."))
            {
                string credentials = "corpappqausr" + Keys.Tab + "CACruise1";
                Console.WriteLine("Entering credentials for Alert window");
                alert.SendKeys(credentials);
                //    alert.SetAuthenticationCredentials("corpappqausr", "CACruise1");
                alert.Accept();
            }

//            TakeScreenshot("SeleniumTestingScreenshot1.jpg");
            BecomeUser("lbrown");

            Console.WriteLine("Navigating to Account Search");
            driverChrome.FindElement(By.Id("tdMenuBarItemAccount")).Click();
            //            driverChrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driverChrome.FindElement(By.LinkText("Account Search")).Click();
        }

        private static bool AlertIsPresent()
        {
            Console.WriteLine("Checking for Alert window");
            try
            {
                alert = driverChrome.SwitchTo().Alert();
                Console.WriteLine("Alert window present");
                return true;
            }   // try 
            catch (NoAlertPresentException)
            {
                Console.WriteLine("Alert window not present");
                return false;
            }
        }

        private static void BecomeUser(string loginID)
        {
            Console.WriteLine("Becoming Latoya Brown");
            string currentuser = "Currently seen as user " + driverChrome.FindElement(By.XPath("//*[contains(text(),'" + "Welcome" + "')]")).Text;
            Trace.WriteLine(currentuser); 
            driverChrome.FindElement(By.LinkText(" Become")).Click();
            driverChrome.FindElement(By.Id("CBEmployee_HHRepID")).SendKeys(loginID);
            driverChrome.FindElement(By.Id("btnAction")).Click();
            driverChrome.FindElement(By.LinkText("Become")).Click();
        }

        public void TakeScreenshot(string screenshotname)
        {
            Console.WriteLine("Taking screenshot");
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