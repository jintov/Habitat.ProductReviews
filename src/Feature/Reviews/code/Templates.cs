namespace Sitecore.Feature.Reviews
{
    using Sitecore.Data;

    public class Templates
    {
        public struct ReviewsSettings
        {
            public static ID ID = new ID("");

            public struct Fields
            {
                public static readonly ID ReviewURL = new ID("");

                public static readonly ID Passkey = new ID("");
            }
        }

        public struct HasReviews
        {
            public static ID ID = new ID("");

            public struct Fields
            {
                public static readonly ID ReviewSKU = new ID("");
            }
        }
    }
}