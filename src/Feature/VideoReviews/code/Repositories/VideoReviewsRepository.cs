namespace Sitecore.Feature.VideoReviews.Repositories
{
    using System;
    using System.Linq;
    using System.Web.Security;
    using Configuration;
    using Data;
    using Data.Items;
    using Reviews;
    using Sitecore;
    using Sitecore.Diagnostics;
    using Sitecore.Foundation.SitecoreExtensions.Extensions;
    using Sites;
    public class VideoReviewsRepository : IVideoReviewsRepository
    {
        public Item ContextItem { get; set; }
        public SiteContext CurrentSite { get; set; }

        public VideoReviewsRepository(Item contextItem, SiteContext currentSite)
        {
            if (contextItem == null) 
            {
                throw new ArgumentNullException(nameof(contextItem));
            }
            if (currentSite == null)
            {
                throw new ArgumentNullException(nameof(currentSite));
            }
            this.ContextItem = contextItem;
            this.CurrentSite = currentSite;
        }


        public Item GetGlobalSetting()
        {   
            Item currentItem = this.ContextItem.Database.GetItem(CurrentSite.RootPath);
            if (currentItem != null)
            {
               return currentItem.Axes.GetDescendants().Where(item => item.TemplateID == Templates.HasVideoReviews.ID)
                    .FirstOrDefault();
            }
            return null;
        }

        public string GetSku()
        {            
            //TODO: replace with actual Sku field id
            return this.ContextItem.FieldHasValue(Templates.HasVideoReviews.Fields.VideoReviewSKU) ? ContextItem.GetString(Templates.HasVideoReviews.Fields.VideoReviewSKU) : string.Empty;
        }
    }
}