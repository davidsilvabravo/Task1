using System;
using OpenQA.Selenium;
using MyStore.Handler;
using MyStore.Utils;


namespace MyStore.PageObject{

    public class SignInPage{

        // Driver
        protected IWebDriver Driver;


        // Localizadores
        protected By emailInput = By.Id("email_create");
        protected By createAccountBtn = By.Id("SubmitCreate");


        // Constructor
        public SignInPage(IWebDriver driver){
            Driver = driver;
        }


        // Llenar el mail y clickear en el botón "Create an account"
        public void CompleteEmailForm(){

            try{
                // Esperar que carguen el campo de correo y llenarlo
                WaitHandler.ElementAvailable(Driver, emailInput).SendKeys(DataGenerator.RandomEmail());

                // Esperar que cargue el botón de Crear cuenta y darle click
                WaitHandler.ElementAvailable(Driver, createAccountBtn).Click();
            }
            catch (Exception e){
                Console.WriteLine("Exception message: " + e.Message);
                Console.WriteLine("StackTrace: \n" + e.StackTrace);
                throw new Exception("Error when trying to complete Email form");
            }
        }
    }
}
