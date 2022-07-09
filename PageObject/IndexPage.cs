using OpenQA.Selenium;
using MyStore.Handler;
using System;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using System.Threading;


namespace MyStore.PageObject{

    public class IndexPage
    {

        // Driver
        protected IWebDriver Driver;


        // Localizadores
        protected By SignInBtn = By.LinkText("Sign in");


        // Constructor
        public IndexPage(IWebDriver driver)
        {
            Driver = driver;
        }


        // Clickear el botón de SignIn
        public void ClickSignInButton()
        {

            try{
                // Se ejecdutará un bugfix temporal en caso se utilice Chrome v.103
                bugFix();
                // Esperar que cargue el botón Sign In y luego dar click
                WaitHandler.ElementAvailable(Driver, SignInBtn).Click();
            }
            catch (Exception e){
                Console.WriteLine("Exception message: " + e.Message);
                Console.WriteLine("StackTrace: \n" + e.StackTrace);
                throw new Exception("Error when trying to click on Sign In button");
            }
        }

        public void bugFix(){
            // Debido a un bug intermitente descrito en https://bugs.chromium.org/p/chromedriver/issues/detail?id=4121
            // es necesario hacer una espera en caso que la versión de Chrome sea la 103 (la más reciente)
            ICapabilities capabilities = ((RemoteWebDriver)Driver).Capabilities;
            string browserVersion = (capabilities.GetCapability("chrome") as Dictionary<string, object>)["chromedriverVersion"].ToString().Substring(0, 3);
            if (browserVersion.Equals("103")) Thread.Sleep(5000);
        }
    }
}
