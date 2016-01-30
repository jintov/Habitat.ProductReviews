namespace Sitecore.Feature.VideoReviews.Services
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Xml.Linq;
    using Helpers;
    using Reviews;
    using Sitecore.Data.Items;
    using Sitecore.Foundation.SitecoreExtensions.Extensions;
    using Sitecore.Feature.VideoReviews.Models;
    using System.Linq;
    using Sitecore.Feature.VideoReviews.Extensions;

    public class VideoReviewsService : IVideoReviewsService
    {

        //TODO:pick value from configuration
        private static readonly TimeSpan APITimeout = new TimeSpan(0, 0, 10);
        public virtual VideoReviews GetReviews(Item expoTvsettings, string sku)
        {
            VideoReviews videoReviewResponse = null;
            if (expoTvsettings != null && !string.IsNullOrWhiteSpace(sku))
            {
                string expoTvUrl = 
                      expoTvsettings.GetString(Templates.VideoReviewsSettings.Fields.DetailedReviewURL) + "/" + sku;
                if (!string.IsNullOrWhiteSpace(expoTvUrl))
                {
                    NameValueCollection headers = GetHeadersForRequest(expoTvsettings);
                    string expoTvResponse = ExpoTvExternalProviderClient.GetDataFromExpoTvProvider(expoTvUrl, headers).Result;
                    XDocument expoResponseDoc = XDocument.Parse(expoTvResponse);
                    if (expoResponseDoc != null && expoResponseDoc.Root != null &&
                        expoResponseDoc.Root.Element("reviews") != null)
                    {
                        IEnumerable<XElement> reviewItems = expoResponseDoc.Root.Element("reviews").Elements("review_item");
                        ////get the request info sections
                        //videoResponse = GetRequestInformation(doc.Root.Element("request_information"), videoReviewResponse);
                        //get the reviews
                        videoReviewResponse = GetReviewsFromXml(reviewItems);
                    }
                }
            }
            return videoReviewResponse;
        }

        private VideoReviews GetReviewsFromXml(IEnumerable<XElement> reviewItems)
        {
            VideoReviews reviewData = new VideoReviews();
            if (reviewItems.Any())
            {

                var reviews = reviewItems.Where(item => item != null).Select(reviewItem => new Review
                {

                    Id = reviewItem.GetElementValue("review_id", int.TryParse, -1),
                    Date = reviewItem.GetElementValue("date", DateTime.TryParse, DateTime.MinValue),
                    Title = reviewItem.GetElementValueAsString("review_title"),
                    Description = reviewItem.GetElementValueAsString("review_description"),
                    UserName = reviewItem.GetElementValueAsString("username"),


                    VideoUrl = reviewItem.GetElementValueAsUri("video_URL"),
                    ThumbnailImage = reviewItem.GetElementValueAsUri("video_thumb_URL"),

                    Rating = reviewItem.GetElementValue("member_product_rating", float.TryParse, default(float)),
                    RatingPercentage = GetRatingStarWidth(reviewItem.GetElementValue("member_product_rating", float.TryParse, default(float))),
                });
                if (reviews.Any())
                {
                    reviewData.Reviews.AddRange(reviews);
                }
            }
            return reviewData;
        }

        private double GetRatingStarWidth(float rating)
        {            
            return (double)(rating * 100) / 5;
        }

        private NameValueCollection GetHeadersForRequest(Item expoTvsettings)
        {
            NameValueCollection headers = new NameValueCollection();
            headers.Add("X-Expo_API_version", (expoTvsettings.FieldHasValue(Templates.VideoReviewsSettings.Fields.ApiVersion) ?
                expoTvsettings.GetString(Templates.VideoReviewsSettings.Fields.ApiVersion) : "2.0"));
            headers.Add("X-Expo_API_client_id", (expoTvsettings.FieldHasValue(Templates.VideoReviewsSettings.Fields.ClientId) ?
                expoTvsettings.GetString(Templates.VideoReviewsSettings.Fields.ClientId) : string.Empty));
            return headers;
        }
    }
}
