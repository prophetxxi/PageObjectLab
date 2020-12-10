using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObjectLab
{
    public class Tests
    {
        IWebDriver driver;
        WebDriverWait wait;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void WrongLoggining()
        {
            MainPage mainPage = new MainPage(driver, wait);
            Assert.AreEqual(
                mainPage.Open()
                .OpenLoginForm()
                .EnterLogin("wrongmail@wrong.ru")
                .EnterPassword("wrongpass")
                .Entering()
                .GetLoginResult(),
                "Неверный логин или пароль."
                );
        }
        [Test]
        public void AddingAdapterToBusket()
        {
            MainPage mainPage = new MainPage(driver, wait);
            AccessoriesPage accessoriesPage = mainPage.Open().OpenAccessoriesPage();
            BusketPage busketPage = accessoriesPage.AudioFilter().OpenAdapterPage().BuyAdapter().OpenBusketPage();
            Assert.AreEqual(busketPage.OrderSum(), "1 990 ₽");
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}