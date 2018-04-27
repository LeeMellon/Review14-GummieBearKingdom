using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Review14.Models;

namespace Review14.Migrations
{
    [DbContext(typeof(GummyKingdomDbContext))]
    [Migration("20180427180423_AddVirtualProductToReview")]
    partial class AddVirtualProductToReview
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Review14.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Img");

                    b.Property<string>("ImgAlt");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<int>("Rating");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Review14.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProductId");

                    b.Property<string>("ReviewText");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("ReviewId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Review14.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ProfileName");

                    b.Property<string>("UserEmail");

                    b.Property<string>("UserImg");

                    b.Property<string>("UserImgAlt");

                    b.Property<string>("UserNameFirst");

                    b.Property<string>("UserNameLast");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Review14.Models.Review", b =>
                {
                    b.HasOne("Review14.Models.Product", "Product")
                        .WithMany("ProductReviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Review14.Models.User", "User")
                        .WithMany("UserReviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
