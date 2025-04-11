using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingProjectA.Models
{
    public class StoreReqVM
    {
        public RequestTable requestTable { get; set; }

        public List<StoreDetails> storeDetails { get; set; }
    }
}