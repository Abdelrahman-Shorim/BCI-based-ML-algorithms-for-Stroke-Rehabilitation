﻿using BCI_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BCI_Project.Repository
{
    public class AppDbContext : IdentityDbContext<User, Role, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData
                (
                new Role() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new Role() { Name = "Patient", ConcurrencyStamp = "2", NormalizedName = "Patient" },
                new Role() { Name = "Doctor", ConcurrencyStamp = "3", NormalizedName = "Doctor" }
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedRoles(modelBuilder);


            modelBuilder.Entity<RoleAttributes>()
                .HasOne(a => a.Role)
                .WithMany(b => b.RoleAttributesRoles)
                .HasForeignKey(c => c.RoleId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DrPatients>()
                .HasOne(a => a.Patient)
                .WithMany(b => b.DrPatientsPatients)
                .HasForeignKey(c => c.PatientId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<DrPatients>()
                .HasOne(a => a.Doctor)
                .WithMany(b => b.DrPatientsDoctors)
                .HasForeignKey(c => c.DoctorId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SignalsAdaptation>()
                .HasOne(a => a.Patient)
                .WithMany(b => b.SignalsAdaptationPatients)
                .HasForeignKey(c => c.PatientId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comments>()
                .HasOne(a => a.Patient)
                .WithMany(b => b.CommentsPatients)
                .HasForeignKey(c => c.PatientId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comments>()
                .HasOne(a => a.Doctor)
                .WithMany(b => b.CommentsDoctors)
                .HasForeignKey(c => c.DoctorId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Game>()
                .HasOne(a => a.Patient)
                .WithMany(b => b.GamePatients)
                .HasForeignKey(c => c.PatientId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Game>()
                .HasOne(a => a.GameType)
                .WithMany(b => b.GameTypes)
                .HasForeignKey(c => c.GameTypeId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<GameMovements>()
                .HasOne(a => a.Game)
                .WithMany(b => b.GameMovementsGames)
                .HasForeignKey(c => c.GameId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}

