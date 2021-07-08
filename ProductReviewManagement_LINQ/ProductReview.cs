using System;
using System.Collections.Generic;
using System.Text;

namespace ProductReviewManagement_LINQ
{
    class ProductReview
    {
        public int ProducID { get; set; }
        public int UserID { get; set; }
        public double Rating { get; set; }
        public string Review { get; set; }
        public bool isLike { get; set; }

    }
}
