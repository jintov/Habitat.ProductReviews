namespace Sitecore.Feature.Reviews.Controllers
{
  using System;
  using System.Web.Mvc;
  using System.Web.Security;
  using Sitecore;
  using Sitecore.Diagnostics;
  using Sitecore.Feature.Reviews.Repositories;

  public class ReviewsController : Controller
  {
    private readonly IReviewsRepository reviewsRepository;

    public ReviewsController() : this(new ReviewsRepository())
    {
    }

    public ReviewsController(IReviewsRepository reviewsRepository)
    {
      this.reviewsRepository = reviewsRepository;
    }
  }
}