using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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

            Thread.Sleep(2000);
            _webDriver.Close();
            _webDriver.Quit();
        }

//        [Test]
//        public void SeleniumTestAmazoninChrome()
//        {
//            _webDriver = new ChromeDriver();
//            Console.Out.WriteLine("Navigating to Amazon");
//            _webDriver.Navigate().GoToUrl("http://www.amazon.com");
//            Console.Out.WriteLine("Searching keyword");
//            _webDriver.FindElement(By.Id("twotabsearchtextbox")).SendKeys(_searchstring);
//            //            driverChrome.FindElement(By.Id("uh-search-button")).Click();
//        }

//        [Test]
//        public void SeleniumTestGoogleinChrome()
//        {
//            _webDriver = new ChromeDriver();
//            Console.Out.WriteLine("Navigating to Google");
//            _webDriver.Navigate().GoToUrl("https://www.google.com");
//            Console.Out.WriteLine("Searching keyword");
//            _webDriver.FindElement(By.Id("lst-ib")).SendKeys(_searchstring);
////            driverChrome.FindElement(By.Id("_fZ1")).Click();
//        }

//        [Test]
//        public void SeleniumTestYahooinChrome()
//        {
//            _webDriver = new ChromeDriver();
//            Console.Out.WriteLine("Navigating to Yahoo");
//            _webDriver.Navigate().GoToUrl("http://www.yahoo.com");
//            Console.Out.WriteLine("Searching keyword");
//            _webDriver.FindElement(By.Id("uh-search-box")).SendKeys(_searchstring);
////            driverChrome.FindElement(By.Id("uh-search-button")).Click();
//        }

//        [Test]
//        public void SeleniumTestBossTestinChrome()
//        {
//            _webDriver = new ChromeDriver();
//            Console.WriteLine("Navigating to URL http://bosstest.careerbuilder.com/axiom/ at " + DateTime.Now.ToLongTimeString());
//            _webDriver.Navigate().GoToUrl("http://bosstest.careerbuilder.com/axiom/");
//            Console.WriteLine(_webDriver.PageSource);
////            TakeScreenshot("SeleniumTestingScreenshot0.jpg");

//            if (AlertIsPresent()) //&& alert.Text.Contains("http://bosstest.careerbuilder.com")
//                //                alert.Text.Equals("http://bosstest.careerbuilder.com is requesting your username and password."))
//            {
//                string credentials = "corpappqausr" + Keys.Tab + "CACruise1";
//                Console.WriteLine("Entering credentials for Alert window");
//                _alert.SendKeys(credentials);
//                //    alert.SetAuthenticationCredentials("corpappqausr", "CACruise1");
//                _alert.Accept();
//            }

////            TakeScreenshot("SeleniumTestingScreenshot1.jpg");
//            BecomeUser("lbrown");

