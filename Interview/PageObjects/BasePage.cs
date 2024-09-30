using OpenQA.Selenium;

namespace Interview.PageObjects
{
    public class BasePage
    {
        public IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Returns the text value from the given locator.
        /// </summary>
        /// <param name="locator">A locator where text is expected.</param>
        /// <returns>Text as a string found at the locator.</returns>
        public string GetText(By locator)
        {
            return Driver.FindElement(locator).Text;
        }

        /// <summary>
        /// Inputs the string into the element that was found by the locator.
        /// </summary>
        /// <param name="locator">A field that is expected to accept text input.</param>
        /// <param name="text">The string text to be inputted into the field found by the locator.</param>
        public void InputText(By locator, string text)
        {
            IWebElement found = Driver.FindElement(locator);
            found?.SendKeys(text);
        }

        /// <summary>
        /// Finds the element with the locator and clicks it.
        /// </summary>
        /// <param name="locator">The element that is expected to be clicked.</param>
        public void Select(By locator)
        {
            Driver.FindElement(locator).Click();
        }
    }
}
