using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Metadata;
using PolicyManagementMailer.Models;


#nullable disable

namespace PolicyManagementDataAccess.Context
{
     public partial class BrkBaseContext : IdentityDbContext<IdentityUser>
    //public partial class BrkBaseContext :DbContext
    {
         protected readonly IConfiguration Configuration;
        public BrkBaseContext()
        {
        }

        //public BrkBaseContext(DbContextOptions<BrkBaseContext> options)
        ////: base(options)
        //{

        // }
        public BrkBaseContext(IConfiguration configuration, DbContextOptions<BrkBaseContext> options)/*(DbContextOptions<BrkBaseContext> options)*/
        : base(options)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //            if (!optionsBuilder.IsConfigured)
            //            {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            //                optionsBuilder.UseSqlServer("Server=MFU001_TRUSERVC;Database=BrkBase;Trusted_Connection=True;");
            //            }

            
            if (!optionsBuilder.IsConfigured)
            {
                // connect to sql server database
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DataConnection"));
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Addresses>(entity => {
                entity.HasKey(e => e.AddressID)
                  .IsClustered(false);

              
                entity.Property(e => e.AddressLine1).HasMaxLength(250);

                entity.Property(e => e.AddressLine2).HasMaxLength(250);

                entity.Property(e => e.PostalCode).HasMaxLength(250);

                entity.Property(e => e.City).HasMaxLength(20);
                entity.Property(e => e.AddressType).HasMaxLength(250);
                entity.Property(e => e.AddressName).HasMaxLength(250);

               

            });

            modelBuilder.Entity<Agent>(entity =>
            {
                entity.HasKey(e => e.AgentKey)
                    .IsClustered(false);

                entity.ToTable("Agent");

                entity.HasComment("Keeps all Data of Agents.");

                entity.HasIndex(e => e.AgentKey, "IX_Agent");

                entity.HasIndex(e => e.AgentKey, "Key_Agent")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.AgentKey).ValueGeneratedNever();

                entity.Property(e => e.AccHolder).HasMaxLength(35);

                entity.Property(e => e.AccNum).HasMaxLength(15);

                entity.Property(e => e.AccType).HasMaxLength(3);

                entity.Property(e => e.Address1).HasMaxLength(250);

                entity.Property(e => e.Address2).HasMaxLength(250);

                entity.Property(e => e.Address3).HasMaxLength(250);

                entity.Property(e => e.AgentName).HasMaxLength(350);

                entity.Property(e => e.AgentNum).HasMaxLength(25);

                entity.Property(e => e.AgtComFreq).HasDefaultValueSql("((0))");

                entity.Property(e => e.AgtVatregTf)
                    .HasColumnName("AgtVATRegTF")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.BankName).HasMaxLength(35);

                entity.Property(e => e.BranchCode).HasMaxLength(15);

                entity.Property(e => e.BranchName).HasMaxLength(35);

                entity.Property(e => e.BranchTown).HasMaxLength(25);

                entity.Property(e => e.ContactEmail).HasMaxLength(50);

                entity.Property(e => e.ContactFax).HasMaxLength(15);

                entity.Property(e => e.ContactPhone).HasMaxLength(15);

                entity.Property(e => e.FldAgentIsactiveflag)
                    .HasColumnName("fldAGENT_ISACTIVEFLAG")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FldIsrecompliantflag)
                    .HasColumnName("fldISRECOMPLIANTFLAG")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IdregNum)
                    .HasMaxLength(20)
                    .HasColumnName("IDRegNum");

