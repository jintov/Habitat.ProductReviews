namespace Sitecore.Feature.VideoReviews.Controllers
{
    using System;
    using System.Web.Mvc;
    using System.Web.Security;
    using Data.Items;
    using Services;
    using Sitecore;
    using Sitecore.Diagnostics;
    using Sitecore.Feature.VideoReviews.Repositories;
    using Sitecore.Feature.VideoReviews.Models;

    public class VideoReviewsController : Controller
    {
        private readonly IVideoReviewsService videoReviewsService;
        private readonly IVideoReviewsRepository videoReviewsRepository;

        public VideoReviewsController() : this(new VideoReviewsRepository(Context.Item), new VideoReviewsService())
        {

        }

        public VideoReviewsController(IVideoReviewsRepository videoReviewsRepository, IVideoReviewsService videoReviewsService)
        {
            this.videoReviewsRepository = videoReviewsRepository;
            this.videoReviewsService = videoReviewsService;
        }

        [HttpGet]
        public ActionResult ReviewsDisplay()
        {
            Item globalSetting = this.videoReviewsRepository.GetGlobalSetting();
            string skuId = this.videoReviewsRepository.GetSku();
            if (globalSetting != null && !string.IsNullOrWhiteSpace(skuId))
            {
                return this.View("ReviewDisplay", this.videoReviewsService.GetReviews(globalSetting, skuId));
            }
            else
            {
                return this.View("ReviewDisplay", (VideoReviews)null);
            }
        }
    }
}