﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ISpanSTA.Models
{
    public partial class dbIspanStudentSystemContext : DbContext
    {
        public dbIspanStudentSystemContext()
        {
        }

        public dbIspanStudentSystemContext(DbContextOptions<dbIspanStudentSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAccount> TAccounts { get; set; }
        public virtual DbSet<TArrangeCourseInfo> TArrangeCourseInfos { get; set; }
        public virtual DbSet<TArtiCategory> TArtiCategories { get; set; }
        public virtual DbSet<TArtiSubCategory> TArtiSubCategories { get; set; }
        public virtual DbSet<TArticleInfo> TArticleInfos { get; set; }
        public virtual DbSet<TCategory> TCategories { get; set; }
        public virtual DbSet<TClassCategory> TClassCategories { get; set; }
        public virtual DbSet<TClassCourseFullInfo> TClassCourseFullInfos { get; set; }
        public virtual DbSet<TClassFullInfo> TClassFullInfos { get; set; }
        public virtual DbSet<TClassroomFullInfo> TClassroomFullInfos { get; set; }
        public virtual DbSet<TComment> TComments { get; set; }
        public virtual DbSet<TEvaluationCheck> TEvaluationChecks { get; set; }
        public virtual DbSet<TEvaluationDetail> TEvaluationDetails { get; set; }
        public virtual DbSet<TEvaluationHeader> TEvaluationHeaders { get; set; }
        public virtual DbSet<TEvaluationQuestionDetail> TEvaluationQuestionDetails { get; set; }
        public virtual DbSet<TEvaluationQuestionType> TEvaluationQuestionTypes { get; set; }
        public virtual DbSet<TEvaluationReviewHeader> TEvaluationReviewHeaders { get; set; }
        public virtual DbSet<TExamPaperDetail> TExamPaperDetails { get; set; }
        public virtual DbSet<TExaminationPaper> TExaminationPapers { get; set; }
        public virtual DbSet<TFilmVideo> TFilmVideos { get; set; }
        public virtual DbSet<THomework> THomeworks { get; set; }
        public virtual DbSet<THomeworkScore> THomeworkScores { get; set; }
        public virtual DbSet<TLeaveInfo> TLeaveInfos { get; set; }
        public virtual DbSet<TLike> TLikes { get; set; }
        public virtual DbSet<TOption> TOptions { get; set; }
        public virtual DbSet<TPunchInfo> TPunchInfos { get; set; }
        public virtual DbSet<TRecord> TRecords { get; set; }
        public virtual DbSet<TScore> TScores { get; set; }
        public virtual DbSet<TStudentFullInfo> TStudentFullInfos { get; set; }
        public virtual DbSet<TSuject> TSujects { get; set; }
        public virtual DbSet<TTeacherCourseFullInfo> TTeacherCourseFullInfos { get; set; }
        public virtual DbSet<TTeacherFullInfo> TTeacherFullInfos { get; set; }
        public virtual DbSet<TType> TTypes { get; set; }
        public virtual DbSet<Tquestionnare> Tquestionnares { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:msit40group2.database.windows.net,1433;Initial Catalog=dbIspanStudentSystem;Persist Security Info=False;User ID=ispanadmin;Password=Ispansta123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<TAccount>(entity =>
            {
                entity.HasKey(e => e.FAccountId);

                entity.ToTable("tAccount");

                entity.Property(e => e.FAccountId).HasColumnName("fAccountID");

                entity.Property(e => e.FAccount)
                    .HasMaxLength(50)
                    .HasColumnName("fAccount");

                entity.Property(e => e.FEmail)
                    .HasMaxLength(50)
                    .HasColumnName("fEmail");

                entity.Property(e => e.FGender)
                    .HasMaxLength(50)
                    .HasColumnName("fGender");

                entity.Property(e => e.FHeadShot)
                    .HasMaxLength(50)
                    .HasColumnName("fHeadShot");

                entity.Property(e => e.FIdentity)
                    .HasMaxLength(50)
                    .HasColumnName("fIdentity");

                entity.Property(e => e.FPassword)
                    .HasMaxLength(50)
                    .HasColumnName("fPassword");

                entity.Property(e => e.FPhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("fPhoneNumber");

                entity.Property(e => e.FUserName)
                    .HasMaxLength(50)
                    .HasColumnName("fUserName");
            });

            modelBuilder.Entity<TArrangeCourseInfo>(entity =>
            {
                entity.HasKey(e => e.FArrangeNumber)
                    .HasName("PK_ArrangeCourseInfo");

                entity.ToTable("tArrangeCourseInfo");

                entity.Property(e => e.FArrangeNumber).HasColumnName("fArrangeNumber");

                entity.Property(e => e.FCell).HasColumnName("fCell");

                entity.Property(e => e.FClassDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fClassDate");

                entity.Property(e => e.FClassPeriod)
                    .HasMaxLength(10)
                    .HasColumnName("fClassPeriod");

                entity.Property(e => e.FCourseId).HasColumnName("fCourseID");

                entity.Property(e => e.FCourseName)
                    .HasMaxLength(50)
                    .HasColumnName("fCourseName");

                entity.Property(e => e.FRow).HasColumnName("fRow");

                entity.Property(e => e.FTeacherId).HasColumnName("fTeacherID");

                entity.Property(e => e.FTeachingHours)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("fTeachingHours");

                entity.Property(e => e.FTimeEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("fTimeEnd");

                entity.Property(e => e.FTimeStart)
                    .HasColumnType("datetime")
                    .HasColumnName("fTimeStart");

                entity.HasOne(d => d.FClassPeriodNavigation)
                    .WithMany(p => p.TArrangeCourseInfos)
                    .HasForeignKey(d => d.FClassPeriod)
                    .HasConstraintName("FK_ArrangeCourseInfo_ClassFullInfo");

                entity.HasOne(d => d.FCourse)
                    .WithMany(p => p.TArrangeCourseInfos)
                    .HasForeignKey(d => d.FCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ArrangeCourseInfo_ClassCourseFullInfo");

                entity.HasOne(d => d.FTeacher)
                    .WithMany(p => p.TArrangeCourseInfos)
                    .HasForeignKey(d => d.FTeacherId)
                    .HasConstraintName("FK_ArrangeCourseInfo_TeacherFullInfo");
            });

            modelBuilder.Entity<TArtiCategory>(entity =>
            {
                entity.HasKey(e => e.FCategoryName);

                entity.ToTable("tArtiCategory");

                entity.Property(e => e.FCategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("fCategoryName");

                entity.Property(e => e.FCategoryNumber)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("fCategoryNumber");
            });

            modelBuilder.Entity<TArtiSubCategory>(entity =>
            {
                entity.HasKey(e => e.FSubCategoryId);

                entity.ToTable("tArtiSubCategory");

                entity.Property(e => e.FSubCategoryId).HasColumnName("fSubCategoryID");

                entity.Property(e => e.FCategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fCategoryName");

                entity.Property(e => e.FSubCategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fSubCategoryName");

                entity.HasOne(d => d.FCategoryNameNavigation)
                    .WithMany(p => p.TArtiSubCategories)
                    .HasForeignKey(d => d.FCategoryName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tArtiSubCategory_tArtiCategory");
            });

            modelBuilder.Entity<TArticleInfo>(entity =>
            {
                entity.HasKey(e => e.FArticleId)
                    .HasName("PK_tArticleInFo");

                entity.ToTable("tArticleInfo");

                entity.Property(e => e.FArticleId).HasColumnName("fArticleID");

                entity.Property(e => e.FCategory)
                    .HasMaxLength(50)
                    .HasColumnName("fCategory");

                entity.Property(e => e.FComments).HasColumnName("fComments");

                entity.Property(e => e.FContent)
                    .HasMaxLength(1000)
                    .HasColumnName("fContent");

                entity.Property(e => e.FDeleteTime)
                    .HasColumnType("datetime")
                    .HasColumnName("fDeleteTime");

                entity.Property(e => e.FLike).HasColumnName("fLike");

                entity.Property(e => e.FModifiedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("fModifiedTime");

                entity.Property(e => e.FPhotoPath)
                    .HasMaxLength(50)
                    .HasColumnName("fPhotoPath");

                entity.Property(e => e.FReleaseTime)
                    .HasColumnType("datetime")
                    .HasColumnName("fReleaseTime");

                entity.Property(e => e.FStudentNumber).HasColumnName("fStudentNumber");

                entity.Property(e => e.FSubCategory)
                    .HasMaxLength(50)
                    .HasColumnName("fSubCategory");

                entity.Property(e => e.FTitle)
                    .HasMaxLength(50)
                    .HasColumnName("fTitle");

                entity.Property(e => e.FVideo)
                    .HasMaxLength(50)
                    .HasColumnName("fVideo");

                entity.Property(e => e.FWriter)
                    .HasMaxLength(50)
                    .HasColumnName("fWriter");

                entity.HasOne(d => d.FCategoryNavigation)
                    .WithMany(p => p.TArticleInfos)
                    .HasForeignKey(d => d.FCategory)
                    .HasConstraintName("FK_tArticleInFo_tArtiCategory");
            });

            modelBuilder.Entity<TCategory>(entity =>
            {
                entity.HasKey(e => e.FCategoryId);

                entity.ToTable("tCategory");

                entity.Property(e => e.FCategoryId).HasColumnName("fCategoryId");

                entity.Property(e => e.FContent)
                    .HasMaxLength(100)
                    .HasColumnName("fContent");

                entity.Property(e => e.FCourseId).HasColumnName("fCourseId");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.HasOne(d => d.FCourse)
                    .WithMany(p => p.TCategories)
                    .HasForeignKey(d => d.FCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tCategory_tClassCourseFullInfo");
            });

            modelBuilder.Entity<TClassCategory>(entity =>
            {
                entity.HasKey(e => e.FClass)
                    .HasName("PK_ClassCategory_1");

                entity.ToTable("tClassCategory");

                entity.Property(e => e.FClass)
                    .HasMaxLength(10)
                    .HasColumnName("fClass");

                entity.Property(e => e.FClassCategoryNumber)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("fClassCategoryNumber");
            });

            modelBuilder.Entity<TClassCourseFullInfo>(entity =>
            {
                entity.HasKey(e => e.FCourseId)
                    .HasName("PK_CourseID");

                entity.ToTable("tClassCourseFullInfo");

                entity.Property(e => e.FCourseId).HasColumnName("fCourseID");

                entity.Property(e => e.FClass)
                    .HasMaxLength(10)
                    .HasColumnName("fClass");

                entity.Property(e => e.FCourse)
                    .HasMaxLength(50)
                    .HasColumnName("fCourse");

                entity.Property(e => e.FCourseHours).HasColumnName("fCourseHours");

                entity.HasOne(d => d.FClassNavigation)
                    .WithMany(p => p.TClassCourseFullInfos)
                    .HasForeignKey(d => d.FClass)
                    .HasConstraintName("FK_ClassCourseFullInfo_ClassCategory");
            });

            modelBuilder.Entity<TClassFullInfo>(entity =>
            {
                entity.HasKey(e => e.FClassPeriod)
                    .HasName("PK_ClassNumber");

                entity.ToTable("tClassFullInfo");

                entity.Property(e => e.FClassPeriod)
                    .HasMaxLength(10)
                    .HasColumnName("fClassPeriod");

                entity.Property(e => e.FClass)
                    .HasMaxLength(10)
                    .HasColumnName("fClass");

                entity.Property(e => e.FClassEndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("fClassEndTime");

                entity.Property(e => e.FClassNumber)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("fClassNumber");

                entity.Property(e => e.FClassStartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("fClassStartTime");

                entity.Property(e => e.FClassroom)
                    .HasMaxLength(10)
                    .HasColumnName("fClassroom");

                entity.Property(e => e.FMentorName)
                    .HasMaxLength(5)
                    .HasColumnName("fMentorName");

                entity.HasOne(d => d.FClassNavigation)
                    .WithMany(p => p.TClassFullInfos)
                    .HasForeignKey(d => d.FClass)
                    .HasConstraintName("FK_ClassFullInfo_ClassCategory");

                entity.HasOne(d => d.FClassroomNavigation)
                    .WithMany(p => p.TClassFullInfos)
                    .HasForeignKey(d => d.FClassroom)
                    .HasConstraintName("FK_ClassFullInfo_ClassroomFullInfo");
            });

            modelBuilder.Entity<TClassroomFullInfo>(entity =>
            {
                entity.HasKey(e => e.FClassroom)
                    .HasName("PK_ClassroomFullInfo_1");

                entity.ToTable("tClassroomFullInfo");

                entity.Property(e => e.FClassroom)
                    .HasMaxLength(10)
                    .HasColumnName("fClassroom");

                entity.Property(e => e.FClassroomNumber)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("fClassroomNumber");

                entity.Property(e => e.Flatitude)
                    .HasColumnType("decimal(5, 3)")
                    .HasColumnName("flatitude");

                entity.Property(e => e.Flatitudeend)
                    .HasColumnType("decimal(5, 3)")
                    .HasColumnName("flatitudeend");

                entity.Property(e => e.Flatitudestart)
                    .HasColumnType("decimal(5, 3)")
                    .HasColumnName("flatitudestart");

                entity.Property(e => e.Flongitude)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("flongitude");
            });

            modelBuilder.Entity<TComment>(entity =>
            {
                entity.HasKey(e => e.FCommentsId);

                entity.ToTable("tComments");

                entity.Property(e => e.FCommentsId).HasColumnName("fCommentsID");

                entity.Property(e => e.FArticleNumber).HasColumnName("fArticleNumber");

                entity.Property(e => e.FCommentLike).HasColumnName("fCommentLike");

                entity.Property(e => e.FCommentTime)
                    .HasColumnType("datetime")
                    .HasColumnName("fCommentTime");

                entity.Property(e => e.FComments)
                    .HasMaxLength(200)
                    .HasColumnName("fComments");

                entity.Property(e => e.FDeleteTime)
                    .HasColumnType("datetime")
                    .HasColumnName("fDeleteTime");

                entity.Property(e => e.FModifiedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("fModifiedTime");

                entity.Property(e => e.FStudentName)
                    .HasMaxLength(50)
                    .HasColumnName("fStudentName");

                entity.Property(e => e.FStudentNumber).HasColumnName("fStudentNumber");

                entity.HasOne(d => d.FArticleNumberNavigation)
                    .WithMany(p => p.TComments)
                    .HasForeignKey(d => d.FArticleNumber)
                    .HasConstraintName("FK_tComments_tArticleInFo");
            });

            modelBuilder.Entity<TEvaluationCheck>(entity =>
            {
                entity.HasKey(e => e.FCheckId);

                entity.ToTable("tEvaluationCheck");

                entity.Property(e => e.FCheckId).HasColumnName("fCheckId");

                entity.Property(e => e.FEvaluationId).HasColumnName("fEvaluationId");

                entity.Property(e => e.FStudentNumber).HasColumnName("fStudentNumber");

                entity.Property(e => e.FSurveyStatus).HasColumnName("fSurveyStatus");
            });

            modelBuilder.Entity<TEvaluationDetail>(entity =>
            {
                entity.HasKey(e => new { e.FEvaluationId, e.FEvaluationQid });

                entity.ToTable("tEvaluationDetail");

                entity.HasIndex(e => e.FEvaluationDetailId, "IX_tEvaluationDetail");

                entity.Property(e => e.FEvaluationId).HasColumnName("fEvaluationId");

                entity.Property(e => e.FEvaluationQid).HasColumnName("fEvaluationQId");

                entity.Property(e => e.FEvaluationDetailId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("fEvaluationDetailId");

                entity.Property(e => e.FEvaluationQtypeId).HasColumnName("fEvaluationQTypeId");

                entity.HasOne(d => d.FEvaluation)
                    .WithMany(p => p.TEvaluationDetails)
                    .HasForeignKey(d => d.FEvaluationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tEvaluationDetail_tEvaluationHeader");

                entity.HasOne(d => d.FEvaluationQ)
                    .WithMany(p => p.TEvaluationDetails)
                    .HasForeignKey(d => d.FEvaluationQid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tEvaluationDetail_tEvaluationQuestionDetail");
            });

            modelBuilder.Entity<TEvaluationHeader>(entity =>
            {
                entity.HasKey(e => e.FEvaluationId);

                entity.ToTable("tEvaluationHeader");

                entity.Property(e => e.FEvaluationId).HasColumnName("fEvaluationId");

                entity.Property(e => e.FArrangeNumber).HasColumnName("fArrangeNumber");

                entity.Property(e => e.FClassPeriod)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("fClassPeriod");

                entity.Property(e => e.FCourseId).HasColumnName("fCourseID");

                entity.Property(e => e.FCreatePerson)
                    .HasMaxLength(30)
                    .HasColumnName("fCreatePerson");

                entity.Property(e => e.FCreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fCreationDate");

                entity.Property(e => e.FEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fEndDate");

                entity.Property(e => e.FExtensionTime).HasColumnName("fExtensionTime");

                entity.Property(e => e.FLaunchDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fLaunchDate");

                entity.Property(e => e.FTeacherId).HasColumnName("fTeacherID");

                entity.HasOne(d => d.FArrangeNumberNavigation)
                    .WithMany(p => p.TEvaluationHeaders)
                    .HasForeignKey(d => d.FArrangeNumber)
                    .HasConstraintName("FK_tEvaluationHeader_tArrangeCourseInfo");

                entity.HasOne(d => d.FClassPeriodNavigation)
                    .WithMany(p => p.TEvaluationHeaders)
                    .HasForeignKey(d => d.FClassPeriod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tEvaluationHeader_tClassFullInfo");

                entity.HasOne(d => d.FCourse)
                    .WithMany(p => p.TEvaluationHeaders)
                    .HasForeignKey(d => d.FCourseId)
                    .HasConstraintName("FK_tEvaluationHeader_tClassCourseFullInfo");

                entity.HasOne(d => d.FTeacher)
                    .WithMany(p => p.TEvaluationHeaders)
                    .HasForeignKey(d => d.FTeacherId)
                    .HasConstraintName("FK_tEvaluationHeader_tTeacherFullInfo");
            });

            modelBuilder.Entity<TEvaluationQuestionDetail>(entity =>
            {
                entity.HasKey(e => e.FEvaluationQid);

                entity.ToTable("tEvaluationQuestionDetail");

                entity.Property(e => e.FEvaluationQid).HasColumnName("fEvaluationQId");

                entity.Property(e => e.FDescription)
                    .HasMaxLength(100)
                    .HasColumnName("fDescription");

                entity.Property(e => e.FEvaluationQtypeId).HasColumnName("fEvaluationQTypeId");

                entity.HasOne(d => d.FEvaluationQtype)
                    .WithMany(p => p.TEvaluationQuestionDetails)
                    .HasForeignKey(d => d.FEvaluationQtypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tEvaluationQuestionDetail_tEvaluationQuestionType");
            });

            modelBuilder.Entity<TEvaluationQuestionType>(entity =>
            {
                entity.HasKey(e => e.FEvaluationQtypeId);

                entity.ToTable("tEvaluationQuestionType");

                entity.Property(e => e.FEvaluationQtypeId).HasColumnName("fEvaluationQTypeId");

                entity.Property(e => e.FQtypeName)
                    .HasMaxLength(50)
                    .HasColumnName("fQTypeName");
            });

            modelBuilder.Entity<TEvaluationReviewHeader>(entity =>
            {
                entity.HasKey(e => e.FReviewHeaderId)
                    .HasName("PK_TEvaluationReviewHeader");

                entity.ToTable("tEvaluationReviewHeader");

                entity.Property(e => e.FReviewHeaderId).HasColumnName("fReviewHeaderId");

                entity.Property(e => e.FCommon)
                    .HasMaxLength(250)
                    .HasColumnName("fCommon");

                entity.Property(e => e.FEvaluationId).HasColumnName("fEvaluationId");

                entity.Property(e => e.FEvaluationQid).HasColumnName("fEvaluationQId");

                entity.Property(e => e.FRate)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("fRate");

                entity.Property(e => e.FStudentNumber).HasColumnName("fStudentNumber");

                entity.Property(e => e.FSubmitDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fSubmitDate");

                entity.HasOne(d => d.FEvaluation)
                    .WithMany(p => p.TEvaluationReviewHeaders)
                    .HasForeignKey(d => d.FEvaluationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEvaluationReviewHeader_tEvaluationHeader");

                entity.HasOne(d => d.FStudentNumberNavigation)
                    .WithMany(p => p.TEvaluationReviewHeaders)
                    .HasForeignKey(d => d.FStudentNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TEvaluationReviewHeader_tStudentFullInfo");
            });

            modelBuilder.Entity<TExamPaperDetail>(entity =>
            {
                entity.HasKey(e => e.FEpDetailId);

                entity.ToTable("tExamPaperDetail");

                entity.Property(e => e.FEpDetailId).HasColumnName("fEpDetailId");

                entity.Property(e => e.FExamPaperId).HasColumnName("fExamPaperId");

                entity.Property(e => e.FSujectId).HasColumnName("fSujectId");

                entity.HasOne(d => d.FExamPaper)
                    .WithMany(p => p.TExamPaperDetails)
                    .HasForeignKey(d => d.FExamPaperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tExamPaperDetail_tExaminationPaper");

                entity.HasOne(d => d.FSuject)
                    .WithMany(p => p.TExamPaperDetails)
                    .HasForeignKey(d => d.FSujectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tExamPaperDetail_tSuject");
            });

            modelBuilder.Entity<TExaminationPaper>(entity =>
            {
                entity.HasKey(e => e.FExamPaperId);

                entity.ToTable("tExaminationPaper");

                entity.Property(e => e.FExamPaperId).HasColumnName("fExamPaperId");

                entity.Property(e => e.FBegin)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("fBegin");

                entity.Property(e => e.FClassPeriod)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("fClassPeriod");

                entity.Property(e => e.FCourseId).HasColumnName("fCourseId");

                entity.Property(e => e.FDescription)
                    .HasMaxLength(50)
                    .HasColumnName("fDescription");

                entity.Property(e => e.FEnd)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("fEnd");

                entity.Property(e => e.FName)
                    .HasMaxLength(50)
                    .HasColumnName("fName");

                entity.Property(e => e.FOrder).HasColumnName("fOrder");

                entity.Property(e => e.FReveal)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("fReveal");

                entity.Property(e => e.FTimeLimit).HasColumnName("fTimeLimit");

                entity.HasOne(d => d.FClassPeriodNavigation)
                    .WithMany(p => p.TExaminationPapers)
                    .HasForeignKey(d => d.FClassPeriod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tExaminationPaper_tExaminationPaper");

                entity.HasOne(d => d.FCourse)
                    .WithMany(p => p.TExaminationPapers)
                    .HasForeignKey(d => d.FCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tExaminationPaper_tClassCourseFullInfo");
            });

            modelBuilder.Entity<TFilmVideo>(entity =>
            {
                entity.HasKey(e => e.FVideoId)
                    .HasName("PK_FilmVideo");

                entity.ToTable("tFilmVideo");

                entity.Property(e => e.FVideoId).HasColumnName("fVideoID");

                entity.Property(e => e.FClassId).HasColumnName("fClassID");

                entity.Property(e => e.FCourseId).HasColumnName("fCourseID");

                entity.Property(e => e.FCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fCreateDate");

                entity.Property(e => e.FLocalFile)
                    .IsUnicode(false)
                    .HasColumnName("fLocalFile");

                entity.Property(e => e.FTeacherId).HasColumnName("fTeacherID");

                entity.Property(e => e.FUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fUpdateDate");

                entity.Property(e => e.FVdoContent)
                    .HasColumnType("text")
                    .HasColumnName("fVdoContent");

                entity.Property(e => e.FVideoFileName)
                    .HasMaxLength(50)
                    .HasColumnName("fVideoFileName");

                entity.Property(e => e.FYoutubeFile)
                    .IsUnicode(false)
                    .HasColumnName("fYoutubeFile");
            });

            modelBuilder.Entity<THomework>(entity =>
            {
                entity.HasKey(e => e.FAssignmentId)
                    .HasName("PK_Homework");

                entity.ToTable("tHomework");

                entity.Property(e => e.FAssignmentId).HasColumnName("fAssignmentID");

                entity.Property(e => e.FClassId).HasColumnName("fClassID");

                entity.Property(e => e.FCourseId).HasColumnName("fCourseID");

                entity.Property(e => e.FEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fEndDate");

                entity.Property(e => e.FHomeworkFile)
                    .HasMaxLength(50)
                    .HasColumnName("fHomeworkFile");

                entity.Property(e => e.FHomeworkTitle)
                    .HasMaxLength(50)
                    .HasColumnName("fHomeworkTitle");

                entity.Property(e => e.FHwContent)
                    .HasColumnType("text")
                    .HasColumnName("fHwContent");

                entity.Property(e => e.FStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fStartDate");

                entity.Property(e => e.FStatus).HasColumnName("fStatus");

                entity.Property(e => e.FTeacherId).HasColumnName("fTeacherID");
            });

            modelBuilder.Entity<THomeworkScore>(entity =>
            {
                entity.HasKey(e => e.FAssignmentId)
                    .HasName("PK_HomeworkScore");

                entity.ToTable("tHomeworkScore");

                entity.Property(e => e.FAssignmentId).HasColumnName("fAssignmentID");

                entity.Property(e => e.FCourseId).HasColumnName("fCourseID");

                entity.Property(e => e.FCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fCreateDate");

                entity.Property(e => e.FScore).HasColumnName("fScore");

                entity.Property(e => e.FStdHwFile)
                    .HasMaxLength(50)
                    .HasColumnName("fStdHwFile")
                    .IsFixedLength(true);

                entity.Property(e => e.FStudentId).HasColumnName("fStudentID");

                entity.Property(e => e.FTeacherComment)
                    .HasMaxLength(100)
                    .HasColumnName("fTeacherComment")
                    .IsFixedLength(true);

                entity.Property(e => e.FUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fUpdateDate");

                entity.Property(e => e.FUpload).HasColumnName("fUpload");
            });

            modelBuilder.Entity<TLeaveInfo>(entity =>
            {
                entity.HasKey(e => e.FLeaveNumber)
                    .HasName("PK_LeaveInfo");

                entity.ToTable("tLeaveInfo");

                entity.Property(e => e.FLeaveNumber).HasColumnName("fLeaveNumber");

                entity.Property(e => e.FLeave)
                    .HasMaxLength(50)
                    .HasColumnName("fLeave");

                entity.Property(e => e.FLeaveDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fLeaveDate");

                entity.Property(e => e.FLeaveEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("fLeaveEnd");

                entity.Property(e => e.FLeaveHours).HasColumnName("fLeaveHours");

                entity.Property(e => e.FLeaveStart)
                    .HasColumnType("datetime")
                    .HasColumnName("fLeaveStart");

                entity.Property(e => e.FStatus)
                    .HasMaxLength(50)
                    .HasColumnName("fStatus");

                entity.Property(e => e.FStudentNumber).HasColumnName("fStudentNumber");

                entity.HasOne(d => d.FStudentNumberNavigation)
                    .WithMany(p => p.TLeaveInfos)
                    .HasForeignKey(d => d.FStudentNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LeaveInfo_StudentFullInfo");
            });

            modelBuilder.Entity<TLike>(entity =>
            {
                entity.HasKey(e => e.FLikeNumber);

                entity.ToTable("tLike");

                entity.Property(e => e.FLikeNumber).HasColumnName("fLikeNumber");

                entity.Property(e => e.FArticleId).HasColumnName("fArticleID");

                entity.Property(e => e.FArticleLike)
                    .HasMaxLength(50)
                    .HasColumnName("fArticleLike");

                entity.Property(e => e.FCommentId).HasColumnName("fCommentID");

                entity.Property(e => e.FCommentLike)
                    .HasMaxLength(50)
                    .HasColumnName("fCommentLike");

                entity.Property(e => e.FStudentNumber).HasColumnName("fStudentNumber");
            });

            modelBuilder.Entity<TOption>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tOptions");

                entity.Property(e => e.FAns).HasColumnName("fAns");

                entity.Property(e => e.FAnsAnalyze)
                    .HasMaxLength(200)
                    .HasColumnName("fAnsAnalyze");

                entity.Property(e => e.FOption1)
                    .HasMaxLength(50)
                    .HasColumnName("fOption1");

                entity.Property(e => e.FOption2)
                    .HasMaxLength(50)
                    .HasColumnName("fOption2");

                entity.Property(e => e.FOption3)
                    .HasMaxLength(50)
                    .HasColumnName("fOption3");

                entity.Property(e => e.FOption4)
                    .HasMaxLength(50)
                    .HasColumnName("fOption4");

                entity.Property(e => e.FOptionId).HasColumnName("fOptionId");

                entity.Property(e => e.FSujectId).HasColumnName("fSujectId");

                entity.HasOne(d => d.FSuject)
                    .WithMany()
                    .HasForeignKey(d => d.FSujectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tOptions_tSuject");
            });

            modelBuilder.Entity<TPunchInfo>(entity =>
            {
                entity.HasKey(e => e.FPunchNumber)
                    .HasName("PK_PunchInfo");

                entity.ToTable("tPunchInfo");

                entity.Property(e => e.FPunchNumber).HasColumnName("fPunchNumber");

                entity.Property(e => e.FPunchStatus)
                    .HasMaxLength(20)
                    .HasColumnName("fPunchStatus");

                entity.Property(e => e.FStudentNumber).HasColumnName("fStudentNumber");

                entity.Property(e => e.FTimeStart)
                    .HasColumnType("datetime")
                    .HasColumnName("fTimeStart");

                entity.HasOne(d => d.FStudentNumberNavigation)
                    .WithMany(p => p.TPunchInfos)
                    .HasForeignKey(d => d.FStudentNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PunchInfo_StudentFullInfo");
            });

            modelBuilder.Entity<TRecord>(entity =>
            {
                entity.HasKey(e => e.FRecordId);

                entity.ToTable("tRecord");

                entity.Property(e => e.FRecordId).HasColumnName("fRecordId");

                entity.Property(e => e.FChoose).HasColumnName("fChoose");

                entity.Property(e => e.FDateTime)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("fDateTime");

                entity.Property(e => e.FExamPaperId).HasColumnName("fExamPaperId");

                entity.Property(e => e.FStudentId).HasColumnName("fStudentId");

                entity.Property(e => e.FSujectId).HasColumnName("fSujectID");

                entity.HasOne(d => d.FExamPaper)
                    .WithMany(p => p.TRecords)
                    .HasForeignKey(d => d.FExamPaperId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tRecord_tExaminationPaper");

                entity.HasOne(d => d.FStudent)
                    .WithMany(p => p.TRecords)
                    .HasForeignKey(d => d.FStudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tRecord_tStudentFullInfo");

                entity.HasOne(d => d.FSuject)
                    .WithMany(p => p.TRecords)
                    .HasForeignKey(d => d.FSujectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tRecord_tSuject");
            });

            modelBuilder.Entity<TScore>(entity =>
            {
                entity.HasKey(e => e.FScoreId)
                    .HasName("PK_dbo.tScore");

                entity.ToTable("tScore");

                entity.Property(e => e.FScoreId).HasColumnName("fScoreId");

                entity.Property(e => e.FExamPaperId).HasColumnName("fExamPaperId");

                entity.Property(e => e.FScore).HasColumnName("fScore");

                entity.Property(e => e.FStudentId).HasColumnName("fStudentId");

                entity.HasOne(d => d.FExamPaper)
                    .WithMany(p => p.TScores)
                    .HasForeignKey(d => d.FExamPaperId)
                    .HasConstraintName("FK_dbo.tScore_tExaminationPaper");

                entity.HasOne(d => d.FStudent)
                    .WithMany(p => p.TScores)
                    .HasForeignKey(d => d.FStudentId)
                    .HasConstraintName("FK_dbo.tScore_tStudentFullInfo");
            });

            modelBuilder.Entity<TStudentFullInfo>(entity =>
            {
                entity.HasKey(e => e.FStudentNumber)
                    .HasName("PK_StudentFullInfo");

                entity.ToTable("tStudentFullInfo");

                entity.Property(e => e.FStudentNumber).HasColumnName("fStudentNumber");

                entity.Property(e => e.FAccount)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("fAccount");

                entity.Property(e => e.FClassPeriod)
                    .HasMaxLength(10)
                    .HasColumnName("fClassPeriod");

                entity.Property(e => e.FEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fEmail");

                entity.Property(e => e.FGender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("fGender")
                    .IsFixedLength(true);

                entity.Property(e => e.FHeadShot)
                    .HasMaxLength(200)
                    .HasColumnName("fHeadShot");

                entity.Property(e => e.FPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("fPassword");

                entity.Property(e => e.FPhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("fPhoneNumber")
                    .IsFixedLength(true);

                entity.Property(e => e.FStudentName)
                    .HasMaxLength(6)
                    .HasColumnName("fStudentName");

                entity.HasOne(d => d.FClassPeriodNavigation)
                    .WithMany(p => p.TStudentFullInfos)
                    .HasForeignKey(d => d.FClassPeriod)
                    .HasConstraintName("FK_StudentFullInfo_ClassFullInfo");
            });

            modelBuilder.Entity<TSuject>(entity =>
            {
                entity.HasKey(e => e.FSujectId);

                entity.ToTable("tSuject");

                entity.Property(e => e.FSujectId).HasColumnName("fSujectId");

                entity.Property(e => e.FAns).HasColumnName("fAns");

                entity.Property(e => e.FAnsAnalyze)
                    .HasMaxLength(200)
                    .HasColumnName("fAnsAnalyze");

                entity.Property(e => e.FCategoryId).HasColumnName("fCategoryId");

                entity.Property(e => e.FCourseId).HasColumnName("fCourseId");

                entity.Property(e => e.FOption1)
                    .HasMaxLength(50)
                    .HasColumnName("fOption1");

                entity.Property(e => e.FOption2)
                    .HasMaxLength(50)
                    .HasColumnName("fOption2");

                entity.Property(e => e.FOption3)
                    .HasMaxLength(50)
                    .HasColumnName("fOption3");

                entity.Property(e => e.FOption4)
                    .HasMaxLength(50)
                    .HasColumnName("fOption4");

                entity.Property(e => e.FQuestion)
                    .HasMaxLength(200)
                    .HasColumnName("fQuestion");

                entity.Property(e => e.FTypeId).HasColumnName("fTypeId");

                entity.HasOne(d => d.FCategory)
                    .WithMany(p => p.TSujects)
                    .HasForeignKey(d => d.FCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tSuject_tCategory");

                entity.HasOne(d => d.FCourse)
                    .WithMany(p => p.TSujects)
                    .HasForeignKey(d => d.FCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tSuject_tClassCourseFullInfo");

                entity.HasOne(d => d.FType)
                    .WithMany(p => p.TSujects)
                    .HasForeignKey(d => d.FTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tSuject_tType");
            });

            modelBuilder.Entity<TTeacherCourseFullInfo>(entity =>
            {
                entity.HasKey(e => e.FTeacherCourseId)
                    .HasName("PK_TeacherCourseFullInfo");

                entity.ToTable("tTeacherCourseFullInfo");

                entity.Property(e => e.FTeacherCourseId).HasColumnName("fTeacherCourseID");

                entity.Property(e => e.FCourseId).HasColumnName("fCourseID");

                entity.Property(e => e.FTeacherId).HasColumnName("fTeacherID");

                entity.Property(e => e.FTeacherName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("fTeacherName")
                    .IsFixedLength(true);

                entity.HasOne(d => d.FCourse)
                    .WithMany(p => p.TTeacherCourseFullInfos)
                    .HasForeignKey(d => d.FCourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeacherCourseFullInfo_ClassCourseFullInfo");
            });

            modelBuilder.Entity<TTeacherFullInfo>(entity =>
            {
                entity.HasKey(e => e.FTeacherId)
                    .HasName("PK_TeacherID");

                entity.ToTable("tTeacherFullInfo");

                entity.Property(e => e.FTeacherId).HasColumnName("fTeacherID");

                entity.Property(e => e.FEmail)
                    .HasMaxLength(50)
                    .HasColumnName("fEmail");

                entity.Property(e => e.FTeacherName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("fTeacherName");
            });

            modelBuilder.Entity<TType>(entity =>
            {
                entity.HasKey(e => e.FTypeId)
                    .HasName("PK_fType");

                entity.ToTable("tType");

                entity.Property(e => e.FTypeId).HasColumnName("fTypeId");

                entity.Property(e => e.FType)
                    .HasMaxLength(50)
                    .HasColumnName("fType");
            });

            modelBuilder.Entity<Tquestionnare>(entity =>
            {
                entity.HasKey(e => e.Fqid)
                    .HasName("PK_questionnare");

                entity.ToTable("tquestionnare");

                entity.Property(e => e.Fqid).HasColumnName("fqid");

                entity.Property(e => e.FqSalary)
                    .HasMaxLength(50)
                    .HasColumnName("fqSalary");

                entity.Property(e => e.Fqclass)
                    .HasMaxLength(50)
                    .HasColumnName("fqclass");

                entity.Property(e => e.FqemploymentStatus)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fqemployment_status");

                entity.Property(e => e.FqjobDescription)
                    .HasMaxLength(50)
                    .HasColumnName("fqjob_description");

                entity.Property(e => e.Fqname)
                    .HasMaxLength(50)
                    .HasColumnName("fqname");

                entity.Property(e => e.Fqposition)
                    .HasMaxLength(50)
                    .HasColumnName("fqposition");

                entity.Property(e => e.Fqterm)
                    .HasMaxLength(50)
                    .HasColumnName("fqterm");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