                entity.Property(e => e.PostalCode).HasMaxLength(16);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.AreaKeyNavigation)
                    .WithMany(p => p.Agents)
                    .HasForeignKey(d => d.AreaKey)
                    .HasConstraintName("FK_Agent_Area");

                entity.HasOne(d => d.LevelKeyNavigation)
                    .WithMany(p => p.Agents)
                    .HasForeignKey(d => d.LevelKey)
                    .HasConstraintName("FK_Agent_AgentLevel");
            });

            modelBuilder.Entity<AgentCommission>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AgentCommission", "Policy");

                entity.Property(e => e.FldBranchName)
                    .HasMaxLength(25)
                    .HasColumnName("fldBRANCH_NAME");

                entity.Property(e => e.FldMemberCover)
                    .HasColumnType("money")
                    .HasColumnName("fldMEMBER_COVER");

                entity.Property(e => e.FldMemberPremium)
                    .HasColumnType("money")
                    .HasColumnName("fldMEMBER_PREMIUM");

                entity.Property(e => e.FldPolicyCapturedby)
                    .HasMaxLength(70)
                    .HasColumnName("fldPOLICY_CAPTUREDBY");

                entity.Property(e => e.FldPolicyCommencementdate)
                    .HasColumnType("date")
                    .HasColumnName("fldPOLICY_COMMENCEMENTDATE");

                entity.Property(e => e.FldPolicyStatus)
                    .HasMaxLength(70)
                    .HasColumnName("fldPOLICY_STATUS");

                entity.Property(e => e.FldPolicyTerminationdate)
                    .HasColumnType("date")
                    .HasColumnName("fldPOLICY_TERMINATIONDATE");

                entity.Property(e => e.FldSalespersonDisplayname)
                    .HasMaxLength(350)
                    .HasColumnName("fldSALESPERSON_DISPLAYNAME");

                entity.Property(e => e.FldSalespersonEnddate)
                    .HasColumnType("date")
                    .HasColumnName("fldSALESPERSON_ENDDATE");

                entity.Property(e => e.FldSalespersonStartdate)
                    .HasColumnType("date")
                    .HasColumnName("fldSALESPERSON_STARTDATE");
            });

            modelBuilder.Entity<AgentLevel>(entity =>
            {
                entity.HasKey(e => e.LevelKey);

                entity.ToTable("AgentLevel");

                entity.Property(e => e.LevelKey).ValueGeneratedNever();

                entity.Property(e => e.ActiveTf).HasColumnName("ActiveTF");

                entity.Property(e => e.LvlDescript)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AgentPayment>(entity =>
            {
                entity.HasKey(e => e.AgtPayKey)
                    .IsClustered(false);

                entity.ToTable("AgentPayment");

                entity.HasComment("Keeps the calculation of what was due and what was paid to an Agent for a specific Month.");

                entity.HasIndex(e => e.AgtPayKey, "IX_AgentPayment")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.AgtPayKey).ValueGeneratedNever();

                entity.Property(e => e.AgtPayType).HasMaxLength(3);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.AgentKeyNavigation)
                    .WithMany(p => p.AgentPayments)
                    .HasForeignKey(d => d.AgentKey)
                    .HasConstraintName("FK_AgentPayment_Agent");

                entity.HasOne(d => d.CapitalKeyNavigation)
                    .WithMany(p => p.AgentPayments)
                    .HasForeignKey(d => d.CapitalKey)
                    .HasConstraintName("FK_AgentPayment_Capital");
            });

            modelBuilder.Entity<AmmendBeneficiary>(entity =>
            {
                entity.HasKey(e => e.BeneficiaryId);

                entity.ToTable("AmmendBeneficiary");

                entity.Property(e => e.BeneficiaryId).HasColumnName("BeneficiaryID");

                entity.Property(e => e.Alias)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BenNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Code).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idnum)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("IDNum");

                entity.Property(e => e.Initials)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Pst1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pst2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pst3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.UserDateTime).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<AmmendMemberCollect>(entity =>
            {
                entity.HasKey(e => e.MemColKey);

                entity.ToTable("AmmendMemberCollect");

                entity.Property(e => e.MemColKey).ValueGeneratedNever();

                entity.Property(e => e.CollectAction)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CollectIdnum)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CollectIDNum");

                entity.Property(e => e.CollectInitial)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CollectSurname)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.CollectType)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DoAccNum)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DoAccType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DoBankName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DoBranchCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DoBranchName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SoStaffNum)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UnpReason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AmmendMemberDetail>(entity =>
            {
                entity.HasKey(e => e.MemDetNum);

                entity.ToTable("AmmendMemberDetail");

                entity.Property(e => e.MemDetNum).ValueGeneratedNever();

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.FirstName).HasMaxLength(25);

                entity.Property(e => e.Idnum)
                    .HasMaxLength(15)
                    .HasColumnName("IDNum");

                entity.Property(e => e.MaidenName).HasMaxLength(25);

                entity.Property(e => e.Occupation).HasMaxLength(25);

                entity.Property(e => e.SecondName).HasMaxLength(25);

                entity.Property(e => e.Sex).HasMaxLength(8);

                entity.Property(e => e.Surname).HasMaxLength(25);

                entity.Property(e => e.Title).HasMaxLength(5);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AmmendMemberGroup>(entity =>
            {
                entity.HasKey(e => e.MemGrpNum);

                entity.ToTable("AmmendMemberGroup");

                entity.Property(e => e.MemGrpNum).ValueGeneratedNever();

                entity.Property(e => e.ActiveTf).HasColumnName("ActiveTF");

                entity.Property(e => e.CanReason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactCell)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ContactEmail).HasMaxLength(50);

                entity.Property(e => e.ContactPerson).HasMaxLength(25);

                entity.Property(e => e.ContactPhone).HasMaxLength(15);

                entity.Property(e => e.CoverId).HasColumnName("CoverID");

                entity.Property(e => e.EasyPayNum).HasMaxLength(20);

                entity.Property(e => e.FldRef)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Idnum)
                    .HasMaxLength(15)
                    .HasColumnName("IDNum");

                entity.Property(e => e.InsInterest).HasMaxLength(25);

                entity.Property(e => e.InsRef)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatus).HasMaxLength(25);

                entity.Property(e => e.PostalCode).HasMaxLength(6);

                entity.Property(e => e.PstAddress1).HasMaxLength(25);

                entity.Property(e => e.PstAddress2).HasMaxLength(25);

                entity.Property(e => e.PstAddress3).HasMaxLength(25);

                entity.Property(e => e.StrAddress1)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StrAddress2)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StrAddress3)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StrAddress4)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(25);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<AmmendMemberProposer>(entity =>
            {
                entity.HasKey(e => e.MemPropKey);

                entity.ToTable("AmmendMemberProposer");

                entity.Property(e => e.MemPropKey).ValueGeneratedNever();

                entity.Property(e => e.Address1).HasMaxLength(25);

                entity.Property(e => e.Address2).HasMaxLength(25);

                entity.Property(e => e.Address3).HasMaxLength(25);

                entity.Property(e => e.ContactEmail).HasMaxLength(35);

                entity.Property(e => e.ContactPhone).HasMaxLength(15);

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.FirstName).HasMaxLength(25);

                entity.Property(e => e.Idnum)
                    .HasMaxLength(25)
                    .HasColumnName("IDNum");

                entity.Property(e => e.Occupation).HasMaxLength(25);

                entity.Property(e => e.PostalCode).HasMaxLength(6);

                entity.Property(e => e.RelationToPrincipalMember).HasMaxLength(25);

                entity.Property(e => e.SecondName).HasMaxLength(25);

                entity.Property(e => e.Surname).HasMaxLength(25);

                entity.Property(e => e.Title).HasMaxLength(5);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.Property(e => e.WorkPhone).HasMaxLength(15);
            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.AreaKey)
                    .IsClustered(false);

                entity.ToTable("Area");

                entity.HasComment("All geographical areas where the agents may operate. One or multiples.");

                entity.HasIndex(e => e.AreaKey, "IX_Area")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.AreaKey).ValueGeneratedNever();

                entity.Property(e => e.ActiveTf).HasColumnName("ActiveTF");

                entity.Property(e => e.AreaDescript).HasMaxLength(50);

                entity.Property(e => e.AreaName).HasMaxLength(25);

                entity.Property(e => e.AreaNum).HasMaxLength(10);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            //modelBuilder.Entity<AspNetRole>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedName] IS NOT NULL)");

            //    entity.Property(e => e.Name).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetRoleClaim>(entity =>
            //{
            //    entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            //    entity.Property(e => e.RoleId).IsRequired();

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetRoleClaims)
            //        .HasForeignKey(d => d.RoleId);
            //});

            //modelBuilder.Entity<AspNetUser>(entity =>
            //{
            //    entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            //    entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
            //        .IsUnique()
            //        .HasFilter("([NormalizedUserName] IS NOT NULL)");

            //    entity.Property(e => e.Email).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            //    entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            //    entity.Property(e => e.UserName).HasMaxLength(256);
            //});

            //modelBuilder.Entity<AspNetUserClaim>(entity =>
            //{
            //    entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            //    entity.Property(e => e.UserId).IsRequired();

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserClaims)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserLogin>(entity =>
            //{
            //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            //    entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            //    entity.Property(e => e.UserId).IsRequired();

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserLogins)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserRole>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.RoleId });

            //    entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.RoleId);

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserRoles)
            //        .HasForeignKey(d => d.UserId);
            //});

            //modelBuilder.Entity<AspNetUserToken>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.AspNetUserTokens)
            //        .HasForeignKey(d => d.UserId);
            //});

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.BankKey);

                entity.ToTable("Bank");

                entity.Property(e => e.BankName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.BankShort)
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.HasKey(e => e.AccKey);

                entity.ToTable("BankAccount");

                entity.Property(e => e.AccKey).ValueGeneratedNever();

                entity.Property(e => e.AccName).HasMaxLength(25);

                entity.Property(e => e.AccNum).HasMaxLength(15);

                entity.Property(e => e.AccType).HasMaxLength(3);

                entity.Property(e => e.BankName).HasMaxLength(50);

                entity.Property(e => e.BranchCode).HasMaxLength(10);

                entity.Property(e => e.BranchName).HasMaxLength(50);

                entity.Property(e => e.ContactEmail).HasMaxLength(30);

                entity.Property(e => e.ContactFax).HasMaxLength(15);

                entity.Property(e => e.ContactPerson).HasMaxLength(25);

                entity.Property(e => e.ContactPhone).HasMaxLength(15);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Beneficiary>(entity =>
            {
                entity.ToTable("Beneficiary");

                entity.HasIndex(e => e.MemGrpNum, "NonClusteredIndex-20180705-134727");

                entity.Property(e => e.BeneficiaryId).HasColumnName("BeneficiaryID");

                entity.Property(e => e.Alias)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BenNum)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Code).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idnum)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("IDNum");

                entity.Property(e => e.Initials)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Pst1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pst2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pst3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserDateTime).HasColumnType("smalldatetime");
            });

            modelBuilder.Entity<BenefitCover>(entity =>
            {
                entity.HasKey(e => new { e.CoverKey, e.CvrVersion });

                entity.ToTable("BenefitCover");

                entity.Property(e => e.ActiveTf).HasColumnName("ActiveTF");

                entity.Property(e => e.CompulsoryTf).HasColumnName("CompulsoryTF");

                entity.Property(e => e.CurrentTf).HasColumnName("CurrentTF");

                entity.Property(e => e.CvrAtClmTf).HasColumnName("CvrAtClmTF");

                entity.Property(e => e.CvrDescript).HasMaxLength(30);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Ben)
                    .WithMany(p => p.BenefitCovers)
                    .HasForeignKey(d => new { d.BenefitKey, d.BenVersion })
                    .HasConstraintName("FK_BenefitCover_SchemeBenefit");
            });

            modelBuilder.Entity<BnkBranch>(entity =>
            {
                entity.HasKey(e => e.BrnKey);

                entity.ToTable("BnkBranch");

                entity.Property(e => e.BrnCde).HasMaxLength(6);

                entity.Property(e => e.BrnName).HasMaxLength(30);

                entity.Property(e => e.BrnStream).HasMaxLength(2);

                entity.Property(e => e.ContactDialCode).HasMaxLength(20);

                entity.Property(e => e.ContactFax).HasMaxLength(20);

                entity.Property(e => e.ContactPhone).HasMaxLength(14);

                entity.Property(e => e.PostalCode).HasMaxLength(6);

                entity.Property(e => e.PstAddress1).HasMaxLength(8);

                entity.Property(e => e.PstAddress2).HasMaxLength(20);

                entity.Property(e => e.StrAddress1).HasMaxLength(48);

                entity.Property(e => e.StrAddress2).HasMaxLength(48);
            });

            modelBuilder.Entity<BrnPerBnk>(entity =>
            {
                entity.HasKey(e => new { e.BankKey, e.BrnKey });

                entity.ToTable("BrnPerBnk");

                entity.HasOne(d => d.BankKeyNavigation)
                    .WithMany(p => p.BrnPerBnks)
                    .HasForeignKey(d => d.BankKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BrnPerBnk_Bank");

                entity.HasOne(d => d.BrnKeyNavigation)
                    .WithMany(p => p.BrnPerBnks)
                    .HasForeignKey(d => d.BrnKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BrnPerBnk_BnkBranch");
            });

            modelBuilder.Entity<BrnRange>(entity =>
            {
                entity.HasKey(e => e.RngKey);

                entity.ToTable("BrnRange");

                entity.HasOne(d => d.BankKeyNavigation)
                    .WithMany(p => p.BrnRanges)
                    .HasForeignKey(d => d.BankKey)
                    .HasConstraintName("FK_BrnRange_Bank");
            });

            modelBuilder.Entity<Broker>(entity =>
            {
                entity.HasKey(e => e.BrokerKey);

                entity.ToTable("Broker");

                entity.Property(e => e.BrokerKey).ValueGeneratedNever();

                entity.Property(e => e.BrokerName).HasMaxLength(35);

                entity.Property(e => e.BrokerShort).HasMaxLength(3);

                entity.Property(e => e.GetBrkFeeTf).HasColumnName("GetBrkFeeTF");

                entity.Property(e => e.RegNum).HasMaxLength(15);

                entity.Property(e => e.UseAgentSysTf).HasColumnName("UseAgentSysTF");

                entity.Property(e => e.UseImgSysTf).HasColumnName("UseImgSysTF");

                entity.Property(e => e.UsePropSysTf).HasColumnName("UsePropSysTF");

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<BrokerBranch>(entity =>
            {
                entity.HasKey(e => e.BranchKey)
                    .HasName("PK_BrokerSystem");

                entity.ToTable("BrokerBranch");

                entity.Property(e => e.BranchKey).ValueGeneratedNever();

                entity.Property(e => e.ActiveTf).HasColumnName("ActiveTF");

                entity.Property(e => e.BranchCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BranchName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ContactFax)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PstAddress1)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PstAddress2)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PstAddress3)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StrAddress1)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StrAddress2)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StrAddress3)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StrAddress4)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.BrokerKeyNavigation)
                    .WithMany(p => p.BrokerBranches)
                    .HasForeignKey(d => d.BrokerKey)
                    .HasConstraintName("FK_BrokerBranch_Broker");
            });

            modelBuilder.Entity<BrokerControl>(entity =>
            {
                entity.HasKey(e => e.ControlKey);

                entity.ToTable("BrokerControl");

                entity.Property(e => e.ControlKey).ValueGeneratedNever();

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.PayMonthlyTf).HasColumnName("PayMonthlyTF");

                entity.Property(e => e.RatePerMember).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SysDateFormat).HasMaxLength(10);
            });

            modelBuilder.Entity<BrokerFee>(entity =>
            {
                entity.HasKey(e => e.BrkFeeKey);

                entity.ToTable("BrokerFee");

                entity.Property(e => e.BrkFeeKey).ValueGeneratedNever();

                entity.Property(e => e.BrkFeeType).HasMaxLength(3);

                entity.Property(e => e.Descript).HasMaxLength(35);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.CapitalKeyNavigation)
                    .WithMany(p => p.BrokerFees)
                    .HasForeignKey(d => d.CapitalKey)
                    .HasConstraintName("FK_BrokerFee_Capital");
            });

            modelBuilder.Entity<BrokerImage>(entity =>
            {
                entity.HasKey(e => e.ImageKey);

                entity.ToTable("BrokerImage");

                entity.Property(e => e.ImageKey).ValueGeneratedNever();

                entity.Property(e => e.ImgDescript)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ImgReference1)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ImgReference2)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<BrokerNotification>(entity =>
            {
                entity.ToTable("BrokerNotification");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AmendRef).HasMaxLength(250);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");
            });

            modelBuilder.Entity<BrokerPerson>(entity =>
            {
                entity.HasKey(e => e.PersonKey);

                entity.ToTable("BrokerPerson");

                entity.Property(e => e.PersonKey).ValueGeneratedNever();

                entity.Property(e => e.ActiveTf).HasColumnName("ActiveTF");

                entity.Property(e => e.ContactEmail)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.ContactFax)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhone)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PersonType)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Position)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.BrokerKeyNavigation)
                    .WithMany(p => p.BrokerPeople)
                    .HasForeignKey(d => d.BrokerKey)
                    .HasConstraintName("FK_BrokerPerson_Broker");
            });

            modelBuilder.Entity<BrokerTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BrokerTable");

                entity.Property(e => e.ImgLinkTf).HasColumnName("ImgLinkTF");

                entity.Property(e => e.TableCode).HasMaxLength(15);

                entity.Property(e => e.TableName).HasMaxLength(50);
            });

            modelBuilder.Entity<CallMeBack>(entity =>
            {
                entity.ToTable("CallMeBack");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Comment).HasMaxLength(250);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.MobileNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NearestBranch)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Product)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Capital>(entity =>
            {
                entity.HasKey(e => e.CapitalKey);

                entity.ToTable("Capital");

                entity.Property(e => e.CapitalKey).ValueGeneratedNever();

                entity.Property(e => e.BalancedTf).HasColumnName("BalancedTF");

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.Property(e => e.UserNum).HasMaxLength(50);

                entity.HasOne(d => d.AccKeyNavigation)
                    .WithMany(p => p.Capitals)
                    .HasForeignKey(d => d.AccKey)
                    .HasConstraintName("FK_Capital_BankAccount");
            });

            modelBuilder.Entity<Cheque>(entity =>
            {
                entity.HasKey(e => e.ChequeKey);

                entity.ToTable("Cheque");

                entity.Property(e => e.ChequeKey).ValueGeneratedNever();

                entity.Property(e => e.ChqAutDateTime).HasColumnType("datetime");

                entity.Property(e => e.ChqCanDateTime).HasColumnType("datetime");

                entity.Property(e => e.ChqCanReason).HasMaxLength(50);

                entity.Property(e => e.ChqCapDateTime).HasColumnType("datetime");

                entity.Property(e => e.ChqPayDateTime).HasColumnType("datetime");

                entity.Property(e => e.ChqStatus).HasMaxLength(3);

                entity.Property(e => e.ChqUnaReason).HasMaxLength(50);

                entity.Property(e => e.Chqeftnum)
                    .HasMaxLength(30)
                    .HasColumnName("CHQEFTNum");

                entity.Property(e => e.PayAccNum).HasMaxLength(15);

                entity.Property(e => e.PayAccType).HasMaxLength(3);

                entity.Property(e => e.PayBank).HasMaxLength(30);

                entity.Property(e => e.PayBranchCode).HasMaxLength(10);

                entity.Property(e => e.PayType).HasMaxLength(3);

                entity.Property(e => e.Payee).HasMaxLength(45);

                entity.HasOne(d => d.CapitalKeyNavigation)
                    .WithMany(p => p.Cheques)
                    .HasForeignKey(d => d.CapitalKey)
                    .HasConstraintName("FK_Cheque_Capital");
            });

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.HasKey(e => e.ClaimNum);

                entity.ToTable("Claim");

                entity.Property(e => e.ClaimNum).HasMaxLength(12);

                entity.Property(e => e.AssFirstName).HasMaxLength(25);

                entity.Property(e => e.AssSecondName).HasMaxLength(25);

                entity.Property(e => e.AssSurname).HasMaxLength(25);

                entity.Property(e => e.CertNum).HasMaxLength(10);

                entity.Property(e => e.CertType).HasMaxLength(10);

                entity.Property(e => e.ClmAutDateTime).HasColumnType("datetime");

                entity.Property(e => e.ClmCanDateTime).HasColumnType("datetime");

                entity.Property(e => e.ClmCanReason).HasMaxLength(50);

                entity.Property(e => e.ClmCapDateTime).HasColumnType("datetime");

                entity.Property(e => e.ClmCause).HasMaxLength(50);

                entity.Property(e => e.ClmDob).HasColumnName("ClmDOB");

                entity.Property(e => e.ClmFinDateTime).HasColumnType("datetime");

                entity.Property(e => e.ClmFirstName).HasMaxLength(25);

                entity.Property(e => e.ClmFwdDateTime).HasColumnType("datetime");

                entity.Property(e => e.ClmIdnum)
                    .HasMaxLength(15)
                    .HasColumnName("ClmIDNum");

                entity.Property(e => e.ClmRefDateTime).HasColumnType("datetime");

                entity.Property(e => e.ClmRepDateTime).HasColumnType("datetime");

                entity.Property(e => e.ClmRepReason).HasMaxLength(50);

                entity.Property(e => e.ClmSecondName).HasMaxLength(25);

                entity.Property(e => e.ClmStatus).HasMaxLength(3);

                entity.Property(e => e.ClmSurname).HasMaxLength(25);

                entity.Property(e => e.ClmType).HasMaxLength(3);

                entity.Property(e => e.ExtClaimNum).HasMaxLength(25);

                entity.Property(e => e.FldClaimAmountpaid)
                    .HasColumnType("money")
                    .HasColumnName("fldCLAIM_AMOUNTPAID");

                entity.Property(e => e.FldClaimDatepaid)
                    .HasColumnType("date")
                    .HasColumnName("fldCLAIM_DATEPAID");

                entity.Property(e => e.FldClaimRefnumber)
                    .HasMaxLength(75)
                    .HasColumnName("fldCLAIM_REFNUMBER");

                entity.Property(e => e.NotifyMethod).HasMaxLength(25);

                entity.Property(e => e.NotifyPerson).HasMaxLength(25);

                entity.Property(e => e.PenCode).HasMaxLength(10);

                entity.HasOne(d => d.CapitalKeyNavigation)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.CapitalKey)
                    .HasConstraintName("FK_Claim_Capital");

                entity.HasOne(d => d.RelationKeyNavigation)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.RelationKey)
                    .HasConstraintName("FK_Claim_Relation");
            });

            modelBuilder.Entity<ClaimRefund>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ClaimRefund");

                entity.Property(e => e.ClaimNum).HasMaxLength(12);

                entity.Property(e => e.UserDateTime).HasColumnType("smalldatetime");

                entity.HasOne(d => d.CapitalKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CapitalKey)
                    .HasConstraintName("FK_ClaimRefund_Capital");

                entity.HasOne(d => d.ClaimNumNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ClaimNum)
                    .HasConstraintName("FK_ClaimRefund_Claim");
            });

            modelBuilder.Entity<ClmPenCode>(entity =>
            {
                entity.HasKey(e => e.PenCodeKey);

                entity.ToTable("ClmPenCode");

                entity.Property(e => e.PenCodeKey).ValueGeneratedNever();

                entity.Property(e => e.PenCode).HasMaxLength(1);

                entity.Property(e => e.PenDescript).HasMaxLength(25);
            });

            modelBuilder.Entity<ColOrgDept>(entity =>
            {
                entity.HasKey(e => e.DeptKey);

                entity.ToTable("ColOrgDept");

                entity.Property(e => e.DeptKey).ValueGeneratedNever();

                entity.Property(e => e.ActiveTf).HasColumnName("ActiveTF");

                entity.Property(e => e.Address1).HasMaxLength(25);

                entity.Property(e => e.Address2).HasMaxLength(25);

                entity.Property(e => e.Address3).HasMaxLength(25);

                entity.Property(e => e.ContactEmail).HasMaxLength(50);

                entity.Property(e => e.ContactFax).HasMaxLength(15);

                entity.Property(e => e.ContactPerson).HasMaxLength(55);

                entity.Property(e => e.ContactPhone).HasMaxLength(15);

                entity.Property(e => e.DeptHead).HasMaxLength(50);

                entity.Property(e => e.DeptName).HasMaxLength(85);

                entity.Property(e => e.DeptShort).HasMaxLength(5);

                entity.Property(e => e.PostalCode).HasMaxLength(6);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.ColOrgKeyNavigation)
                    .WithMany(p => p.ColOrgDepts)
                    .HasForeignKey(d => d.ColOrgKey)
                    .HasConstraintName("FK_ColOrgDept_CollectOrg");
            });

            modelBuilder.Entity<CollectOrg>(entity =>
            {
                entity.HasKey(e => e.ColOrgKey)
                    .HasName("PK_PayCompany");

                entity.ToTable("CollectOrg");

                entity.Property(e => e.ColOrgKey).ValueGeneratedNever();

                entity.Property(e => e.ActiveTf).HasColumnName("ActiveTF");

                entity.Property(e => e.Address1).HasMaxLength(25);

                entity.Property(e => e.Address2).HasMaxLength(25);

                entity.Property(e => e.Address3).HasMaxLength(25);

                entity.Property(e => e.AltColOrgCode).HasMaxLength(10);

                entity.Property(e => e.ColOrgCode).HasMaxLength(10);

                entity.Property(e => e.ColOrgGroup).HasMaxLength(5);

                entity.Property(e => e.ColOrgName).HasMaxLength(35);

                entity.Property(e => e.ColOrgShort).HasMaxLength(5);

                entity.Property(e => e.ContactEmail).HasMaxLength(30);

                entity.Property(e => e.ContactFax).HasMaxLength(15);

                entity.Property(e => e.ContactPerson).HasMaxLength(25);

                entity.Property(e => e.ContactPhone).HasMaxLength(15);

                entity.Property(e => e.DeductDescript)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode).HasMaxLength(6);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<CollectOrgBkp20200522>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CollectOrgBkp20200522");

                entity.Property(e => e.ActiveTf).HasColumnName("ActiveTF");

                entity.Property(e => e.Address1).HasMaxLength(25);

                entity.Property(e => e.Address2).HasMaxLength(25);

                entity.Property(e => e.Address3).HasMaxLength(25);

                entity.Property(e => e.AltColOrgCode).HasMaxLength(10);

                entity.Property(e => e.ColOrgCode).HasMaxLength(10);

                entity.Property(e => e.ColOrgGroup).HasMaxLength(5);

                entity.Property(e => e.ColOrgName).HasMaxLength(30);

                entity.Property(e => e.ColOrgShort).HasMaxLength(5);

                entity.Property(e => e.ContactEmail).HasMaxLength(30);

                entity.Property(e => e.ContactFax).HasMaxLength(15);

                entity.Property(e => e.ContactPerson).HasMaxLength(25);

                entity.Property(e => e.ContactPhone).HasMaxLength(15);

                entity.Property(e => e.DeductDescript)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode).HasMaxLength(6);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.CommentKey);

                entity.ToTable("Comment");

                entity.Property(e => e.CommentKey).ValueGeneratedNever();

                entity.Property(e => e.CapDateTime).HasColumnType("datetime");

                entity.Property(e => e.CmtHeading)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CmtReference)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CmtSubject)
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.CmtText)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<CommentLink>(entity =>
            {
                entity.HasKey(e => e.LinkKey);

                entity.ToTable("CommentLink");

                entity.Property(e => e.LinkKey).ValueGeneratedNever();

                entity.Property(e => e.AlphaLnkKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CmtLnkType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.CommentKeyNavigation)
                    .WithMany(p => p.CommentLinks)
                    .HasForeignKey(d => d.CommentKey)
                    .HasConstraintName("FK_CommentLink_Comment");
            });

            modelBuilder.Entity<Commission>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("COMMISSIONS", "Policy");

                entity.Property(e => e.CommissionEarned)
                    .HasColumnType("money")
                    .HasColumnName("COMMISSION_EARNED");

                entity.Property(e => e.FldBranchName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("fldBRANCH_NAME");

                entity.Property(e => e.FldMemberCover)
                    .HasColumnType("money")
                    .HasColumnName("fldMEMBER_COVER");

                entity.Property(e => e.FldMemberPremium)
                    .HasColumnType("money")
                    .HasColumnName("fldMEMBER_PREMIUM");

                entity.Property(e => e.FldPolicyCapturedby)
                    .HasMaxLength(70)
                    .HasColumnName("fldPOLICY_CAPTUREDBY");

                entity.Property(e => e.FldPolicyCommencementdate)
                    .HasColumnType("date")
                    .HasColumnName("fldPOLICY_COMMENCEMENTDATE");

                entity.Property(e => e.FldPolicyTerminationdate)
                    .HasColumnType("date")
                    .HasColumnName("fldPOLICY_TERMINATIONDATE");
            });

            modelBuilder.Entity<CompulsoryCover>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CompulsoryCover");

                entity.Property(e => e.ClaimNum).HasMaxLength(12);

                entity.HasOne(d => d.ClaimNumNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ClaimNum)
                    .HasConstraintName("FK_CompulsoryCover_Claim");

                entity.HasOne(d => d.C)
                    .WithMany()
                    .HasForeignKey(d => new { d.CoverKey, d.CvrVersion })
                    .HasConstraintName("FK_CompulsoryCover_BenefitCover");
            });

            //modelBuilder.Entity<PolicyCover>(entity =>
            //{
            //    entity.ToTable("PolicyCover", "Policy");

            //    entity.Property(e => e.PolicyCoverID).HasColumnName("PolicyCoverID");
            //    entity.Property(e => e.RelationKey).HasColumnName("RelationKey");
            //    entity.Property(e => e.MinAge).HasColumnName("MinAge");
            //    entity.Property(e => e.MaxAge).HasColumnName("MaxAge");

            //    entity.Property(e => e.CoverAmount)
            //        .HasColumnType("money")
            //        .HasColumnName("CoverAmount");
            //    entity.Property(e => e.Premium)
            //     .HasColumnType("money")
            //     .HasColumnName("Premium");

            //    entity.Property(e => e.Description).HasMaxLength(150);



            //    entity.Property(e => e.PlanID)
            //        .HasMaxLength(75)
            //        .HasColumnName("PlanID");

             
            //});

            modelBuilder.Entity<DeleteGroup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DeleteGroup");
            });

            modelBuilder.Entity<EasyPayImport>(entity =>
            {
                entity.HasKey(e => e.ImportId)
                    .HasName("PK_EasyPayImports");

                entity.ToTable("EasyPayImport");

                entity.Property(e => e.ImportId).HasColumnName("ImportID");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.Property(e => e.UserNum)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ImageLink>(entity =>
            {
                entity.HasKey(e => e.LinkKey);

                entity.ToTable("ImageLink");

                entity.Property(e => e.LinkKey).ValueGeneratedNever();

                entity.Property(e => e.AlphaLnkKey)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ImgLnkType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.ImageKeyNavigation)
                    .WithMany(p => p.ImageLinks)
                    .HasForeignKey(d => d.ImageKey)
                    .HasConstraintName("FK_ImageLink_BrokerImage");

                entity.HasOne(d => d.NumLnkKeyNavigation)
                    .WithMany(p => p.ImageLinks)
                    .HasForeignKey(d => d.NumLnkKey)
                    .HasConstraintName("FK_ImageLink_Agent");

                entity.HasOne(d => d.NumLnkKey1)
                    .WithMany(p => p.ImageLinks)
                    .HasForeignKey(d => d.NumLnkKey)
                    .HasConstraintName("FK_ImageLink_MemberGroup");

                entity.HasOne(d => d.NumLnkKey2)
                    .WithMany(p => p.ImageLinks)
                    .HasForeignKey(d => d.NumLnkKey)
                    .HasConstraintName("FK_ImageLink_InsPlan");

                entity.HasOne(d => d.NumLnkKey3)
                    .WithMany(p => p.ImageLinks)
                    .HasForeignKey(d => d.NumLnkKey)
                    .HasConstraintName("FK_ImageLink_Receipt");
            });

            modelBuilder.Entity<InsPlan>(entity =>
            {
                entity.HasKey(e => e.PlanNum);

                entity.ToTable("InsPlan");

                entity.Property(e => e.PlanNum).ValueGeneratedNever();

                entity.Property(e => e.ActiveTf).HasColumnName("ActiveTF");

                entity.Property(e => e.PlanName).HasMaxLength(30);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.InsurerKeyNavigation)
                    .WithMany(p => p.InsPlans)
                    .HasForeignKey(d => d.InsurerKey)
                    .HasConstraintName("FK_InsPlan_Insurer");
            });

            modelBuilder.Entity<Insurer>(entity =>
            {
                entity.HasKey(e => e.InsurerKey);

                entity.ToTable("Insurer");

                entity.Property(e => e.InsurerKey).ValueGeneratedNever();

                entity.Property(e => e.ActiveTf).HasColumnName("ActiveTF");

                entity.Property(e => e.AnnexuresTf).HasColumnName("AnnexuresTF");

                entity.Property(e => e.CompRegNum).HasMaxLength(15);

                entity.Property(e => e.ContactEmail).HasMaxLength(35);

                entity.Property(e => e.ContactFax).HasMaxLength(15);

                entity.Property(e => e.ContactPerson).HasMaxLength(25);

                entity.Property(e => e.ContactPhone).HasMaxLength(15);

                entity.Property(e => e.InsurerName).HasMaxLength(30);

                entity.Property(e => e.InsurerNotesTf).HasColumnName("InsurerNotesTF");

                entity.Property(e => e.PostalCode).HasMaxLength(6);

                entity.Property(e => e.PstAddress1).HasMaxLength(25);

                entity.Property(e => e.PstAddress2).HasMaxLength(25);

                entity.Property(e => e.PstAddress3).HasMaxLength(25);

                entity.Property(e => e.PstAddress4).HasMaxLength(25);

                entity.Property(e => e.StrAddress1).HasMaxLength(25);

                entity.Property(e => e.StrAddress2).HasMaxLength(25);

                entity.Property(e => e.StrAddress3).HasMaxLength(25);

                entity.Property(e => e.StrAddress4).HasMaxLength(25);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<LevelCover>(entity =>
            {
                entity.HasKey(e => new { e.LevelKey, e.CoverKey, e.CvrVersion });

                entity.ToTable("LevelCover");

                entity.Property(e => e.LvlPayType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.LevelKeyNavigation)
                    .WithMany(p => p.LevelCovers)
                    .HasForeignKey(d => d.LevelKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LevelCover_AgentLevel");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.LevelCovers)
                    .HasForeignKey(d => new { d.CoverKey, d.CvrVersion })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LevelCover_BenefitCover");
            });

            modelBuilder.Entity<MemberApplication>(entity =>
            {
                entity.HasKey(e => e.MemDetNum)
                    .HasName("PK__MemberAp__92D3BBDA7D528F9E");

                entity.ToTable("MemberApplication");

                entity.Property(e => e.MemDetNum).ValueGeneratedNever();

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(250);

                entity.Property(e => e.Idnum)
                    .HasMaxLength(150)
                    .HasColumnName("IDNum");

                entity.Property(e => e.MaidenName).HasMaxLength(250);

                entity.Property(e => e.Occupation).HasMaxLength(250);

                entity.Property(e => e.Phone).HasMaxLength(250);

                entity.Property(e => e.SecondName).HasMaxLength(250);

                entity.Property(e => e.Sex).HasMaxLength(8);

                entity.Property(e => e.Surname).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<MemberCollect>(entity =>
            {
                entity.HasKey(e => e.MemColKey);

                entity.ToTable("MemberCollect");

                entity.HasIndex(e => e.ColOrgKey, "IX_ColOrgKey");

                entity.Property(e => e.MemColKey).ValueGeneratedNever();

                entity.Property(e => e.CollectAction)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CollectIdnum)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CollectIDNum");

                entity.Property(e => e.CollectInitial)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.CollectSurname)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.CollectType)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DoAccNum)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DoAccType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DoBankName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DoBranchCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DoBranchName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SoStaffNum)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UnpReason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.ColOrgKeyNavigation)
                    .WithMany(p => p.MemberCollects)
                    .HasForeignKey(d => d.ColOrgKey)
                    .HasConstraintName("FK_MemberCollect_CollectOrg");
            });

            modelBuilder.Entity<MemberCollectBkp20200429>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MemberCollectBkp20200429");

                entity.Property(e => e.CollectAction)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CollectIdnum)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CollectIDNum");

                entity.Property(e => e.CollectInitial)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CollectSurname)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.CollectType)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DoAccNum)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DoAccType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DoBankName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DoBranchCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DoBranchName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SoStaffNum)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UnpReason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<MemberCollectBkp20200504>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MemberCollectBkp20200504");

                entity.Property(e => e.CollectAction)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CollectIdnum)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CollectIDNum");

                entity.Property(e => e.CollectInitial)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CollectSurname)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.CollectType)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DoAccNum)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DoAccType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DoBankName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DoBranchCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DoBranchName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SoStaffNum)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UnpReason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<MemberCollectHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MemberCollectHistory");

                entity.Property(e => e.CollectAction)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CollectIdnum)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CollectIDNum");

                entity.Property(e => e.CollectInitial)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CollectSurname)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.CollectType)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DoAccNum)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DoAccType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DoBankName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DoBranchCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DoBranchName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MemColId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MemColID");

                entity.Property(e => e.Memgrpnum).HasColumnName("memgrpnum");

                entity.Property(e => e.SoStaffNum)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.UnpReason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<MemberCompliance>(entity =>
            {
                entity.ToTable("MemberCompliance");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.PolicyReplacementCompany).HasMaxLength(150);

                entity.Property(e => e.PremiumPayerSignature).HasMaxLength(150);
            });

            modelBuilder.Entity<MemberCover>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MemberCover");

                entity.HasIndex(e => new { e.MemDetNum, e.CoverKey, e.CvrVersion }, "IX_MemberCover")
                    .IsUnique()
                    .IsClustered();

                entity.Property(e => e.ClaimNum).HasMaxLength(12);

                entity.Property(e => e.PayCvrFeeTf).HasColumnName("PayCvrFeeTF");

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.ClaimNumNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ClaimNum)
                    .HasConstraintName("FK_MemberCover_Claim");

                entity.HasOne(d => d.MemDetNumNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.MemDetNum)
                    .HasConstraintName("FK_MemberCover_MemberDetail");

                entity.HasOne(d => d.C)
                    .WithMany()
                    .HasForeignKey(d => new { d.CoverKey, d.CvrVersion })
                    .HasConstraintName("FK_MemberCover_BenefitCover");
            });

            modelBuilder.Entity<MemberCoverHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MemberCoverHistory");

                entity.Property(e => e.ClaimNum).HasMaxLength(12);

                entity.Property(e => e.MemCvrId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MemCvrID");

                entity.Property(e => e.PayCvrFeeTf).HasColumnName("PayCvrFeeTF");

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<MemberDetail>(entity =>
            {
                entity.HasKey(e => e.MemDetNum);

                entity.ToTable("MemberDetail");

                entity.HasIndex(e => e.MemGrpNum, "IX_PolicyID");

                entity.HasIndex(e => e.RelationKey, "IX_RelationKey");

                entity.Property(e => e.MemDetNum).ValueGeneratedNever();

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.FirstName).HasMaxLength(25);

                entity.Property(e => e.Idnum)
                    .HasMaxLength(15)
                    .HasColumnName("IDNum");

                entity.Property(e => e.MaidenName).HasMaxLength(25);

                entity.Property(e => e.Occupation).HasMaxLength(25);

                entity.Property(e => e.SecondName).HasMaxLength(25);

                entity.Property(e => e.Sex).HasMaxLength(8);

                entity.Property(e => e.Surname).HasMaxLength(25);

                entity.Property(e => e.Title).HasMaxLength(5);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.MemGrpNumNavigation)
                    .WithMany(p => p.MemberDetails)
                    .HasForeignKey(d => d.MemGrpNum)
                    .HasConstraintName("FK_MemberDetail_MemberGroup");

                entity.HasOne(d => d.RelationKeyNavigation)
                    .WithMany(p => p.MemberDetails)
                    .HasForeignKey(d => d.RelationKey)
                    .HasConstraintName("FK_MemberDetail_Relation");
            });

            modelBuilder.Entity<MemberDetailHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MemberDetailHistory");

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.FirstName).HasMaxLength(25);

                entity.Property(e => e.Idnum)
                    .HasMaxLength(15)
                    .HasColumnName("IDNum");

                entity.Property(e => e.MaidenName).HasMaxLength(25);

                entity.Property(e => e.MemDetId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MemDetID");

                entity.Property(e => e.Occupation).HasMaxLength(25);

                entity.Property(e => e.SecondName).HasMaxLength(25);

                entity.Property(e => e.Sex).HasMaxLength(8);

                entity.Property(e => e.Surname).HasMaxLength(25);

                entity.Property(e => e.Title).HasMaxLength(5);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<MemberGroup>(entity =>
            {
                entity.HasKey(e => e.MemGrpNum);

                entity.ToTable("MemberGroup");

                entity.HasIndex(e => e.EasyPayNum, "NonClusteredIndex-20180726-115802");

                entity.HasIndex(e => e.MemPropKey, "ixMemPropKey");

                entity.HasIndex(e => e.MemColKey, "ix_MemColKey");

                entity.Property(e => e.MemGrpNum).ValueGeneratedNever();

                entity.Property(e => e.ActiveTf).HasColumnName("ActiveTF");

                entity.Property(e => e.CanReason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactCell)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ContactEmail).HasMaxLength(50);

                entity.Property(e => e.ContactPerson).HasMaxLength(250);

                entity.Property(e => e.ContactPhone).HasMaxLength(15);

                entity.Property(e => e.CoverId).HasColumnName("CoverID");

                entity.Property(e => e.EasyPayNum).HasMaxLength(20);

                entity.Property(e => e.FldRef)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Idnum)
                    .HasMaxLength(15)
                    .HasColumnName("IDNum");

                entity.Property(e => e.InsInterest).HasMaxLength(25);

                entity.Property(e => e.InsRef)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MaritalStatus).HasMaxLength(250);

                entity.Property(e => e.MiddleName).HasMaxLength(250);

                entity.Property(e => e.PostalCode).HasMaxLength(60);

                entity.Property(e => e.PstAddress1).HasMaxLength(250);

                entity.Property(e => e.PstAddress2).HasMaxLength(250);

                entity.Property(e => e.PstAddress3).HasMaxLength(250);

                entity.Property(e => e.StrAddress1)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StrAddress2)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StrAddress3)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StrAddress4)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Surname).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.MemColKeyNavigation)
                    .WithMany(p => p.MemberGroups)
                    .HasForeignKey(d => d.MemColKey)
                    .HasConstraintName("FK_MemberGroup_MemberCollect");

                entity.HasOne(d => d.MemPropKeyNavigation)
                    .WithMany(p => p.MemberGroups)
                    .HasForeignKey(d => d.MemPropKey)
                    .HasConstraintName("FK_MemberGroup_MemberProposer");
            });

            modelBuilder.Entity<MemberGroupHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MemberGroupHistory");

                entity.Property(e => e.ActiveTf).HasColumnName("ActiveTF");

                entity.Property(e => e.CanReason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactCell)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ContactEmail).HasMaxLength(50);

                entity.Property(e => e.ContactPerson).HasMaxLength(25);

                entity.Property(e => e.ContactPhone).HasMaxLength(15);

                entity.Property(e => e.FldRef)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.InsInterest).HasMaxLength(25);

                entity.Property(e => e.InsRef)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MemGrpId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("MemGrpID");

                entity.Property(e => e.PostalCode).HasMaxLength(6);

                entity.Property(e => e.PstAddress1).HasMaxLength(25);

                entity.Property(e => e.PstAddress2).HasMaxLength(25);

                entity.Property(e => e.PstAddress3).HasMaxLength(25);

                entity.Property(e => e.StrAddress1)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StrAddress2)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StrAddress3)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.StrAddress4)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<MemberPayment>(entity =>
            {
                entity.HasKey(e => e.MemPayNum);

                entity.ToTable("MemberPayment");

                entity.HasIndex(e => e.MemGrpNum, "MemGrpNum");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.DblDeductTf).HasColumnName("DblDeductTF");

                entity.Property(e => e.MemPayType).HasMaxLength(3);

                entity.Property(e => e.Reason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<MemberPaymentNew>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MemberPaymentNew");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.DblDeductTf).HasColumnName("DblDeductTF");

                entity.Property(e => e.MemPayNum).ValueGeneratedOnAdd();

                entity.Property(e => e.MemPayType).HasMaxLength(3);

                entity.Property(e => e.Reason)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<MemberProposer>(entity =>
            {
                entity.HasKey(e => e.MemPropKey);

                entity.ToTable("MemberProposer");

                entity.Property(e => e.MemPropKey).ValueGeneratedNever();

                entity.Property(e => e.Address1).HasMaxLength(250);

                entity.Property(e => e.Address2).HasMaxLength(250);

                entity.Property(e => e.Address3).HasMaxLength(250);

                entity.Property(e => e.ContactEmail).HasMaxLength(35);

                entity.Property(e => e.ContactPhone).HasMaxLength(15);

                entity.Property(e => e.Dob).HasColumnName("DOB");

                entity.Property(e => e.FirstName).HasMaxLength(250);

                entity.Property(e => e.Idnum)
                    .HasMaxLength(25)
                    .HasColumnName("IDNum");

                entity.Property(e => e.Occupation).HasMaxLength(25);

                entity.Property(e => e.PostalCode).HasMaxLength(100);

                entity.Property(e => e.RelationToPrincipalMember).HasMaxLength(25);

                entity.Property(e => e.SecondName).HasMaxLength(250);

                entity.Property(e => e.Status).HasMaxLength(25);

                entity.Property(e => e.Surname).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(34);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.Property(e => e.WorkPhone).HasMaxLength(15);
            });

            modelBuilder.Entity<MemberpaymentBkp20140714>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MemberpaymentBKP20140714");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.DblDeductTf).HasColumnName("DblDeductTF");

                entity.Property(e => e.MemPayNum).ValueGeneratedOnAdd();

                entity.Property(e => e.MemPayType).HasMaxLength(3);

                entity.Property(e => e.Reason)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");
            });

            //modelBuilder.Entity<New>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("New", "Policy");

            //    entity.Property(e => e.Cover).HasMaxLength(50);

            //    entity.Property(e => e.CoverId)
            //        .HasMaxLength(50)
            //        .HasColumnName("CoverID");

            //    entity.Property(e => e.Description).HasMaxLength(50);

            //    entity.Property(e => e.IsPibflag)
            //        .HasMaxLength(50)
            //        .HasColumnName("IsPIBFLag");

            //    entity.Property(e => e.MaxAge).HasMaxLength(50);

            //    entity.Property(e => e.MinAge).HasMaxLength(50);

            //    entity.Property(e => e.PlanId)
            //        .HasMaxLength(50)
            //        .HasColumnName("PlanID");

            //    entity.Property(e => e.Premium).HasMaxLength(50);

            //    entity.Property(e => e.RelationKey).HasMaxLength(50);
            //});

            modelBuilder.Entity<PartSchemeText>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PartSchemeText");

                entity.Property(e => e.Comment)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Welcome)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");
            });

            modelBuilder.Entity<PerSalColErr>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PerSalColErr");
            });

            modelBuilder.Entity<PerSalError>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PerSalError");

                entity.Property(e => e.ErrorAction).HasMaxLength(3);

                entity.Property(e => e.ErrorDescript).HasMaxLength(85);
            });

            modelBuilder.Entity<PerSalIn>(entity =>
            {
                entity.HasKey(e => e.PslRecKey);

                entity.ToTable("PerSalIn");

                entity.Property(e => e.FileType).HasMaxLength(10);

                entity.Property(e => e.PslIdnum)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("PslIDNum");

                entity.Property(e => e.PslInitial)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.PslInsType)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PslReference)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PslStaffNum)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PslSurname)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.PslTrnType)
                    .HasMaxLength(4)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PostCode>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PostCode");

                entity.Property(e => e.Area).HasMaxLength(255);

                entity.Property(e => e.Area2).HasMaxLength(255);

                entity.Property(e => e.PostalCode).HasMaxLength(6);

                entity.Property(e => e.Province).HasMaxLength(255);
            });

            modelBuilder.Entity<PrcAgtRemit>(entity =>
            {
                entity.HasKey(e => new { e.AgentKey, e.MemGrpNum });

                entity.ToTable("PrcAgtRemit");

                entity.Property(e => e.ColOrgName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CollectType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ContactCell)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FldRef)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MemFirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MemIdnum)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MemIDNum");

                entity.Property(e => e.MemSecondName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MemSurname)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UnpReason)
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrcDueFeePerDet>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PrcDueFeePerDet");

                entity.Property(e => e.PayCvrFeeTf).HasColumnName("PayCvrFeeTF");
            });

            modelBuilder.Entity<PrcDueFeePerGrp>(entity =>
            {
                entity.HasKey(e => e.MemGrpNum);

                entity.ToTable("PrcDueFeePerGrp");

                entity.Property(e => e.MemGrpNum).ValueGeneratedNever();
            });

            modelBuilder.Entity<PrcExtCost>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PrcExtCost");

                entity.Property(e => e.Cost).HasColumnType("money");
            });

            modelBuilder.Entity<PrcGrpDue>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PrcGrpDue");

                entity.Property(e => e.GrpDue).HasColumnType("money");
            });

            modelBuilder.Entity<PrcGrpPay>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PrcGrpPay");

                entity.Property(e => e.GrpPay).HasColumnType("money");
            });

            modelBuilder.Entity<PrcMemExt>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PrcMemExt");

                entity.Property(e => e.Charge).HasColumnType("money");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Descript)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("DOB");

                entity.Property(e => e.ExtendedCost).HasColumnType("money");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FldRef)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Idnum)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("IDNum");

                entity.Property(e => e.InsRef)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MemGrpNum)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Total).HasColumnType("money");
            });

            modelBuilder.Entity<PrcMemStat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PrcMemStat");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.PstAddress1)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PstAddress2)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PstAddress3)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.RelDescript)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SecondName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrcOverage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PrcOverage");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Dob)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DOB");

                entity.Property(e => e.MainMember)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.OverageDep)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Proposer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");
            });

            modelBuilder.Entity<PrcPartCert>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PrcPartCert");

                entity.Property(e => e.AccType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AgentName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AppDate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Ben1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ben1Id)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Ben1ID");

                entity.Property(e => e.Ben2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ben2Id)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Ben2ID");

                entity.Property(e => e.BranchPayPoint)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactCell)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ContactTel)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DebitDay)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExtCharge).HasColumnType("money");

                entity.Property(e => e.FamCharge).HasColumnType("money");

                entity.Property(e => e.FieldRef)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GrpBenAmount)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.GrpBenCover)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.GrpBenStart)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.GrpDob)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("GrpDOB");

                entity.Property(e => e.GrpIdnum)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("GrpIDNum");

                entity.Property(e => e.GrpPerson)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.GrpRelation)
                    .HasMaxLength(1500)
                    .IsUnicode(false);

                entity.Property(e => e.MainMemTf).HasColumnName("MainMemTF");

                entity.Property(e => e.PayFreq)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PayType)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PersalAccNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReinstateDate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SchemeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.SuspendDate)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.TotalCharge).HasColumnType("money");
            });

            modelBuilder.Entity<PrcPslColPay>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PrcPslColPay");
            });

            modelBuilder.Entity<PrcPslExpTbl>(entity =>
            {
                entity.HasKey(e => new { e.MemColKey, e.SalMonth })
                    .HasName("PK_PrcPslExpTbl_1");

                entity.ToTable("PrcPslExpTbl");

                entity.Property(e => e.AmendType).HasMaxLength(4);

                entity.Property(e => e.CollectIdnum)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("CollectIDNum");

                entity.Property(e => e.CollectInitial)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.CollectSurname)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.PslFoundTf).HasColumnName("PslFoundTF");

                entity.Property(e => e.PslInsType)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PslReference)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SoStaffNum)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Status).HasMaxLength(3);
            });

            modelBuilder.Entity<PrcRemittance>(entity =>
            {
                entity.HasKey(e => e.MemGrpNum);

                entity.ToTable("PrcRemittance");

                entity.Property(e => e.MemGrpNum).ValueGeneratedNever();

                entity.Property(e => e.InsRef)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MemFirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MemIdnum)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("MemIDNum");

                entity.Property(e => e.MemSecondName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MemSurname)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductPerAgent>(entity =>
            {
                entity.HasKey(e => new { e.AgentKey, e.ProductKey });

                entity.ToTable("ProductPerAgent");

                entity.HasIndex(e => e.ProductKey, "ixProductKey");

                entity.Property(e => e.ActiveTf).HasColumnName("ActiveTF");

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.AgentKeyNavigation)
                    .WithMany(p => p.ProductPerAgents)
                    .HasForeignKey(d => d.AgentKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPerAgent_Agent");

                entity.HasOne(d => d.ProductKeyNavigation)
                    .WithMany(p => p.ProductPerAgents)
                    .HasForeignKey(d => d.ProductKey)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductPerAgent_MemberGroup");
            });

            modelBuilder.Entity<ProviderPayment>(entity =>
            {
                entity.HasKey(e => e.ProvPayKey);

                entity.ToTable("ProviderPayment");

                entity.Property(e => e.ProvPayKey).ValueGeneratedNever();

                entity.Property(e => e.ProvPayType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RatePerMember).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.CapitalKeyNavigation)
                    .WithMany(p => p.ProviderPayments)
                    .HasForeignKey(d => d.CapitalKey)
                    .HasConstraintName("FK_ProviderPayment_Capital");
            });

            modelBuilder.Entity<PslLodging>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.TransType).HasMaxLength(4);

                entity.Property(e => e.UserDateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasKey(e => e.ReceiptKey);

                entity.ToTable("Receipt");

                entity.Property(e => e.ReceiptKey).ValueGeneratedNever();

                entity.Property(e => e.DrawerChqEftNum).HasMaxLength(30);

                entity.Property(e => e.DrawerName).HasMaxLength(35);

                entity.Property(e => e.PayMethod).HasMaxLength(3);

                entity.Property(e => e.RdreceiptKey).HasColumnName("RDReceiptKey");

                entity.Property(e => e.ReceiptPurpose)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiptType).HasMaxLength(3);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.CapitalKeyNavigation)
                    .WithMany(p => p.Receipts)
                    .HasForeignKey(d => d.CapitalKey)
                    .HasConstraintName("FK_Receipt_Capital");
            });

            modelBuilder.Entity<Relation>(entity =>
            {
                entity.HasKey(e => e.RelationKey);

                entity.ToTable("Relation");

                entity.Property(e => e.RelationKey).ValueGeneratedNever();

                entity.Property(e => e.Descript).HasMaxLength(15);

                entity.Property(e => e.SponsorTf).HasColumnName("SponsorTF");
            });

            modelBuilder.Entity<RelativeCover>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("RelativeCover");

                entity.HasOne(d => d.RelationKeyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.RelationKey)
                    .HasConstraintName("FK_RelativeCover_Relation");

                entity.HasOne(d => d.C)
                    .WithMany()
                    .HasForeignKey(d => new { d.CoverKey, d.CvrVersion })
                    .HasConstraintName("FK_RelativeCover_BenefitCover");
            });

            modelBuilder.Entity<SchComVat>(entity =>
            {
                entity.HasKey(e => e.ComVatKey);

                entity.ToTable("SchComVat");

                entity.Property(e => e.ComVatKey).ValueGeneratedNever();

                entity.Property(e => e.ComVatType).HasMaxLength(3);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.CapitalKeyNavigation)
                    .WithMany(p => p.SchComVats)
                    .HasForeignKey(d => d.CapitalKey)
                    .HasConstraintName("FK_SchComVat_Capital");
            });

            modelBuilder.Entity<Scheme>(entity =>
            {
                entity.HasKey(e => new { e.SchemeNum, e.SchVersion });

                entity.ToTable("Scheme");

                entity.Property(e => e.ActiveTf).HasColumnName("ActiveTF");

                entity.Property(e => e.ContactEmail).HasMaxLength(35);

                entity.Property(e => e.ContactFax).HasMaxLength(15);

                entity.Property(e => e.ContactPerson).HasMaxLength(25);

                entity.Property(e => e.ContactPhone).HasMaxLength(15);

                entity.Property(e => e.CoverPeriod).HasMaxLength(3);

                entity.Property(e => e.CurrentTf).HasColumnName("CurrentTF");

                entity.Property(e => e.EligibilityNote).HasMaxLength(100);

                entity.Property(e => e.ExtSchNum).HasMaxLength(10);

                entity.Property(e => e.PupdeathTf).HasColumnName("PUPDeathTF");

                entity.Property(e => e.PupdisableTf).HasColumnName("PUPDisableTF");

                entity.Property(e => e.PupretireTf).HasColumnName("PUPRetireTF");

                entity.Property(e => e.ReviewTf).HasColumnName("ReviewTF");

                entity.Property(e => e.SchemeName).HasMaxLength(30);

                entity.Property(e => e.SchemeType).HasMaxLength(3);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.PlanNumNavigation)
                    .WithMany(p => p.Schemes)
                    .HasForeignKey(d => d.PlanNum)
                    .HasConstraintName("FK_Scheme_InsPlan");
            });

            modelBuilder.Entity<SchemeBenefit>(entity =>
            {
                entity.HasKey(e => new { e.BenefitKey, e.BenVersion });

                entity.ToTable("SchemeBenefit");

                entity.Property(e => e.ActiveTf).HasColumnName("ActiveTF");

                entity.Property(e => e.BenDescript).HasMaxLength(30);

                entity.Property(e => e.CurrentTf).HasColumnName("CurrentTF");

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Sch)
                    .WithMany(p => p.SchemeBenefits)
                    .HasForeignKey(d => new { d.SchemeNum, d.SchVersion })
                    .HasConstraintName("FK_SchemeBenefit_Scheme");
            });

            modelBuilder.Entity<SchemeCharge>(entity =>
            {
                entity.HasKey(e => e.SchChgKey);

                entity.ToTable("SchemeCharge");

                entity.Property(e => e.SchChgKey).ValueGeneratedNever();

                entity.Property(e => e.SchChgType).HasMaxLength(3);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.CapitalKeyNavigation)
                    .WithMany(p => p.SchemeCharges)
                    .HasForeignKey(d => d.CapitalKey)
                    .HasConstraintName("FK_SchemeCharge_Capital");

                entity.HasOne(d => d.Sch)
                    .WithMany(p => p.SchemeCharges)
                    .HasForeignKey(d => new { d.SchemeNum, d.SchVersion })
                    .HasConstraintName("FK_SchemeCharge_Scheme");
            });

            modelBuilder.Entity<SchemeCommission>(entity =>
            {
                entity.HasKey(e => e.SchComKey);

                entity.ToTable("SchemeCommission");

                entity.Property(e => e.SchComKey).ValueGeneratedNever();

                entity.Property(e => e.SchComType).HasMaxLength(3);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.CapitalKeyNavigation)
                    .WithMany(p => p.SchemeCommissions)
                    .HasForeignKey(d => d.CapitalKey)
                    .HasConstraintName("FK_SchemeCommission_Capital");

                entity.HasOne(d => d.Sch)
                    .WithMany(p => p.SchemeCommissions)
                    .HasForeignKey(d => new { d.SchemeNum, d.SchVersion })
                    .HasConstraintName("FK_SchemeCommission_Scheme");
            });

            modelBuilder.Entity<SchemeCost>(entity =>
            {
                entity.HasKey(e => e.SchCstKey);

                entity.ToTable("SchemeCost");

                entity.Property(e => e.SchCstKey).ValueGeneratedNever();

                entity.Property(e => e.SchCstType).HasMaxLength(3);

                entity.Property(e => e.UserDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.CapitalKeyNavigation)
                    .WithMany(p => p.SchemeCosts)
                    .HasForeignKey(d => d.CapitalKey)
                    .HasConstraintName("FK_SchemeCost_Capital");

                entity.HasOne(d => d.Sch)
                    .WithMany(p => p.SchemeCosts)
                    .HasForeignKey(d => new { d.SchemeNum, d.SchVersion })
                    .HasConstraintName("FK_SchemeCost_Scheme");
            });

            modelBuilder.Entity<SchemeEndorsement>(entity =>
            {
                entity.HasKey(e => e.EndorseKey);

                entity.ToTable("SchemeEndorsement");

                entity.Property(e => e.EndorseKey).ValueGeneratedNever();

                entity.Property(e => e.EndorseNote).HasMaxLength(100);

                entity.HasOne(d => d.Sch)
                    .WithMany(p => p.SchemeEndorsements)
                    .HasForeignKey(d => new { d.SchemeNum, d.SchVersion })
                    .HasConstraintName("FK_SchemeEndorsement_Scheme");
            });

            modelBuilder.Entity<SecureAccess>(entity =>
            {
                entity.HasKey(e => e.AccNum);

                entity.ToTable("SecureAccess");

                entity.Property(e => e.AccNum).ValueGeneratedNever();

                entity.Property(e => e.AccDescript).HasMaxLength(25);
            });

            modelBuilder.Entity<SecureUser>(entity =>
            {
                entity.HasKey(e => e.UserNum);

                entity.ToTable("SecureUser");

                entity.Property(e => e.UserNum).ValueGeneratedNever();

                entity.Property(e => e.LogName).HasMaxLength(25);

                entity.Property(e => e.PassWord1).HasMaxLength(30);

                entity.Property(e => e.PassWord2).HasMaxLength(30);

                entity.Property(e => e.PassWord3).HasMaxLength(30);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.StaffNum).HasMaxLength(10);

                entity.Property(e => e.UserEmail).HasMaxLength(25);

                entity.Property(e => e.UserFax).HasMaxLength(15);

                entity.Property(e => e.UserName).HasMaxLength(25);

                entity.Property(e => e.UserPhone).HasMaxLength(15);

                entity.Property(e => e.UserSurname).HasMaxLength(25);
            });

            modelBuilder.Entity<TblAddress>(entity =>
            {
                entity.HasKey(e => new { e.FldObjectType, e.FldObjectId, e.FldAddressTypeid });

                entity.ToTable("tblADDRESS", "SYSTEM");

                entity.Property(e => e.FldObjectType)
                    .HasMaxLength(25)
                    .HasColumnName("fldOBJECT_TYPE");

                entity.Property(e => e.FldObjectId).HasColumnName("fldOBJECT_ID");

                entity.Property(e => e.FldAddressTypeid)
                    .HasMaxLength(25)
                    .HasColumnName("fldADDRESS_TYPEID");

                entity.Property(e => e.FldAddressLine1)
                    .HasMaxLength(60)
                    .HasColumnName("fldADDRESS_LINE1");

                entity.Property(e => e.FldAddressLine2)
                    .HasMaxLength(60)
                    .HasColumnName("fldADDRESS_LINE2");

                entity.Property(e => e.FldAddressPostalcode)
                    .HasMaxLength(4)
                    .HasColumnName("fldADDRESS_POSTALCODE")
                    .IsFixedLength(true);

                entity.Property(e => e.FldAddressTowncity)
                    .HasMaxLength(30)
                    .HasColumnName("fldADDRESS_TOWNCITY");
            });

            modelBuilder.Entity<TblAttachmentcategoty>(entity =>
            {
                entity.HasKey(e => e.FldCategotyId);

                entity.ToTable("tblATTACHMENTCATEGOTY", "Policy");

                entity.Property(e => e.FldCategotyId).HasColumnName("fldCATEGOTY_ID");

                entity.Property(e => e.FldCategoryType)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("fldCATEGORY_TYPE");

                entity.Property(e => e.FldCategotyIsactiveflag)
                    .IsRequired()
                    .HasColumnName("fldCATEGOTY_ISACTIVEFLAG")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FldCategotyName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("fldCATEGOTY_NAME");
            });

            modelBuilder.Entity<TblClawback>(entity =>
            {
                entity.HasKey(e => e.FldDetailId);

                entity.ToTable("tblCLAWBACK", "UNDERWRITING");

                entity.Property(e => e.FldDetailId).HasColumnName("fldDETAIL_ID");

                entity.Property(e => e.FldAgentId).HasColumnName("fldAGENT_ID");

                entity.Property(e => e.FldAmountClawback)
                    .HasColumnType("money")
                    .HasColumnName("fldAMOUNT_CLAWBACK");

                entity.Property(e => e.FldAmountPaid)
                    .HasColumnType("money")
                    .HasColumnName("fldAMOUNT_PAID");

                entity.Property(e => e.FldClawbackType)
                    .HasMaxLength(150)
                    .HasColumnName("fldCLAWBACK_TYPE");

                entity.Property(e => e.FldCommissionId).HasColumnName("fldCOMMISSION_ID");

                entity.Property(e => e.FldDateCancelled)
                    .HasColumnType("date")
                    .HasColumnName("fldDATE_CANCELLED");

                entity.Property(e => e.FldDateTaken)
                    .HasColumnType("date")
                    .HasColumnName("fldDATE_TAKEN");

                entity.Property(e => e.FldMemberDisplayname)
                    .HasMaxLength(250)
                    .HasColumnName("fldMEMBER_DISPLAYNAME");

                entity.Property(e => e.FldMemberIdnumber)
                    .HasMaxLength(25)
                    .HasColumnName("fldMEMBER_IDNUMBER");

                entity.Property(e => e.FldMemberIsreflag).HasColumnName("fldMEMBER_ISREFLAG");

                entity.Property(e => e.FldMemberProduct)
                    .HasMaxLength(150)
                    .HasColumnName("fldMEMBER_PRODUCT");

                entity.Property(e => e.FldMemberType)
                    .HasMaxLength(150)
                    .HasColumnName("fldMEMBER_TYPE");

                entity.Property(e => e.FldPolicyId).HasColumnName("fldPOLICY_ID");

                entity.Property(e => e.FldPremium)
                    .HasColumnType("money")
                    .HasColumnName("fldPREMIUM");

                entity.Property(e => e.FldReasonCancelled).HasColumnName("fldREASON_CANCELLED");

                entity.Property(e => e.FldSchemeId).HasColumnName("fldSCHEME_ID");

                entity.Property(e => e.FldStartDate)
                    .HasColumnType("date")
                    .HasColumnName("fldSTART_DATE");

                entity.Property(e => e.FldStatus)
                    .HasMaxLength(25)
                    .HasColumnName("fldSTATUS");

                entity.Property(e => e.FldTransSortorder).HasColumnName("fldTRANS_SORTORDER");

                entity.HasOne(d => d.FldCommission)
                    .WithMany(p => p.TblClawbacks)
                    .HasForeignKey(d => d.FldCommissionId)
                    .HasConstraintName("FK_tblCLAWBACK_tblCOMMISSION");
            });

            modelBuilder.Entity<TblClient>(entity =>
            {
                entity.HasKey(e => e.FldClientId);

                entity.ToTable("tblCLIENT");

                entity.Property(e => e.FldClientId).HasColumnName("fldCLIENT_ID");

                entity.Property(e => e.FldCompanyId).HasColumnName("fldCOMPANY_ID");

                entity.Property(e => e.FldPassword)
                    .HasMaxLength(13)
                    .HasColumnName("fldPASSWORD");

                entity.Property(e => e.FldUsername)
                    .HasMaxLength(13)
                    .HasColumnName("fldUSERNAME");
            });

            modelBuilder.Entity<TblCommission>(entity =>
            {
                entity.HasKey(e => e.FldCommissionId);

                entity.ToTable("tblCOMMISSION", "UNDERWRITING");

                entity.Property(e => e.FldCommissionId).HasColumnName("fldCOMMISSION_ID");

                entity.Property(e => e.FldCommissionCreatedby)
                    .HasColumnName("fldCOMMISSION_CREATEDBY")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FldCommissionDatecreated)
                    .HasColumnType("datetime")
                    .HasColumnName("fldCOMMISSION_DATECREATED")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FldCommissionDatesubmitted)
                    .HasColumnType("datetime")
                    .HasColumnName("fldCOMMISSION_DATESUBMITTED");

                entity.Property(e => e.FldCommissionEnddate)
                    .HasColumnType("date")
                    .HasColumnName("fldCOMMISSION_ENDDATE");

                entity.Property(e => e.FldCommissionIscurrentflag)
                    .IsRequired()
                    .HasColumnName("fldCOMMISSION_ISCURRENTFLAG")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FldCommissionName)
                    .IsRequired()
                    .HasMaxLength(75)
                    .HasColumnName("fldCOMMISSION_NAME");

                entity.Property(e => e.FldCommissionStartdate)
                    .HasColumnType("date")
                    .HasColumnName("fldCOMMISSION_STARTDATE");

                entity.Property(e => e.FldCommissionSubmittedby).HasColumnName("fldCOMMISSION_SUBMITTEDBY");
            });

            modelBuilder.Entity<TblCompany>(entity =>
            {
                entity.HasKey(e => e.FldCompanyId)
                    .HasName("PK_tblVENDOR");

                entity.ToTable("tblCOMPANY", "COMPANY");

                entity.Property(e => e.FldCompanyId).HasColumnName("fldCOMPANY_ID");

                entity.Property(e => e.FldCompanyIsactiveflag)
                    .HasColumnName("fldCOMPANY_ISACTIVEFLAG")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FldCompanyLogo).HasColumnName("fldCOMPANY_LOGO");

                entity.Property(e => e.FldCompanyName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("fldCOMPANY_NAME");

                entity.Property(e => e.FldCompanyRegnumber)
                    .HasMaxLength(20)
                    .HasColumnName("fldCOMPANY_REGNUMBER");

                entity.Property(e => e.FldCompanySlogan)
                    .IsUnicode(false)
                    .HasColumnName("fldCOMPANY_SLOGAN");

                entity.Property(e => e.FldCompanyTradingas)
                    .HasMaxLength(70)
                    .HasColumnName("fldCOMPANY_TRADINGAS");

                entity.Property(e => e.FldCompanyVatnumber)
                    .HasMaxLength(20)
                    .HasColumnName("fldCOMPANY_VATNUMBER");

                entity.Property(e => e.FldCompanyWebsite)
                    .HasMaxLength(70)
                    .HasColumnName("fldCOMPANY_WEBSITE");

                entity.Property(e => e.FldSmsaccountId).HasColumnName("fldSMSACCOUNT_ID");
            });

            modelBuilder.Entity<TblCoverrule>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("tblCOVERRULE");

                entity.Property(e => e.ActiveTf).HasColumnName("ActiveTF");

                entity.Property(e => e.FldBenefitDescription)
                    .HasMaxLength(30)
                    .HasColumnName("fldBENEFIT_DESCRIPTION");

                entity.Property(e => e.FldBenefitId).HasColumnName("fldBENEFIT_ID");

                entity.Property(e => e.FldBenefitVersion).HasColumnName("fldBENEFIT_VERSION");

                entity.Property(e => e.FldBenefitWaitingperiod).HasColumnName("fldBENEFIT_WAITINGPERIOD");

                entity.Property(e => e.FldCoverAmount).HasColumnName("fldCOVER_AMOUNT");

                entity.Property(e => e.FldCoverCost).HasColumnName("fldCOVER_COST");

                entity.Property(e => e.FldCoverDescription)
                    .HasMaxLength(30)
                    .HasColumnName("fldCOVER_DESCRIPTION");

                entity.Property(e => e.FldCoverId).HasColumnName("fldCOVER_ID");

                entity.Property(e => e.FldCoverMaxage).HasColumnName("fldCOVER_MAXAGE");

                entity.Property(e => e.FldCoverMinage).HasColumnName("fldCOVER_MINAGE");

                entity.Property(e => e.FldCoverPremium).HasColumnName("fldCOVER_PREMIUM");

                entity.Property(e => e.FldCoverVersion).HasColumnName("fldCOVER_VERSION");

                entity.Property(e => e.FldPlanId).HasColumnName("fldPLAN_ID");

                entity.Property(e => e.FldPlanName)
                    .HasMaxLength(30)
                    .HasColumnName("fldPLAN_NAME");

                entity.Property(e => e.FldRelationId).HasColumnName("fldRELATION_ID");

                entity.Property(e => e.FldRelationName)
                    .HasMaxLength(15)
                    .HasColumnName("fldRELATION_NAME");

                entity.Property(e => e.FldSchemeId).HasColumnName("fldSCHEME_ID");

                entity.Property(e => e.FldSchemeName)
                    .HasMaxLength(30)
                    .HasColumnName("fldSCHEME_NAME");

                entity.Property(e => e.FldSchemeVersion).HasColumnName("fldSCHEME_VERSION");

                entity.Property(e => e.FldUnderwriterId).HasColumnName("fldUNDERWRITER_ID");

                entity.Property(e => e.FldUnderwriterName)
                    .HasMaxLength(30)
                    .HasColumnName("fldUNDERWRITER_NAME");
            });

            modelBuilder.Entity<TblDocument>(entity =>
            {
                entity.HasKey(e => e.FldDocumentId)
                    .HasName("PK_tblRESOURCES");

                entity.ToTable("tblDOCUMENT", "RESOURCE");

                entity.Property(e => e.FldDocumentId).HasColumnName("fldDOCUMENT_ID");

                entity.Property(e => e.FldDocumentBytes).HasColumnName("fldDOCUMENT_BYTES");

                entity.Property(e => e.FldDocumentDateaccessed)
                    .HasColumnType("datetime")
                    .HasColumnName("fldDOCUMENT_DATEACCESSED");

                entity.Property(e => e.FldDocumentDatecreated)
                    .HasColumnType("datetime")
                    .HasColumnName("fldDOCUMENT_DATECREATED")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FldDocumentDescription).HasColumnName("fldDOCUMENT_DESCRIPTION");

                entity.Property(e => e.FldDocumentFilename)
                    .HasMaxLength(125)
                    .HasColumnName("fldDOCUMENT_FILENAME");

                entity.Property(e => e.FldDocumentIsactiveflag)
                    .IsRequired()
                    .HasColumnName("fldDOCUMENT_ISACTIVEFLAG")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FldDocumentName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("fldDOCUMENT_NAME");

                entity.Property(e => e.FldDocumentType)
                    .HasMaxLength(25)
                    .HasColumnName("fldDOCUMENT_TYPE");

                entity.Property(e => e.FldDocumentUri)
                    .IsRequired()
                    .HasColumnName("fldDOCUMENT_URI");

                entity.Property(e => e.FldDocumetAccessedby)
                    .HasMaxLength(150)
                    .HasColumnName("fldDOCUMET_ACCESSEDBY");

                entity.Property(e => e.FldDocumetCreatedby)
                    .HasMaxLength(150)
                    .HasColumnName("fldDOCUMET_CREATEDBY");

                entity.Property(e => e.FldGroupId).HasColumnName("fldGROUP_ID");

                entity.Property(e => e.FldPolicyId).HasColumnName("fldPOLICY_ID");

                entity.HasOne(d => d.FldGroup)
                    .WithMany(p => p.TblDocuments)
                    .HasForeignKey(d => d.FldGroupId)
                    .HasConstraintName("FK_tblDOCUMENT_tblGROUP");
            });

            modelBuilder.Entity<TblEmail>(entity =>
            {
                entity.HasKey(e => new { e.FldObjectType, e.FldObjectId, e.FldEmailTypeid });

                entity.ToTable("tblEMAIL", "SYSTEM");

                entity.Property(e => e.FldObjectType)
                    .HasMaxLength(25)
                    .HasColumnName("fldOBJECT_TYPE");

                entity.Property(e => e.FldObjectId).HasColumnName("fldOBJECT_ID");

                entity.Property(e => e.FldEmailTypeid)
                    .HasMaxLength(20)
                    .HasColumnName("fldEMAIL_TYPEID");

                entity.Property(e => e.FldEmailAddress)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("fldEMAIL_ADDRESS");
            });

            modelBuilder.Entity<TblEvent>(entity =>
            {
                entity.HasKey(e => e.FldEventId)
                    .HasName("PK_tblEVENTLOG");

                entity.ToTable("tblEVENT", "SYSTEM");

                entity.Property(e => e.FldEventId).HasColumnName("fldEVENT_ID");

                entity.Property(e => e.FldEventComputer)
                    .IsRequired()
                    .HasMaxLength(70)
                    .HasColumnName("fldEVENT_COMPUTER");

                entity.Property(e => e.FldEventDatelogged)
                    .HasColumnType("datetime")
                    .HasColumnName("fldEVENT_DATELOGGED")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FldEventDescription).HasColumnName("fldEVENT_DESCRIPTION");

                entity.Property(e => e.FldEventFunctionid)
                    .HasMaxLength(25)
                    .HasColumnName("fldEVENT_FUNCTIONID");

                entity.Property(e => e.FldEventLevel)
                    .HasMaxLength(25)
                    .HasColumnName("fldEVENT_LEVEL");

                entity.Property(e => e.FldEventLoggedby).HasColumnName("fldEVENT_LOGGEDBY");

                entity.Property(e => e.FldEventObjectid).HasColumnName("fldEVENT_OBJECTID");

                entity.Property(e => e.FldEventSqlscript).HasColumnName("fldEVENT_SQLSCRIPT");
            });

            modelBuilder.Entity<TblFax>(entity =>
            {
                entity.HasKey(e => new { e.FldObjectType, e.FldObjectId, e.FldFaxTypeid });

                entity.ToTable("tblFAX", "SYSTEM");

                entity.Property(e => e.FldObjectType)
                    .HasMaxLength(25)
                    .HasColumnName("fldOBJECT_TYPE");

                entity.Property(e => e.FldObjectId).HasColumnName("fldOBJECT_ID");

                entity.Property(e => e.FldFaxTypeid)
                    .HasMaxLength(25)
                    .HasColumnName("fldFAX_TYPEID");

                entity.Property(e => e.FldFaxNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("fldFAX_NUMBER")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TblFunction>(entity =>
            {
                entity.HasKey(e => e.FldFunctionId);

                entity.ToTable("tblFUNCTION", "SECURITY");

                entity.Property(e => e.FldFunctionId)
                    .HasMaxLength(25)
                    .HasColumnName("fldFUNCTION_ID");

                entity.Property(e => e.FldFunctionCrud)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("fldFUNCTION_CRUD");

                entity.Property(e => e.FldFunctionDescription).HasColumnName("fldFUNCTION_DESCRIPTION");

                entity.Property(e => e.FldFunctionKey)
                    .HasMaxLength(25)
                    .HasColumnName("fldFUNCTION_KEY");

                entity.Property(e => e.FldFunctionName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("fldFUNCTION_NAME");

                entity.Property(e => e.FldFunctionOrder).HasColumnName("fldFUNCTION_ORDER");

                entity.Property(e => e.FldObjectId)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("fldOBJECT_ID");

                entity.HasOne(d => d.FldObject)
                    .WithMany(p => p.TblFunctions)
                    .HasForeignKey(d => d.FldObjectId)
                    .HasConstraintName("FK_tblFUNCTION_tblOBJECTTYPE");
            });

            modelBuilder.Entity<TblGroup>(entity =>
            {
                entity.HasKey(e => e.FldGroupId);

                entity.ToTable("tblGROUP", "RESOURCE");

                entity.Property(e => e.FldGroupId).HasColumnName("fldGROUP_ID");

                entity.Property(e => e.FldGroupDescription).HasColumnName("fldGROUP_DESCRIPTION");

                entity.Property(e => e.FldGroupIsactiveflag)
                    .IsRequired()
                    .HasColumnName("fldGROUP_ISACTIVEFLAG")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FldGroupName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("fldGROUP_NAME");

                entity.Property(e => e.FldGroupParent).HasColumnName("fldGROUP_PARENT");
            });

            modelBuilder.Entity<TblImage>(entity =>
            {
                entity.HasKey(e => e.FldImageId);

                entity.ToTable("tblIMAGE", "SYSTEM");

                entity.Property(e => e.FldImageId).HasColumnName("fldIMAGE_ID");

                entity.Property(e => e.FldCompanyId).HasColumnName("fldCOMPANY_ID");

                entity.Property(e => e.FldImageByte).HasColumnName("fldIMAGE_BYTE");

                entity.Property(e => e.FldImageCreatedby).HasColumnName("fldIMAGE_CREATEDBY");

                entity.Property(e => e.FldImageDatecreated)
                    .HasColumnType("datetime")
                    .HasColumnName("fldIMAGE_DATECREATED")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FldImageExtension)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("fldIMAGE_EXTENSION");

                entity.Property(e => e.FldImageName)
                    .IsRequired()
                    .HasMaxLength(75)
                    .HasColumnName("fldIMAGE_NAME");

                entity.Property(e => e.FldImagePath)
                    .IsRequired()
                    .HasColumnName("fldIMAGE_PATH");

                entity.Property(e => e.FldImageSize)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("fldIMAGE_SIZE");
            });

            modelBuilder.Entity<TblObjecttype>(entity =>
            {
                entity.HasKey(e => e.FldObjectId)
                    .HasName("PK_REFERENCE_OBJECT");

                entity.ToTable("tblOBJECTTYPE", "SYSTEM");

                entity.Property(e => e.FldObjectId)
                    .HasMaxLength(25)
                    .HasColumnName("fldOBJECT_ID");

                entity.Property(e => e.FldObjectDescription).HasColumnName("fldOBJECT_DESCRIPTION");

                entity.Property(e => e.FldObjectIsactiveflag)
                    .IsRequired()
                    .HasColumnName("fldOBJECT_ISACTIVEFLAG")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FldObjectName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("fldOBJECT_NAME");
            });

            modelBuilder.Entity<TblPermission>(entity =>
            {
                entity.HasKey(e => new { e.FldRoleId, e.FldFunctionId })
                    .HasName("PK_tblROLE_FUNCTION");

                entity.ToTable("tblPERMISSION", "SECURITY");

                entity.Property(e => e.FldRoleId).HasColumnName("fldROLE_ID");

                entity.Property(e => e.FldFunctionId)
                    .HasMaxLength(25)
                    .HasColumnName("fldFUNCTION_ID");
            });

            modelBuilder.Entity<TblPhone>(entity =>
            {
                entity.HasKey(e => new { e.FldObjectType, e.FldObjectId, e.FldPhoneTypeid });

                entity.ToTable("tblPHONE", "SYSTEM");

                entity.Property(e => e.FldObjectType)
                    .HasMaxLength(25)
                    .HasColumnName("fldOBJECT_TYPE");

                entity.Property(e => e.FldObjectId).HasColumnName("fldOBJECT_ID");

                entity.Property(e => e.FldPhoneTypeid)
                    .HasMaxLength(25)
                    .HasColumnName("fldPHONE_TYPEID");

                entity.Property(e => e.FldPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("fldPHONE_NUMBER")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TblPostalcode>(entity =>
            {
                entity.HasKey(e => e.FldPostalcodeId);

                entity.ToTable("tblPOSTALCODE");

                entity.Property(e => e.FldPostalcodeId).HasColumnName("fldPOSTALCODE_ID");

                entity.Property(e => e.FldCity)
                    .HasMaxLength(250)
                    .HasColumnName("fldCITY");

                entity.Property(e => e.FldPlace)
                    .HasMaxLength(250)
                    .HasColumnName("fldPLACE");

                entity.Property(e => e.FldPoboxcode)
                    .HasMaxLength(250)
                    .HasColumnName("fldPOBOXCODE");

                entity.Property(e => e.FldProvince)
                    .HasMaxLength(250)
                    .HasColumnName("fldPROVINCE");

                entity.Property(e => e.FldStreetcode)
                    .HasMaxLength(250)
                    .HasColumnName("fldSTREETCODE");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.HasKey(e => e.FldRoleId)
                    .HasName("PK_tblGROUPROLE");

                entity.ToTable("tblROLE", "SECURITY");

                entity.Property(e => e.FldRoleId).HasColumnName("fldROLE_ID");

                entity.Property(e => e.FldRoleDescription)
                    .HasMaxLength(250)
                    .HasColumnName("fldROLE_DESCRIPTION");

                entity.Property(e => e.FldRoleIsactiveflag)
                    .HasColumnName("fldROLE_ISACTIVEFLAG")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FldRoleName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("fldROLE_NAME");

                entity.Property(e => e.FldRoleParentid).HasColumnName("fldROLE_PARENTID");
            });

            modelBuilder.Entity<TblSale>(entity =>
            {
                entity.HasKey(e => e.FldDetailId)
                    .HasName("PK_tblDETAIL");

                entity.ToTable("tblSALES", "UNDERWRITING");

                entity.Property(e => e.FldDetailId).HasColumnName("fldDETAIL_ID");

                entity.Property(e => e.FldAgentId).HasColumnName("fldAGENT_ID");

                entity.Property(e => e.FldAmountEarned)
                    .HasColumnType("money")
                    .HasColumnName("fldAMOUNT_EARNED");

                entity.Property(e => e.FldCommissionId).HasColumnName("fldCOMMISSION_ID");

                entity.Property(e => e.FldDateReinstated)
                    .HasColumnType("date")
                    .HasColumnName("fldDATE_REINSTATED");

                entity.Property(e => e.FldDateTaken)
                    .HasColumnType("date")
                    .HasColumnName("fldDATE_TAKEN");

                entity.Property(e => e.FldMemberDisplayname)
                    .HasMaxLength(150)
                    .HasColumnName("fldMEMBER_DISPLAYNAME");

                entity.Property(e => e.FldMemberIdnumber)
                    .HasMaxLength(25)
                    .HasColumnName("fldMEMBER_IDNUMBER");

                entity.Property(e => e.FldMemberIsreflag).HasColumnName("fldMEMBER_ISREFLAG");

                entity.Property(e => e.FldMemberNewcover)
                    .HasColumnType("money")
                    .HasColumnName("fldMEMBER_NEWCOVER");

                entity.Property(e => e.FldMemberNewpremium)
                    .HasColumnType("money")
                    .HasColumnName("fldMEMBER_NEWPREMIUM");

                entity.Property(e => e.FldMemberOldcover)
                    .HasColumnType("money")
                    .HasColumnName("fldMEMBER_OLDCOVER");

                entity.Property(e => e.FldMemberOldpremium)
                    .HasColumnType("money")
                    .HasColumnName("fldMEMBER_OLDPREMIUM");

                entity.Property(e => e.FldMemberOldproduct)
                    .HasMaxLength(125)
                    .HasColumnName("fldMEMBER_OLDPRODUCT");

                entity.Property(e => e.FldMemberProduct)
                    .HasMaxLength(125)
                    .HasColumnName("fldMEMBER_PRODUCT");

                entity.Property(e => e.FldMemberType)
                    .HasMaxLength(25)
                    .HasColumnName("fldMEMBER_TYPE");

                entity.Property(e => e.FldPolicyId).HasColumnName("fldPOLICY_ID");

                entity.Property(e => e.FldSaletype)
                    .HasMaxLength(25)
                    .HasColumnName("fldSALETYPE");

                entity.Property(e => e.FldSchemeId).HasColumnName("fldSCHEME_ID");

                entity.Property(e => e.FldStartDate)
                    .HasColumnType("date")
                    .HasColumnName("fldSTART_DATE");

                entity.Property(e => e.FldStatus)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("fldSTATUS");

                entity.Property(e => e.FldTransSortorder).HasColumnName("fldTRANS_SORTORDER");

                entity.HasOne(d => d.FldAgent)
                    .WithMany(p => p.TblSales)
                    .HasForeignKey(d => d.FldAgentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDETAIL_Agent");

                entity.HasOne(d => d.FldCommission)
                    .WithMany(p => p.TblSales)
                    .HasForeignKey(d => d.FldCommissionId)
                    .HasConstraintName("FK_tblDETAIL_tblCOMMISSION");

                entity.HasOne(d => d.FldPolicy)
                    .WithMany(p => p.TblSales)
                    .HasForeignKey(d => d.FldPolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblDETAIL_MemberGroup");
            });

            modelBuilder.Entity<TblScheme>(entity =>
            {
                entity.HasKey(e => e.FldSchemeId)
                    .HasName("PK_tblCATEGORY");

                entity.ToTable("tblSCHEME", "PRODUCTION");

                entity.Property(e => e.FldSchemeId)
                    .ValueGeneratedNever()
                    .HasColumnName("fldSCHEME_ID");

                entity.Property(e => e.FldSchemeContractresource)
                    .HasMaxLength(150)
                    .HasColumnName("fldSCHEME_CONTRACTRESOURCE");

                entity.Property(e => e.FldSchemeDescription).HasColumnName("fldSCHEME_DESCRIPTION");

                entity.Property(e => e.FldSchemeIsactiveflag)
                    .IsRequired()
                    .HasColumnName("fldSCHEME_ISACTIVEFLAG")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FldSchemeLogo).HasColumnName("fldSCHEME_LOGO");

                entity.Property(e => e.FldSchemeName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("fldSCHEME_NAME");
            });

            modelBuilder.Entity<TblSetting>(entity =>
            {
                entity.HasKey(e => e.FldSettingId)
                    .HasName("PK_tblCOMPANYSETTING");

                entity.ToTable("tblSETTING", "COMPANY");

                entity.Property(e => e.FldSettingId)
                    .HasMaxLength(75)
                    .HasColumnName("fldSETTING_ID");

                entity.Property(e => e.FldSettingValue)
                    .HasMaxLength(75)
                    .HasColumnName("fldSETTING_VALUE");
            });

            modelBuilder.Entity<TblSetting1>(entity =>
            {
                entity.HasKey(e => new { e.FldUserId, e.FldSettingId })
                    .HasName("PK_tblCOMPANYSETTING");

                entity.ToTable("tblSETTING", "SECURITY");

                entity.Property(e => e.FldUserId).HasColumnName("fldUSER_ID");

                entity.Property(e => e.FldSettingId)
                    .HasMaxLength(75)
                    .HasColumnName("fldSETTING_ID");

                entity.Property(e => e.FldSettingValue)
                    .HasMaxLength(75)
                    .HasColumnName("fldSETTING_VALUE");
            });

            modelBuilder.Entity<TblSetting2>(entity =>
            {
                entity.HasKey(e => e.FldSettingId)
                    .HasName("PK_fldSETTING");

                entity.ToTable("tblSETTING", "SYSTEM");

                entity.Property(e => e.FldSettingId)
                    .HasMaxLength(75)
                    .HasColumnName("fldSETTING_ID");

                entity.Property(e => e.FldSettingDatatype)
                    .HasMaxLength(75)
                    .HasColumnName("fldSETTING_DATATYPE");

                entity.Property(e => e.FldSettingScope)
                    .HasMaxLength(75)
                    .HasColumnName("fldSETTING_SCOPE");

                entity.Property(e => e.FldSettingValue)
                    .HasMaxLength(75)
                    .HasColumnName("fldSETTING_VALUE");
            });

            modelBuilder.Entity<TblSm>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblSMS", "SYSTEM");

                entity.Property(e => e.FldBody)
                    .IsRequired()
                    .HasMaxLength(350)
                    .HasColumnName("fldBODY");

                entity.Property(e => e.FldDate).HasColumnName("fldDATE");

                entity.Property(e => e.FldFrom)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fldFROM");

                entity.Property(e => e.FldId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fldID");

                entity.Property(e => e.FldPolicyId).HasColumnName("fldPOLICY_ID");

                entity.Property(e => e.FldStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fldSTATUS");

                entity.Property(e => e.FldTo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fldTO");

                entity.Property(e => e.FldType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fldTYPE");
            });

            modelBuilder.Entity<TblSmsaccount>(entity =>
            {
                entity.HasKey(e => e.FldAccountId)
                    .HasName("PK_tblSMSOPTION");

                entity.ToTable("tblSMSACCOUNT", "SYSTEM");

                entity.Property(e => e.FldAccountId).HasColumnName("fldACCOUNT_ID");

                entity.Property(e => e.FldAccountApiid).HasColumnName("fldACCOUNT_APIID");

                entity.Property(e => e.FldAccountCallback).HasColumnName("fldACCOUNT_CALLBACK");

                entity.Property(e => e.FldAccountConcat)
                    .HasColumnName("fldACCOUNT_CONCAT")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FldAccountCreatedby).HasColumnName("fldACCOUNT_CREATEDBY");

                entity.Property(e => e.FldAccountDeliverytime)
                    .HasColumnType("datetime")
                    .HasColumnName("fldACCOUNT_DELIVERYTIME");

                entity.Property(e => e.FldAccountEscalate)
                    .HasColumnName("fldACCOUNT_ESCALATE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FldAccountPassword)
                    .HasMaxLength(25)
                    .HasColumnName("fldACCOUNT_PASSWORD");

                entity.Property(e => e.FldAccountSenderid)
                    .HasMaxLength(25)
                    .HasColumnName("fldACCOUNT_SENDERID");

                entity.Property(e => e.FldAccountUsername)
                    .HasMaxLength(25)
                    .HasColumnName("fldACCOUNT_USERNAME");
            });

            modelBuilder.Entity<TblSmstemp>(entity =>
            {
                entity.HasKey(e => new { e.FldId, e.FldPolicyId });

                entity.ToTable("tblSMSTEMP", "SYSTEM");

                entity.Property(e => e.FldId).HasColumnName("fldID");

                entity.Property(e => e.FldPolicyId)
                    .HasMaxLength(75)
                    .HasColumnName("fldPOLICY_ID");

                entity.Property(e => e.FldBody).HasColumnName("fldBODY");

                entity.Property(e => e.FldDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldDATE");

                entity.Property(e => e.FldFrom)
                    .HasMaxLength(25)
                    .HasColumnName("fldFROM");

                entity.Property(e => e.FldStatus)
                    .HasMaxLength(125)
                    .HasColumnName("fldSTATUS");

                entity.Property(e => e.FldTo)
                    .HasMaxLength(25)
                    .HasColumnName("fldTO");

                entity.Property(e => e.FldType)
                    .HasMaxLength(25)
                    .HasColumnName("fldTYPE");
            });

            modelBuilder.Entity<TblSmstest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tblSMSTEST", "SYSTEM");

                entity.Property(e => e.FldBody).HasColumnName("fldBODY");

                entity.Property(e => e.FldDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldDATE");

                entity.Property(e => e.FldFrom)
                    .HasMaxLength(25)
                    .HasColumnName("fldFROM");

                entity.Property(e => e.FldId).HasColumnName("fldID");

                entity.Property(e => e.FldStatus)
                    .HasMaxLength(125)
                    .HasColumnName("fldSTATUS");

                entity.Property(e => e.FldTo)
                    .HasMaxLength(25)
                    .HasColumnName("fldTO");

                entity.Property(e => e.FldType)
                    .HasMaxLength(25)
                    .HasColumnName("fldTYPE");
            });

            modelBuilder.Entity<TblUserRole>(entity =>
            {
                entity.HasKey(e => new { e.FldUserId, e.FldRoleId })
                    .HasName("PK_tblUSER_SECURITYGROUP");

                entity.ToTable("tblUSER_ROLE", "SECURITY");

                entity.Property(e => e.FldUserId).HasColumnName("fldUSER_ID");

                entity.Property(e => e.FldRoleId).HasColumnName("fldROLE_ID");
            });

            modelBuilder.Entity<TblUseraccount>(entity =>
            {
                entity.HasKey(e => e.FldAccountId);

                entity.ToTable("tblUSERACCOUNT", "SECURITY");

                entity.Property(e => e.FldAccountId)
                    .ValueGeneratedNever()
                    .HasColumnName("fldACCOUNT_ID");

                entity.Property(e => e.FldAgentId).HasColumnName("fldAGENT_ID");

                entity.Property(e => e.FldCompanyId)
                    .HasColumnName("fldCOMPANY_ID")
                    .HasDefaultValueSql("((1001))");

                entity.Property(e => e.FldUserAccounttype)
                    .HasMaxLength(25)
                    .HasColumnName("fldUSER_ACCOUNTTYPE");

                entity.Property(e => e.FldUserCanchangepassword).HasColumnName("fldUSER_CANCHANGEPASSWORD");

                entity.Property(e => e.FldUserChangepasswordatlogin).HasColumnName("fldUSER_CHANGEPASSWORDATLOGIN");

                entity.Property(e => e.FldUserDatelastloggedin)
                    .HasColumnType("datetime")
                    .HasColumnName("fldUSER_DATELASTLOGGEDIN");

                entity.Property(e => e.FldUserDepartment)
                    .HasMaxLength(25)
                    .HasColumnName("fldUSER_DEPARTMENT");

                entity.Property(e => e.FldUserDoespasswordexpire).HasColumnName("fldUSER_DOESPASSWORDEXPIRE");

                entity.Property(e => e.FldUserEmail)
                    .HasMaxLength(25)
                    .HasColumnName("fldUSER_Email");

                entity.Property(e => e.FldUserHasaccountexpired).HasColumnName("fldUSER_HASACCOUNTEXPIRED");

                entity.Property(e => e.FldUserIsaccountdisabled).HasColumnName("fldUSER_ISACCOUNTDISABLED");

                entity.Property(e => e.FldUserIsaccountlockedout).HasColumnName("fldUSER_ISACCOUNTLOCKEDOUT");

                entity.Property(e => e.FldUserIsactiveflag)
                    .HasColumnName("fldUSER_ISACTIVEFLAG")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.FldUserIsloggedin).HasColumnName("fldUSER_ISLOGGEDIN");

                entity.Property(e => e.FldUserJobtitle)
                    .HasMaxLength(25)
                    .HasColumnName("fldUSER_JOBTITLE");

                entity.Property(e => e.FldUserLastloggedonmachine)
                    .HasMaxLength(150)
                    .HasColumnName("fldUSER_LASTLOGGEDONMACHINE");

                entity.Property(e => e.FldUserPassword)
                    .HasMaxLength(25)
                    .HasColumnName("fldUSER_PASSWORD");

                entity.Property(e => e.FldUserPasswordexpiarydate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldUSER_PASSWORDEXPIARYDATE");

                entity.Property(e => e.FldUserTitle)
                    .HasMaxLength(25)
                    .HasColumnName("fldUSER_TITLE");

                entity.Property(e => e.FldUsername)
                    .HasMaxLength(25)
                    .HasColumnName("fldUSERNAME");

                entity.HasOne(d => d.FldAccount)
                    .WithOne(p => p.TblUseraccount)
                    .HasForeignKey<TblUseraccount>(d => d.FldAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblUSERACCOUNT_SecureUser");
            });

            modelBuilder.Entity<TmpGrpDue>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TmpGrpDue", "Enigma");

                entity.Property(e => e.GrpDue).HasColumnType("money");
            });

            modelBuilder.Entity<TmpPslColPay>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TmpPslColPay", "Enigma");
            });

            modelBuilder.Entity<TmpUnpActive>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TmpUnpActive", "Enigma");

                entity.Property(e => e.CanPrdPay).HasColumnType("money");
            });

            modelBuilder.Entity<UserAccess>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserAccess");

                entity.Property(e => e.AccTf).HasColumnName("AccTF");

                entity.HasOne(d => d.AccNumNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.AccNum)
                    .HasConstraintName("FK_UserAccess_SecureAccess");

                entity.HasOne(d => d.UserNumNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.UserNum)
                    .HasConstraintName("FK_UserAccess_SecureUser");
            });

            modelBuilder.Entity<VwAddress>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwAddress", "SYSTEM");

                entity.Property(e => e.FldAddressLine1)
                    .HasMaxLength(75)
                    .HasColumnName("fldADDRESS_LINE1");

                entity.Property(e => e.FldAddressLine2)
                    .HasMaxLength(75)
                    .HasColumnName("fldADDRESS_LINE2");

                entity.Property(e => e.FldAddressPostalcode)
                    .HasMaxLength(4)
                    .HasColumnName("fldADDRESS_POSTALCODE")
                    .IsFixedLength(true);

                entity.Property(e => e.FldAddressTowncity)
                    .HasMaxLength(75)
                    .HasColumnName("fldADDRESS_TOWNCITY");

                entity.Property(e => e.FldAddressTypeid)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("fldADDRESS_TYPEID");

                entity.Property(e => e.FldObjectId).HasColumnName("fldOBJECT_ID");

                entity.Property(e => e.FldObjectType)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("fldOBJECT_TYPE");
            });

            modelBuilder.Entity<VwAssuredLife>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwAssuredLives", "Policy");

                entity.Property(e => e.CurrentTf).HasColumnName("CurrentTF");

                entity.Property(e => e.FldAgentId).HasColumnName("fldAGENT_ID");

                entity.Property(e => e.FldClaimId)
                    .HasMaxLength(12)
                    .HasColumnName("fldCLAIM_ID");

                entity.Property(e => e.FldCoverVersion).HasColumnName("fldCOVER_VERSION");

                entity.Property(e => e.FldCoverruleCost).HasColumnName("fldCOVERRULE_COST");

                entity.Property(e => e.FldCoverruleCover).HasColumnName("fldCOVERRULE_COVER");

                entity.Property(e => e.FldCoverruleCover1).HasColumnName("fldCOVERRULE_COVER1");

                entity.Property(e => e.FldCoverruleId).HasColumnName("fldCOVERRULE_ID");

                entity.Property(e => e.FldCoverruleIsactiveflag).HasColumnName("fldCOVERRULE_ISACTIVEFLAG");

                entity.Property(e => e.FldCoverruleMaxage).HasColumnName("fldCOVERRULE_MAXAGE");

                entity.Property(e => e.FldCoverruleMembertype)
                    .HasMaxLength(15)
                    .HasColumnName("fldCOVERRULE_MEMBERTYPE");

                entity.Property(e => e.FldCoverruleMinage).HasColumnName("fldCOVERRULE_MINAGE");

                entity.Property(e => e.FldCoverrulePremium).HasColumnName("fldCOVERRULE_PREMIUM");

                entity.Property(e => e.FldMemberAge).HasColumnName("fldMEMBER_AGE");

                entity.Property(e => e.FldMemberDateofbirth)
                    .HasColumnType("date")
                    .HasColumnName("fldMEMBER_DATEOFBIRTH");

                entity.Property(e => e.FldMemberDisplayname)
                    .HasMaxLength(70)
                    .HasColumnName("fldMEMBER_DISPLAYNAME");

                entity.Property(e => e.FldMemberEnddate)
                    .HasColumnType("date")
                    .HasColumnName("fldMEMBER_ENDDATE");

                entity.Property(e => e.FldMemberFname)
                    .HasMaxLength(51)
                    .HasColumnName("fldMEMBER_FNAME");

                entity.Property(e => e.FldMemberId).HasColumnName("fldMEMBER_ID");

                entity.Property(e => e.FldMemberIdnumber)
                    .HasMaxLength(15)
                    .HasColumnName("fldMEMBER_IDNUMBER");

                entity.Property(e => e.FldMemberLname)
                    .HasMaxLength(25)
                    .HasColumnName("fldMEMBER_LNAME");

                entity.Property(e => e.FldMemberStartdate)
                    .HasColumnType("date")
                    .HasColumnName("fldMEMBER_STARTDATE");

                entity.Property(e => e.FldMemberStatus)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("fldMEMBER_STATUS");

                entity.Property(e => e.FldMemberStatusdesc)
                    .HasMaxLength(75)
                    .HasColumnName("fldMEMBER_STATUSDESC");

                entity.Property(e => e.FldMemberTitle)
                    .HasMaxLength(5)
                    .HasColumnName("fldMEMBER_TITLE");

                entity.Property(e => e.FldPolicyNumber).HasColumnName("fldPOLICY_NUMBER");

                entity.Property(e => e.FldRelationId).HasColumnName("fldRELATION_ID");
            });

            modelBuilder.Entity<VwAssuredLives1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwAssuredLives1", "Policy");

                entity.Property(e => e.CurrentTf).HasColumnName("CurrentTF");

                entity.Property(e => e.FldAgentId).HasColumnName("fldAGENT_ID");

                entity.Property(e => e.FldClaimId)
                    .HasMaxLength(12)
                    .HasColumnName("fldCLAIM_ID");

                entity.Property(e => e.FldCoverVersion).HasColumnName("fldCOVER_VERSION");

                entity.Property(e => e.FldCoverruleCost).HasColumnName("fldCOVERRULE_COST");

                entity.Property(e => e.FldCoverruleCover).HasColumnName("fldCOVERRULE_COVER");

                entity.Property(e => e.FldCoverruleId).HasColumnName("fldCOVERRULE_ID");

                entity.Property(e => e.FldCoverruleIsactiveflag).HasColumnName("fldCOVERRULE_ISACTIVEFLAG");

                entity.Property(e => e.FldCoverruleMaxage).HasColumnName("fldCOVERRULE_MAXAGE");

                entity.Property(e => e.FldCoverruleMembertype)
                    .HasMaxLength(15)
                    .HasColumnName("fldCOVERRULE_MEMBERTYPE");

                entity.Property(e => e.FldCoverruleMinage).HasColumnName("fldCOVERRULE_MINAGE");

                entity.Property(e => e.FldCoverrulePremium).HasColumnName("fldCOVERRULE_PREMIUM");

                entity.Property(e => e.FldCoverruleWaitingperiod).HasColumnName("fldCOVERRULE_WAITINGPERIOD");

                entity.Property(e => e.FldMemberAge).HasColumnName("fldMEMBER_AGE");

                entity.Property(e => e.FldMemberDateofbirth)
                    .HasColumnType("date")
                    .HasColumnName("fldMEMBER_DATEOFBIRTH");

                entity.Property(e => e.FldMemberDisplayname)
                    .HasMaxLength(70)
                    .HasColumnName("fldMEMBER_DISPLAYNAME");

                entity.Property(e => e.FldMemberEnddate)
                    .HasColumnType("date")
                    .HasColumnName("fldMEMBER_ENDDATE");

                entity.Property(e => e.FldMemberFname)
                    .HasMaxLength(51)
                    .HasColumnName("fldMEMBER_FNAME");

                entity.Property(e => e.FldMemberId).HasColumnName("fldMEMBER_ID");

                entity.Property(e => e.FldMemberIdnumber)
                    .HasMaxLength(15)
                    .HasColumnName("fldMEMBER_IDNUMBER");

                entity.Property(e => e.FldMemberLname)
                    .HasMaxLength(25)
                    .HasColumnName("fldMEMBER_LNAME");

                entity.Property(e => e.FldMemberStartdate)
                    .HasColumnType("date")
                    .HasColumnName("fldMEMBER_STARTDATE");

                entity.Property(e => e.FldMemberStatus)
                    .HasMaxLength(75)
                    .HasColumnName("fldMEMBER_STATUS");

                entity.Property(e => e.FldMemberStatusdesc)
                    .HasMaxLength(75)
                    .HasColumnName("fldMEMBER_STATUSDESC");

                entity.Property(e => e.FldMemberTitle)
                    .HasMaxLength(5)
                    .HasColumnName("fldMEMBER_TITLE");

                entity.Property(e => e.FldPolicyNumber).HasColumnName("fldPOLICY_NUMBER");

                entity.Property(e => e.FldRelationId).HasColumnName("fldRELATION_ID");
            });

            modelBuilder.Entity<VwClaim>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwClaim", "Policy");

                entity.Property(e => e.FldClaimAmount).HasColumnName("fldCLAIM_AMOUNT");

                entity.Property(e => e.FldClaimDate)
                    .HasColumnType("date")
                    .HasColumnName("fldCLAIM_DATE");

                entity.Property(e => e.FldClaimDatepaid)
                    .HasColumnType("date")
                    .HasColumnName("fldCLAIM_DATEPAID");

                entity.Property(e => e.FldClaimIdnumber)
                    .HasMaxLength(15)
                    .HasColumnName("fldCLAIM_IDNUMBER");

                entity.Property(e => e.FldClaimMembertype)
                    .HasMaxLength(15)
                    .HasColumnName("fldCLAIM_MEMBERTYPE");

                entity.Property(e => e.FldClaimName)
                    .HasMaxLength(70)
                    .HasColumnName("fldCLAIM_NAME");

                entity.Property(e => e.FldClaimNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("fldCLAIM_NUMBER");

                entity.Property(e => e.FldClaimPaid)
                    .HasColumnType("money")
                    .HasColumnName("fldCLAIM_PAID");

                entity.Property(e => e.FldClaimPmtref)
                    .HasMaxLength(75)
                    .HasColumnName("fldCLAIM_PMTREF");

                entity.Property(e => e.FldClaimStatus)
                    .HasMaxLength(3)
                    .HasColumnName("fldCLAIM_STATUS");

                entity.Property(e => e.FldPolicyNumber).HasColumnName("fldPOLICY_NUMBER");

                entity.Property(e => e.FldSchemeId).HasColumnName("fldSCHEME_ID");
            });

            modelBuilder.Entity<VwCompany>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwCompany");

                entity.Property(e => e.FldAccountApiid).HasColumnName("fldACCOUNT_APIID");

                entity.Property(e => e.FldAccountCallback).HasColumnName("fldACCOUNT_CALLBACK");

                entity.Property(e => e.FldAccountConcat).HasColumnName("fldACCOUNT_CONCAT");

                entity.Property(e => e.FldAccountDeliverytime)
                    .HasColumnType("datetime")
                    .HasColumnName("fldACCOUNT_DELIVERYTIME");

                entity.Property(e => e.FldAccountEscalate).HasColumnName("fldACCOUNT_ESCALATE");

                entity.Property(e => e.FldAccountId).HasColumnName("fldACCOUNT_ID");

                entity.Property(e => e.FldAccountPassword)
                    .HasMaxLength(25)
                    .HasColumnName("fldACCOUNT_PASSWORD");

                entity.Property(e => e.FldAccountSenderid)
                    .HasMaxLength(25)
                    .HasColumnName("fldACCOUNT_SENDERID");

                entity.Property(e => e.FldAccountUsername)
                    .HasMaxLength(25)
                    .HasColumnName("fldACCOUNT_USERNAME");

                entity.Property(e => e.FldCompanyId).HasColumnName("fldCOMPANY_ID");

                entity.Property(e => e.FldCompanyIsactiveflag).HasColumnName("fldCOMPANY_ISACTIVEFLAG");

                entity.Property(e => e.FldCompanyLogo).HasColumnName("fldCOMPANY_LOGO");

                entity.Property(e => e.FldCompanyName)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("fldCOMPANY_NAME");

                entity.Property(e => e.FldCompanyRegnumber)
                    .HasMaxLength(20)
                    .HasColumnName("fldCOMPANY_REGNUMBER");

                entity.Property(e => e.FldCompanySlogan)
                    .IsUnicode(false)
                    .HasColumnName("fldCOMPANY_SLOGAN");

                entity.Property(e => e.FldCompanyTradingas)
                    .HasMaxLength(70)
                    .HasColumnName("fldCOMPANY_TRADINGAS");

                entity.Property(e => e.FldCompanyVatnumber)
                    .HasMaxLength(20)
                    .HasColumnName("fldCOMPANY_VATNUMBER");

                entity.Property(e => e.FldCompanyWebsite)
                    .HasMaxLength(70)
                    .HasColumnName("fldCOMPANY_WEBSITE");

                entity.Property(e => e.FldImageByte).HasColumnName("fldIMAGE_BYTE");

                entity.Property(e => e.FldImageCreatedby).HasColumnName("fldIMAGE_CREATEDBY");

                entity.Property(e => e.FldImageExtension)
                    .HasMaxLength(15)
                    .HasColumnName("fldIMAGE_EXTENSION");

                entity.Property(e => e.FldImageId).HasColumnName("fldIMAGE_ID");

                entity.Property(e => e.FldImageName)
                    .HasMaxLength(75)
                    .HasColumnName("fldIMAGE_NAME");

                entity.Property(e => e.FldImagePath).HasColumnName("fldIMAGE_PATH");

                entity.Property(e => e.FldImageSize)
                    .HasMaxLength(25)
                    .HasColumnName("fldIMAGE_SIZE");

                entity.Property(e => e.FldSmsaccountId).HasColumnName("fldSMSACCOUNT_ID");
            });

            modelBuilder.Entity<VwCoverRule>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwCoverRule", "PRODUCTION");

                entity.Property(e => e.FldCoverVersion).HasColumnName("fldCOVER_VERSION");

                entity.Property(e => e.FldCoverruleCost).HasColumnName("fldCOVERRULE_COST");

                entity.Property(e => e.FldCoverruleCover).HasColumnName("fldCOVERRULE_COVER");

                entity.Property(e => e.FldCoverruleDatemodified)
                    .HasColumnType("datetime")
                    .HasColumnName("fldCOVERRULE_DATEMODIFIED");

                entity.Property(e => e.FldCoverruleEffectivedate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldCOVERRULE_EFFECTIVEDATE");

                entity.Property(e => e.FldCoverruleId).HasColumnName("fldCOVERRULE_ID");

                entity.Property(e => e.FldCoverruleIsactiveflag).HasColumnName("fldCOVERRULE_ISACTIVEFLAG");

                entity.Property(e => e.FldCoverruleMaxage).HasColumnName("fldCOVERRULE_MAXAGE");

                entity.Property(e => e.FldCoverruleMinage).HasColumnName("fldCOVERRULE_MINAGE");

                entity.Property(e => e.FldCoverruleModifiedby).HasColumnName("fldCOVERRULE_MODIFIEDBY");

                entity.Property(e => e.FldCoverrulePremium).HasColumnName("fldCOVERRULE_PREMIUM");

                entity.Property(e => e.FldCoverruleWaitingperiod).HasColumnName("fldCOVERRULE_WAITINGPERIOD");
            });

            modelBuilder.Entity<VwEmail>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwEmail", "SYSTEM");

                entity.Property(e => e.FldEmailAddress)
                    .HasMaxLength(60)
                    .HasColumnName("fldEMAIL_ADDRESS");

                entity.Property(e => e.FldEmailTypeid)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("fldEMAIL_TYPEID");

                entity.Property(e => e.FldObjectId).HasColumnName("fldOBJECT_ID");

                entity.Property(e => e.FldObjectType)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("fldOBJECT_TYPE");
            });

            modelBuilder.Entity<VwFax>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwFax", "SYSTEM");

                entity.Property(e => e.FldFaxNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("fldFAX_NUMBER")
                    .IsFixedLength(true);

                entity.Property(e => e.FldFaxTypeid)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("fldFAX_TYPEID");

                entity.Property(e => e.FldObjectId).HasColumnName("fldOBJECT_ID");

                entity.Property(e => e.FldObjectType)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("fldOBJECT_TYPE");
            });

            modelBuilder.Entity<VwPhone>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPhone", "SYSTEM");

                entity.Property(e => e.FldObjectId).HasColumnName("fldOBJECT_ID");

                entity.Property(e => e.FldObjectType)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("fldOBJECT_TYPE");

                entity.Property(e => e.FldPhoneNumber)
                    .HasMaxLength(10)
                    .HasColumnName("fldPHONE_NUMBER")
                    .IsFixedLength(true);

                entity.Property(e => e.FldPhoneTypeid)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("fldPHONE_TYPEID");
            });

            modelBuilder.Entity<VwPolicy>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPolicy", "Policy");

                entity.Property(e => e.FldAccountHolder)
                    .HasMaxLength(41)
                    .IsUnicode(false)
                    .HasColumnName("fldACCOUNT_HOLDER");

                entity.Property(e => e.FldAccountNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("fldACCOUNT_NUMBER");

                entity.Property(e => e.FldAccountType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("fldACCOUNT_TYPE")
                    .IsFixedLength(true);

                entity.Property(e => e.FldBankId).HasColumnName("fldBANK_ID");

                entity.Property(e => e.FldBankName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("fldBANK_NAME");

                entity.Property(e => e.FldBeneficiaryDisplayname)
                    .HasMaxLength(70)
                    .HasColumnName("fldBENEFICIARY_DISPLAYNAME");

                entity.Property(e => e.FldBeneficiaryEmail)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("fldBENEFICIARY_EMAIL");

                entity.Property(e => e.FldBeneficiaryFax).HasColumnName("fldBENEFICIARY_FAX");

                entity.Property(e => e.FldBeneficiaryFname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fldBENEFICIARY_FNAME");

                entity.Property(e => e.FldBeneficiaryId).HasColumnName("fldBENEFICIARY_ID");

                entity.Property(e => e.FldBeneficiaryIdnumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("fldBENEFICIARY_IDNUMBER");

                entity.Property(e => e.FldBeneficiaryLname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fldBENEFICIARY_LNAME");

                entity.Property(e => e.FldBeneficiaryPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("fldBENEFICIARY_PHONE");

                entity.Property(e => e.FldBeneficiaryRelation).HasColumnName("fldBENEFICIARY_RELATION");

                entity.Property(e => e.FldBeneficiaryTitle)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("fldBENEFICIARY_TITLE");

                entity.Property(e => e.FldBranchCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("fldBRANCH_CODE");

                entity.Property(e => e.FldBranchName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("fldBRANCH_NAME");

                entity.Property(e => e.FldCollecorgKey).HasColumnName("fldCOLLECORG_KEY");

                entity.Property(e => e.FldCollecorgName)
                    .HasMaxLength(42)
                    .HasColumnName("fldCOLLECORG_NAME");

                entity.Property(e => e.FldDebitDay).HasColumnName("fldDEBIT_DAY");

                entity.Property(e => e.FldIssuesCount).HasColumnName("fldISSUES_COUNT");

                entity.Property(e => e.FldMemberCover)
                    .HasColumnType("money")
                    .HasColumnName("fldMEMBER_COVER");

                entity.Property(e => e.FldMemberDateofbirth)
                    .HasColumnType("date")
                    .HasColumnName("fldMEMBER_DATEOFBIRTH");

                entity.Property(e => e.FldMemberDisplayname)
                    .HasMaxLength(70)
                    .HasColumnName("fldMEMBER_DISPLAYNAME");

                entity.Property(e => e.FldMemberIdnumber)
                    .HasMaxLength(15)
                    .HasColumnName("fldMEMBER_IDNUMBER");

                entity.Property(e => e.FldMemberPremium)
                    .HasColumnType("money")
                    .HasColumnName("fldMEMBER_PREMIUM");

                entity.Property(e => e.FldMemcollectKey).HasColumnName("fldMEMCOLLECT_KEY");

                entity.Property(e => e.FldPaymentFrequency).HasColumnName("fldPAYMENT_FREQUENCY");

                entity.Property(e => e.FldPaymentMethod)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("fldPAYMENT_METHOD")
                    .IsFixedLength(true);

                entity.Property(e => e.FldPhysicaladdressLine1)
                    .HasMaxLength(75)
                    .HasColumnName("fldPHYSICALADDRESS_LINE1");

                entity.Property(e => e.FldPhysicaladdressLine2)
                    .HasMaxLength(75)
                    .HasColumnName("fldPHYSICALADDRESS_LINE2");

                entity.Property(e => e.FldPhysicaladdressPostalcode)
                    .HasMaxLength(4)
                    .HasColumnName("fldPHYSICALADDRESS_POSTALCODE")
                    .IsFixedLength(true);

                entity.Property(e => e.FldPhysicaladdressTowncity)
                    .HasMaxLength(75)
                    .HasColumnName("fldPHYSICALADDRESS_TOWNCITY");

                entity.Property(e => e.FldPolicyCancelreason)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("fldPOLICY_CANCELREASON");

                entity.Property(e => e.FldPolicyCapturedby)
                    .HasMaxLength(70)
                    .HasColumnName("fldPOLICY_CAPTUREDBY");

                entity.Property(e => e.FldPolicyCommencementdate)
                    .HasColumnType("date")
                    .HasColumnName("fldPOLICY_COMMENCEMENTDATE");

                entity.Property(e => e.FldPolicyDatecaptured)
                    .HasColumnType("datetime")
                    .HasColumnName("fldPOLICY_DATECAPTURED");

                entity.Property(e => e.FldPolicyDatetaken)
                    .HasColumnType("date")
                    .HasColumnName("fldPOLICY_DATETAKEN");

                entity.Property(e => e.FldPolicyEasypaynumber)
                    .HasMaxLength(20)
                    .HasColumnName("fldPOLICY_EASYPAYNUMBER");

                entity.Property(e => e.FldPolicyInsurableinterest)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("fldPOLICY_INSURABLEINTEREST");

                entity.Property(e => e.FldPolicyNumber).HasColumnName("fldPOLICY_NUMBER");

                entity.Property(e => e.FldPolicyReinstatedate)
                    .HasColumnType("date")
                    .HasColumnName("fldPOLICY_REINSTATEDATE");

                entity.Property(e => e.FldPolicyStatus)
                    .HasMaxLength(70)
                    .HasColumnName("fldPOLICY_STATUS");

                entity.Property(e => e.FldPolicyTerminationdate)
                    .HasColumnType("date")
                    .HasColumnName("fldPOLICY_TERMINATIONDATE");

                entity.Property(e => e.FldPolicyTotalpremium)
                    .HasColumnType("money")
                    .HasColumnName("fldPOLICY_TOTALPREMIUM");

                entity.Property(e => e.FldPolicyViewgroup)
                    .HasMaxLength(70)
                    .HasColumnName("fldPOLICY_VIEWGROUP");

                entity.Property(e => e.FldPostaladdressLine1)
                    .HasMaxLength(75)
                    .HasColumnName("fldPOSTALADDRESS_LINE1");

                entity.Property(e => e.FldPostaladdressLine2)
                    .HasMaxLength(75)
                    .HasColumnName("fldPOSTALADDRESS_LINE2");

                entity.Property(e => e.FldPostaladdressPostalcode)
                    .HasMaxLength(4)
                    .HasColumnName("fldPOSTALADDRESS_POSTALCODE")
                    .IsFixedLength(true);

                entity.Property(e => e.FldPostaladdressTowncity)
                    .HasMaxLength(75)
                    .HasColumnName("fldPOSTALADDRESS_TOWNCITY");

                entity.Property(e => e.FldPremiumpayerDisplayname)
                    .HasMaxLength(70)
                    .HasColumnName("fldPREMIUMPAYER_DISPLAYNAME");

                entity.Property(e => e.FldPremiumpayerEmail)
                    .HasMaxLength(50)
                    .HasColumnName("fldPREMIUMPAYER_EMAIL");

                entity.Property(e => e.FldPremiumpayerFname)
                    .HasMaxLength(25)
                    .HasColumnName("fldPREMIUMPAYER_FNAME");

                entity.Property(e => e.FldPremiumpayerId).HasColumnName("fldPREMIUMPAYER_ID");

                entity.Property(e => e.FldPremiumpayerIdnumber)
                    .HasMaxLength(25)
                    .HasColumnName("fldPREMIUMPAYER_IDNUMBER");

                entity.Property(e => e.FldPremiumpayerLname)
                    .HasMaxLength(25)
                    .HasColumnName("fldPREMIUMPAYER_LNAME");

                entity.Property(e => e.FldPremiumpayerMobilephone)
                    .HasMaxLength(10)
                    .HasColumnName("fldPREMIUMPAYER_MOBILEPHONE")
                    .IsFixedLength(true);

                entity.Property(e => e.FldPremiumpayerOccupation)
                    .HasMaxLength(25)
                    .HasColumnName("fldPREMIUMPAYER_OCCUPATION");

                entity.Property(e => e.FldPremiumpayerStaffno)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("fldPREMIUMPAYER_STAFFNO");

                entity.Property(e => e.FldPremiumpayerTitle)
                    .HasMaxLength(5)
                    .HasColumnName("fldPREMIUMPAYER_TITLE");

                entity.Property(e => e.FldPremiumpayerWorkphone)
                    .HasMaxLength(10)
                    .HasColumnName("fldPREMIUMPAYER_WORKPHONE")
                    .IsFixedLength(true);

                entity.Property(e => e.FldProductIsreflag).HasColumnName("fldPRODUCT_ISREFLAG");

                entity.Property(e => e.FldSalespersonId).HasColumnName("fldSALESPERSON_ID");

                entity.Property(e => e.FldSchemeId).HasColumnName("fldSCHEME_ID");

                entity.Property(e => e.FldServerDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldSERVER_DATE");

                entity.Property(e => e.FldWaitingperiod).HasColumnName("fldWAITINGPERIOD");

                entity.Property(e => e.MemberDetailDob).HasColumnName("MemberDetailDOB");
            });

            modelBuilder.Entity<VwPolicyCopy>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPolicy_Copy", "Policy");

                entity.Property(e => e.FldAccountHolder)
                    .HasMaxLength(41)
                    .IsUnicode(false)
                    .HasColumnName("fldACCOUNT_HOLDER");

                entity.Property(e => e.FldAccountNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("fldACCOUNT_NUMBER");

                entity.Property(e => e.FldAccountType)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("fldACCOUNT_TYPE")
                    .IsFixedLength(true);

                entity.Property(e => e.FldBankId).HasColumnName("fldBANK_ID");

                entity.Property(e => e.FldBankName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("fldBANK_NAME");

                entity.Property(e => e.FldBeneficiaryDisplayname)
                    .HasMaxLength(70)
                    .HasColumnName("fldBENEFICIARY_DISPLAYNAME");

                entity.Property(e => e.FldBeneficiaryEmail)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("fldBENEFICIARY_EMAIL");

                entity.Property(e => e.FldBeneficiaryFax).HasColumnName("fldBENEFICIARY_FAX");

                entity.Property(e => e.FldBeneficiaryFname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fldBENEFICIARY_FNAME");

                entity.Property(e => e.FldBeneficiaryId).HasColumnName("fldBENEFICIARY_ID");

                entity.Property(e => e.FldBeneficiaryIdnumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("fldBENEFICIARY_IDNUMBER");

                entity.Property(e => e.FldBeneficiaryLname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fldBENEFICIARY_LNAME");

                entity.Property(e => e.FldBeneficiaryPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("fldBENEFICIARY_PHONE");

                entity.Property(e => e.FldBeneficiaryRelation).HasColumnName("fldBENEFICIARY_RELATION");

                entity.Property(e => e.FldBeneficiaryTitle)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("fldBENEFICIARY_TITLE");

                entity.Property(e => e.FldBranchCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("fldBRANCH_CODE");

                entity.Property(e => e.FldBranchName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("fldBRANCH_NAME");

                entity.Property(e => e.FldCollecorgKey).HasColumnName("fldCOLLECORG_KEY");

                entity.Property(e => e.FldCollecorgName)
                    .HasMaxLength(30)
                    .HasColumnName("fldCOLLECORG_NAME");

                entity.Property(e => e.FldDebitDay).HasColumnName("fldDEBIT_DAY");

                entity.Property(e => e.FldMemberCover)
                    .HasColumnType("money")
                    .HasColumnName("fldMEMBER_COVER");

                entity.Property(e => e.FldMemberDateofbirth)
                    .HasColumnType("date")
                    .HasColumnName("fldMEMBER_DATEOFBIRTH");

                entity.Property(e => e.FldMemberDisplayname)
                    .HasMaxLength(70)
                    .HasColumnName("fldMEMBER_DISPLAYNAME");

                entity.Property(e => e.FldMemberIdnumber)
                    .HasMaxLength(15)
                    .HasColumnName("fldMEMBER_IDNUMBER");

                entity.Property(e => e.FldMemcollectKey).HasColumnName("fldMEMCOLLECT_KEY");

                entity.Property(e => e.FldPaymentFrequency).HasColumnName("fldPAYMENT_FREQUENCY");

                entity.Property(e => e.FldPaymentMethod)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("fldPAYMENT_METHOD")
                    .IsFixedLength(true);

                entity.Property(e => e.FldPhysicaladdressLine1)
                    .HasMaxLength(75)
                    .HasColumnName("fldPHYSICALADDRESS_LINE1");

                entity.Property(e => e.FldPhysicaladdressLine2)
                    .HasMaxLength(75)
                    .HasColumnName("fldPHYSICALADDRESS_LINE2");

                entity.Property(e => e.FldPhysicaladdressPostalcode)
                    .HasMaxLength(4)
                    .HasColumnName("fldPHYSICALADDRESS_POSTALCODE")
                    .IsFixedLength(true);

                entity.Property(e => e.FldPhysicaladdressTowncity)
                    .HasMaxLength(75)
                    .HasColumnName("fldPHYSICALADDRESS_TOWNCITY");

                entity.Property(e => e.FldPolicyCancelreason)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("fldPOLICY_CANCELREASON");

                entity.Property(e => e.FldPolicyCapturedby)
                    .HasMaxLength(70)
                    .HasColumnName("fldPOLICY_CAPTUREDBY");

                entity.Property(e => e.FldPolicyCommencementdate)
                    .HasColumnType("date")
                    .HasColumnName("fldPOLICY_COMMENCEMENTDATE");

                entity.Property(e => e.FldPolicyDatecaptured)
                    .HasColumnType("datetime")
                    .HasColumnName("fldPOLICY_DATECAPTURED");

                entity.Property(e => e.FldPolicyDatetaken)
                    .HasColumnType("date")
                    .HasColumnName("fldPOLICY_DATETAKEN");

                entity.Property(e => e.FldPolicyEasypaynumber)
                    .HasMaxLength(20)
                    .HasColumnName("fldPOLICY_EASYPAYNUMBER");

                entity.Property(e => e.FldPolicyInsurableinterest)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("fldPOLICY_INSURABLEINTEREST");

                entity.Property(e => e.FldPolicyNumber).HasColumnName("fldPOLICY_NUMBER");

                entity.Property(e => e.FldPolicyPremium)
                    .HasColumnType("money")
                    .HasColumnName("fldPOLICY_PREMIUM");

                entity.Property(e => e.FldPolicyReinstatedate)
                    .HasColumnType("date")
                    .HasColumnName("fldPOLICY_REINSTATEDATE");

                entity.Property(e => e.FldPolicyStatus)
                    .HasMaxLength(70)
                    .HasColumnName("fldPOLICY_STATUS");

                entity.Property(e => e.FldPolicyTerminationdate)
                    .HasColumnType("date")
                    .HasColumnName("fldPOLICY_TERMINATIONDATE");

                entity.Property(e => e.FldPolicyViewgroup)
                    .HasMaxLength(70)
                    .HasColumnName("fldPOLICY_VIEWGROUP");

                entity.Property(e => e.FldPostaladdressLine1)
                    .HasMaxLength(75)
                    .HasColumnName("fldPOSTALADDRESS_LINE1");

                entity.Property(e => e.FldPostaladdressLine2)
                    .HasMaxLength(75)
                    .HasColumnName("fldPOSTALADDRESS_LINE2");

                entity.Property(e => e.FldPostaladdressPostalcode)
                    .HasMaxLength(4)
                    .HasColumnName("fldPOSTALADDRESS_POSTALCODE")
                    .IsFixedLength(true);

                entity.Property(e => e.FldPostaladdressTowncity)
                    .HasMaxLength(75)
                    .HasColumnName("fldPOSTALADDRESS_TOWNCITY");

                entity.Property(e => e.FldPremiumpayerDisplayname)
                    .HasMaxLength(70)
                    .HasColumnName("fldPREMIUMPAYER_DISPLAYNAME");

                entity.Property(e => e.FldPremiumpayerEmail)
                    .HasMaxLength(35)
                    .HasColumnName("fldPREMIUMPAYER_EMAIL");

                entity.Property(e => e.FldPremiumpayerFname)
                    .HasMaxLength(25)
                    .HasColumnName("fldPREMIUMPAYER_FNAME");

                entity.Property(e => e.FldPremiumpayerId).HasColumnName("fldPREMIUMPAYER_ID");

                entity.Property(e => e.FldPremiumpayerIdnumber)
                    .HasMaxLength(25)
                    .HasColumnName("fldPREMIUMPAYER_IDNUMBER");

                entity.Property(e => e.FldPremiumpayerLname)
                    .HasMaxLength(25)
                    .HasColumnName("fldPREMIUMPAYER_LNAME");

                entity.Property(e => e.FldPremiumpayerMobilephone)
                    .HasMaxLength(10)
                    .HasColumnName("fldPREMIUMPAYER_MOBILEPHONE")
                    .IsFixedLength(true);

                entity.Property(e => e.FldPremiumpayerOccupation)
                    .HasMaxLength(25)
                    .HasColumnName("fldPREMIUMPAYER_OCCUPATION");

                entity.Property(e => e.FldPremiumpayerStaffno)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("fldPREMIUMPAYER_STAFFNO");

                entity.Property(e => e.FldPremiumpayerTitle)
                    .HasMaxLength(5)
                    .HasColumnName("fldPREMIUMPAYER_TITLE");

                entity.Property(e => e.FldPremiumpayerWorkphone)
                    .HasMaxLength(10)
                    .HasColumnName("fldPREMIUMPAYER_WORKPHONE")
                    .IsFixedLength(true);

                entity.Property(e => e.FldProductIsreflag).HasColumnName("fldPRODUCT_ISREFLAG");

                entity.Property(e => e.FldSalespersonId).HasColumnName("fldSALESPERSON_ID");

                entity.Property(e => e.FldSchemeId).HasColumnName("fldSCHEME_ID");

                entity.Property(e => e.FldServerDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldSERVER_DATE");

                entity.Property(e => e.FldWaitingperiod).HasColumnName("fldWAITINGPERIOD");
            });

            modelBuilder.Entity<VwPolicyPremium>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPolicyPremium", "Policy");

                entity.Property(e => e.FldPolicyNumber).HasColumnName("fldPOLICY_NUMBER");

                entity.Property(e => e.FldPolicyPremium).HasColumnName("fldPOLICY_PREMIUM");
            });

            modelBuilder.Entity<VwPremiumPayer>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwPremiumPayer", "Policy");

                entity.Property(e => e.FldPolicyNumber).HasColumnName("fldPOLICY_NUMBER");

                entity.Property(e => e.FldPremiumpayerCell)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("fldPREMIUMPAYER_CELL");

                entity.Property(e => e.FldPremiumpayerDateofbith)
                    .HasColumnType("date")
                    .HasColumnName("fldPREMIUMPAYER_DATEOFBITH");

                entity.Property(e => e.FldPremiumpayerDisplayname)
                    .HasMaxLength(70)
                    .HasColumnName("fldPREMIUMPAYER_DISPLAYNAME");

                entity.Property(e => e.FldPremiumpayerEmail)
                    .HasMaxLength(50)
                    .HasColumnName("fldPREMIUMPAYER_EMAIL");

                entity.Property(e => e.FldPremiumpayerFname)
                    .HasMaxLength(51)
                    .HasColumnName("fldPREMIUMPAYER_FNAME");

                entity.Property(e => e.FldPremiumpayerId).HasColumnName("fldPREMIUMPAYER_ID");

                entity.Property(e => e.FldPremiumpayerIdnumber)
                    .HasMaxLength(15)
                    .HasColumnName("fldPREMIUMPAYER_IDNUMBER");

                entity.Property(e => e.FldPremiumpayerLname)
                    .HasMaxLength(25)
                    .HasColumnName("fldPREMIUMPAYER_LNAME");

                entity.Property(e => e.FldPremiumpayerMname)
                    .HasMaxLength(25)
                    .HasColumnName("fldPREMIUMPAYER_MNAME");

                entity.Property(e => e.FldPremiumpayerOccupation)
                    .HasMaxLength(25)
                    .HasColumnName("fldPREMIUMPAYER_OCCUPATION");

                entity.Property(e => e.FldPremiumpayerPhone)
                    .HasMaxLength(15)
                    .HasColumnName("fldPREMIUMPAYER_PHONE");

                entity.Property(e => e.FldPremiumpayerTitle)
                    .HasMaxLength(25)
                    .HasColumnName("fldPREMIUMPAYER_TITLE");
            });

            modelBuilder.Entity<VwRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwRole", "SECURITY");

                entity.Property(e => e.FldRoleDescription)
                    .HasMaxLength(250)
                    .HasColumnName("fldROLE_DESCRIPTION");

                entity.Property(e => e.FldRoleId).HasColumnName("fldROLE_ID");

                entity.Property(e => e.FldRoleName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("fldROLE_NAME");

                entity.Property(e => e.FldRoleParentid).HasColumnName("fldROLE_PARENTID");

                entity.Property(e => e.FldRoleParentname)
                    .HasMaxLength(60)
                    .HasColumnName("fldROLE_PARENTNAME");
            });

            modelBuilder.Entity<VwSalesperson>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwSalesperson", "Policy");

                entity.Property(e => e.FldAddressLine1)
                    .HasMaxLength(25)
                    .HasColumnName("fldADDRESS_LINE1");

                entity.Property(e => e.FldAddressLine2)
                    .HasMaxLength(25)
                    .HasColumnName("fldADDRESS_LINE2");

                entity.Property(e => e.FldAddressPostalcode)
                    .HasMaxLength(6)
                    .HasColumnName("fldADDRESS_POSTALCODE");

                entity.Property(e => e.FldAddressTowncity)
                    .HasMaxLength(25)
                    .HasColumnName("fldADDRESS_TOWNCITY");

                entity.Property(e => e.FldAddressTypeid)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("fldADDRESS_TYPEID");

                entity.Property(e => e.FldAgentIsactiveflag).HasColumnName("fldAGENT_ISACTIVEFLAG");

                entity.Property(e => e.FldBranchId).HasColumnName("fldBRANCH_ID");

                entity.Property(e => e.FldBranchName)
                    .HasMaxLength(25)
                    .HasColumnName("fldBRANCH_NAME");

                entity.Property(e => e.FldCountSales).HasColumnName("fldCOUNT_SALES");

                entity.Property(e => e.FldIsrecompliantflag).HasColumnName("fldISRECOMPLIANTFLAG");

                entity.Property(e => e.FldSalespersonDisplayname)
                    .HasMaxLength(35)
                    .HasColumnName("fldSALESPERSON_DISPLAYNAME");

                entity.Property(e => e.FldSalespersonEmail)
                    .HasMaxLength(475)
                    .HasColumnName("fldSALESPERSON_EMAIL");

                entity.Property(e => e.FldSalespersonEnddate)
                    .HasColumnType("date")
                    .HasColumnName("fldSALESPERSON_ENDDATE");

                entity.Property(e => e.FldSalespersonFax)
                    .HasMaxLength(10)
                    .HasColumnName("fldSALESPERSON_FAX");

                entity.Property(e => e.FldSalespersonFname).HasColumnName("fldSALESPERSON_FNAME");

                entity.Property(e => e.FldSalespersonId).HasColumnName("fldSALESPERSON_ID");

                entity.Property(e => e.FldSalespersonIdnumber)
                    .HasMaxLength(20)
                    .HasColumnName("fldSALESPERSON_IDNUMBER");

                entity.Property(e => e.FldSalespersonLevel)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("fldSALESPERSON_LEVEL");

                entity.Property(e => e.FldSalespersonLname).HasColumnName("fldSALESPERSON_LNAME");

                entity.Property(e => e.FldSalespersonNumber)
                    .HasMaxLength(25)
                    .HasColumnName("fldSALESPERSON_NUMBER");

                entity.Property(e => e.FldSalespersonPhone)
                    .HasMaxLength(10)
                    .HasColumnName("fldSALESPERSON_PHONE");

                entity.Property(e => e.FldSalespersonStartdate)
                    .HasColumnType("date")
                    .HasColumnName("fldSALESPERSON_STARTDATE");

                entity.Property(e => e.FldSalespersonTitle).HasColumnName("fldSALESPERSON_TITLE");

                entity.Property(e => e.FldSumSales).HasColumnName("fldSUM_SALES");
            });

            modelBuilder.Entity<VwUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vwUser", "SECURITY");

                entity.Property(e => e.ExcellencePassword).HasMaxLength(50);

                entity.Property(e => e.ExcellenceUsername).HasMaxLength(25);

                entity.Property(e => e.FldAccountId).HasColumnName("fldACCOUNT_ID");

                entity.Property(e => e.FldAddressLine1)
                    .HasMaxLength(125)
                    .HasColumnName("fldADDRESS_LINE1");

                entity.Property(e => e.FldAddressLine2)
                    .HasMaxLength(125)
                    .HasColumnName("fldADDRESS_LINE2");

                entity.Property(e => e.FldAddressPostalcode)
                    .HasMaxLength(4)
                    .HasColumnName("fldADDRESS_POSTALCODE");

                entity.Property(e => e.FldAddressTowncity)
                    .HasMaxLength(125)
                    .HasColumnName("fldADDRESS_TOWNCITY");

                entity.Property(e => e.FldAgentId).HasColumnName("fldAGENT_ID");

                entity.Property(e => e.FldCompanyEmail)
                    .HasMaxLength(475)
                    .HasColumnName("fldCOMPANY_EMAIL");

                entity.Property(e => e.FldCompanyFax)
                    .HasMaxLength(10)
                    .HasColumnName("fldCOMPANY_FAX");

                entity.Property(e => e.FldCompanyId).HasColumnName("fldCOMPANY_ID");

                entity.Property(e => e.FldCompanyName)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("fldCOMPANY_NAME");

                entity.Property(e => e.FldCompanyPhone)
                    .HasMaxLength(10)
                    .HasColumnName("fldCOMPANY_PHONE");

                entity.Property(e => e.FldCompanyTradingas)
                    .HasMaxLength(70)
                    .HasColumnName("fldCOMPANY_TRADINGAS");

                entity.Property(e => e.FldCompanyWebsite)
                    .HasMaxLength(70)
                    .HasColumnName("fldCOMPANY_WEBSITE");

                entity.Property(e => e.FldUserAccounttype)
                    .HasMaxLength(25)
                    .HasColumnName("fldUSER_ACCOUNTTYPE");

                entity.Property(e => e.FldUserCanchangepassword).HasColumnName("fldUSER_CANCHANGEPASSWORD");

                entity.Property(e => e.FldUserChangepasswordatlogin).HasColumnName("fldUSER_CHANGEPASSWORDATLOGIN");

                entity.Property(e => e.FldUserDatelastloggedin)
                    .HasColumnType("datetime")
                    .HasColumnName("fldUSER_DATELASTLOGGEDIN");

                entity.Property(e => e.FldUserDepartment)
                    .HasMaxLength(25)
                    .HasColumnName("fldUSER_DEPARTMENT");

                entity.Property(e => e.FldUserDisplayname)
                    .HasMaxLength(70)
                    .HasColumnName("fldUSER_DISPLAYNAME");

                entity.Property(e => e.FldUserDoespasswordexpire).HasColumnName("fldUSER_DOESPASSWORDEXPIRE");

                entity.Property(e => e.FldUserFname)
                    .HasMaxLength(25)
                    .HasColumnName("fldUSER_FNAME");

                entity.Property(e => e.FldUserHasaccountexpired).HasColumnName("fldUSER_HASACCOUNTEXPIRED");

                entity.Property(e => e.FldUserIsaccountdisabled).HasColumnName("fldUSER_ISACCOUNTDISABLED");

                entity.Property(e => e.FldUserIsaccountlockedout).HasColumnName("fldUSER_ISACCOUNTLOCKEDOUT");

                entity.Property(e => e.FldUserIsactiveflag).HasColumnName("fldUSER_ISACTIVEFLAG");

                entity.Property(e => e.FldUserIsloggedin).HasColumnName("fldUSER_ISLOGGEDIN");

                entity.Property(e => e.FldUserJobtitle)
                    .HasMaxLength(25)
                    .HasColumnName("fldUSER_JOBTITLE");

                entity.Property(e => e.FldUserLastloggedonmachine)
                    .HasMaxLength(150)
                    .HasColumnName("fldUSER_LASTLOGGEDONMACHINE");

                entity.Property(e => e.FldUserLname)
                    .HasMaxLength(25)
                    .HasColumnName("fldUSER_LNAME");

                entity.Property(e => e.FldUserPassword)
                    .HasMaxLength(25)
                    .HasColumnName("fldUSER_PASSWORD");

                entity.Property(e => e.FldUserPasswordexpiarydate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldUSER_PASSWORDEXPIARYDATE");

                entity.Property(e => e.FldUserStaffnumber)
                    .HasMaxLength(10)
                    .HasColumnName("fldUSER_STAFFNUMBER");

                entity.Property(e => e.FldUserTitle)
                    .HasMaxLength(25)
                    .HasColumnName("fldUSER_TITLE");

                entity.Property(e => e.FldUsername)
                    .HasMaxLength(25)
                    .HasColumnName("fldUSERNAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Agent> Agents { get; set; }
        public virtual DbSet<AgentCommission> AgentCommissions { get; set; }
        public virtual DbSet<AgentLevel> AgentLevels { get; set; }
        public virtual DbSet<AgentPayment> AgentPayments { get; set; }
        public virtual DbSet<AmmendBeneficiary> AmmendBeneficiaries { get; set; }
        public virtual DbSet<AmmendMemberCollect> AmmendMemberCollects { get; set; }
        public virtual DbSet<AmmendMemberDetail> AmmendMemberDetails { get; set; }
        public virtual DbSet<AmmendMemberGroup> AmmendMemberGroups { get; set; }
        public virtual DbSet<AmmendMemberProposer> AmmendMemberProposers { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
    
      //  public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
     //   public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<Beneficiary> Beneficiaries { get; set; }
        public virtual DbSet<BenefitCover> BenefitCovers { get; set; }
        public virtual DbSet<BnkBranch> BnkBranches { get; set; }
        public virtual DbSet<BrnPerBnk> BrnPerBnks { get; set; }
        public virtual DbSet<BrnRange> BrnRanges { get; set; }
        public virtual DbSet<Broker> Brokers { get; set; }
        public virtual DbSet<BrokerBranch> BrokerBranches { get; set; }
        public virtual DbSet<BrokerControl> BrokerControls { get; set; }
        public virtual DbSet<BrokerFee> BrokerFees { get; set; }
        public virtual DbSet<BrokerImage> BrokerImages { get; set; }
        public virtual DbSet<BrokerNotification> BrokerNotifications { get; set; }
        public virtual DbSet<BrokerPerson> BrokerPeople { get; set; }
        public virtual DbSet<BrokerTable> BrokerTables { get; set; }
        public virtual DbSet<CallMeBack> CallMeBacks { get; set; }
        public virtual DbSet<Capital> Capitals { get; set; }
        public virtual DbSet<Cheque> Cheques { get; set; }
        public virtual DbSet<Claim> Claims { get; set; }
        public virtual DbSet<ClaimRefund> ClaimRefunds { get; set; }
        public virtual DbSet<ClmPenCode> ClmPenCodes { get; set; }
        public virtual DbSet<ColOrgDept> ColOrgDepts { get; set; }
        public virtual DbSet<CollectOrg> CollectOrgs { get; set; }
        public virtual DbSet<Covers> Covers { get; set; }
        public virtual DbSet<CollectOrgBkp20200522> CollectOrgBkp20200522s { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentLink> CommentLinks { get; set; }
        public virtual DbSet<Commission> Commissions { get; set; }
        public virtual DbSet<CompulsoryCover> CompulsoryCovers { get; set; }
        //public virtual DbSet<Cover> Covers { get; set; }
        public virtual DbSet<DeleteGroup> DeleteGroups { get; set; }
        public virtual DbSet<EasyPayImport> EasyPayImports { get; set; }
        public virtual DbSet<ImageLink> ImageLinks { get; set; }
        public virtual DbSet<InsPlan> InsPlans { get; set; }
        public virtual DbSet<Insurer> Insurers { get; set; }
        public virtual DbSet<LevelCover> LevelCovers { get; set; }
        public virtual DbSet<MemberApplication> MemberApplications { get; set; }
        public virtual DbSet<MemberCollect> MemberCollects { get; set; }
        public virtual DbSet<MemberCollectBkp20200429> MemberCollectBkp20200429s { get; set; }
        public virtual DbSet<MemberCollectBkp20200504> MemberCollectBkp20200504s { get; set; }
        public virtual DbSet<MemberCollectHistory> MemberCollectHistories { get; set; }
        public virtual DbSet<MemberCompliance> MemberCompliances { get; set; }
        public virtual DbSet<MemberCover> MemberCovers { get; set; }
        public virtual DbSet<MemberCoverHistory> MemberCoverHistories { get; set; }
        public virtual DbSet<MemberDetail> MemberDetails { get; set; }
        public virtual DbSet<MemberDetailHistory> MemberDetailHistories { get; set; }
        public virtual DbSet<MemberGroup> MemberGroups { get; set; }
        public virtual DbSet<MemberGroupHistory> MemberGroupHistories { get; set; }
        public virtual DbSet<MemberPayment> MemberPayments { get; set; }
        public virtual DbSet<MemberPaymentNew> MemberPaymentNews { get; set; }
        public virtual DbSet<MemberProposer> MemberProposers { get; set; }
        public virtual DbSet<MemberpaymentBkp20140714> MemberpaymentBkp20140714s { get; set; }
        public virtual DbSet<PartSchemeText> PartSchemeTexts { get; set; }
        public virtual DbSet<PerSalColErr> PerSalColErrs { get; set; }
        public virtual DbSet<PerSalError> PerSalErrors { get; set; }
        public virtual DbSet<PerSalIn> PerSalIns { get; set; }
        public virtual DbSet<PostCode> PostCodes { get; set; }
        public virtual DbSet<PolicyCover> PolicyCovers { get; set; }
        public virtual DbSet<PrcAgtRemit> PrcAgtRemits { get; set; }
        public virtual DbSet<PrcDueFeePerDet> PrcDueFeePerDets { get; set; }
        public virtual DbSet<PrcDueFeePerGrp> PrcDueFeePerGrps { get; set; }
        public virtual DbSet<PrcExtCost> PrcExtCosts { get; set; }
        public virtual DbSet<PrcGrpDue> PrcGrpDues { get; set; }
        public virtual DbSet<PrcGrpPay> PrcGrpPays { get; set; }
        public virtual DbSet<PrcMemExt> PrcMemExts { get; set; }
        public virtual DbSet<PrcMemStat> PrcMemStats { get; set; }
        public virtual DbSet<PrcOverage> PrcOverages { get; set; }
        public virtual DbSet<PrcPartCert> PrcPartCerts { get; set; }
        public virtual DbSet<PrcPslColPay> PrcPslColPays { get; set; }
        public virtual DbSet<PrcPslExpTbl> PrcPslExpTbls { get; set; }
        public virtual DbSet<PrcRemittance> PrcRemittances { get; set; }
        public virtual DbSet<ProductPerAgent> ProductPerAgents { get; set; }
        public virtual DbSet<ProviderPayment> ProviderPayments { get; set; }
        public virtual DbSet<PslLodging> PslLodgings { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Relation> Relations { get; set; }
        public virtual DbSet<RelativeCover> RelativeCovers { get; set; }
        public virtual DbSet<SchComVat> SchComVats { get; set; }
        public virtual DbSet<Scheme> Schemes { get; set; }
        public virtual DbSet<SchemeBenefit> SchemeBenefits { get; set; }
        public virtual DbSet<SchemeCharge> SchemeCharges { get; set; }
        public virtual DbSet<SchemeCommission> SchemeCommissions { get; set; }
        public virtual DbSet<SchemeCost> SchemeCosts { get; set; }
        public virtual DbSet<SchemeEndorsement> SchemeEndorsements { get; set; }
        public virtual DbSet<SecureAccess> SecureAccesses { get; set; }
        public virtual DbSet<SecureUser> SecureUsers { get; set; }
        public virtual DbSet<TblAddress> TblAddresses { get; set; }
        public virtual DbSet<TblAttachmentcategoty> TblAttachmentcategoties { get; set; }
        public virtual DbSet<TblClawback> TblClawbacks { get; set; }
        public virtual DbSet<TblClient> TblClients { get; set; }
        public virtual DbSet<TblCommission> TblCommissions { get; set; }
        public virtual DbSet<TblCompany> TblCompanies { get; set; }
        public virtual DbSet<TblCoverrule> TblCoverrules { get; set; }
        public virtual DbSet<TblDocument> TblDocuments { get; set; }
        public virtual DbSet<TblEmail> TblEmails { get; set; }
        public virtual DbSet<TblEvent> TblEvents { get; set; }
        public virtual DbSet<TblFax> TblFaxes { get; set; }
        public virtual DbSet<TblFunction> TblFunctions { get; set; }
        public virtual DbSet<TblGroup> TblGroups { get; set; }
        public virtual DbSet<TblImage> TblImages { get; set; }
        public virtual DbSet<TblObjecttype> TblObjecttypes { get; set; }
        public virtual DbSet<TblPermission> TblPermissions { get; set; }
        public virtual DbSet<TblPhone> TblPhones { get; set; }
        public virtual DbSet<TblPostalcode> TblPostalcodes { get; set; }
        public virtual DbSet<TblRole> TblRoles { get; set; }
        public virtual DbSet<TblSale> TblSales { get; set; }
        public virtual DbSet<TblScheme> TblSchemes { get; set; }
        public virtual DbSet<TblSetting> TblSettings { get; set; }
        public virtual DbSet<TblSetting1> TblSettings1 { get; set; }
        public virtual DbSet<TblSetting2> TblSettings2 { get; set; }
        public virtual DbSet<TblSm> TblSms { get; set; }
        public virtual DbSet<TblSmsaccount> TblSmsaccounts { get; set; }
        public virtual DbSet<TblSmstemp> TblSmstemps { get; set; }
        public virtual DbSet<TblSmstest> TblSmstests { get; set; }
        public virtual DbSet<TblUserRole> TblUserRoles { get; set; }
        public virtual DbSet<TblUseraccount> TblUseraccounts { get; set; }
        public virtual DbSet<TmpGrpDue> TmpGrpDues { get; set; }
        public virtual DbSet<TmpPslColPay> TmpPslColPays { get; set; }
        public virtual DbSet<TmpUnpActive> TmpUnpActives { get; set; }
        public virtual DbSet<UserAccess> UserAccesses { get; set; }
        public virtual DbSet<VwAddress> VwAddresses { get; set; }
        public virtual DbSet<VwAssuredLife> VwAssuredLives { get; set; }
        public virtual DbSet<VwAssuredLives1> VwAssuredLives1s { get; set; }
        public virtual DbSet<VwClaim> VwClaims { get; set; }
        public virtual DbSet<VwCompany> VwCompanies { get; set; }
        public virtual DbSet<VwCoverRule> VwCoverRules { get; set; }
        public virtual DbSet<VwEmail> VwEmails { get; set; }
        public virtual DbSet<VwFax> VwFaxes { get; set; }
        public virtual DbSet<VwPhone> VwPhones { get; set; }
        public virtual DbSet<VwPolicy> VwPolicies { get; set; }
        public virtual DbSet<VwPolicyCopy> VwPolicyCopies { get; set; }
        public virtual DbSet<VwPolicyPremium> VwPolicyPremia { get; set; }
        public virtual DbSet<VwPremiumPayer> VwPremiumPayers { get; set; }
        public virtual DbSet<VwRole> VwRoles { get; set; }
        public virtual DbSet<VwSalesperson> VwSalespeople { get; set; }
        public virtual DbSet<VwUser> VwUsers { get; set; }
        

        
    }
}
