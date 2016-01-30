namespace Sitecore.Feature.VideoReviews.Repositories
{
    using System;
    using System.Web.Security;
    using Configuration;
    using Data;
    using Data.Items;
    using Reviews;
    using Sitecore;
    using Sitecore.Diagnostics;
    using Sitecore.Foundation.SitecoreExtensions.Extensions;

    public class VideoReviewsRepository : IVideoReviewsRepository
    {
        public Item ContextItem { get; set; }

        public VideoReviewsRepository(Item contextItem)
        {
            if (contextItem == null)
            {
                throw new ArgumentNullException(nameof(contextItem));
            }
            this.ContextItem = contextItem;
        }


        public Item GetGlobalSetting()
        {
            //TODO: replace with actual settings path
            string globalSettingsPath = "{F1BB8AA8-F01E-43A1-8FBF-BC17BA6CF859}";
            return this.ContextItem.Database.GetItem(globalSettingsPath);
        }

        public string GetSku()
        {
            //TODO: replace with actual Sku field id
            return this.ContextItem.FieldHasValue(Templates.HasVideoReviews.Fields.VideoReviewSKU) ? ContextItem.GetString(Templates.HasVideoReviews.Fields.VideoReviewSKU) : string.Empty;
        }
    }
}