﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientInformationPortalAPI;

#nullable disable

namespace PatientInformationPortalAPI.Migrations
{
    [DbContext(typeof(PatientDbContext))]
    partial class PatientDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PatientInformationPortalAPI.Models.Allergies", b =>
                {
                    b.Property<int>("AllergiesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllergiesId"), 1L, 1);

                    b.Property<string>("AllergiesName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AllergiesId");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("PatientInformationPortalAPI.Models.Allergies_Details", b =>
                {
                    b.Property<int>("Allergies_DetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Allergies_DetailsId"), 1L, 1);

                    b.Property<int>("AllergiesId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int?>("PatientInformationPatientId")
                        .HasColumnType("int");

                    b.HasKey("Allergies_DetailsId");

                    b.HasIndex("AllergiesId");

                    b.HasIndex("PatientInformationPatientId");

                    b.ToTable("Allergies_details");
                });

            modelBuilder.Entity("PatientInformationPortalAPI.Models.DiseaseInformation", b =>
                {
                    b.Property<int>("DiseaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiseaseId"), 1L, 1);

                    b.Property<string>("DiseaseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiseaseId");

                    b.ToTable("DiseaseInformation");
                });

            modelBuilder.Entity("PatientInformationPortalAPI.Models.NCD", b =>
                {
                    b.Property<int>("NCDId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NCDId"), 1L, 1);

                    b.Property<string>("NCDName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NCDId");

                    b.ToTable("NCD");
                });

            modelBuilder.Entity("PatientInformationPortalAPI.Models.NCD_Details", b =>
                {
                    b.Property<int>("NCD_DetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NCD_DetailsId"), 1L, 1);

                    b.Property<int>("NCDId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int?>("PatientInformationPatientId")
                        .HasColumnType("int");

                    b.HasKey("NCD_DetailsId");

                    b.HasIndex("NCDId");

                    b.HasIndex("PatientInformationPatientId");

                    b.ToTable("NCDDetails");
                });

            modelBuilder.Entity("PatientInformationPortalAPI.Models.PatientInformation", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"), 1L, 1);

                    b.Property<int>("DiseaseId")
                        .HasColumnType("int");

                    b.Property<int>("Epilepsy")
                        .HasColumnType("int");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.HasIndex("DiseaseId");

                    b.ToTable("PatientInformation");
                });

            modelBuilder.Entity("PatientInformationPortalAPI.Models.Allergies_Details", b =>
                {
                    b.HasOne("PatientInformationPortalAPI.Models.Allergies", "Allergies")
                        .WithMany("Allergies_Details")
                        .HasForeignKey("AllergiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PatientInformationPortalAPI.Models.PatientInformation", null)
                        .WithMany("Allergies")
                        .HasForeignKey("PatientInformationPatientId");

                    b.Navigation("Allergies");
                });

            modelBuilder.Entity("PatientInformationPortalAPI.Models.NCD_Details", b =>
                {
                    b.HasOne("PatientInformationPortalAPI.Models.NCD", "NCD")
                        .WithMany("NCDDetails")
                        .HasForeignKey("NCDId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PatientInformationPortalAPI.Models.PatientInformation", null)
                        .WithMany("NCDs")
                        .HasForeignKey("PatientInformationPatientId");

                    b.Navigation("NCD");
                });

            modelBuilder.Entity("PatientInformationPortalAPI.Models.PatientInformation", b =>
                {
                    b.HasOne("PatientInformationPortalAPI.Models.DiseaseInformation", "DiseaseInformation")
                        .WithMany()
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiseaseInformation");
                });

            modelBuilder.Entity("PatientInformationPortalAPI.Models.Allergies", b =>
                {
                    b.Navigation("Allergies_Details");
                });

            modelBuilder.Entity("PatientInformationPortalAPI.Models.NCD", b =>
                {
                    b.Navigation("NCDDetails");
                });

            modelBuilder.Entity("PatientInformationPortalAPI.Models.PatientInformation", b =>
                {
                    b.Navigation("Allergies");

                    b.Navigation("NCDs");
                });
#pragma warning restore 612, 618
        }
    }
}
