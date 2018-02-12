using StairEstate.Entity;
using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace StairEstate.Data
{
    public class MHLDB : DbContext
    {
        public MHLDB()
            : base("name=MHLDBConnection")
        {
        }

        public virtual DbSet<company> companies { get; set; }
        public virtual DbSet<lisence> lisences { get; set; }
        public virtual DbSet<survey_agenda> survey_agenda { get; set; }
        public virtual DbSet<survey_answer> survey_answer { get; set; }
        public virtual DbSet<survey_html> survey_html { get; set; }
        public virtual DbSet<survey_master> survey_master { get; set; }
        public virtual DbSet<survey_question> survey_question { get; set; }
        public virtual DbSet<survey_user_access> survey_user_access { get; set; }
        public virtual DbSet<sys_branch> sys_branch { get; set; }
        public virtual DbSet<sys_country> sys_country { get; set; }
        public virtual DbSet<sys_currency> sys_currency { get; set; }
        public virtual DbSet<sys_loginlog> sys_loginlog { get; set; }
        public virtual DbSet<sys_menu> sys_menu { get; set; }
        public virtual DbSet<sys_restrictions> sys_restrictions { get; set; }
        public virtual DbSet<sys_scheduler> sys_scheduler { get; set; }
        public virtual DbSet<sys_scheduler_switch> sys_scheduler_switch { get; set; }
        public virtual DbSet<sys_user> sys_user { get; set; }
        public virtual DbSet<sys_user_menu_access> sys_user_menu_access { get; set; }
        public virtual DbSet<sys_user_restriction> sys_user_restriction { get; set; }
        public virtual DbSet<sys_user_type> sys_user_type { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<company>()
                .Property(e => e.companyname)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.TIN)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.BIN)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<company>()
                .Property(e => e.started)
                .IsUnicode(false);

            modelBuilder.Entity<lisence>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<lisence>()
                .Property(e => e.expires)
                .IsUnicode(false);

            modelBuilder.Entity<survey_agenda>()
                .HasMany(e => e.survey_master)
                .WithOptional(e => e.survey_agenda)
                .HasForeignKey(e => e.agenda)
                .WillCascadeOnDelete();

            modelBuilder.Entity<survey_agenda>()
                .HasMany(e => e.survey_question)
                .WithOptional(e => e.survey_agenda)
                .HasForeignKey(e => e.agenda);

            modelBuilder.Entity<survey_html>()
                .HasMany(e => e.survey_question)
                .WithOptional(e => e.survey_html)
                .HasForeignKey(e => e.htmlstring);

            modelBuilder.Entity<survey_master>()
                .HasMany(e => e.survey_answer)
                .WithOptional(e => e.survey_master)
                .HasForeignKey(e => e.survey)
                .WillCascadeOnDelete();

            modelBuilder.Entity<survey_question>()
                .HasMany(e => e.survey_answer)
                .WithOptional(e => e.survey_question)
                .HasForeignKey(e => e.question)
                .WillCascadeOnDelete();

            modelBuilder.Entity<sys_branch>()
                .Property(e => e.branch_tin)
                .IsUnicode(false);

            modelBuilder.Entity<sys_branch>()
                .HasMany(e => e.survey_master)
                .WithOptional(e => e.sys_branch)
                .HasForeignKey(e => e.branch);

            modelBuilder.Entity<sys_country>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<sys_country>()
                .HasMany(e => e.sys_branch)
                .WithOptional(e => e.sys_country)
                .HasForeignKey(e => e.country);

            modelBuilder.Entity<sys_currency>()
                .Property(e => e.currency_name)
                .IsUnicode(false);

            modelBuilder.Entity<sys_currency>()
                .Property(e => e.shortname)
                .IsUnicode(false);

            modelBuilder.Entity<sys_currency>()
                .HasOptional(e => e.sys_country)
                .WithRequired(e => e.sys_currency);

            modelBuilder.Entity<sys_loginlog>()
                .Property(e => e.logintime)
                .IsUnicode(false);

            modelBuilder.Entity<sys_loginlog>()
                .Property(e => e.loginuser)
                .IsUnicode(false);

            modelBuilder.Entity<sys_restrictions>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<sys_restrictions>()
                .HasMany(e => e.sys_user_restriction)
                .WithOptional(e => e.sys_restrictions)
                .HasForeignKey(e => e.accesscode);

            modelBuilder.Entity<sys_scheduler>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<sys_scheduler>()
                .Property(e => e.detail)
                .IsUnicode(false);

            modelBuilder.Entity<sys_user>()
                .HasMany(e => e.survey_master)
                .WithOptional(e => e.sys_user)
                .HasForeignKey(e => e.userid);

            modelBuilder.Entity<sys_user>()
                .HasMany(e => e.sys_user_restriction)
                .WithOptional(e => e.sys_user)
                .HasForeignKey(e => e.userid);

            modelBuilder.Entity<sys_user_type>()
                .HasMany(e => e.sys_user_menu_access)
                .WithOptional(e => e.sys_user_type)
                .WillCascadeOnDelete();
        }
    }
}
