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
