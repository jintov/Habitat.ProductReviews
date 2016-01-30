namespace Sitecore.Feature.Reviews.Texts
{
    using Sitecore.Foundation.SitecoreExtensions.Repositories;

    public static class Captions
    {
        public static string Reviews => DictionaryRepository.Get("/Reviews/Captions/Reviews", "reviews");
    }
}