using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Feature.VideoReviews.Models
{
    public class VideoReviews
    {
        public VideoReviews()
        {
            this.Reviews = new List<Review>();
        }

        public List<Review> Reviews { get; private set; }
    }
}