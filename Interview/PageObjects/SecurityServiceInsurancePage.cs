using OpenQA.Selenium;

namespace Interview.PageObjects
{
    internal class SecurityServiceInsurancePage : BasePage
    {
        private readonly By _RequestAQuoteLocator = By.Id("RequestQuoteTop");

        public SecurityServiceInsurancePage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Selects the Request a Quote button on Insurance page.
        /// </summary>
        public void SelectGetStartedButton()
        {
            Select(_RequestAQuoteLocator);
        }
    }
}
