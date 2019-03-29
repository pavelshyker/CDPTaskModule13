using log4net;
using log4net.Config;
using OpenQA.Selenium;
using System;
using TestWebProject.Webdriver;

namespace TestWebProject
{

    public static class Logger
    {
        public static ILog log = LogManager.GetLogger("LOGGER");

        public static ILog Log
        {
            get { return log; }
        }

        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }

        static Logger()
        {
            InitLogger();
        }

        public static void TakeScreenshot()
        {
            String fileName = "C:\\Users\\Pavel_Shyker\\CDPTasks\\CDPTaskModule13(1)\\UnitTestProject2\\Logs\\Image" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".jpg";
            Log.Error("Image" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".jpg -> Screen is created");
            Screenshot ss = ((ITakesScreenshot)Browser.GetDriver()).GetScreenshot();
            ss.SaveAsFile(fileName, ScreenshotImageFormat.Png);
        }
    }
}
