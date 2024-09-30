using OpenQA.Selenium;

namespace Interview.PageObjects
{
    public class RequestAQuotePage : BasePage
    {
        private readonly By _PageTitleLocator = By.CssSelector("h1.Title");
        private readonly By _FirstNameFieldLocator = By.Id("FirstName");
        private readonly string _InterestCheckboxXPathLocatorBuilder = "//label[text()='";
        private readonly string _InterestCheckboxXPathLocatorEndBuilder = "']";

        private readonly By _SubmitButtonEndOfFormLocator = By.CssSelector("#AdobeSessionId+div button");
        private readonly By _FirstNameErrorLocator = By.Id("FirstName-error");
        private readonly By _LastNameErrorLocator = By.Id("LastName-error");

        public RequestAQuotePage(IWebDriver driver) : base(driver)
        {

        }

        /// <summary>
        /// Returns the Title of the Request a Quote page.
        /// </summary>
        /// <returns>The text string of the Title.</returns>
        public string GetTitle()
        {
            return GetText(_PageTitleLocator);
        }

        /// <summary>
        /// Inputs the given text into the First Name field.
        /// </summary>
        /// <param name="firstName">Text to be inputted into the First Name field.</param>
        public void InputFirstName(string firstName)
        {
            InputText(_FirstNameFieldLocator, firstName);
        }

        /// <summary>
        /// Finds the given Interest selection by building the locator within the method using the interest inputted.
        /// </summary>
        /// <param name="interest">The Interest element to be selected.</param>
        public void SelectInterest(string interest)
        {
            By chosenInterest = By.XPath($"{_InterestCheckboxXPathLocatorBuilder}{interest}{_InterestCheckboxXPathLocatorEndBuilder}");
            Select(chosenInterest);
        }

        /// <summary>
        /// Selects the Submit button on the page.
        /// </summary>
        public void SelectSubmitButton()
        {
            Select(_SubmitButtonEndOfFormLocator);
        }

        /// <summary>
        /// Grabs the error message generated on the page if the first name field did not have any input.
        /// </summary>
        /// <returns>The error message unless none is found, then it returns a message stating this fact.</returns>
        public string GetFirstNameErrorMessage()
        {
            try
            {
                return GetText(_FirstNameErrorLocator);
            }
            catch (NoSuchElementException)
            {
                return "Error message was unable to be located.";
            }
        }

        /// <summary>
        /// Grabs the error message generated on the page if the last name field did not have any input.
        /// </summary>
        /// <returns>The error message unless none is found, then it returns a message stating this fact.</returns>
        public string GetLastNameErrorMessage()
        {
            try
            {
                return GetText(_LastNameErrorLocator);
            }
            catch (NoSuchElementException)
            {
                return "Error message was unable to be located.";
            }
        }
    }
}
