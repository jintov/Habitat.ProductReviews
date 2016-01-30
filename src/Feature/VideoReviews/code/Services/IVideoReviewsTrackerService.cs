namespace Sitecore.Feature.VideoReviews.Services
{
    public interface IVideoReviewsTrackerService
    {
        void TrackVideoWatch(string videoId);
    }
}