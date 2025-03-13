﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using apartment_portal_api.Data;

#nullable disable

namespace apartment_portal_api.Data.Migrations
{
    [DbContext(typeof(PostgresContext))]
    partial class PostgresContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "auth", "aal_level", new[] { "aal1", "aal2", "aal3" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "auth", "code_challenge_method", new[] { "s256", "plain" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "auth", "factor_status", new[] { "unverified", "verified" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "auth", "factor_type", new[] { "totp", "webauthn", "phone" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "pgsodium", "key_status", new[] { "default", "valid", "invalid", "expired" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "pgsodium", "key_type", new[] { "aead-ietf", "aead-det", "hmacsha512", "hmacsha256", "auth", "shorthash", "generichash", "kdf", "secretbox", "secretstream", "stream_xchacha20" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" });
            NpgsqlModelBuilderExtensions.HasPostgresEnum(modelBuilder, "realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in" });
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "extensions", "pg_stat_statements");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "extensions", "pgcrypto");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "extensions", "pgjwt");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "extensions", "uuid-ossp");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "graphql", "pg_graphql");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "pgsodium", "pgsodium");
            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "vault", "supabase_vault");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("apartment_portal_api.Models.Guests.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessCode")
                        .HasColumnType("integer")
                        .HasColumnName("accessCode");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdOn")
                        .HasDefaultValueSql("(now() AT TIME ZONE 'utc'::text)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expiration");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("firstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("lastName");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phoneNumber");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userId");

                    b.HasKey("Id")
                        .HasName("guests_pkey");

                    b.HasIndex("UserId");

                    b.HasIndex(new[] { "Email" }, "guests_email_key")
                        .IsUnique();

                    b.HasIndex(new[] { "PhoneNumber" }, "guests_phoneNumber_key")
                        .IsUnique();

                    b.ToTable("guests", (string)null);
                });

            modelBuilder.Entity("apartment_portal_api.Models.IssueTypes.IssueType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("issueTypes_pkey");

                    b.ToTable("issueTypes", (string)null);
                });

            modelBuilder.Entity("apartment_portal_api.Models.Issues.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdOn")
                        .HasDefaultValueSql("(now() AT TIME ZONE 'utc'::text)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("IssueTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("issueTypeId");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer")
                        .HasColumnName("statusId");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userId");

                    b.HasKey("Id")
                        .HasName("issues_pkey");

                    b.HasIndex("IssueTypeId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("issues", (string)null);
                });

            modelBuilder.Entity("apartment_portal_api.Models.Packages.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("integer")
                        .HasColumnName("code");

                    b.Property<int>("LockerNumber")
                        .HasColumnType("integer")
                        .HasColumnName("lockerNumber");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer")
                        .HasColumnName("statusId");

                    b.Property<int>("UnitId")
                        .HasColumnType("integer")
                        .HasColumnName("unitId");

                    b.HasKey("Id")
                        .HasName("packages_pkey");

                    b.HasIndex("StatusId");

                    b.HasIndex("UnitId");

                    b.ToTable("packages", (string)null);
                });

            modelBuilder.Entity("apartment_portal_api.Models.ParkingPermits.ParkingPermit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("GuestId")
                        .HasColumnType("integer")
                        .HasColumnName("guestId");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("licensePlate");

                    b.Property<string>("LicensePlateState")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("licensePlateState");

                    b.Property<string>("VehicleMake")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("vehicleMake");

                    b.Property<string>("VehicleModel")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("vehicleModel");

                    b.HasKey("Id")
                        .HasName("parkingPermits_pkey");

                    b.HasIndex("GuestId");

                    b.ToTable("parkingPermits", (string)null);
                });

            modelBuilder.Entity("apartment_portal_api.Models.Statuses.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("statuses_pkey");

                    b.HasIndex(new[] { "Name" }, "statuses_name_key")
                        .IsUnique();

                    b.ToTable("statuses", (string)null);
                });

            modelBuilder.Entity("apartment_portal_api.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number");

                    b.Property<int>("Price")
                        .HasColumnType("integer")
                        .HasColumnName("price");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer")
                        .HasColumnName("statusId");

                    b.HasKey("Id")
                        .HasName("units_pkey");

                    b.HasIndex("StatusId");

                    b.HasIndex(new[] { "Number" }, "units_number_key")
                        .IsUnique();

                    b.ToTable("units", (string)null);
                });

            modelBuilder.Entity("apartment_portal_api.Models.UnitUsers.UnitUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("createdBy");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdOn")
                        .HasDefaultValueSql("(now() AT TIME ZONE 'utc'::text)");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("boolean")
                        .HasColumnName("isPrimary");

                    b.Property<string>("LeaseAgreement")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("leaseAgreement");

                    b.Property<DateTime>("LeaseExpiration")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("leaseExpiration");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("integer")
                        .HasColumnName("modifiedBy");

                    b.Property<DateTime>("ModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modifiedOn")
                        .HasDefaultValueSql("(now() AT TIME ZONE 'utc'::text)");

                    b.Property<int>("UnitId")
                        .HasColumnType("integer")
                        .HasColumnName("unitId");

                    b.Property<int>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("userId");

                    b.HasKey("Id")
                        .HasName("unitUsers_pkey");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("UnitId");

                    b.HasIndex("UserId");

                    b.ToTable("unitUsers", (string)null);
                });

            modelBuilder.Entity("apartment_portal_api.Models.Users.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer")
                        .HasColumnName("createdBy");

                    b.Property<DateTime>("CreatedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("createdOn")
                        .HasDefaultValueSql("(now() AT TIME ZONE 'utc'::text)");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("dateOfBirth");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("firstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("lastName");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ModifiedBy")
                        .HasColumnType("integer")
                        .HasColumnName("modifiedBy");

                    b.Property<DateTime>("ModifiedOn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("modifiedOn")
                        .HasDefaultValueSql("(now() AT TIME ZONE 'utc'::text)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer")
                        .HasColumnName("statusId");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id")
                        .HasName("users_pkey");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("StatusId");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("apartment_portal_api.Models.Users.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("apartment_portal_api.Models.Users.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("apartment_portal_api.Models.Users.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("apartment_portal_api.Models.Users.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("apartment_portal_api.Models.Guests.Guest", b =>
                {
                    b.HasOne("apartment_portal_api.Models.Users.ApplicationUser", "ApplicationUser")
                        .WithMany("Guests")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("guests_userId_fkey");

                    b.Navigation("ApplicationUser");
                });

            modelBuilder.Entity("apartment_portal_api.Models.Issues.Issue", b =>
                {
                    b.HasOne("apartment_portal_api.Models.IssueTypes.IssueType", "IssueType")
                        .WithMany("Issues")
                        .HasForeignKey("IssueTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("issues_issueTypeId_fkey");

                    b.HasOne("apartment_portal_api.Models.Statuses.Status", "Status")
                        .WithMany("Issues")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("issues_statusId_fkey");

                    b.HasOne("apartment_portal_api.Models.Users.ApplicationUser", "ApplicationUser")
                        .WithMany("Issues")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("issues_userId_fkey");

                    b.Navigation("ApplicationUser");

                    b.Navigation("IssueType");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("apartment_portal_api.Models.Packages.Package", b =>
                {
                    b.HasOne("apartment_portal_api.Models.Statuses.Status", "Status")
                        .WithMany("Packages")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("packages_statusId_fkey");

                    b.HasOne("apartment_portal_api.Models.Unit", "Unit")
                        .WithMany("Packages")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("packages_unitId_fkey");

                    b.Navigation("Status");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("apartment_portal_api.Models.ParkingPermits.ParkingPermit", b =>
                {
                    b.HasOne("apartment_portal_api.Models.Guests.Guest", "Guest")
                        .WithMany("ParkingPermits")
                        .HasForeignKey("GuestId")
                        .IsRequired()
                        .HasConstraintName("parkingPermits_guestId_fkey");

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("apartment_portal_api.Models.Unit", b =>
                {
                    b.HasOne("apartment_portal_api.Models.Statuses.Status", "Status")
                        .WithMany("Units")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("units_statusId_fkey");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("apartment_portal_api.Models.UnitUsers.UnitUser", b =>
                {
                    b.HasOne("apartment_portal_api.Models.Users.ApplicationUser", "CreatedByNavigation")
                        .WithMany("UnitUserCreatedByNavigations")
                        .HasForeignKey("CreatedBy")
                        .IsRequired()
                        .HasConstraintName("unitUsers_createdBy_fkey");

                    b.HasOne("apartment_portal_api.Models.Users.ApplicationUser", "ModifiedByNavigation")
                        .WithMany("UnitUserModifiedByNavigations")
                        .HasForeignKey("ModifiedBy")
                        .IsRequired()
                        .HasConstraintName("unitUsers_modifiedBy_fkey");

                    b.HasOne("apartment_portal_api.Models.Unit", "Unit")
                        .WithMany("UnitUsers")
                        .HasForeignKey("UnitId")
                        .IsRequired()
                        .HasConstraintName("unitUsers_unitId_fkey");

                    b.HasOne("apartment_portal_api.Models.Users.ApplicationUser", "ApplicationUser")
                        .WithMany("UnitUserUsers")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("unitUsers_userId_fkey");

                    b.Navigation("ApplicationUser");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("ModifiedByNavigation");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("apartment_portal_api.Models.Users.ApplicationUser", b =>
                {
                    b.HasOne("apartment_portal_api.Models.Users.ApplicationUser", "CreatedByNavigation")
                        .WithMany("InverseCreatedByNavigation")
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("users_createdBy_fkey");

                    b.HasOne("apartment_portal_api.Models.Users.ApplicationUser", "ModifiedByNavigation")
                        .WithMany("InverseModifiedByNavigation")
                        .HasForeignKey("ModifiedBy")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("users_modifiedBy_fkey");

                    b.HasOne("apartment_portal_api.Models.Statuses.Status", "Status")
                        .WithMany("Users")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("users_statusId_fkey");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("ModifiedByNavigation");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("apartment_portal_api.Models.Guests.Guest", b =>
                {
                    b.Navigation("ParkingPermits");
                });

            modelBuilder.Entity("apartment_portal_api.Models.IssueTypes.IssueType", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("apartment_portal_api.Models.Statuses.Status", b =>
                {
                    b.Navigation("Issues");

                    b.Navigation("Packages");

                    b.Navigation("Units");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("apartment_portal_api.Models.Unit", b =>
                {
                    b.Navigation("Packages");

                    b.Navigation("UnitUsers");
                });

            modelBuilder.Entity("apartment_portal_api.Models.Users.ApplicationUser", b =>
                {
                    b.Navigation("Guests");

                    b.Navigation("InverseCreatedByNavigation");

                    b.Navigation("InverseModifiedByNavigation");

                    b.Navigation("Issues");

                    b.Navigation("UnitUserCreatedByNavigations");

                    b.Navigation("UnitUserModifiedByNavigations");

                    b.Navigation("UnitUserUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
