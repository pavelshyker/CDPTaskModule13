namespace TestWebProject
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TestWebProject.Pages;
    using TestWebProject.Webdriver;
    using TestWebProject.BO;
    using log4net;
    using System;

    [TestClass]
    public class MailRuMSTests : BaseTest
    {
        private const string LogIn = "testuser.19";
        private const string Password = "testCDP123";
        private const string EmailAddress = "litmarsd@mail.ru";
        private const string EmailSubject = "Subject";
        private const string EmailText = "EmailTestText";


        [TestMethod, TestCategory("Login")]
        public void LoginTest()
        {
            try
            {
                var startPage = new StartPage();
                startPage.Login(new User(LogIn, Password));
                Assert.IsTrue(startPage.LoginSuccessMarker());
            }
            catch (Exception ex)
            {
                Logger.TakeScreenshot();
                Logger.log.Error("Exception: " + ex);
            }
        }

        [TestMethod, TestCategory("EmailCreating")]
        public void CreateDraftEmailTest()
        {
            try
            {
                new StartPage().Login(new User(LogIn, Password));
                new InboxPage().GoToNewEmailPage();

                var emailPage = new EmailPage();
                emailPage.CreateANewEmail(new Email(EmailAddress, EmailSubject, EmailText));
                emailPage.SaveAsADraft();
                emailPage.GoToDraftPage();

                Assert.AreEqual(EmailAddress, new DraftPage().GetEmailAddress());
            }
            catch(Exception ex)
            {
                Logger.TakeScreenshot();
                Logger.log.Error("Exception: " + ex);
            }
        }

        [TestMethod, TestCategory("EmailSending")]
        public void SendFolderAfterSendingTest()
        {
            try
            {
                new StartPage().Login(new User(LogIn, Password));
                new InboxPage().GoToSentPage();

                var sentPage = new SentPage();
                sentPage.DeleteAllSent();
                sentPage.GoToNewEmailPage();

                var emailPage = new EmailPage();
                emailPage.CreateANewEmail(new Email(EmailAddress, EmailSubject, EmailText));
                emailPage.SaveAsADraft();
                emailPage.GoToDraftPage();

                new DraftPage().OpenEmail();

                emailPage.SendEmail();
                emailPage.GoToSentPage();

                Assert.IsTrue(sentPage.SentEmailExist());
            }

            catch (Exception ex)
            {
                Logger.TakeScreenshot();
                Logger.log.Error("Exception: " + ex);
            }
        }

        [TestMethod, TestCategory("Logout")]
        public void LogoutTest()
        {
            try
            {
                var startPage = new StartPage();
                startPage.Login(new User(LogIn, Password));

                new InboxPage().LogOut();

                Assert.IsTrue(startPage.LogoutSuccessMarker());
            }

            catch (Exception ex)
            {
                Logger.log.Error("Exception: " + ex);
            }
        }
    }
}
