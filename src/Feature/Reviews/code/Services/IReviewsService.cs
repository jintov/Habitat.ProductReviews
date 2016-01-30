namespace Sitecore.Feature.Reviews.Services
{
    using Sitecore.Data.Items;

    public interface IReviewsService
    {
        void GetReviews(Item settings, string sku);
    }
}