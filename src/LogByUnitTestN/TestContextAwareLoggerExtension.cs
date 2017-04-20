using System;
using System.IO;
using NLog;
using NUnit.Framework;

namespace LogByUnitTestN
{
    public static class TestContextAwareLoggerExtension
    {
        public static Logger GetLogger(this object obj)
        {
            try
            {
                var testName = TestContext.CurrentContext.Test.Name;
                foreach (char someChar in Path.GetInvalidFileNameChars())
                {
                    testName = testName.Replace(someChar, '_');
                }
                return LogManager.GetLogger(testName);
            }
            catch (NullReferenceException)
            {
                return LogManager.GetLogger(obj.GetType().Name);
            }
        }
    }
}
