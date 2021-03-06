﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _20_MVC_Assignment_1_DOTNET.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TwitterCloneEntities : DbContext
    {
        public TwitterCloneEntities()
            : base("name=TwitterCloneEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<PERSON> People { get; set; }
        public virtual DbSet<TWEET> TWEETs { get; set; }
    
        public virtual ObjectResult<USP_GETTWEETS_Result> USP_GETTWEETS(string userID)
        {
            var userIDParameter = userID != null ?
                new ObjectParameter("UserID", userID) :
                new ObjectParameter("UserID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<USP_GETTWEETS_Result>("USP_GETTWEETS", userIDParameter);
        }
    }
}
