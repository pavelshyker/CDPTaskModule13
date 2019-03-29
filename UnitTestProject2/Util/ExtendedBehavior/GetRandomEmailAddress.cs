using TestWebProject.Pages;

namespace TestWebProject.Webdriver
{
    public class GetRandomEmailAddress
    {
        public static string GetRandomEmail()
        {
            string currentPage = Browser.GetDriver().CurrentWindowHandle;
            Browser.OpenNewTab(Configuration.RandomEmailServiceUrl);
            var randomEmailForm = new RandomEmailPage();
            randomEmailForm.SetEmailAddress();
            Browser.GetDriver().SwitchTo().Window(currentPage);
            return randomEmailForm.EmailAddress;
        }
    }
}
