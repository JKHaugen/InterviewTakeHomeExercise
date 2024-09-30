using Interview.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Interview.Tests
{
    /// <summary>
    /// 
    /// Please take time to read all instructions carefully before starting.
    /// 
    /// This exercise is intended to test your problem solving skills, knowledge of C#, Selenium, HTML/CSS, and OO principals and design.  Feel free to use
    /// books or internet references to complete this exercise but please do not get help from others in any way or discuss this exercise with others.
    /// 
    /// </summary>
    [TestFixture]
    public class TakeHomeExercise
    {
        /// <summary>
        /// 
        /// Using C# and Selenium, please automate the test steps provided below:
        /// 1. Navigate to the "Request an Insurance Quote" page on our website, https://www.ssfcu.org/insurance/personal/request-a-quote
        /// 2. Assert the title ON the webpage (not driver.Title) using the variable, pageTitle
        /// 3. Fill in ONLY the first name field using the variable, firstName
        /// 4. Check "Auto" in the Interest section using the variable, interest
        /// 5. Click Submit
        ///
        /// Using NUnit (included)
        /// 6. Assert that the First Name field does not display an error message
        /// 7. Assert the Last Name field error message using the variable, lastNameErrorMessage
        /// 
        /// Create a page object in the PageObjects folder for the quote form page, linked above, that provides the functionality
        /// needed to complete this scenario using the variables provided. Please do not use PageFactory.
        /// 
        /// Your finished script should compile and run successfully using ChromeDriver, already setup and ready to use.
        ///
        /// NOTE: Please run Build > Clean Solution before zipping your project and emailing it back. Thanks!
        /// 
        /// </summary>

        [Test]
        public void TakeHomeExercise1()
        {
            string firstName = "Security";
            string interest = "Auto";
            string lastNameErrorMessage = "Response required";
            string pageTitle = "Get a Quote";
            IWebDriver driver = new ChromeDriver();

            string pulledPageTitle;
            string firstNameErrorMessage = "Response required";
            string pulledFirstNameError;
            string pulledLastNameError;

            // 1.
            driver.Url = "https://www.ssfcu.org/";
            SSFCUWebsitePage sSFCUWebsitePage = new SSFCUWebsitePage(driver);
            sSFCUWebsitePage.NavigateToQuotePage();

            SecurityServiceInsurancePage insurancePage = new SecurityServiceInsurancePage(driver);
            insurancePage.SelectGetStartedButton();

            // 2.
            RequestAQuotePage requestAQuotePage = new RequestAQuotePage(driver);
            pulledPageTitle = requestAQuotePage.GetTitle();
            Assert.AreEqual(pageTitle, pulledPageTitle);

            // 3.
            requestAQuotePage.InputFirstName(firstName);

            // 4.
            requestAQuotePage.SelectInterest(interest);

            // 5.
            requestAQuotePage.SelectSubmitButton();

            // 6.
            pulledFirstNameError = requestAQuotePage.GetFirstNameErrorMessage();
            Assert.AreNotEqual(firstNameErrorMessage, pulledFirstNameError);

            // 7.
            pulledLastNameError = requestAQuotePage.GetLastNameErrorMessage();
            Assert.AreEqual(lastNameErrorMessage, pulledLastNameError);

            driver.Quit();
        }
    }
}