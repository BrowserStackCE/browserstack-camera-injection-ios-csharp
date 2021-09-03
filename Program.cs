using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Appium.iOS;
using System.Threading;

namespace browserstack_camera_injection_ios_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            AppiumOptions caps = new AppiumOptions();


            // Set your BrowserStack access credentials
            caps.AddAdditionalCapability("browserstack.user", Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME"));
            caps.AddAdditionalCapability("browserstack.key", Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY"));

            // Set URL of the application under test
            caps.AddAdditionalCapability("app", Environment.GetEnvironmentVariable("BROWSERSTACK_APP_ID"));

            // Specify device and os_version
            caps.AddAdditionalCapability("device", "iPhone 11");
            caps.AddAdditionalCapability("os_version", "13");

            // Specify the platformName
            caps.PlatformName = "iOS";

            // Set other BrowserStack capabilities
            caps.AddAdditionalCapability("project", "Camera Injection BrowserStack");
            caps.AddAdditionalCapability("build", Environment.GetEnvironmentVariable("BROWSERSTACK_BUILD_NAME"));
            caps.AddAdditionalCapability("name", "sample_test");

            //Set media url
            caps.AddAdditionalCapability("browserstack.uploadMedia", new[] { "media://c190a75dc86cd8d1d84d2c4f5c690164faaeed31" });
            
            //Set camera injection capability
            caps.AddAdditionalCapability("browserstack.enableCameraImageInjection", "true");


            // Initialize the remote Webdriver using BrowserStack remote URL and desired capabilities defined above
            IOSDriver<IOSElement> driver = new IOSDriver<IOSElement>(new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);
            
            // JSE for camera injection with media url 
            driver.ExecuteScript("browserstack_executor: {\"action\": \"cameraImageInjection\", \"arguments\": {\"imageUrl\": \"media://c190a75dc86cd8d1d84d2c4f5c690164faaeed31\"}}");

            

            IOSElement TakePhotoButton = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Name("Take Photo"))
            );
            TakePhotoButton.Click();

            IOSElement allowCamera = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.AccessibilityId("OK"))
            );
            allowCamera.Click();

            IOSElement shutter = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Name("PhotoCapture"))
            );
            shutter.Click();

            IOSElement usephoto = (IOSElement)new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Name("Use Photo"))
            );
            usephoto.Click();

            driver.Quit();
        }
    }
    
}
