namespace Sitecore.Feature.Reviews
{
    using Sitecore.Configuration;
    using Sitecore.Data;

    public class ConfigSettings
    {
        public static ID SubmitReviewGoalId => new ID(Settings.GetSetting("Sitecore.Feature.Reviews.SubmitReviewGoalId", ""));
    }
}