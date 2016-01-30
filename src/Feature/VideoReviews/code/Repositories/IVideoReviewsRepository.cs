using Sitecore.Data.Items;

namespace Sitecore.Feature.VideoReviews.Repositories
{
    public interface IVideoReviewsRepository
    {
        /// <summary>
        /// Gets the global settings from sitecore
        /// </summary>
        /// <returns>return the settings data back</returns>
        Item GetGlobalSetting();

        /// <summary>
        /// gets the sku value from the 
        /// </summary>
        /// <param name="currentItem"></param>
        /// <returns></returns>
        string GetSku();
    }
}