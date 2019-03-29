using OpenQA.Selenium;
using TestWebProject.Webdriver;
using System.Linq;

namespace TestWebProject.Pages
{
    public class DraftPage : BasePage
    {
        private static readonly By DraftPageLocator = By.XPath("//div[@class = 'b-sticky js-not-sticky']//div[@data-cache-key='500001_undefined_false']//div[@data-shortcut-title='Del'] | //div[@class = 'b-sticky']//div[@data-cache-key='500001_undefined_false']//div[@data-shortcut-title='Del']");

        public DraftPage() : base(DraftPageLocator, "Draft Page")
        {

        }

        private readonly BaseElement draftEmailItems = new BaseElement(By.XPath(".//a[contains(@href, 'drafts') and contains(@class, 'item')]//div[contains(@class, 'addr')]"));
        private readonly BaseElement newEmailButton = new BaseElement(By.XPath("//div[@class = 'b-sticky']//a[@data-name='compose'] | //div[@class = 'b-sticky js-not-sticky']//a[@data-name='compose']"));
        private readonly BaseElement checkBoxSelectAllDraft = new BaseElement(By.XPath("//div[@class = 'b-sticky js-not-sticky']//div[@data-cache-key != '0_undefined_false']//div[contains(@class, 'selectAll')]//div[contains(@class, 'b-checkbox__box')]"));
        private readonly BaseElement deleteButton = new BaseElement(By.XPath("//div[@class = 'b-sticky js-not-sticky']//div[@data-cache-key='500001_undefined_false']//div[@data-shortcut-title='Del']"));
        private readonly BaseElement emptyBlock = new BaseElement(By.ClassName("b-datalist__empty__block"));

        public string GetEmailAddress()
        {
            var draftElements = driver.FindElements(draftEmailItems.Locator);
            return draftElements.First().Text;
        }

        public void OpenEmail()
        {
            var draftElements = driver.FindElements(draftEmailItems.Locator);
            draftElements.First().Click();
        }

        public bool DraftEmailExist()
        {
            var draftElements = driver.FindElements(draftEmailItems.Locator);
            return draftElements.Any();
        }

        public void GoToNewEmailPage()
        {
            this.newEmailButton.Click();
        }

        public bool DeleteAllDraft()
        {
            var draftElements = driver.FindElements(draftEmailItems.Locator);
            if (draftElements.Any())
            {
                var elem = driver.FindElements(checkBoxSelectAllDraft.Locator);
                elem.First().Click();
                this.deleteButton.Click();
            }
            bool draftEmpty = this.emptyBlock.Displayed;
            return draftEmpty;
        }

    }
}
