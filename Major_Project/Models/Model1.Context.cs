﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Major_Project.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Major_ProjectEntities : DbContext
    {
        public Major_ProjectEntities()
            : base("name=Major_ProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<item> items { get; set; }
        public virtual DbSet<tbl_const> tbl_const { get; set; }
        public virtual DbSet<transac> transacs { get; set; }
        public virtual DbSet<tbl_FinalAmerge> tbl_FinalAmerge { get; set; }
        public virtual DbSet<tbl_FinalBmerge> tbl_FinalBmerge { get; set; }
        public virtual DbSet<tbl_Initial1> tbl_Initial1 { get; set; }
        public virtual DbSet<tbl_Initial2> tbl_Initial2 { get; set; }
    
        public virtual ObjectResult<string> prune()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("prune");
        }
    
        public virtual ObjectResult<sp_emptyall_Result> sp_emptyall()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_emptyall_Result>("sp_emptyall");
        }
    
        public virtual int sp_movetofinalAmerge(Nullable<int> level)
        {
            var levelParameter = level.HasValue ?
                new ObjectParameter("level", level) :
                new ObjectParameter("level", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_movetofinalAmerge", levelParameter);
        }
    
        public virtual int sp_refresh()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_refresh");
        }
    
        public virtual int sp_stepfirst()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_stepfirst");
        }
    
        public virtual int sp_stepsecond(string itema, string itemb)
        {
            var itemaParameter = itema != null ?
                new ObjectParameter("itema", itema) :
                new ObjectParameter("itema", typeof(string));
    
            var itembParameter = itemb != null ?
                new ObjectParameter("itemb", itemb) :
                new ObjectParameter("itemb", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_stepsecond", itemaParameter, itembParameter);
        }
    
        public virtual ObjectResult<string> count_itemname()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("count_itemname");
        }
    
        public virtual ObjectResult<Nullable<int>> count_itemcount()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("count_itemcount");
        }
    }
}
