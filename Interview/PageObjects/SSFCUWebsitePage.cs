using OpenQA.Selenium;

namespace Interview.PageObjects
{
    internal class SSFCUWebsitePage : BasePage
    {
        private readonly By _InsuranceTabLocator = By.XPath("//a[contains(text(),'Insurance\n')]");
        private readonly By _InsuranceForYouLocator = By.CssSelector("a[href='/insurance/personal']");

        public SSFCUWebsitePage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Selects the Insurance tab then the Insurance For You link on the SSFCU website.
        /// </summary>
        public void NavigateToQuotePage()
        {
            Select(_InsuranceTabLocator);
            Select(_InsuranceForYouLocator);
        }
    }
}
