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
                public static readonly ID SummarizedReviewURL = new ID("{9EE671E7-958E-4457-B9F1-2C30406FA157}");

                public static readonly ID DetailedReviewURL = new ID("{2AAD17DF-222B-41AC-9901-66F709C11B6E}");

                public static readonly ID ApiVersion = new ID("{B745785B-88FD-4A42-B154-177CC4E8F849}");

                public static readonly ID VideoPerPage = new ID("{0C33B7CB-E6D2-4AD6-A12D-660549B0BFA9}");

                public static readonly ID ClientId = new ID("{D6BEFC69-0522-47B6-845D-CE8832D552CE}");
            }
        }

        public struct HasVideoReviews
        {
            public static ID ID = new ID("");

            public struct Fields
            {
                public static readonly ID VideoReviewSKU = new ID("{62D5AAFB-C1BF-4570-9314-8F6CAE9986A7}");
            }
        }
    }
}