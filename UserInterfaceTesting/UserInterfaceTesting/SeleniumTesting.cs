using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITestingProject
{
    [TestClass]
    public class SeleniumTesting
    {
        static IWebDriver driverChrome;
        static IAlert alert;

        [AssemblyInitialize]
        public static void setup(TestContext context)
        {
            driverChrome = new ChromeDriver();
        }

        [AssemblyCleanup]
        public static void cleanup()
        {
            driverChrome.Close();
            driverChrome.Quit();
        }

        [TestMethod]
        public void TestMethod1()
        {
            driverChrome.Navigate().GoToUrl("http://www.google.com");
            driverChrome.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
//            driverChrome.Close();
        }

        private static Boolean AlertIsPresent()
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
            driverChrome.FindElement(By.LinkText(" Become")).Click();
            driverChrome.FindElement(By.Id("CBEmployee_HHRepID")).SendKeys(loginID);
            driverChrome.FindElement(By.Id("btnAction")).Click();
            driverChrome.FindElement(By.LinkText("Become")).Click();
        }

        [TestMethod]
        public void SeleniumTestMethod1()
        {
            driverChrome.Navigate().GoToUrl("http://bosstest.careerbuilder.com/axiom/");
            if (AlertIsPresent() &&
                alert.Text.Equals("http://bosstest.careerbuilder.com is requesting your username and password."))
            {
                string credentials = "corpappqausr" + Keys.Tab + "CACruise1";
                alert.SendKeys(credentials);
                //    alert.SetAuthenticationCredentials("corpappqausr", "CACruise1");
                alert.Accept();
            }
            BecomeUser("lbrown");
            driverChrome.FindElement(By.Id("tdMenuBarItemAccount")).Click();
            //            driverChrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driverChrome.FindElement(By.LinkText("Account Search")).Click();
//            driverChrome.Close();
        }
    }
}