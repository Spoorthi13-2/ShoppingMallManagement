using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingProjectA.Models
{
    public class ReportsVM
    {
        public List<StoreDetails> storeDetailsOcc { get; set; }

        public List<StoreDetails> storeDetailsVac { get; set; }
    }
}