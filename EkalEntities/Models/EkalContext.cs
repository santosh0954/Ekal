using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EkalEntities.Models
{
    public partial class EkalContext : DbContext
    {
        public EkalContext()
        {
        }

        public EkalContext(DbContextOptions<EkalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MstBank> MstBank { get; set; }
        public virtual DbSet<MstDistricts> MstDistricts { get; set; }
        public virtual DbSet<MstEkai> MstEkai { get; set; }
        public virtual DbSet<MstEkaiType> MstEkaiType { get; set; }
        public virtual DbSet<MstItems> MstItems { get; set; }
        public virtual DbSet<MstRegion> MstRegion { get; set; }
        public virtual DbSet<MstSector> MstSector { get; set; }
        public virtual DbSet<MstStates> MstStates { get; set; }
        public virtual DbSet<MstUnit> MstUnit { get; set; }
        public virtual DbSet<MstVolunteerType> MstVolunteerType { get; set; }
        public virtual DbSet<TxnCustomer> TxnCustomer { get; set; }
        public virtual DbSet<TxnCustomerDeliveryAddress> TxnCustomerDeliveryAddress { get; set; }
        public virtual DbSet<TxnCustomerOrder> TxnCustomerOrder { get; set; }
        public virtual DbSet<TxnCustomerOrderDetails> TxnCustomerOrderDetails { get; set; }
        public virtual DbSet<TxnItemFormula> TxnItemFormula { get; set; }
        public virtual DbSet<TxnItemFormulaDetails> TxnItemFormulaDetails { get; set; }
        public virtual DbSet<TxnItemProvider> TxnItemProvider { get; set; }
        public virtual DbSet<TxnItemStock> TxnItemStock { get; set; }
        public virtual DbSet<TxnTasks> TxnTasks { get; set; }
        public virtual DbSet<TxnVolunteer> TxnVolunteer { get; set; }
        public virtual DbSet<TxnVolunteerAttendance> TxnVolunteerAttendance { get; set; }
        public virtual DbSet<TxnVolunteerBankDetails> TxnVolunteerBankDetails { get; set; }
        public virtual DbSet<VCustomerOrderWithDetails> VCustomerOrderWithDetails { get; set; }
        public virtual DbSet<VDistricts> VDistricts { get; set; }
        public virtual DbSet<VEkai> VEkai { get; set; }
        public virtual DbSet<VItemFormula> VItemFormula { get; set; }
        public virtual DbSet<VItemFormulaDetails> VItemFormulaDetails { get; set; }
        public virtual DbSet<VItemProvider> VItemProvider { get; set; }
        public virtual DbSet<VItemStock> VItemStock { get; set; }
        public virtual DbSet<VItems> VItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Ekal;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MstBank>(entity =>
            {
                entity.HasKey(e => e.BankId);

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.BankName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MstDistricts>(entity =>
            {
                entity.HasKey(e => e.DistrictCode);

                entity.Property(e => e.DistrictCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.StateCodeNavigation)
                    .WithMany(p => p.MstDistricts)
                    .HasForeignKey(d => d.StateCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MstDistricts_MstStates");
            });

            modelBuilder.Entity<MstEkai>(entity =>
            {
                entity.HasKey(e => e.EkaiId);

                entity.Property(e => e.EkaiId).HasColumnName("EkaiID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EkaiName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.EkaiTypeId).HasColumnName("EkaiTypeID");

                entity.Property(e => e.ParentEkaiId).HasColumnName("ParentEkaiID");

                entity.HasOne(d => d.EkaiType)
                    .WithMany(p => p.MstEkai)
                    .HasForeignKey(d => d.EkaiTypeId)
                    .HasConstraintName("FK_MstEkai_MstEkaiType");
            });

            modelBuilder.Entity<MstEkaiType>(entity =>
            {
                entity.HasKey(e => e.EkaiTypeId);

                entity.Property(e => e.EkaiTypeId).HasColumnName("EkaiTypeID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EkaiTypeName)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstItems>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SaleRate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.MstItems)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK_MstItems_MstUnit");
            });

            modelBuilder.Entity<MstRegion>(entity =>
            {
                entity.HasKey(e => e.RegionId);

                entity.Property(e => e.RegionId).HasColumnName("RegionID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.RegionName)
                    .HasMaxLength(512)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstSector>(entity =>
            {
                entity.HasKey(e => e.SectorId);

                entity.Property(e => e.SectorId).HasColumnName("SectorID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.SectorName)
                    .HasMaxLength(512)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstStates>(entity =>
            {
                entity.HasKey(e => e.StateCode);

                entity.Property(e => e.StateCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ShortName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tin)
                    .HasColumnName("TIN")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MstUnit>(entity =>
            {
                entity.HasKey(e => e.UnitId);

                entity.Property(e => e.UnitId).HasColumnName("UnitID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MstVolunteerType>(entity =>
            {
                entity.HasKey(e => e.VolunteerTypeId);

                entity.Property(e => e.VolunteerTypeId).HasColumnName("VolunteerTypeID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedId).HasColumnName("CreatedID");

                entity.Property(e => e.VolunteerType)
                    .HasMaxLength(512)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TxnCustomer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AltMobileNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DistrictCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EMail)
                    .HasColumnName("eMail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StateCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Tehsil)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TxnCustomerDeliveryAddress>(entity =>
            {
                entity.HasKey(e => e.CustomerDeliveryAddressId);

                entity.Property(e => e.CustomerDeliveryAddressId).HasColumnName("CustomerDeliveryAddressID");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine3)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.AddressType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DistrictCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Pincode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.StateCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Tehsil)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TxnCustomerDeliveryAddress)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_TxnCustomerDeliveryAddress_TxnCustomer");
            });

            modelBuilder.Entity<TxnCustomerOrder>(entity =>
            {
                entity.HasKey(e => e.CustomerOrderId);

                entity.Property(e => e.CustomerOrderId).HasColumnName("CustomerOrderID");

                entity.Property(e => e.ActualDeliveryDate).HasColumnType("date");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.ExpectedDeliveryDate).HasColumnType("date");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TxnCustomerOrder)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_TxnCustomerOrder_TxnCustomer");
            });

            modelBuilder.Entity<TxnCustomerOrderDetails>(entity =>
            {
                entity.HasKey(e => e.OrderDetailsId);

                entity.Property(e => e.OrderDetailsId).HasColumnName("OrderDetailsID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TxnCustomerOrderDetails)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_TxnCustomerOrderDetails_MstItems");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TxnCustomerOrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_TxnCustomerOrderDetails_TxnCustomerOrder");
            });

            modelBuilder.Entity<TxnItemFormula>(entity =>
            {
                entity.HasKey(e => e.ItemFormulaId)
                    .HasName("PK_TxnProductionFormula");

                entity.Property(e => e.ItemFormulaId).HasColumnName("ItemFormulaID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ForQty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FormulaName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TxnItemFormula)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_TxnItemFormula_MstItems");
            });

            modelBuilder.Entity<TxnItemFormulaDetails>(entity =>
            {
                entity.HasKey(e => e.ItemFormulaDetailsId)
                    .HasName("PK_TxnProductionFormulaDetails");

                entity.Property(e => e.ItemFormulaDetailsId).HasColumnName("ItemFormulaDetailsID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ItemFormulaId).HasColumnName("ItemFormulaID");

                entity.Property(e => e.Qty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SubItemId).HasColumnName("SubItemID");

                entity.HasOne(d => d.ItemFormula)
                    .WithMany(p => p.TxnItemFormulaDetails)
                    .HasForeignKey(d => d.ItemFormulaId)
                    .HasConstraintName("FK_TxnItemFormulaDetails_TxnItemFormula");

                entity.HasOne(d => d.SubItem)
                    .WithMany(p => p.TxnItemFormulaDetails)
                    .HasForeignKey(d => d.SubItemId)
                    .HasConstraintName("FK_TxnItemFormulaDetails_MstItems");
            });

            modelBuilder.Entity<TxnItemProvider>(entity =>
            {
                entity.HasKey(e => e.ItemProviderId);

                entity.Property(e => e.ItemProviderId).HasColumnName("ItemProviderID");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AltMobileNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DistrictCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EMail)
                    .HasColumnName("eMail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProviderType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StateCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Tehsil)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TxnItemStock>(entity =>
            {
                entity.HasKey(e => e.ItemStockId);

                entity.Property(e => e.ItemStockId).HasColumnName("ItemStockID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EkaiId).HasColumnName("EkaiID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ItemProviderId).HasColumnName("ItemProviderID");

                entity.Property(e => e.Qty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.TxnItemStock)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_TxnItemStock_MstItems");

                entity.HasOne(d => d.ItemProvider)
                    .WithMany(p => p.TxnItemStock)
                    .HasForeignKey(d => d.ItemProviderId)
                    .HasConstraintName("FK_TxnItemStock_TxnItemProvider");
            });

            modelBuilder.Entity<TxnTasks>(entity =>
            {
                entity.HasKey(e => e.TaskId);

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.ActualEndDate).HasColumnType("date");

                entity.Property(e => e.ActualStartDate).HasColumnType("date");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.EstimatedEndDate).HasColumnType("date");

                entity.Property(e => e.EstimatedStartDate).HasColumnType("date");

                entity.Property(e => e.ForItemId).HasColumnName("ForItemID");

                entity.Property(e => e.ForQty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TaskName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.WorkType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("G : Group based; I : Individual");

                entity.HasOne(d => d.ForItem)
                    .WithMany(p => p.TxnTasks)
                    .HasForeignKey(d => d.ForItemId)
                    .HasConstraintName("FK_TxnTasks_MstItems");
            });

            modelBuilder.Entity<TxnVolunteer>(entity =>
            {
                entity.HasKey(e => e.VolunteerId);

                entity.Property(e => e.VolunteerId).HasColumnName("VolunteerID");

                entity.Property(e => e.AadhaarNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AltMobileNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DistrictCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.EkaiId).HasColumnName("EkaiID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StateCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Tehsil)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VolunteerTypeId).HasColumnName("VolunteerTypeID");

                entity.HasOne(d => d.Ekai)
                    .WithMany(p => p.TxnVolunteer)
                    .HasForeignKey(d => d.EkaiId)
                    .HasConstraintName("FK_TxnVolunteer_MstEkai");

                entity.HasOne(d => d.VolunteerType)
                    .WithMany(p => p.TxnVolunteer)
                    .HasForeignKey(d => d.VolunteerTypeId)
                    .HasConstraintName("FK_TxnVolunteer_MstVolunteerType");
            });

            modelBuilder.Entity<TxnVolunteerAttendance>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AttDate).HasColumnType("date");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.VolunteerAttendanceDetails).ValueGeneratedOnAdd();

                entity.Property(e => e.VolunteerId).HasColumnName("VolunteerID");

                entity.HasOne(d => d.Volunteer)
                    .WithMany()
                    .HasForeignKey(d => d.VolunteerId)
                    .HasConstraintName("FK_TxnVolunteerAttendance_TxnVolunteer");
            });

            modelBuilder.Entity<TxnVolunteerBankDetails>(entity =>
            {
                entity.HasKey(e => e.VolunteerBankDetailsId);

                entity.Property(e => e.VolunteerBankDetailsId).HasColumnName("VolunteerBankDetailsID");

                entity.Property(e => e.AccountNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankId).HasColumnName("BankID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Ifsc)
                    .HasColumnName("IFSC")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VolunteerId).HasColumnName("VolunteerID");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.TxnVolunteerBankDetails)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK_TxnVolunteerBankDetails_MstBank");

                entity.HasOne(d => d.Volunteer)
                    .WithMany(p => p.TxnVolunteerBankDetails)
                    .HasForeignKey(d => d.VolunteerId)
                    .HasConstraintName("FK_TxnVolunteerBankDetails_TxnVolunteer");
            });

            modelBuilder.Entity<VCustomerOrderWithDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vCustomerOrderWithDetails");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderDetailsId).HasColumnName("OrderDetailsID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.OrderNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rate).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VDistricts>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vDistricts");

                entity.Property(e => e.DistrictCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VEkai>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vEkai");

                entity.Property(e => e.Anchal)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Bhag)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Gram)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Prabhag)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.PrabhagId).HasColumnName("PrabhagID");

                entity.Property(e => e.Sambhag)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Sanch)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VItemFormula>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vItemFormula");

                entity.Property(e => e.ForQty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FormulaName)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ItemFormulaId).HasColumnName("ItemFormulaID");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VItemFormulaDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vItemFormulaDetails");

                entity.Property(e => e.ItemFormulaDetailsId).HasColumnName("ItemFormulaDetailsID");

                entity.Property(e => e.ItemFormulaId).HasColumnName("ItemFormulaID");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qty).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SubItemId).HasColumnName("SubItemID");

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VItemProvider>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vItemProvider");

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AltMobileNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DistrictCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EMail)
                    .HasColumnName("eMail")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemProviderId).HasColumnName("ItemProviderID");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pincode)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProviderType)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ProviderTypeName)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.StateCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tehsil)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VItemStock>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vItemStock");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalQty).HasColumnType("decimal(38, 2)");
            });

            modelBuilder.Entity<VItems>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vItems");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ItemName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Unit)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
