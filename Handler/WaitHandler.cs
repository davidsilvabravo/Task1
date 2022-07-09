using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace MyStore.Handler
{
    public static class WaitHandler{

        //Método para esperar (hasta 10s) a que un elemento se encuentre disponible
        public static IWebElement ElementAvailable(IWebDriver driver, By locator){
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement webElement = null;
            Func<IWebDriver, bool> condition =
                d =>
                {
                    webElement = d.FindElement(locator);
                    return webElement.Displayed && webElement.Enabled;
                };
            wait.Until(condition);
            return webElement;
        }
    }
}
