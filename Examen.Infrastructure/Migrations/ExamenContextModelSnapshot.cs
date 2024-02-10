﻿// <auto-generated />
using System;
using Examen.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    [DbContext(typeof(ExamenContext))]
    partial class ExamenContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Admission", b =>
                {
                    b.Property<DateTime>("DateAdmission")
                        .HasColumnType("datetime2");

                    b.Property<string>("PatientFK")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ChambreFK")
                        .HasColumnType("int");

                    b.Property<string>("MotifAdmission")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NbJours")
                        .HasColumnType("int");

                    b.HasKey("DateAdmission", "PatientFK", "ChambreFK");

                    b.HasIndex("ChambreFK");

                    b.HasIndex("PatientFK");

                    b.ToTable("Admissions");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Chambre", b =>
                {
                    b.Property<int>("NumeroChambre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumeroChambre"), 1L, 1);

                    b.Property<int>("CliniqueFK")
                        .HasColumnType("int");

                    b.Property<float>("Prix")
                        .HasColumnType("real");

                    b.Property<int>("TypeChambre")
                        .HasColumnType("int");

                    b.HasKey("NumeroChambre");

                    b.HasIndex("CliniqueFK");

                    b.ToTable("Chambres");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Clinique", b =>
                {
                    b.Property<int>("CliniqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CliniqueId"), 1L, 1);

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacite")
                        .HasColumnType("int");

                    b.Property<int>("NumTel")
                        .HasColumnType("int");

                    b.HasKey("CliniqueId");

                    b.ToTable("Cliniques");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Patient", b =>
                {
                    b.Property<string>("CIN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdresseEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumDossier")
                        .HasColumnType("int");

                    b.Property<int>("NumTel")
                        .HasColumnType("int");

                    b.HasKey("CIN");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Admission", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Chambre", "Chambre")
                        .WithMany("Admissions")
                        .HasForeignKey("ChambreFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examen.ApplicationCore.Domain.Patient", "Patient")
                        .WithMany("Admissions")
                        .HasForeignKey("PatientFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chambre");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Chambre", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Clinique", "Clinique")
                        .WithMany("Chambres")
                        .HasForeignKey("CliniqueFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clinique");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Patient", b =>
                {
                    b.OwnsOne("Examen.ApplicationCore.Domain.NomComplet", "NomComplet", b1 =>
                        {
                            b1.Property<string>("PatientCIN")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<string>("Nom")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Prenom")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("PatientCIN");

                            b1.ToTable("Patients");

                            b1.WithOwner()
                                .HasForeignKey("PatientCIN");
                        });

                    b.Navigation("NomComplet")
                        .IsRequired();
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Chambre", b =>
                {
                    b.Navigation("Admissions");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Clinique", b =>
                {
                    b.Navigation("Chambres");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Patient", b =>
                {
                    b.Navigation("Admissions");
                });
#pragma warning restore 612, 618
        }
    }
}