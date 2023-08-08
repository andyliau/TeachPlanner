﻿// <auto-generated />
using System;
using Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Assessments.Assessment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<DateTime>("ConductedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("YearLevel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Assessment");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Domain.Assessments.SummativeAssessmentResult", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateMarked")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("summative_assessment_results", (string)null);
                });

            modelBuilder.Entity("Domain.Common.Planner.SchoolEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("EventEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("EventStart")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("FullDay")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("school_events", (string)null);
                });

            modelBuilder.Entity("Domain.LessonPlanAggregate.LessonPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PlanningNotes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("WeekPlannerId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("WeekPlannerId");

                    b.ToTable("lesson_plans", (string)null);
                });

            modelBuilder.Entity("Domain.ReportAggregate.Report", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("YearLevel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("reports", (string)null);
                });

            modelBuilder.Entity("Domain.ResourceAggregate.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<string>("AssociatedStrands")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsAssessment")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("resources", (string)null);
                });

            modelBuilder.Entity("Domain.StudentAggregate.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Domain.SubjectAggregates.ContentDescription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CurriculumCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<Guid?>("StrandId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("SubstrandId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("StrandId");

                    b.HasIndex("SubstrandId");

                    b.ToTable("content_descriptions", (string)null);
                });

            modelBuilder.Entity("Domain.SubjectAggregates.Elaboration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ContentDescriptionId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("ContentDescriptionId");

                    b.ToTable("elaborations", (string)null);
                });

            modelBuilder.Entity("Domain.SubjectAggregates.Strand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("YearLevelId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("YearLevelId");

                    b.ToTable("strands", (string)null);
                });

            modelBuilder.Entity("Domain.SubjectAggregates.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("subjects", (string)null);
                });

            modelBuilder.Entity("Domain.SubjectAggregates.Substrand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("StrandId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("StrandId");

                    b.ToTable("substrands", (string)null);
                });

            modelBuilder.Entity("Domain.SubjectAggregates.YearLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AchievementStandard")
                        .HasColumnType("longtext");

                    b.Property<int?>("BandLevelValue")
                        .HasColumnType("int");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("char(36)");

                    b.Property<string>("YearLevelDescription")
                        .HasColumnType("longtext");

                    b.Property<int?>("YearLevelValue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("year_levels", (string)null);
                });

            modelBuilder.Entity("Domain.TeacherAggregate.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("teachers", (string)null);
                });

            modelBuilder.Entity("Domain.TermPlannerAggregate.TermPlanner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("TermEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TermNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("TermStart")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("term_planner", (string)null);
                });

            modelBuilder.Entity("Domain.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.WeekPlannerAggregate.WeekPlanner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TermPlannerId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("WeekNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("WeekStart")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.HasIndex("TermPlannerId");

                    b.ToTable("week_planner", (string)null);
                });

            modelBuilder.Entity("Domain.YearPlannerAggregate.YearPlanner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("Id");

                    b.Property<string>("YearLevel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("year_planner", (string)null);
                });

            modelBuilder.Entity("LessonPlanResource", b =>
                {
                    b.Property<Guid>("LessonPlansId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ResourcesId")
                        .HasColumnType("char(36)");

                    b.HasKey("LessonPlansId", "ResourcesId");

                    b.HasIndex("ResourcesId");

                    b.ToTable("LessonPlanResource");
                });

            modelBuilder.Entity("SchoolEventTermPlanner", b =>
                {
                    b.Property<Guid>("SchoolEventsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TermPlannerId")
                        .HasColumnType("char(36)");

                    b.HasKey("SchoolEventsId", "TermPlannerId");

                    b.HasIndex("TermPlannerId");

                    b.ToTable("SchoolEventTermPlanner");
                });

            modelBuilder.Entity("SchoolEventWeekPlanner", b =>
                {
                    b.Property<Guid>("SchoolEventsId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("WeekPlannerId")
                        .HasColumnType("char(36)");

                    b.HasKey("SchoolEventsId", "WeekPlannerId");

                    b.HasIndex("WeekPlannerId");

                    b.ToTable("SchoolEventWeekPlanner");
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("char(36)");

                    b.HasKey("SubjectId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("SubjectTeacher");
                });

            modelBuilder.Entity("Domain.Assessments.FormativeAssessment", b =>
                {
                    b.HasBaseType("Domain.Assessments.Assessment");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("LessonPlanId")
                        .HasColumnType("char(36)");

                    b.HasIndex("LessonPlanId");

                    b.ToTable("formative_assessments", (string)null);
                });

            modelBuilder.Entity("Domain.Assessments.SummativeAssessment", b =>
                {
                    b.HasBaseType("Domain.Assessments.Assessment");

                    b.Property<DateTime>("DateScheduled")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("LessonPlanId")
                        .HasColumnType("char(36)");

                    b.Property<string>("PlanningNotes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("ResultId")
                        .HasColumnType("char(36)");

                    b.HasIndex("LessonPlanId");

                    b.HasIndex("ResultId");

                    b.ToTable("summative_assessments", (string)null);
                });

            modelBuilder.Entity("Domain.Assessments.Assessment", b =>
                {
                    b.HasOne("Domain.StudentAggregate.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.SubjectAggregates.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.TeacherAggregate.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Assessments.SummativeAssessmentResult", b =>
                {
                    b.OwnsOne("Domain.Assessments.AssessmentGrade", "Grade", b1 =>
                        {
                            b1.Property<Guid>("SummativeAssessmentResultId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Grade")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<double?>("Percentage")
                                .HasColumnType("double");

                            b1.HasKey("SummativeAssessmentResultId");

                            b1.ToTable("summative_assessment_results");

                            b1.WithOwner()
                                .HasForeignKey("SummativeAssessmentResultId");
                        });

                    b.Navigation("Grade")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Common.Planner.SchoolEvent", b =>
                {
                    b.OwnsOne("Domain.Common.Planner.Location", "Location", b1 =>
                        {
                            b1.Property<Guid>("SchoolEventId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("StreetName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)");

                            b1.Property<string>("StreetNumber")
                                .IsRequired()
                                .HasMaxLength(30)
                                .HasColumnType("varchar(30)");

                            b1.Property<string>("Suburb")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("varchar(50)");

                            b1.HasKey("SchoolEventId");

                            b1.ToTable("school_events");

                            b1.WithOwner()
                                .HasForeignKey("SchoolEventId");
                        });

                    b.Navigation("Location")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.LessonPlanAggregate.LessonPlan", b =>
                {
                    b.HasOne("Domain.SubjectAggregates.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.TeacherAggregate.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.WeekPlannerAggregate.WeekPlanner", null)
                        .WithMany()
                        .HasForeignKey("WeekPlannerId");

                    b.OwnsMany("Domain.LessonPlanAggregate.LessonComment", "Comments", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("LessonPlanId")
                                .HasColumnType("char(36)");

                            b1.Property<bool>("Completed")
                                .HasColumnType("tinyint(1)");

                            b1.Property<DateTime?>("CompletedDateTime")
                                .HasColumnType("datetime(6)");

                            b1.Property<string>("Content")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<DateTime>("CreatedDateTime")
                                .HasColumnType("datetime(6)");

                            b1.Property<bool>("StruckOut")
                                .HasColumnType("tinyint(1)");

                            b1.Property<DateTime>("UpdatedDateTime")
                                .HasColumnType("datetime(6)");

                            b1.HasKey("Id", "LessonPlanId");

                            b1.HasIndex("LessonPlanId");

                            b1.ToTable("lesson_comment", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("LessonPlanId");
                        });

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Domain.ReportAggregate.Report", b =>
                {
                    b.HasOne("Domain.StudentAggregate.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.SubjectAggregates.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.TeacherAggregate.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("Domain.ReportAggregate.ReportComment", "ReportComments", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("char(36)");

                            b1.Property<int>("CharacterLimit")
                                .HasColumnType("int");

                            b1.Property<string>("Comments")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Grade")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<Guid>("Guid")
                                .HasColumnType("char(36)");

                            b1.Property<Guid>("ReportId")
                                .HasColumnType("char(36)");

                            b1.HasKey("Id");

                            b1.HasIndex("ReportId");

                            b1.ToTable("report_comments", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("ReportId");
                        });

                    b.Navigation("ReportComments");
                });

            modelBuilder.Entity("Domain.ResourceAggregate.Resource", b =>
                {
                    b.HasOne("Domain.SubjectAggregates.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.StudentAggregate.Student", b =>
                {
                    b.HasOne("Domain.TeacherAggregate.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeacherId");
                });

            modelBuilder.Entity("Domain.SubjectAggregates.ContentDescription", b =>
                {
                    b.HasOne("Domain.SubjectAggregates.Strand", "Strand")
                        .WithMany("ContentDescriptions")
                        .HasForeignKey("StrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Domain.SubjectAggregates.Substrand", "Substrand")
                        .WithMany("ContentDescriptions")
                        .HasForeignKey("SubstrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Strand");

                    b.Navigation("Substrand");
                });

            modelBuilder.Entity("Domain.SubjectAggregates.Elaboration", b =>
                {
                    b.HasOne("Domain.SubjectAggregates.ContentDescription", "ContentDescription")
                        .WithMany("Elaborations")
                        .HasForeignKey("ContentDescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContentDescription");
                });

            modelBuilder.Entity("Domain.SubjectAggregates.Strand", b =>
                {
                    b.HasOne("Domain.SubjectAggregates.YearLevel", null)
                        .WithMany("Strands")
                        .HasForeignKey("YearLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.SubjectAggregates.Substrand", b =>
                {
                    b.HasOne("Domain.SubjectAggregates.Strand", "Strand")
                        .WithMany("Substrands")
                        .HasForeignKey("StrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Strand");
                });

            modelBuilder.Entity("Domain.SubjectAggregates.YearLevel", b =>
                {
                    b.HasOne("Domain.SubjectAggregates.Subject", null)
                        .WithMany("YearLevels")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.TeacherAggregate.Teacher", b =>
                {
                    b.HasOne("Domain.UserAggregate.User", null)
                        .WithOne()
                        .HasForeignKey("Domain.TeacherAggregate.Teacher", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.WeekPlannerAggregate.WeekPlanner", b =>
                {
                    b.HasOne("Domain.TeacherAggregate.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.TermPlannerAggregate.TermPlanner", null)
                        .WithMany()
                        .HasForeignKey("TermPlannerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.YearPlannerAggregate.YearPlanner", b =>
                {
                    b.OwnsMany("Domain.YearPlannerAggregate.TermPlan", "TermPlans", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            b1.Property<Guid>("YearPlannerId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Subjects")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("Id", "YearPlannerId");

                            b1.HasIndex("YearPlannerId");

                            b1.ToTable("term_plans", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("YearPlannerId");
                        });

                    b.Navigation("TermPlans");
                });

            modelBuilder.Entity("LessonPlanResource", b =>
                {
                    b.HasOne("Domain.LessonPlanAggregate.LessonPlan", null)
                        .WithMany()
                        .HasForeignKey("LessonPlansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.ResourceAggregate.Resource", null)
                        .WithMany()
                        .HasForeignKey("ResourcesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolEventTermPlanner", b =>
                {
                    b.HasOne("Domain.Common.Planner.SchoolEvent", null)
                        .WithMany()
                        .HasForeignKey("SchoolEventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.TermPlannerAggregate.TermPlanner", null)
                        .WithMany()
                        .HasForeignKey("TermPlannerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SchoolEventWeekPlanner", b =>
                {
                    b.HasOne("Domain.Common.Planner.SchoolEvent", null)
                        .WithMany()
                        .HasForeignKey("SchoolEventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.WeekPlannerAggregate.WeekPlanner", null)
                        .WithMany()
                        .HasForeignKey("WeekPlannerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubjectTeacher", b =>
                {
                    b.HasOne("Domain.SubjectAggregates.Subject", null)
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.TeacherAggregate.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Assessments.FormativeAssessment", b =>
                {
                    b.HasOne("Domain.Assessments.Assessment", null)
                        .WithOne()
                        .HasForeignKey("Domain.Assessments.FormativeAssessment", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.LessonPlanAggregate.LessonPlan", null)
                        .WithMany()
                        .HasForeignKey("LessonPlanId");
                });

            modelBuilder.Entity("Domain.Assessments.SummativeAssessment", b =>
                {
                    b.HasOne("Domain.Assessments.Assessment", null)
                        .WithOne()
                        .HasForeignKey("Domain.Assessments.SummativeAssessment", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.LessonPlanAggregate.LessonPlan", null)
                        .WithMany()
                        .HasForeignKey("LessonPlanId");

                    b.HasOne("Domain.Assessments.SummativeAssessmentResult", "Result")
                        .WithMany()
                        .HasForeignKey("ResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Result");
                });

            modelBuilder.Entity("Domain.SubjectAggregates.ContentDescription", b =>
                {
                    b.Navigation("Elaborations");
                });

            modelBuilder.Entity("Domain.SubjectAggregates.Strand", b =>
                {
                    b.Navigation("ContentDescriptions");

                    b.Navigation("Substrands");
                });

            modelBuilder.Entity("Domain.SubjectAggregates.Subject", b =>
                {
                    b.Navigation("YearLevels");
                });

            modelBuilder.Entity("Domain.SubjectAggregates.Substrand", b =>
                {
                    b.Navigation("ContentDescriptions");
                });

            modelBuilder.Entity("Domain.SubjectAggregates.YearLevel", b =>
                {
                    b.Navigation("Strands");
                });
#pragma warning restore 612, 618
        }
    }
}
