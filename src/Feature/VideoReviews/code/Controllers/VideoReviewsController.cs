namespace Sitecore.Feature.VideoReviews.Controllers
{
  using System;
  using System.Web.Mvc;
  using System.Web.Security;
  using Sitecore;
  using Sitecore.Diagnostics;
  using Sitecore.Feature.VideoReviews.Repositories;

  public class VideoReviewsController : Controller
  {
    private readonly IVideoReviewsRepository videoReviewsRepository;

    public VideoReviewsController() : this(new VideoReviewsRepository())
    {
    }

    public VideoReviewsController(IVideoReviewsRepository videoReviewsRepository)
    {
      this.videoReviewsRepository = videoReviewsRepository;
    }
  }
}