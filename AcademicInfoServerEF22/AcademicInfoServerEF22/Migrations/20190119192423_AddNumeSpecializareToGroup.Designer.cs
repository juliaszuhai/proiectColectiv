﻿// <auto-generated />
using System;
using AcademicInfoServerEF22EF22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcademicInfoServerEF22.Migrations
{
    [DbContext(typeof(AcademicInfoContext))]
    [Migration("20190119192423_AddNumeSpecializareToGroup")]
    partial class AddNumeSpecializareToGroup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.Admin", b =>
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

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StudentUsername")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("StudentUsername");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.ContractToDiscipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContractId");

                    b.Property<string>("DisciplineCod")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("DisciplineCod");

                    b.ToTable("ContractToDiscipline");
                });

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FacultyId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.Discipline", b =>
                {
                    b.Property<string>("Cod")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("An");

                    b.Property<int>("Credite");

                    b.Property<int>("LocuriDisponibile");

                    b.Property<string>("Nume")
                        .IsRequired();

                    b.Property<int>("RequiredLabAttendance");

                    b.Property<int>("RequiredSeminaryAttendance");

                    b.Property<int>("Semestru");

                    b.Property<int>("SpecializareId");

                    b.Property<string>("TeacherUsername");

                    b.Property<int>("Type");

                    b.HasKey("Cod");

                    b.HasIndex("SpecializareId");

                    b.HasIndex("TeacherUsername");

                    b.ToTable("Discipline");
                });

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .IsRequired();

                    b.Property<string>("Nume")
                        .IsRequired();

                    b.Property<string>("NumeUniveristate")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Faculty");
                });

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.FacultyEnroll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GroupId")
                        .IsRequired();

                    b.Property<int>("SpecializareId");

                    b.Property<string>("StudentUsername");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("SpecializareId");

                    b.HasIndex("StudentUsername");

                    b.ToTable("FacultyEnroll");
                });

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DataNotei");

                    b.Property<double>("GradeValue");

                    b.Property<int?>("GradesToDisciplineId");

                    b.Property<double>("ProcentInnerType");

                    b.Property<double>("ProcentOuter");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("GradesToDisciplineId");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.GradesToDiscipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttendanceLab");

                    b.Property<int>("AttendanceSeminary");

                    b.Property<string>("DisciplineCod")
                        .IsRequired();

                    b.Property<string>("StudentUsername");

                    b.HasKey("Id");

                    b.HasIndex("DisciplineCod");

                    b.HasIndex("StudentUsername");

                    b.ToTable("GradeToDiscipline");
                });

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupName")
                        .IsRequired();

                    b.Property<string>("NumeSpecializare")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.Specializare", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminUsername");

                    b.Property<bool>("CuFrecventa");

                    b.Property<int?>("DepartmentId");

                    b.Property<string>("DepartmentName")
                        .IsRequired();

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

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.Student", b =>
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

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.Teacher", b =>
                {
                    b.Property<string>("Username")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("NumarTelefon")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Nume")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("PictureURL");

                    b.Property<string>("Prenume")
                        .IsRequired();

                    b.Property<string>("Salt")
                        .IsRequired();

                    b.Property<int>("UserType");

                    b.HasKey("Username");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.Contract", b =>
                {
                    b.HasOne("AcademicInfoServerEF22EF22.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentUsername")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.ContractToDiscipline", b =>
                {
                    b.HasOne("AcademicInfoServerEF22EF22.Models.Contract", "Contract")
                        .WithMany("Disciplines")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AcademicInfoServerEF22EF22.Models.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineCod")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.Department", b =>
                {
                    b.HasOne("AcademicInfoServerEF22EF22.Models.Faculty")
                        .WithMany("Departments")
                        .HasForeignKey("FacultyId");
                });

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.Discipline", b =>
                {
                    b.HasOne("AcademicInfoServerEF22EF22.Models.Specializare", "Specializare")
                        .WithMany()
                        .HasForeignKey("SpecializareId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AcademicInfoServerEF22EF22.Models.Teacher")
                        .WithMany("DisciplinesHolded")
                        .HasForeignKey("TeacherUsername");
                });

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.FacultyEnroll", b =>
                {
                    b.HasOne("AcademicInfoServerEF22EF22.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AcademicInfoServerEF22EF22.Models.Specializare", "Specializare")
                        .WithMany()
                        .HasForeignKey("SpecializareId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AcademicInfoServerEF22EF22.Models.Student")
                        .WithMany("FacultiesEnrolled")
                        .HasForeignKey("StudentUsername");
                });

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.Grade", b =>
                {
                    b.HasOne("AcademicInfoServerEF22EF22.Models.GradesToDiscipline")
                        .WithMany("Grades")
                        .HasForeignKey("GradesToDisciplineId");
                });

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.GradesToDiscipline", b =>
                {
                    b.HasOne("AcademicInfoServerEF22EF22.Models.Discipline", "Discipline")
                        .WithMany()
                        .HasForeignKey("DisciplineCod")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AcademicInfoServerEF22EF22.Models.Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentUsername");
                });

            modelBuilder.Entity("AcademicInfoServerEF22EF22.Models.Specializare", b =>
                {
                    b.HasOne("AcademicInfoServerEF22EF22.Models.Admin")
                        .WithMany("Specializares")
                        .HasForeignKey("AdminUsername");

                    b.HasOne("AcademicInfoServerEF22EF22.Models.Department")
                        .WithMany("Specializares")
                        .HasForeignKey("DepartmentId");
                });
#pragma warning restore 612, 618
        }
    }
}
