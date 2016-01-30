namespace Sitecore.Feature.VideoReviews.Services
{
    using Sitecore.Data.Items;
    using Sitecore.Feature.VideoReviews.Models;
    public interface IVideoReviewsService
    {
        VideoReviews GetReviews(Item settings, string sku);
    }
}