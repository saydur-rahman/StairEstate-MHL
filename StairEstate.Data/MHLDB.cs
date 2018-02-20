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
        public virtual DbSet<hr_employee> hr_employee { get; set; }
        public virtual DbSet<hr_employee_type> hr_employee_type { get; set; }
        public virtual DbSet<hr_profession> hr_profession { get; set; }
        public virtual DbSet<lisence> lisences { get; set; }
        public virtual DbSet<sales_collector> sales_collector { get; set; }
        public virtual DbSet<sales_customer> sales_customer { get; set; }
        public virtual DbSet<sales_nominee> sales_nominee { get; set; }
        public virtual DbSet<sales_nominee_type> sales_nominee_type { get; set; }
        public virtual DbSet<sales_profession> sales_profession { get; set; }
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

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_code)
                .IsUnicode(false);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_name)
                .IsUnicode(false);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_email)
                .IsUnicode(false);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_phone)
                .IsUnicode(false);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_father_or_husband_name)
                .IsUnicode(false);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_mother_name)
                .IsUnicode(false);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_permanent_address)
                .IsUnicode(false);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_present_address)
                .IsUnicode(false);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_birth_place)
                .IsUnicode(false);

            modelBuilder.Entity<hr_employee>()
                .Property(e => e.emp_image)
                .IsFixedLength();

            modelBuilder.Entity<hr_employee>()
                .HasMany(e => e.sales_collector)
                .WithOptional(e => e.hr_employee)
                .HasForeignKey(e => e.collector_sales_person_id);

            modelBuilder.Entity<hr_employee>()
                .HasMany(e => e.sales_customer)
                .WithOptional(e => e.hr_employee)
                .HasForeignKey(e => e.customer_sales_person_id);

            modelBuilder.Entity<hr_employee_type>()
                .Property(e => e.emp_type_name)
                .IsUnicode(false);

            modelBuilder.Entity<hr_profession>()
                .Property(e => e.profession_name)
                .IsUnicode(false);

            modelBuilder.Entity<hr_profession>()
                .HasMany(e => e.sales_collector)
                .WithOptional(e => e.hr_profession)
                .HasForeignKey(e => e.collector_profession_id);

            modelBuilder.Entity<lisence>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<lisence>()
                .Property(e => e.expires)
                .IsUnicode(false);

            modelBuilder.Entity<sales_collector>()
                .Property(e => e.collector_code)
                .IsUnicode(false);

            modelBuilder.Entity<sales_collector>()
                .Property(e => e.collector_phone)
                .IsUnicode(false);

            modelBuilder.Entity<sales_collector>()
                .Property(e => e.collector_father_or_husband_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_collector>()
                .Property(e => e.collector_mother_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_collector>()
                .Property(e => e.collector_parmanent_address)
                .IsUnicode(false);

            modelBuilder.Entity<sales_collector>()
                .Property(e => e.collector_present_address)
                .IsUnicode(false);

            modelBuilder.Entity<sales_collector>()
                .Property(e => e.collector_birth_place)
                .IsUnicode(false);

            modelBuilder.Entity<sales_collector>()
                .Property(e => e.collector_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_collector>()
                .Property(e => e.collector_image)
                .IsFixedLength();

            modelBuilder.Entity<sales_collector>()
                .HasMany(e => e.sales_customer)
                .WithOptional(e => e.sales_collector)
                .HasForeignKey(e => e.customer_collector_id);

            modelBuilder.Entity<sales_customer>()
                .Property(e => e.customer_code)
                .IsUnicode(false);

            modelBuilder.Entity<sales_customer>()
                .Property(e => e.customer_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_customer>()
                .Property(e => e.customer_phone)
                .IsUnicode(false);

            modelBuilder.Entity<sales_customer>()
                .Property(e => e.customer_father_or_husband_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_customer>()
                .Property(e => e.customer_mother_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_customer>()
                .Property(e => e.customer_permanent_address)
                .IsUnicode(false);

            modelBuilder.Entity<sales_customer>()
                .Property(e => e.customer_present_address)
                .IsUnicode(false);

            modelBuilder.Entity<sales_customer>()
                .Property(e => e.customer_birth_place)
                .IsUnicode(false);

            modelBuilder.Entity<sales_customer>()
                .Property(e => e.customer_image)
                .IsFixedLength();

            modelBuilder.Entity<sales_customer>()
                .HasMany(e => e.sales_nominee)
                .WithOptional(e => e.sales_customer)
                .HasForeignKey(e => e.nominee_customer_id);

            modelBuilder.Entity<sales_nominee>()
                .Property(e => e.nominee_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_nominee>()
                .Property(e => e.nominee_identification_no)
                .IsUnicode(false);

            modelBuilder.Entity<sales_nominee>()
                .Property(e => e.nominee_relation)
                .IsUnicode(false);

            modelBuilder.Entity<sales_nominee>()
                .Property(e => e.nominee_details)
                .IsUnicode(false);

            modelBuilder.Entity<sales_nominee>()
                .Property(e => e.nominee_image)
                .IsUnicode(false);

            modelBuilder.Entity<sales_nominee_type>()
                .Property(e => e.nominee_type_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_nominee_type>()
                .HasMany(e => e.sales_nominee)
                .WithOptional(e => e.sales_nominee_type)
                .HasForeignKey(e => e.nominee_position_id);

            modelBuilder.Entity<sales_profession>()
                .Property(e => e.profession_name)
                .IsUnicode(false);

            modelBuilder.Entity<sales_profession>()
                .HasMany(e => e.sales_customer)
                .WithOptional(e => e.sales_profession)
                .HasForeignKey(e => e.customer_profession_id);

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
                .HasMany(e => e.hr_employee)
                .WithOptional(e => e.sys_branch)
                .HasForeignKey(e => e.emp_branch_id);

            modelBuilder.Entity<sys_branch>()
                .HasMany(e => e.sales_collector)
                .WithOptional(e => e.sys_branch)
                .HasForeignKey(e => e.collector_branch_id);

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
