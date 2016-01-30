namespace Sitecore.Feature.Reviews
{
    using Sitecore.Configuration;
    using Sitecore.Data;

    public class ConfigSettings
    {
        public static ID WatchedVideoPageEventId => new ID(Settings.GetSetting("Sitecore.Feature.VideoReviews.WatchedVideo", ""));
    }
}