//            Console.WriteLine("Navigating to Account Search");
//            _webDriver.FindElement(By.Id("tdMenuBarItemAccount")).Click();
//            //            driverChrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
//            _webDriver.FindElement(By.LinkText("Account Search")).Click();
//        }

        //        [Test]
        //        public void SeleniumTestBostTest2()
        //        {
        //            Console.WriteLine("Navigating to URL https://bosstest.careerbuilder.com/axiom/");
        //            _webDriver.Navigate().GoToUrl("https://bosstest.careerbuilder.com/axiom/");
        //            Console.WriteLine(_webDriver.PageSource);
        //        }

        //[Test]
        //public void SeleniumTestAmazoninInternetExplorer()
        //{
        //    _webDriver = new InternetExplorerDriver();
        //    Console.Out.WriteLine("Navigating to Amazon");
        //    _webDriver.Navigate().GoToUrl("http://www.amazon.com");
        //    Console.Out.WriteLine("Searching keyword");
        //    _webDriver.FindElement(By.Id("twotabsearchtextbox")).SendKeys(_searchstring);
        //    //            driverChrome.FindElement(By.Id("uh-search-button")).Click();
        //}

        //[Test]
        //public void SeleniumTestGoogleinInternetExplorer()
        //{
        //    _webDriver = new InternetExplorerDriver();
        //    Console.Out.WriteLine("Navigating to Google");
        //    _webDriver.Navigate().GoToUrl("https://www.google.com");
        //    Console.Out.WriteLine("Searching keyword");
        //    _webDriver.FindElement(By.Id("lst-ib")).SendKeys(_searchstring);
        //    //            driverChrome.FindElement(By.Id("_fZ1")).Click();
        //}

        //[Test]
        //public void SeleniumTestYahooinInternetExplorer()
        //{
        //    _webDriver = new InternetExplorerDriver();
        //    Console.Out.WriteLine("Navigating to Yahoo");
        //    _webDriver.Navigate().GoToUrl("http://www.yahoo.com");
        //    Console.Out.WriteLine("Searching keyword");
        //    _webDriver.FindElement(By.Id("uh-search-box")).SendKeys(_searchstring);
        //    //            driverChrome.FindElement(By.Id("uh-search-button")).Click();
        //}

        [Test]
        public void SeleniumTestSearchAndUpdateAccountinBossTestinChrome()
        {
            _webDriver = new ChromeDriver();
            Console.WriteLine("Navigating to URL http://bosstest.careerbuilder.com/axiom/ at " + DateTime.Now.ToLongTimeString());
            _webDriver.Navigate().GoToUrl("http://bosstest.careerbuilder.com/axiom/");

            if (AlertIsPresent() && _alert.Text.Contains("http://bosstest.careerbuilder.com"))
            //                alert.Text.Equals("http://bosstest.careerbuilder.com is requesting your username and password."))
            {
                string credentials = "corpappqausr" + Keys.Tab + "CACruise1";
                Console.WriteLine("Entering credentials for Alert window");
                _alert.SendKeys(credentials);
                //    alert.SetAuthenticationCredentials("corpappqausr", "CACruise1");
                _alert.Accept();
            }

            try
            {
                //            TakeScreenshot("SeleniumTestingScreenshot0.jpg");

//                Console.WriteLine(_webDriver.PageSource);

                _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //Thread.Sleep(2000);
                //            TakeScreenshot("SeleniumTestingScreenshot1.jpg");
                BecomeUser("lbrown");

                Console.WriteLine("Navigating to Account Search");
                _webDriver.FindElement(By.Id("tdMenuBarItemAccount")).Click();
                _webDriver.FindElement(By.LinkText("Account Search")).Click();
                _webDriver.FindElement(By.Name("Acct_CustCompanyName")).SendKeys("Great Scott");
                _webDriver.FindElement(By.Name("btnSearch")).Click();
                _webDriver.FindElement(By.LinkText("Great Scott Group")).Click();

                _webDriver.FindElement(By.LinkText("Edit Account Information")).Click();
                _webDriver.FindElement(By.Name("Acct_ContactFax")).Clear(); 
                _webDriver.FindElement(By.Name("Acct_ContactFax")).SendKeys("5551234567");
                _webDriver.FindElement(By.Name("btnSave")).Click();


            }
            catch (UnhandledAlertException unhandledAlertException)
            {
                Console.WriteLine(unhandledAlertException);
                if (AlertIsPresent() && _alert.Text.Contains("http://bosstest.careerbuilder.com"))
                    //                alert.Text.Equals("http://bosstest.careerbuilder.com is requesting your username and password."))
                {
                    string credentials = "corpappqausr" + Keys.Tab + "CACruise1";
                    Console.WriteLine("Entering credentials for Alert window");
                    _alert.SendKeys(credentials);
                    //    alert.SetAuthenticationCredentials("corpappqausr", "CACruise1");
                    _alert.Accept();
                }
                Console.WriteLine(_webDriver.PageSource);
            }
        }

        [Test]
        public void SeleniumTestCutomerSearchAndUpdateinAxiomCloudinChrome()
        {
            _webDriver = new ChromeDriver();
            Console.WriteLine("Navigating to URL https://stg-axiom.cb.com/invoices at " + DateTime.Now.ToLongTimeString());
            _webDriver.Navigate().GoToUrl("https://stg-axiom.cb.com/invoices");
            try
            {
                if (AlertIsPresent()) //&& alert.Text.Contains("http://bosstest.careerbuilder.com")
                    //                alert.Text.Equals("http://bosstest.careerbuilder.com is requesting your username and password."))
                {
                    string credentials = "corpappqausr" + Keys.Tab + "CACruise1";
                    Console.WriteLine("Entering credentials for Alert window");
                    _alert.SendKeys(credentials);
                    //    alert.SetAuthenticationCredentials("corpappqausr", "CACruise1");
                    _alert.Accept();
                }

                //BecomeUser("lbrown");

                //Console.WriteLine("Navigating to Invoice Search");
                //_webDriver.FindElement(By.Id("tdMenuBarItemA/R")).Click();
                ////            driverChrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //_webDriver.FindElement(By.LinkText("Invoice Search")).Click();
                Thread.Sleep(2000);
                _webDriver.FindElement(By.LinkText("Customers")).Click();
                _webDriver.FindElement(By.Name("company_name")).SendKeys("Lorraine");
                _webDriver.FindElement(By.Id("submit-filter-form")).Click();
                _webDriver.FindElement(By.ClassName("selectable")).Click();

                _webDriver.FindElement(By.LinkText("Journal")).Click();
                Thread.Sleep(1000);
                _webDriver.FindElement(By.Id("comment_note")).SendKeys("Testing");
                _webDriver.FindElement(By.Name("button")).Click();


            }
            catch (UnhandledAlertException unhandledAlertException)
            {
                Console.WriteLine(unhandledAlertException);
                if (AlertIsPresent() && _alert.Text.Contains("http://bosstest.careerbuilder.com"))
                    //                alert.Text.Equals("http://bosstest.careerbuilder.com is requesting your username and password."))
                {
                    string credentials = "corpappqausr" + Keys.Tab + "CACruise1";
                    Console.WriteLine("Entering credentials for Alert window");
                    _alert.SendKeys(credentials);
                    //    alert.SetAuthenticationCredentials("corpappqausr", "CACruise1");
                    _alert.Accept();
                }
                Console.WriteLine(_webDriver.PageSource);
            }
        }

        [Test]
        public void SeleniumTestSalesForceinChrome()
        {
            _webDriver = new ChromeDriver();
            Console.WriteLine("Navigating to URL https://test.salesforce.com at " + DateTime.Now.ToLongTimeString());
            _webDriver.Navigate().GoToUrl("https://test.salesforce.com");
            //            Console.WriteLine(_webDriver.PageSource);
            _webDriver.FindElement(By.Id("username")).SendKeys("abey.mathew@careerbuilder.com.ccdev");
            _webDriver.FindElement(By.Id("password")).SendKeys("SalesForc3Test");
            _webDriver.FindElement(By.Id("Login")).Click();

            Thread.Sleep(3000);
            if (_webDriver.FindElement(By.Id("tsidLabel")).Text != "Service")
            {
                _webDriver.FindElement(By.Id("tsidButton")).Click();
                _webDriver.FindElement(By.Id("tsid-menuItems")).FindElement(By.LinkText("Service")).Click();
            }

            _webDriver.FindElement(By.Id("Case_Tab")).Click();

            Thread.Sleep(1000);
//            if (!_webDriver.FindElement(By.Id("fcf")).FindElement(By.LinkText(".Client Support Queue")).Selected)
//            {
                _webDriver.FindElement(By.Id("fcf")).Click();
                _webDriver.FindElement(By.Id("fcf")).FindElement(By.CssSelector("option[value='00B1400000A4y68']")).Click();            
                _webDriver.FindElement(By.Name("go")).Click();
            //            }
            Thread.Sleep(1000);
            _webDriver.FindElement(By.LinkText("01460173")).Click();

            Thread.Sleep(1000);
            _webDriver.FindElement(By.LinkText("Details")).Click();
            _webDriver.FindElement(By.Name("edit")).Click();

            Thread.Sleep(1000);
            _webDriver.FindElement(By.Id("cas7")).Click();
            _webDriver.FindElement(By.Id("cas7")).FindElement(By.CssSelector("option[value='Awaiting Customer Info']")).Click();
            _webDriver.FindElement(By.Name("save")).Click();
        }

        [Test]
        public void SeleniumTestSalesForceTransitionToBossTestinChrome()
        {
            _webDriver = new ChromeDriver();
            Console.WriteLine("Navigating to URL https://test.salesforce.com at " + DateTime.Now.ToLongTimeString());
            _webDriver.Navigate().GoToUrl("https://test.salesforce.com");
            //            Console.WriteLine(_webDriver.PageSource);
            _webDriver.FindElement(By.Id("username")).SendKeys("abey.mathew@careerbuilder.com.ccdev");
            _webDriver.FindElement(By.Id("password")).SendKeys("SalesForc3Test");
            _webDriver.FindElement(By.Id("Login")).Click();

            Thread.Sleep(3000);
            if (_webDriver.FindElement(By.Id("tsidLabel")).Text != "Service")
            {
                _webDriver.FindElement(By.Id("tsidButton")).Click();
                _webDriver.FindElement(By.Id("tsid-menuItems")).FindElement(By.LinkText("Service")).Click();
            }

            _webDriver.FindElement(By.Id("01r30000001A7Gj_Tab")).Click();

            Thread.Sleep(1000);
            //            if (!_webDriver.FindElement(By.Id("fcf")).FindElement(By.LinkText(".Client Support Queue")).Selected)
            //            {
            _webDriver.FindElement(By.LinkText("OptimHome Portugal")).Click();
            _webDriver.FindElement(By.Id("00N30000008CAZT_ileinner")).Click();
            Console.WriteLine(_webDriver.WindowHandles[1]);
            _webDriver.SwitchTo().Window(_webDriver.WindowHandles[1]);

            _webDriver.FindElement(By.LinkText("Edit Account Information")).Click();
            _webDriver.FindElement(By.Name("Acct_ContactFax")).Clear();
            _webDriver.FindElement(By.Name("Acct_ContactFax")).SendKeys("5551234567");
            _webDriver.FindElement(By.Name("btnSave")).Click();

            //            }
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
                catch
                {
                    Console.WriteLine("Alert window not present");
                    Thread.Sleep(1000);
//                    return false;
                }
                finally
                {

                }
            }
            return false;
        }

        private static void BecomeUser(string loginID)
        {
            Console.WriteLine("Becoming Latoya Brown");
            Thread.Sleep(1000);
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
                Screenshot ss = ((ITakesScreenshot) _webDriver).GetScreenshot();
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