﻿using System;
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
        public virtual DbSet<MstRegion> MstRegion { get; set; }
        public virtual DbSet<MstSector> MstSector { get; set; }
        public virtual DbSet<MstStates> MstStates { get; set; }
        public virtual DbSet<MstUnit> MstUnit { get; set; }
        public virtual DbSet<MstVolunteerType> MstVolunteerType { get; set; }
        public virtual DbSet<TxnCustomer> TxnCustomer { get; set; }
        public virtual DbSet<TxnVolunteer> TxnVolunteer { get; set; }
        public virtual DbSet<TxnVolunteerAttendance> TxnVolunteerAttendance { get; set; }
        public virtual DbSet<TxnVolunteerBankDetails> TxnVolunteerBankDetails { get; set; }

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

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DistrictCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.EMail)
                    .HasColumnName("eMail")
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
            });

            modelBuilder.Entity<TxnVolunteerAttendance>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AttDate).HasColumnType("date");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.VolunteerAttendanceDetails).ValueGeneratedOnAdd();

                entity.Property(e => e.VolunteerId).HasColumnName("VolunteerID");
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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}