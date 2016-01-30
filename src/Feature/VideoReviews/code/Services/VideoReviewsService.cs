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

    public class VideoReviewsService : IVideoReviewsService
    {

        //TODO:pick value from configuration
        private static readonly TimeSpan APITimeout = new TimeSpan(0, 0, 10);
        public virtual void GetReviews(Item expoTvsettings, string sku)
        {
            if (expoTvsettings != null && !string.IsNullOrWhiteSpace(sku))
            {
                string expoTvUrl = expoTvsettings.FieldHasValue(Templates.VideoReviewsSettings.Fields.DetailedReviewURL) ?
                      expoTvsettings.GetString(Templates.VideoReviewsSettings.Fields.DetailedReviewURL) + "/" + sku : string.Empty;
                if (!string.IsNullOrWhiteSpace(expoTvUrl))
                {
                    NameValueCollection headers = GetHeadersForRequest(expoTvsettings);
                    string expoTvResponse = ExpoTvExternalProviderClient.GetDataFromExpoTvProvider(expoTvUrl, headers).Result;
                    XDocument expoResponseDoc = XDocument.Parse(expoTvResponse);
                    if (expoResponseDoc != null && expoResponseDoc.Root != null &&
                        expoResponseDoc.Root.Element("reviews") != null)
                    {
                        IEnumerable<XElement> reviewItems = expoResponseDoc.Root.Elements("review_item");
                        ////get the request info sections
                        //videoResponse = GetRequestInformation(doc.Root.Element("request_information"), videoReviewResponse);
                        ////get the reviews
                        //videoReviewResponse = GetReviews(reviewItems, videoReviewResponse);
                    }
                }

            }
        }
        private NameValueCollection GetHeadersForRequest(Item expoTvsettings)
        {
            NameValueCollection headers = new NameValueCollection();
            headers.Add("X-Expo_API_version", (expoTvsettings.FieldHasValue(Templates.VideoReviewsSettings.Fields.ClientId) ?
                expoTvsettings.GetString("ApiVersion") : "2.0"));
            headers.Add("X-Expo_API_client_id", (expoTvsettings.FieldHasValue(Templates.VideoReviewsSettings.Fields.ClientId) ?
                expoTvsettings.GetString(Templates.VideoReviewsSettings.Fields.ClientId) : string.Empty));
            return headers;
        }