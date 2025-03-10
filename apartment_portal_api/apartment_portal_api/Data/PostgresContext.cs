using apartment_portal_api.Models;
using apartment_portal_api.Models.Guests;
using apartment_portal_api.Models.Issues;
using apartment_portal_api.Models.IssueTypes;
using apartment_portal_api.Models.Packages;
using apartment_portal_api.Models.ParkingPermits;
using apartment_portal_api.Models.Statuses;
using apartment_portal_api.Models.UnitUsers;
using apartment_portal_api.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace apartment_portal_api.Data;

public partial class PostgresContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Issue> Issues { get; set; }

    public virtual DbSet<IssueType> IssueTypes { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<ParkingPermit> ParkingPermits { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<UnitUser> UnitUsers { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
            .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
            .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
            .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn", "phone" })
            .HasPostgresEnum("auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" })
            .HasPostgresEnum("pgsodium", "key_status", new[] { "default", "valid", "invalid", "expired" })
            .HasPostgresEnum("pgsodium", "key_type", new[] { "aead-ietf", "aead-det", "hmacsha512", "hmacsha256", "auth", "shorthash", "generichash", "kdf", "secretbox", "secretstream", "stream_xchacha20" })
            .HasPostgresEnum("realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" })
            .HasPostgresEnum("realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in" })
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "pgjwt")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("graphql", "pg_graphql")
            .HasPostgresExtension("pgsodium", "pgsodium")
            .HasPostgresExtension("vault", "supabase_vault");

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("guests_pkey");

            entity.ToTable("guests");

            entity.HasIndex(e => e.Email, "guests_email_key").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "guests_phoneNumber_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessCode).HasColumnName("accessCode");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(now() AT TIME ZONE 'utc'::text)")
                .HasColumnName("createdOn");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Expiration).HasColumnName("expiration");
            entity.Property(e => e.FirstName).HasColumnName("firstName");
            entity.Property(e => e.LastName).HasColumnName("lastName");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.ApplicationUser).WithMany(p => p.Guests)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("guests_userId_fkey");
        });

        modelBuilder.Entity<Issue>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.IssueTypeId }).HasName("issues_pkey");

            entity.ToTable("issues");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.IssueTypeId).HasColumnName("issueTypeId");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(now() AT TIME ZONE 'utc'::text)")
                .HasColumnName("createdOn");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.StatusId).HasColumnName("statusId");

            entity.HasOne(e => e.Status).WithMany(status => status.Issues)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("issues_statusId_fkey");

            entity.HasOne(d => d.IssueType).WithMany(p => p.Issues)
                .HasForeignKey(d => d.IssueTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("issues_issueTypeId_fkey");

            entity.HasOne(d => d.ApplicationUser).WithMany(p => p.Issues)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("issues_userId_fkey");
        });

        modelBuilder.Entity<IssueType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("issueTypes_pkey");

            entity.ToTable("issueTypes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("packages_pkey");

            entity.ToTable("packages");

            entity.HasIndex(e => e.LockerNumber, "packages_lockerNumber_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.LockerNumber).HasColumnName("lockerNumber");
            entity.Property(e => e.StatusId).HasColumnName("statusId");
            entity.Property(e => e.UnitId).HasColumnName("unitId");

            entity.HasOne(d => d.Status).WithMany(p => p.Packages)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("packages_statusId_fkey");

            entity.HasOne(d => d.Unit).WithMany(p => p.Packages)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("packages_unitId_fkey");
        });

        modelBuilder.Entity<ParkingPermit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("parkingPermits_pkey");

            entity.ToTable("parkingPermits");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GuestId).HasColumnName("guestId");
            entity.Property(e => e.LicensePlate).HasColumnName("licensePlate");
            entity.Property(e => e.LicensePlateState).HasColumnName("licensePlateState");
            entity.Property(e => e.VehicleMake).HasColumnName("vehicleMake");
            entity.Property(e => e.VehicleModel).HasColumnName("vehicleModel");

            entity.HasOne(d => d.Guest).WithMany(p => p.ParkingPermits)
                .HasForeignKey(d => d.GuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("parkingPermits_guestId_fkey");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("statuses_pkey");

            entity.ToTable("statuses");

            entity.HasIndex(e => e.Name, "statuses_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("units_pkey");

            entity.ToTable("units");

            entity.HasIndex(e => e.Number, "units_number_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.StatusId).HasColumnName("statusId");

            entity.HasOne(d => d.Status).WithMany(p => p.Units)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("units_statusId_fkey");
        });

        modelBuilder.Entity<UnitUser>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.UnitId }).HasName("unitUsers_pkey");

            entity.ToTable("unitUsers");

            entity.Property(e => e.UserId)
                .ValueGeneratedOnAdd()
                .HasColumnName("userId");
            entity.Property(e => e.UnitId).HasColumnName("unitId");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(now() AT TIME ZONE 'utc'::text)")
                .HasColumnName("createdOn");
            entity.Property(e => e.IsPrimary).HasColumnName("isPrimary");
            entity.Property(e => e.LeaseAgreement).HasColumnName("leaseAgreement");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(now() AT TIME ZONE 'utc'::text)")
                .HasColumnName("modifiedOn");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.UnitUserCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("unitUsers_createdBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.UnitUserModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("unitUsers_modifiedBy_fkey");

            entity.HasOne(d => d.Unit).WithMany(p => p.UnitUsers)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("unitUsers_unitId_fkey");

            entity.HasOne(d => d.ApplicationUser).WithMany(p => p.UnitUserUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("unitUsers_userId_fkey");
        });

        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(now() AT TIME ZONE 'utc'::text)")
                .HasColumnName("createdOn");
            entity.Property(e => e.DateOfBirth).HasColumnName("dateOfBirth");
            entity.Property(e => e.FirstName).HasColumnName("firstName");
            entity.Property(e => e.LastName).HasColumnName("lastName");
            entity.Property(e => e.ModifiedBy).HasColumnName("modifiedBy");
            entity.Property(e => e.ModifiedOn)
                .HasDefaultValueSql("(now() AT TIME ZONE 'utc'::text)")
                .HasColumnName("modifiedOn");
            entity.Property(e => e.StatusId).HasColumnName("statusId");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("users_createdBy_fkey");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.InverseModifiedByNavigation)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("users_modifiedBy_fkey");

            entity.HasOne(d => d.Status).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_statusId_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
