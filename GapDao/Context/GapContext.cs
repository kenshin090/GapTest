﻿using GapCommon.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapDao.Contexts
{
    /// <summary>
    /// The db context
    /// </summary>
    public class GapContext : DbContext
    {
        /// <summary>
        /// Define the connection string
        /// </summary>
        public GapContext() : base("ConnString")
        {
        }

        /// <summary>
        /// The context to client table
        /// </summary>
        public DbSet<Client> Client { get; set; }

        /// <summary>
        /// The context to coverage type table
        /// </summary>
        public DbSet<CoverageType> CoverageType { get; set; }

        /// <summary>
        /// The context to Permissions table
        /// </summary>
        public DbSet<Permissions> Permissions { get; set; }

        /// <summary>
        /// The context to policies coverages table
        /// </summary>
        public DbSet<PoliciesCoverages> PoliciesCoverages { get; set; }

        /// <summary>
        /// The context to policy table
        /// </summary>
        public DbSet<Policy> Policy { get; set; }

        /// <summary>
        /// The context to policy client
        /// </summary>
        public DbSet<PolicyClient> PolicyClient { get; set; }

        /// <summary>
        /// The context to risk type table
        /// </summary>
        public DbSet<RiskType> RiskType { get; set; }

        /// <summary>
        /// The context to user table
        /// </summary>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// The context to UserToken table
        /// </summary>
        public DbSet<UserToken> UserToken { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ///Disable Lazy Load
            this.Configuration.LazyLoadingEnabled = false;

            ///Set the precision of percentage
            modelBuilder.Entity<PoliciesCoverages>().Property(st => st.Percentage).HasPrecision(10, 2);

            Database.SetInitializer<GapContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}