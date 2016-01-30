using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.VideoReviews.Models
{
    public class Review
    {

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public float Rating { get; set; }

        public Double RatingPercentage { get; set; }

        public string UserName { get; set; }

        public Uri VideoUrl { get; set; }

        public Uri ThumbnailImage { get; set; }
    }
}