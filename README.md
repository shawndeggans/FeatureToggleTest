***Feature Toggle Test

This application requires adding the https://www.nuget.org/packages/Microsoft.FeatureManagement

PM> Install-Package Microsoft.FeatureManagement -Version 1.0.0-preview-009000001-1251

Once the Nuget packages is added, inject the Feature Management in Startup.cs

~~~
using Microsoft.FeatureManagement;

public class Startup 
{
    public void ConfigureServices(IServiceCollection services)
    {
        //...
        services.AddFeatureManagement();
    }
}
~~~

To use the feature flag, we have to add a new section to the appsettings.json file

~~~
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "FeatureManagement": {
    "NewWelcomeBanner": false
  }
}
~~~

Becasue this is a Blazor app, we're going to test the feature flag at the Index.razor by adding a Blazor code behind class. The code for that class looks like the following:

~~~
using Microsoft.AspNetCore.Components;
using Microsoft.FeatureManagement;

namespace FeatureToggleTest.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject] protected IFeatureManager _featureManager { get; set; }

        protected string WelcomeMessage { get; set; }

        protected override void OnInitialized()
        {
            WelcomeMessage = _featureManager.IsEnabled("NewWelcomeBanner") ? "Welcome to the BETA" : "Welcome";
            base.OnInitialized();
        }
    }
}
~~~

The inex page code looks like th following:

~~~
@page "/"
@inherits IndexBase

<h1>@WelcomeMessage</h1>

~~~

By toggling the NewWelcomeBanner setting to true or false, we can either show
Welome or Welcome to the Beta

That's the most basic way to use the Toggle Feature

Thanks to Andrew Lock for providing the original example here: https://andrewlock.net/introducing-the-microsoft-featuremanagement-library-adding-feature-flags-to-an-asp-net-core-app-part-1/



