using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingProjectA.Models
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext() : base("name = Conn")
        {

        }

        public DbSet<Registration> Registrations { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<BusinessCategory> businessCategories { get; set; }

        public DbSet<StoreDetails> storeDetails { get; set; }

        public DbSet<Shop> shops { get; set; }

        public DbSet<FilterList> filterLists { get; set; }

        public DbSet<RequestTable> requestTables { get; set; }

        public System.Data.Entity.DbSet<ShoppingProjectA.Models.ForgotId> ForgotIds { get; set; }

        public System.Data.Entity.DbSet<ShoppingProjectA.Models.ForgotPw> ForgotPws { get; set; }

        public System.Data.Entity.DbSet<ShoppingProjectA.Models.PwReset> PwResets { get; set; }

        public DbSet<ReviewT> reviewTs { get; set; }

        public DbSet<Help> helps { get; set; }
    }
}