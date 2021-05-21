# browserstack-camera-injection-ios-csharp

This repository demonstrates how to test the Camera Injection feature using Appium C# on BrowserStack App Automate.

### Requirements

1. Visual Studio 2019

    - If not installed, download and install Visual Studio 2019 from [here](https://visualstudio.microsoft.com/vs/)

### Getting Started

1. Configuring the test

    - Clone the repo
    - Add your BrowserStack username and access key to your environment variables - 
    ```
        export BROWSERSTACK_USERNAME=<browserstack_username> 
        export BROWSERSTACK_ACCESS_KEY=<browserstack_access_key>
    ```
    - Upload the Camera Injection sample app using the REST API - 
    ```
        curl -u "YOUR_USERNAME:YOUR_ACCESS_KEY" \
        -X POST "https://api-cloud.browserstack.com/app-automate/upload" \
        -F "file=@/path/to/ipa/file"
    ```
    - Update `bs://<app_url>` in [`Program.cs`](Program.cs) file with the obtained app URL after the previous step. 
    - Upload a sample image file using the REST API - 
    ```
        curl -u "YOUR_USERNAME:YOUR_ACCESS_KEY" \
        -X POST "https://api-cloud.browserstack.com/app-automate/upload-media" \
        -F "file=@/path/to/media/file/profile.png"
    ```
    - Update `media://<media_url>` in [`Program.cs`](Program.cs) file with the obtained media URL after the previous step.

2. Running the test
    - Directly run the test using Visual Studio. Or if you want to use terminal then run - 
    ```
        dotnet build
        dotnet run
    ```

3. Viewing the results
    - Go to your App Automate [dashboard](https://www.browserstack.com/app-automate) to view the results.
