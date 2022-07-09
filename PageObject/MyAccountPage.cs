using System;
using OpenQA.Selenium;
using MyStore.Handler;


namespace MyStore.PageObject{

    class MyAccountPage{

        // Driver
        protected IWebDriver Driver;


        // Localizadores
        protected By SignOutBtn = By.LinkText("Sign out");
        protected By Username = By.CssSelector("div[class=\"header_user_info\"]>a>span");


        // Constructor
        public MyAccountPage(IWebDriver driver){
            Driver = driver;
        }


        // 1 My account page(?controller=my-account) is opened
        public bool UrlContainsString(String value){
            if (Driver.Url.Contains(value))
                return true;
            else
                return false;
        }


        // 2 Proper username is shown in the menu bar 
        public string getHeaderUsername(){
             return WaitHandler.ElementAvailable(Driver, Username).Text;
        }


        // 3 Log out action is available
        public bool containsSignOutBtn(){
            try{
                WaitHandler.ElementAvailable(Driver, SignOutBtn);
                return true;
            }
            catch{
                return false;
            }
        }
    }
}
