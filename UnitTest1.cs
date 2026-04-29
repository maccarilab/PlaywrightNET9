using Microsoft.Playwright;

namespace PlaywrightNET9
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        [Test]
        public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
        {
            await Page.GotoAsync("https://playwright.dev");

            // Expect a title "to contain" a substring.
            await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));

            // create a locator
            var getStarted = Page.Locator("text=Get Started");

            // Expect an attribute "to be strictly equal" to the value.
            await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

            // Click the get started link.
            await getStarted.ClickAsync();

            // Expects the URL to contain intro.
            await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
        }
        [Test]
        public async Task VersioneX_81()
        {
            await using var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,
            });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync("https://www.pendolariumbri.it/");
            //await page.GetByRole(AriaRole.Textbox, new() { Name = "Username" }).ClickAsync();
            //await page.GetByRole(AriaRole.Textbox, new() { Name = "Username" }).FillAsync("provaz");
            //await page.GetByRole(AriaRole.Button, new() { Name = "Continua" }).ClickAsync();
            //await page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).ClickAsync();
            //await page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).FillAsync("demo");
            //await page.GetByRole(AriaRole.Button, new() { Name = "Invia" }).ClickAsync();
            await page.WaitForTimeoutAsync(3000);
            await page.ScreenshotAsync(new()
            {
                Path = "./../../../Screenshot/HomeScreenshot.jpg",
                //string fileProcessicsv = "./../../../Processi.csv";
                //C:\Lab2026\PlaywrightNET9\PlaywrightNET9\UnitTest1.cs
                FullPage = true
            });
        }
    }
}
