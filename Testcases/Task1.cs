using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MyStore.PageObject;
using MyStore.Utils;


namespace MyStore.Testcases{

    [TestFixture]
    class Task1{

        protected IWebDriver Driver;

        [SetUp]
        public void BeforeTest(){
            //Abrir el navegador e ir a la url indicada
            Driver = new ChromeDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Navigate().GoToUrl("http://www.automationpractice.com/index.php");
            Driver.Manage().Window.Maximize();
        }


        [Test]
        public void NewAccountRegistration(){
            
            // Generar nombre y apellido que serán validados después
            String firstname = DataGenerator.RandomString(5);
            String lastname = DataGenerator.RandomString(5);

            // Estando en la página Index, dar click en el botón de SignIn (previa espera a que aparezca)
            IndexPage indexPage = new IndexPage(Driver);
            indexPage.ClickSignInButton();

            // Estando en la página SignIn, completar el formulario de email y continuar
            SignInPage signInPage = new SignInPage(Driver);
            signInPage.CompleteEmailForm();

            // Estando en la página CreateAccount, completar el formulario de registro
            CreateAccountPage createAccountPage = new CreateAccountPage(Driver);
            createAccountPage.CompleteRegistrationForm(firstname, lastname);


            // Estando en la página MyAccount, realizar las validaciones solicitadas
            MyAccountPage myAccountPage = new MyAccountPage(Driver);


            // 1 My account page(?controller=my-account) is opened
            Assert.IsTrue(myAccountPage.UrlContainsString("?controller=my-account"));

            // 2 Proper username is shown in the menu bar 
            Assert.AreEqual(firstname + " " + lastname, myAccountPage.getHeaderUsername());

            // 3 Log out action is available
            Assert.IsTrue(myAccountPage.containsSignOutBtn());
        }


        [TearDown]
        public void AfterTest(){
            if (Driver != null)
                Driver.Quit();
        }
    }
}
