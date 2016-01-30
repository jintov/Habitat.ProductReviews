namespace Sitecore.Feature.Reviews
{
    using Sitecore.Data;

    public class Templates
    {
        public struct VideoReviewsSettings
        {
            public static ID ID = new ID("");

            public struct Fields
            {
                public static readonly ID ReviewURL = new ID("");

                public static readonly ID ClientId = new ID("");
            }
        }

        public struct HasVideoReviews
        {
            public static ID ID = new ID("");

            public struct Fields
            {
                public static readonly ID VideoReviewSKU = new ID("");
            }
        }
    }
}