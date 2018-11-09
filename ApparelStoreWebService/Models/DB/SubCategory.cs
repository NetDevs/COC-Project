using System;
using System.Collections.Generic;

namespace ApparelStoreWebService.Models.DB
{
    public partial class SubCategory
    {
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }

        public Category Category { get; set; }
    }
}
