﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PreAcademicInfo.Models;
using System;

namespace PreAcademicInfo.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20181207200058_Cerere")]
    partial class Cerere
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PreAcademicInfo.Models.Admin", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("NumarTelefon")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Nume")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Prenume")
                        .IsRequired();

                    b.Property<string>("Salt")
                        .IsRequired();

                    b.Property<int>("UserType");

                    b.HasKey("Username");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("PreAcademicInfo.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FacultyId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("PreAcademicInfo.Models.Discipline", b =>
                {
                    b.Property<string>("Cod")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("An");

                    b.Property<int>("Credite");

                    b.Property<string>("Nume")
                        .IsRequired();

                    b.Property<int>("Semestru");

                    b.Property<int>("SpecializareId");

                    b.Property<string>("TeacherUsername")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.HasKey("Cod");

                    b.HasIndex("SpecializareId");

                    b.HasIndex("TeacherUsername");

                    b.ToTable("Discipline");
                });

            modelBuilder.Entity("PreAcademicInfo.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa")
                        .IsRequired();

                    b.Property<string>("Nume")
                        .IsRequired();

                    b.Property<string>("NumeUniveristate")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Faculty");
                });

            modelBuilder.Entity("PreAcademicInfo.Models.FacultyEnroll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GroupId")
                        .IsRequired();

                    b.Property<int>("SpecializareId");

                    b.Property<string>("StudentId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("SpecializareId");

                    b.HasIndex("StudentId");

                    b.ToTable("FacultyEnroll");
                });

            modelBuilder.Entity("PreAcademicInfo.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisciplineCod")
                        .IsRequired();

                    b.Property<double>("GradeValue");

                    b.Property<int?>("GradesToDisciplineId");

                    b.Property<string>("StudentUsername")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineCod");

                    b.HasIndex("GradesToDisciplineId");

                    b.HasIndex("StudentUsername");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("PreAcademicInfo.Models.GradesToDiscipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisciplineCod")
                        .IsRequired();

                    b.Property<string>("StudentUsername");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineCod");

                    b.HasIndex("StudentUsername");

                    b.ToTable("GradesToDiscipline");
                });

            modelBuilder.Entity("PreAcademicInfo.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("GroupName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("PreAcademicInfo.Models.Specializare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdminUsername");

                    b.Property<bool>("CuFrecventa");

                    b.Property<int>("DepartmentId");

                    b.Property<int>("Limba");

                    b.Property<int>("NumarSemestre");

                    b.Property<string>("Nume")
                        .IsRequired();

                    b.Property<double>("TaxaPerCredit");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AdminUsername");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Specializare");
                });

            modelBuilder.Entity("PreAcademicInfo.Models.Student", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("An")
                        .IsRequired();

                    b.Property<string>("CNP")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Generatie")
                        .IsRequired();

                    b.Property<string>("InitialaParinte")
                        .IsRequired();

                    b.Property<int>("NumarMatricol");

                    b.Property<string>("NumarTelefon")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Nume")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Prenume")
                        .IsRequired();

                    b.Property<string>("Salt")
                        .IsRequired();

                    b.Property<int>("UserType");

                    b.HasKey("Username");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("PreAcademicInfo.Models.Teacher", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("NumarTelefon")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Nume")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Prenume")
                        .IsRequired();

                    b.Property<string>("Salt")
                        .IsRequired();

                    b.Property<int>("UserType");

                    b.HasKey("Username");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("PreAcademicInfo.Models.Department", b =>
                {
                    b.HasOne("PreAcademicInfo.Models.Faculty", "Faculty")
                        .WithMany("Departments")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PreAcademicInfo.Models.Discipline", b =>
                {
                    b.HasOne("PreAcademicInfo.Models.Specializare", "Specializare")
                        .WithMany("Disciplines")
                        .HasForeignKey("SpecializareId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PreAcademicInfo.Models.Teacher", "Teacher")
                        .WithMany("DisciplinesHolded")
                        .HasForeignKey("TeacherUsername")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PreAcademicInfo.Models.FacultyEnroll", b =>
                {
                    b.HasOne("PreAcademicInfo.Models.Group", "Group")
                        .WithMany("FacultiesEnrolments")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PreAcademicInfo.Models.Specializare", "Specializare")
                        .WithMany()
                        .HasForeignKey("SpecializareId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PreAcademicInfo.Models.Student", "Student")
                        .WithMany("FacultiesEnrolled")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PreAcademicInfo.Models.Grade", b =>
                {
                    b.HasOne("PreAcademicInfo.Models.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineCod")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PreAcademicInfo.Models.GradesToDiscipline")
                        .WithMany("Grades")
                        .HasForeignKey("GradesToDisciplineId");

                    b.HasOne("PreAcademicInfo.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentUsername")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PreAcademicInfo.Models.GradesToDiscipline", b =>
                {
                    b.HasOne("PreAcademicInfo.Models.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineCod")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PreAcademicInfo.Models.Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentUsername");
                });

            modelBuilder.Entity("PreAcademicInfo.Models.Specializare", b =>
                {
                    b.HasOne("PreAcademicInfo.Models.Admin", "Admin")
                        .WithMany("Specializares")
                        .HasForeignKey("AdminUsername");

                    b.HasOne("PreAcademicInfo.Models.Department", "Department")
                        .WithMany("Specializares")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
