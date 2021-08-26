﻿// <auto-generated />
using System;
using Followers.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Followers.Model.Migrations
{
    [DbContext(typeof(FollowersDbContext))]
    [Migration("20210826144120_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("Followers.Model.Clients.Db.Entities.EfClient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("TEXT");

                    b.Property<int?>("Rank")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Clients", "dbo");
                });

            modelBuilder.Entity("Followers.Model.Clients.Db.Entities.EfFollower", b =>
                {
                    b.Property<Guid>("FollowerId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("FollowingId")
                        .HasColumnType("TEXT");

                    b.HasKey("FollowerId", "FollowingId");

                    b.HasIndex("FollowingId");

                    b.ToTable("Followers", "dbo");

                    b.HasCheckConstraint("CK_Followers", "[FollowerId] <> [FollowingId]");
                });

            modelBuilder.Entity("Followers.Model.Clients.Db.Entities.EfFollower", b =>
                {
                    b.HasOne("Followers.Model.Clients.Db.Entities.EfClient", "Follower")
                        .WithMany("Followers")
                        .HasForeignKey("FollowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Followers.Model.Clients.Db.Entities.EfClient", "Following")
                        .WithMany("Followings")
                        .HasForeignKey("FollowingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Follower");

                    b.Navigation("Following");
                });

            modelBuilder.Entity("Followers.Model.Clients.Db.Entities.EfClient", b =>
                {
                    b.Navigation("Followers");

                    b.Navigation("Followings");
                });
#pragma warning restore 612, 618
        }
    }
}