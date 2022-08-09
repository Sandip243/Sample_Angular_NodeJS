using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
[TestFixture]
public class SeleniumTestTest
{
    private IWebDriver driver;
    public IDictionary<string, object> vars { get; private set; }
    private IJavaScriptExecutor js;
    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        js = (IJavaScriptExecutor)driver;
        vars = new Dictionary<string, object>();
    }
    [TearDown]
    protected void TearDown()
    {
        driver.Quit();
    }
    [Test]
    public void seleniumTest()
    {
        driver.Navigate().GoToUrl("http://localhost:4200/");
        driver.Manage().Window.Size = new System.Drawing.Size(1382, 744);
        driver.FindElement(By.CssSelector("b")).Click();
        driver.FindElement(By.CssSelector("li:nth-child(3) img")).Click();
        driver.FindElement(By.CssSelector("b")).Click();
        
        js.ExecuteScript("window.scrollTo(0,0)");
        driver.FindElement(By.CssSelector("button")).Click();
        driver.FindElement(By.LinkText("ABC HEALTHCARE PHARMACY")).Click();
        driver.FindElement(By.CssSelector("li:nth-child(1) img")).Click();
        js.ExecuteScript("window.scrollTo(0,0)");

        driver.FindElement(By.LinkText("ABC HEALTHCARE PHARMACY")).Click();
        driver.FindElement(By.CssSelector("input")).Click();
        driver.FindElement(By.CssSelector("input")).SendKeys("Himalaya");
        driver.FindElement(By.CssSelector("button")).Click();
        js.ExecuteScript("window.scrollTo(0,0)");
        driver.FindElement(By.CssSelector(".details")).Click();
        driver.FindElement(By.CssSelector("button")).Click();
        {
            var element = driver.FindElement(By.CssSelector("button"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(element).Perform();
        }
    }
}
