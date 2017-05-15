using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace UserInterfaceTesting
{
    [TestFixture]
    public class SeleniumTesting
    {
        private static IWebDriver _webDriver;
        private static IAlert _alert;
        private readonly string _searchstring = "Selenium" + Keys.Enter;

        [SetUp]
        public static void Setup()
        {
            Console.WriteLine("Starting Driver");

//            _webDriver.Manage().Window.Maximize();
        }

        [TearDown]
        public static void Cleanup()
        {
            Console.WriteLine("Closing Driver");

            _webDriver.Close();
            _webDriver.Quit();
        }

        [Test]
        public void SeleniumTestAmazoninChrome()
        {
            _webDriver = new ChromeDriver();
            Console.Out.WriteLine("Navigating to Amazon");
            _webDriver.Navigate().GoToUrl("http://www.amazon.com");
            Console.Out.WriteLine("Searching keyword");
            _webDriver.FindElement(By.Id("twotabsearchtextbox")).SendKeys(_searchstring);
            //            driverChrome.FindElement(By.Id("uh-search-button")).Click();
        }

        [Test]
        public void SeleniumTestGoogleinChrome()
        {
            _webDriver = new ChromeDriver();
            Console.Out.WriteLine("Navigating to Google");
            _webDriver.Navigate().GoToUrl("https://www.google.com");
            Console.Out.WriteLine("Searching keyword");
            _webDriver.FindElement(By.Id("lst-ib")).SendKeys(_searchstring);
//            driverChrome.FindElement(By.Id("_fZ1")).Click();
        }

        [Test]
        public void SeleniumTestYahooinChrome()
        {
            _webDriver = new ChromeDriver();
            Console.Out.WriteLine("Navigating to Yahoo");
            _webDriver.Navigate().GoToUrl("http://www.yahoo.com");
            Console.Out.WriteLine("Searching keyword");
            _webDriver.FindElement(By.Id("uh-search-box")).SendKeys(_searchstring);
//            driverChrome.FindElement(By.Id("uh-search-button")).Click();
        }

        [Test]
        public void SeleniumTestBossTestinChrome()
        {
            _webDriver = new ChromeDriver();
            Console.WriteLine("Navigating to URL http://bosstest.careerbuilder.com/axiom/ at " + DateTime.Now.ToLongTimeString());
            _webDriver.Navigate().GoToUrl("http://bosstest.careerbuilder.com/axiom/");
            Console.WriteLine(_webDriver.PageSource);
//            TakeScreenshot("SeleniumTestingScreenshot0.jpg");

            if (AlertIsPresent()) //&& alert.Text.Contains("http://bosstest.careerbuilder.com")
                                  //                alert.Text.Equals("http://bosstest.careerbuilder.com is requesting your username and password."))
            {
                string credentials = "corpappqausr" + Keys.Tab + "CACruise1";
                Console.WriteLine("Entering credentials for Alert window");
                _alert.SendKeys(credentials);
                //    alert.SetAuthenticationCredentials("corpappqausr", "CACruise1");
                _alert.Accept();
            }

//            TakeScreenshot("SeleniumTestingScreenshot1.jpg");
            BecomeUser("lbrown");

            Console.WriteLine("Navigating to Account Search");
            _webDriver.FindElement(By.Id("tdMenuBarItemAccount")).Click();
            //            driverChrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriver.FindElement(By.LinkText("Account Search")).Click();
        }

        //        [Test]
        //        public void SeleniumTestBostTest2()
        //        {
        //            Console.WriteLine("Navigating to URL https://bosstest.careerbuilder.com/axiom/");
        //            _webDriver.Navigate().GoToUrl("https://bosstest.careerbuilder.com/axiom/");
        //            Console.WriteLine(_webDriver.PageSource);
        //        }

        [Test]
        public void SeleniumTestAmazoninInternetExplorer()
        {
            _webDriver = new InternetExplorerDriver();
            Console.Out.WriteLine("Navigating to Amazon");
            _webDriver.Navigate().GoToUrl("http://www.amazon.com");
            Console.Out.WriteLine("Searching keyword");
            _webDriver.FindElement(By.Id("twotabsearchtextbox")).SendKeys(_searchstring);
            //            driverChrome.FindElement(By.Id("uh-search-button")).Click();
        }

        [Test]
        public void SeleniumTestGoogleinInternetExplorer()
        {
            _webDriver = new InternetExplorerDriver();
            Console.Out.WriteLine("Navigating to Google");
            _webDriver.Navigate().GoToUrl("https://www.google.com");
            Console.Out.WriteLine("Searching keyword");
            _webDriver.FindElement(By.Id("lst-ib")).SendKeys(_searchstring);
            //            driverChrome.FindElement(By.Id("_fZ1")).Click();
        }

        [Test]
        public void SeleniumTestYahooinInternetExplorer()
        {
            _webDriver = new InternetExplorerDriver();
            Console.Out.WriteLine("Navigating to Yahoo");
            _webDriver.Navigate().GoToUrl("http://www.yahoo.com");
            Console.Out.WriteLine("Searching keyword");
            _webDriver.FindElement(By.Id("uh-search-box")).SendKeys(_searchstring);
            //            driverChrome.FindElement(By.Id("uh-search-button")).Click();
        }

        [Test]
        public void SeleniumTestBossTestinInternetExplorer()
        {
            _webDriver = new InternetExplorerDriver();
            Console.WriteLine("Navigating to URL http://bosstest.careerbuilder.com/axiom/ at " + DateTime.Now.ToLongTimeString());
            _webDriver.Navigate().GoToUrl("http://bosstest.careerbuilder.com/axiom/");
            //            TakeScreenshot("SeleniumTestingScreenshot0.jpg");

            if (AlertIsPresent()) //&& alert.Text.Contains("http://bosstest.careerbuilder.com")
                //                alert.Text.Equals("http://bosstest.careerbuilder.com is requesting your username and password."))
            {
                string credentials = "corpappqausr" + Keys.Tab + "CACruise1";
                Console.WriteLine("Entering credentials for Alert window");
                _alert.SendKeys(credentials);
                //    alert.SetAuthenticationCredentials("corpappqausr", "CACruise1");
                _alert.Accept();
            }
            Console.WriteLine(_webDriver.PageSource);

            Thread.Sleep(2000);
            Console.WriteLine(_webDriver.PageSource);
            //            TakeScreenshot("SeleniumTestingScreenshot1.jpg");
            BecomeUser("lbrown");

            Console.WriteLine("Navigating to Account Search");
            _webDriver.FindElement(By.Id("tdMenuBarItemAccount")).Click();
            //            driverChrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _webDriver.FindElement(By.LinkText("Account Search")).Click();
        }

        private static bool AlertIsPresent()
        {
            Thread.Sleep(1000);
            const int maxAttempt = 3;
            for (int i = maxAttempt; i > 0; i = i - 1)
            {
                Console.WriteLine("Checking for Alert window at " + DateTime.Now.ToLongTimeString());
                try
                {
                    _alert = _webDriver.SwitchTo().Alert();
                    Console.WriteLine("Alert window present");
                    return true;
                } // try 
                catch (NoAlertPresentException)
                {
                    Console.WriteLine("Alert window not present");
                    Thread.Sleep(1000);
//                    return false;
                }
            }
            return false;
        }

        private static void BecomeUser(string loginID)
        {
            Console.WriteLine("Becoming Latoya Brown");
            string currentuser = "Currently seen as user " + _webDriver.FindElement(By.XPath("//*[contains(text(),'" + "Welcome" + "')]")).Text;
            Trace.WriteLine(currentuser); 
            _webDriver.FindElement(By.LinkText(" Become")).Click();
            _webDriver.FindElement(By.Id("CBEmployee_HHRepID")).SendKeys(loginID);
            _webDriver.FindElement(By.Id("btnAction")).Click();
            _webDriver.FindElement(By.LinkText("Become")).Click();
        }

        public void TakeScreenshot(string screenshotname)
        {
            Console.WriteLine("Taking screenshot");
            try
            {
                Screenshot ss = ((ITakesScreenshot)_webDriver).GetScreenshot();
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