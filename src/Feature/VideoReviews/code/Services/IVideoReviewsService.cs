namespace Sitecore.Feature.VideoReviews.Services
{
    using Sitecore.Data.Items;

    public interface IVideoReviewsService
    {
        void GetReviews(Item settings, string sku);
    }
}